using Assets.JsonModels;
using Assets.Managers;
using Assets.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.ApplicationStates
{
    public class MainState : State<MainManager>
    {
        private PlaybackState CurrentPlaybackState = new();

        private readonly PlaybackState PreviousPlaybackState = new();

        public MainState(StateMachine<MainManager> SM, MainManager manager) : base(SM, manager)
        {
        }

        public override void Enter()
        {
            AttemptUpdatePlaybackState();
            Manager.UIManager.ShowUI(UIManager.UI.Main);
            Manager.UIManager.SetAlbumArt(UIManager.AlbumArtIcons.Search);

            Manager.UIManager.SetPinnedButtonState(Manager.WindowManager.LoadPinnedState());
            Manager.WindowManager.PinWindowToTop(Manager.WindowManager.LoadPinnedState());
        }

        public override void Exit()
        {
            Manager.StopAllCoroutines();
            CurrentPlaybackState = new PlaybackState();
            CurrentPlaybackState = new PlaybackState();
        }

        public override void Update()
        {
            var newPinnedState = Manager.WindowManager.LoadPinnedState();
            Manager.WindowManager.PinWindowToTop(newPinnedState);
        }

        private void AttemptUpdatePlaybackState()
        {
            MainManager.Instance.StartCoroutine(UpdatePlaybackState());
        }

        private IEnumerator UpdatePlaybackState()
        {
            Debug.Log("Attempt Update");
            yield return new WaitForSeconds(1f);

            using var request = MainManager.Instance.GetUnityWebRequestObject("https://api.spotify.com/v1/me/player/currently-playing?additional_types=episode,track", MainManager.RequestMethods.GET);
            yield return request.SendWebRequest();

            EnablePlayPauseButton(true);
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                MainManager.Instance.ApplicationState.ChangeState(MainManager.Instance.ConnectionErrorState);
                yield break;
            }

            if (request.result == UnityWebRequest.Result.Success)
            {
                if (request.downloadHandler.text == string.Empty)
                {
                    Debug.LogWarning("Spotify Instance Disconnected");

                    Manager.UIManager.SetSongName("Spotify not currently playing. Try playing a song to resume Miniplayer!");
                    CurrentPlaybackState.CanShowOverlay = false;
                    Manager.UIManager.SetAlbumArt(UIManager.AlbumArtIcons.MusicOff);
                    AttemptUpdatePlaybackState();
                    EnablePlayPauseButton(false);
                    yield break;
                }

                try
                {
                    //Gets the Current Playing Type
                    var genericPlaybackState = JsonConvert.DeserializeObject<PlaybackStateGeneric>(
                    request.downloadHandler.text);
                    MainManager.Instance.UIManager.SetPlayPauseButtonState(genericPlaybackState.is_playing);

                    switch (genericPlaybackState.currently_playing_type)
                    {
                        case "unknown":
                            EnablePlayPauseButton(false);
                            AttemptUpdatePlaybackState();
                            yield break;
                        case "track":
                            var playBackStateSong = JsonConvert.DeserializeObject<PlaybackStateSong>(request.downloadHandler.text);

                            CurrentPlaybackState.SongName = playBackStateSong.item.name;
                            CurrentPlaybackState.AlbumArtURL = playBackStateSong.item.album.images[0].url;
                            CurrentPlaybackState.Artists = string.Join(", ", playBackStateSong.item.artists.Select(x => x.name));
                            CurrentPlaybackState.IsPlaying = playBackStateSong.is_playing;
                            CurrentPlaybackState.SpotifyUrlString = playBackStateSong.item.external_urls.spotify;

                            break;

                        case "episode":
                            var playBackStatePodcast = JsonConvert.DeserializeObject<PlaybackStatePodcast>(request.downloadHandler.text);

                            CurrentPlaybackState.SongName = playBackStatePodcast.item.name;
                            CurrentPlaybackState.AlbumArtURL = playBackStatePodcast.item.images[0].url;
                            CurrentPlaybackState.Artists = string.Join(", ", playBackStatePodcast.item.show.publisher);
                            CurrentPlaybackState.IsPlaying = playBackStatePodcast.is_playing;
                            CurrentPlaybackState.SpotifyUrlString = playBackStatePodcast.item.external_urls.spotify;
                            break;

                        case "ad":
                            EnablePlayPauseButton(false);
                            CurrentPlaybackState.SongName = "Ad is playing...";
                            AttemptUpdatePlaybackState();
                            yield break;
                        default:
                            Debug.LogError($"Song Type not recognised: {genericPlaybackState.currently_playing_type}");
                            break;
                    }

                    if (!CurrentPlaybackState.CanShowOverlay)
                    {
                        SetAllUI(CurrentPlaybackState);
                        PreviousPlaybackState.CopyPlaybackState(CurrentPlaybackState);
                        CurrentPlaybackState.CanShowOverlay = true;
                    }

                    // If no previous state, set one:
                    if (PreviousPlaybackState.SongName.Equals(string.Empty))
                    {
                        SetAllUI(CurrentPlaybackState);
                        PreviousPlaybackState.CopyPlaybackState(CurrentPlaybackState);
                        AttemptUpdatePlaybackState();

                        yield break;
                    }

                    // Check for Song Difference, then change
                    if (!CurrentPlaybackState.CheckForDifference(PreviousPlaybackState))
                    {
                        SetAllUI(CurrentPlaybackState);
                        PreviousPlaybackState.CopyPlaybackState(CurrentPlaybackState);
                    }

                    AttemptUpdatePlaybackState();
                }
                catch (System.Exception e)
                {
                    Debug.LogException(e);
                    AttemptUpdatePlaybackState();
                }

                yield break;
            }

            if (request.responseCode == 401)
            {
                MainManager.Instance.LoginManager.RefreshToken(false);
                AttemptUpdatePlaybackState();
                yield break;
            }
        }

        public void AttemptPausePlay()
        {
            MainManager.Instance.StartCoroutine(PausePlay());
        }

        public void AttemptSkipSong(bool playNextSong)
        {
            MainManager.Instance.StartCoroutine(SkipSong(playNextSong));
        }

        private IEnumerator SkipSong(bool playNextSong)
        {
            var url = playNextSong ? "https://api.spotify.com/v1/me/player/next" : "https://api.spotify.com/v1/me/player/previous";
            using var request = MainManager.Instance.GetUnityWebRequestObject(url, MainManager.RequestMethods.POST);
            yield return request.SendWebRequest();
        }

        private IEnumerator PausePlay()
        {
            var url = CurrentPlaybackState.IsPlaying ? "https://api.spotify.com/v1/me/player/pause" : "https://api.spotify.com/v1/me/player/play";
            using var request = MainManager.Instance.GetUnityWebRequestObject(url, MainManager.RequestMethods.PUT);
            yield return request.SendWebRequest();
        }

        private void SetAllUI(PlaybackState playbackState)
        {
            var UIManager = MainManager.Instance.UIManager;
            UIManager.SetSongName($"{playbackState.SongName} - {playbackState.Artists}");
            UIManager.SetAlbumArt(playbackState.AlbumArtURL);
        }

        public void EnablePlayPauseOverlay(bool isEnabled)
        {
            Manager.UIManager.EnablePlayPauseOverlay(isEnabled);
        }

        public void EnablePlayPauseButton(bool isEnabled)
        {
            Manager.UIManager.SetPlayPauseButtonVisible(isEnabled);
        }

        public void Logout()
        {
            Manager.LoginManager.InValidateToken();
            Manager.ApplicationState.ChangeState(Manager.LoginState);
        }

        public void PinWindowToTop()
        {
            var windowManager = Manager.WindowManager;
            var newPinnedState = !windowManager.LoadPinnedState();
            windowManager.PinWindowToTop(newPinnedState);
            windowManager.SavePinnedState(newPinnedState);
            Manager.UIManager.SetPinnedButtonState(newPinnedState);
        }

        internal void Minimise()
        {
            Manager.WindowManager.MinimiseWindow();
        }

        internal void CloseWindow()
        {
            Application.Quit();
        }

        internal void PlayOnSpotify()
        {
            if (string.IsNullOrEmpty(CurrentPlaybackState.SpotifyUrlString)) return;
            Application.OpenURL(Uri.EscapeUriString(CurrentPlaybackState.SpotifyUrlString));
        }
    }
}
