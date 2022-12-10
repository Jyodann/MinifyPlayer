namespace Assets.Models
{
    internal class PlaybackStateGeneric
    {
        public string currently_playing_type { get; set; }

        public bool is_playing { get; set; }

        public bool shuffle_state { get; set; }
    }
}