namespace Assets.JsonModels
{
    public class PlaybackStatePodcast
    {
        public Device device { get; set; }

        public bool shuffle_state { get; set; }

        public string repeat_state { get; set; }

        public long timestamp { get; set; }

        public Context context { get; set; }

        public int progress_ms { get; set; }

        public Item item { get; set; }

        public string currently_playing_type { get; set; }

        public Actions actions { get; set; }

        public bool is_playing { get; set; }

        public class Device
        {
            public string id { get; set; }

            public bool is_active { get; set; }

            public bool is_private_session { get; set; }

            public bool is_restricted { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public int volume_percent { get; set; }
        }

        public class Context
        {
            public External_Urls external_urls { get; set; }

            public string href { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls
        {
            public string spotify { get; set; }
        }

        public class Item
        {
            public string audio_preview_url { get; set; }

            public string description { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Urls1 external_urls { get; set; }

            public string href { get; set; }

            public string html_description { get; set; }

            public string id { get; set; }

            public Image1[] images { get; set; }

            public bool is_externally_hosted { get; set; }

            public bool is_playable { get; set; }

            public string language { get; set; }

            public string[] languages { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Show show { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls1
        {
            public string spotify { get; set; }
        }

        public class Show
        {
            public string[] available_markets { get; set; }

            public object[] copyrights { get; set; }

            public string description { get; set; }

            public bool _explicit { get; set; }

            public External_Urls2 external_urls { get; set; }

            public string href { get; set; }

            public string html_description { get; set; }

            public string id { get; set; }

            public Image[] images { get; set; }

            public bool is_externally_hosted { get; set; }

            public string[] languages { get; set; }

            public string media_type { get; set; }

            public string name { get; set; }

            public string publisher { get; set; }

            public int total_episodes { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls2
        {
            public string spotify { get; set; }
        }

        public class Image
        {
            public int height { get; set; }

            public string url { get; set; }

            public int width { get; set; }
        }

        public class Image1
        {
            public int height { get; set; }

            public string url { get; set; }

            public int width { get; set; }
        }

        public class Actions
        {
            public Disallows disallows { get; set; }
        }

        public class Disallows
        {
            public bool resuming { get; set; }
        }
    }
}
