namespace Assets
{
    internal class PlaybackState
    {
        public string SongName { get; set; } = string.Empty;

        public string AlbumArtURL { get; set; } = string.Empty;

        public string Artists { get; set; } = string.Empty;

        public PlaybackState()
        {
        }

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
