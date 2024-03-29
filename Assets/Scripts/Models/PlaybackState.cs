﻿namespace Assets.Models
{
    internal class PlaybackState
    {
        public string SongName { get; set; } = string.Empty;

        public string AlbumArtURL { get; set; } = string.Empty;

        public string Artists { get; set; } = string.Empty;

        public bool IsPlaying { get; set; } = false;

        public bool CanShowOverlay { get; set; } = false;

        public string SpotifyUrlString { get; set; } = string.Empty;

        public bool CheckForDifference(PlaybackState otherPlayback)
        {
            return SongName == otherPlayback.SongName;
        }

        public void CopyPlaybackState(PlaybackState otherPlayback)
        {
            SongName = otherPlayback.SongName;
            AlbumArtURL = otherPlayback.AlbumArtURL;
        }
    }
}