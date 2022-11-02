using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    internal class PlaybackState
    {
        public string SongName { get; set; } = string.Empty;
        public string AlbumArtURL { get; set; } = string.Empty;

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
