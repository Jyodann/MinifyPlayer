using Newtonsoft.Json;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
namespace Assets.ApplicationStates
{
    public class MainState : State<MainManager>
    {
        private PlaybackState CurrentPlaybackState = null;
        public MainState(StateMachine<MainManager> SM, MainManager manager) : base(SM, manager)
        {
        }

        public override void Enter()
        {
            AttemptUpdatePlaybackState();
            Manager.UIManager.ShowUI(UIManager.UI.Main);
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            
        }

        void AttemptUpdatePlaybackState()
        {
            MainManager.Instance.StartCoroutine(UpdatePlaybackState());
        }

        IEnumerator UpdatePlaybackState()
        {
            using (var request = MainManager.Instance.GetUnityWebRequestObject("https://api.spotify.com/v1/me/player", MainManager.RequestMethods.GET))
            {
                yield return request.SendWebRequest(); 

                if (request.result == UnityWebRequest.Result.ConnectionError)
                {
                    MainManager.Instance.ApplicationState.ChangeState(MainManager.Instance.ConnectionErrorState);
                    yield break;
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    try
                    {
                        var playBackState = JsonConvert.DeserializeObject<PlaybackState>(request.downloadHandler.text);

                        if (playBackState.currently_playing_type == "unknown")
                        {
                            AttemptUpdatePlaybackState();
                            yield break;
                        }
                        var UIManager = MainManager.Instance.UIManager;

                        var song_name = playBackState.item.name;
                        var album_art = playBackState.item.album.images[0].url;

                        // If no playback State, set one:
                        if (CurrentPlaybackState == null)
                        {
                            CurrentPlaybackState = playBackState;
                            UIManager.SetSongName(song_name);
                            UIManager.SetAlbumArtURL(album_art);
                        }

                        if (CurrentPlaybackState.item.name != song_name)
                        {
                            UIManager.SetSongName(song_name);
                        }

                        if (CurrentPlaybackState.item.album.images[0].url != album_art)
                        {
                            UIManager.SetAlbumArtURL(album_art);
                        }

                        CurrentPlaybackState = playBackState;

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
                    MainManager.Instance.LoginManager.InformTokenExpiry();
                    MainManager.Instance.ApplicationState.ChangeState(MainManager.Instance.LoginState);

                    yield break;
                }
            }
        }
    }
}
