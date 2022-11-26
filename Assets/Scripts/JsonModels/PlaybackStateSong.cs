namespace Assets.JsonModels
{
    public class PlaybackStateSong
    {
        public Device device { get; set; }

        public string repeat_state { get; set; }

        public string shuffle_state { get; set; }

        public Context context { get; set; }

        public long timestamp { get; set; }

        public long progress_ms { get; set; }

        public bool is_playing { get; set; }

        public Item item { get; set; }

        public string currently_playing_type { get; set; }

        public Actions actions { get; set; }

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
            public string type { get; set; }

            public string href { get; set; }

            public External_Urls external_urls { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls
        {
            public string spotify { get; set; }
        }

        public class Item
        {
            public Album album { get; set; }

            public Artist24[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public long duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids external_ids { get; set; }

            public External_Urls3 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From linked_from { get; set; }

            public Restrictions24 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls1 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist[] artists { get; set; }
        }

        public class External_Urls1
        {
            public string spotify { get; set; }
        }

        public class Restrictions
        {
            public string reason { get; set; }
        }

        public class Image
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Artist
        {
            public External_Urls2 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls2
        {
            public string spotify { get; set; }
        }

        public class External_Ids
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls3
        {
            public string spotify { get; set; }
        }

        public class Linked_From
        {
            public Album1 album { get; set; }

            public Artist23[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids1 external_ids { get; set; }

            public External_Urls6 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From1 linked_from { get; set; }

            public Restrictions23 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album1
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls4 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image1[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions1 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist1[] artists { get; set; }
        }

        public class External_Urls4
        {
            public string spotify { get; set; }
        }

        public class Restrictions1
        {
            public string reason { get; set; }
        }

        public class Image1
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Artist1
        {
            public External_Urls5 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls5
        {
            public string spotify { get; set; }
        }

        public class External_Ids1
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls6
        {
            public string spotify { get; set; }
        }

        public class Linked_From1
        {
            public Album2 album { get; set; }

            public Artist22[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids2 external_ids { get; set; }

            public External_Urls9 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From2 linked_from { get; set; }

            public Restrictions22 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album2
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls7 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image2[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions2 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist2[] artists { get; set; }
        }

        public class External_Urls7
        {
            public string spotify { get; set; }
        }

        public class Restrictions2
        {
            public string reason { get; set; }
        }

        public class Image2
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Artist2
        {
            public External_Urls8 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls8
        {
            public string spotify { get; set; }
        }

        public class External_Ids2
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls9
        {
            public string spotify { get; set; }
        }

        public class Linked_From2
        {
            public Album3 album { get; set; }

            public Artist21[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids3 external_ids { get; set; }

            public External_Urls12 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From3 linked_from { get; set; }

            public Restrictions21 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album3
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls10 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image3[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions3 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist3[] artists { get; set; }
        }

        public class External_Urls10
        {
            public string spotify { get; set; }
        }

        public class Restrictions3
        {
            public string reason { get; set; }
        }

        public class Image3
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Artist3
        {
            public External_Urls11 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls11
        {
            public string spotify { get; set; }
        }

        public class External_Ids3
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls12
        {
            public string spotify { get; set; }
        }

        public class Linked_From3
        {
            public Album4 album { get; set; }

            public Artist20[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids4 external_ids { get; set; }

            public External_Urls15 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From4 linked_from { get; set; }

            public Restrictions20 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album4
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls13 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image4[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions4 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist4[] artists { get; set; }
        }

        public class External_Urls13
        {
            public string spotify { get; set; }
        }

        public class Restrictions4
        {
            public string reason { get; set; }
        }

        public class Image4
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Artist4
        {
            public External_Urls14 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls14
        {
            public string spotify { get; set; }
        }

        public class External_Ids4
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls15
        {
            public string spotify { get; set; }
        }

        public class Linked_From4
        {
            public Album5 album { get; set; }

            public Artist19[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids5 external_ids { get; set; }

            public External_Urls18 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From5 linked_from { get; set; }

            public Restrictions19 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album5
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls16 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image5[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions5 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist5[] artists { get; set; }
        }

        public class External_Urls16
        {
            public string spotify { get; set; }
        }

        public class Restrictions5
        {
            public string reason { get; set; }
        }

        public class Image5
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Artist5
        {
            public External_Urls17 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls17
        {
            public string spotify { get; set; }
        }

        public class External_Ids5
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls18
        {
            public string spotify { get; set; }
        }

        public class Linked_From5
        {
            public Album6 album { get; set; }

            public Artist18[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids6 external_ids { get; set; }

            public External_Urls21 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From6 linked_from { get; set; }

            public Restrictions18 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album6
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls19 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image6[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions6 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist6[] artists { get; set; }
        }

        public class External_Urls19
        {
            public string spotify { get; set; }
        }

        public class Restrictions6
        {
            public string reason { get; set; }
        }

        public class Image6
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Artist6
        {
            public External_Urls20 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls20
        {
            public string spotify { get; set; }
        }

        public class External_Ids6
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls21
        {
            public string spotify { get; set; }
        }

        public class Linked_From6
        {
            public Album7 album { get; set; }

            public Artist17[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids7 external_ids { get; set; }

            public External_Urls24 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From7 linked_from { get; set; }

            public Restrictions17 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album7
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls22 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image7[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions7 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist7[] artists { get; set; }
        }

        public class External_Urls22
        {
            public string spotify { get; set; }
        }

        public class Restrictions7
        {
            public string reason { get; set; }
        }

        public class Image7
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Artist7
        {
            public External_Urls23 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls23
        {
            public string spotify { get; set; }
        }

        public class External_Ids7
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls24
        {
            public string spotify { get; set; }
        }

        public class Linked_From7
        {
            public Album8 album { get; set; }

            public Artist16[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids8 external_ids { get; set; }

            public External_Urls27 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From8 linked_from { get; set; }

            public Restrictions16 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album8
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls25 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image8[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions8 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist8[] artists { get; set; }
        }

        public class External_Urls25
        {
            public string spotify { get; set; }
        }

        public class Restrictions8
        {
            public string reason { get; set; }
        }

        public class Image8
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Artist8
        {
            public External_Urls26 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls26
        {
            public string spotify { get; set; }
        }

        public class External_Ids8
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls27
        {
            public string spotify { get; set; }
        }

        public class Linked_From8
        {
            public Album9 album { get; set; }

            public Artist15[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids9 external_ids { get; set; }

            public External_Urls30 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From9 linked_from { get; set; }

            public Restrictions15 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album9
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls28 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image9[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions9 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist9[] artists { get; set; }
        }

        public class External_Urls28
        {
            public string spotify { get; set; }
        }

        public class Restrictions9
        {
            public string reason { get; set; }
        }

        public class Image9
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Artist9
        {
            public External_Urls29 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public string name { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls29
        {
        }

        public class External_Ids9
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls30
        {
            public string spotify { get; set; }
        }

        public class Linked_From9
        {
            public Album10 album { get; set; }

            public Artist14[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids10 external_ids { get; set; }

            public External_Urls32 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From10 linked_from { get; set; }

            public Restrictions14 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album10
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls31 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image10[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions10 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist10[] artists { get; set; }
        }

        public class External_Urls31
        {
            public string spotify { get; set; }
        }

        public class Restrictions10
        {
            public string reason { get; set; }
        }

        public class Image10
        {
        }

        public class Artist10
        {
        }

        public class External_Ids10
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls32
        {
            public string spotify { get; set; }
        }

        public class Linked_From10
        {
            public Album11 album { get; set; }

            public Artist13[] artists { get; set; }

            public string[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids11 external_ids { get; set; }

            public External_Urls34 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From11 linked_from { get; set; }

            public Restrictions13 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album11
        {
            public string album_type { get; set; }

            public int total_tracks { get; set; }

            public string[] available_markets { get; set; }

            public External_Urls33 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image11[] images { get; set; }

            public string name { get; set; }

            public string release_date { get; set; }

            public string release_date_precision { get; set; }

            public Restrictions11 restrictions { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public string album_group { get; set; }

            public Artist11[] artists { get; set; }
        }

        public class External_Urls33
        {
        }

        public class Restrictions11
        {
        }

        public class Image11
        {
        }

        public class Artist11
        {
        }

        public class External_Ids11
        {
            public string isrc { get; set; }

            public string ean { get; set; }

            public string upc { get; set; }
        }

        public class External_Urls34
        {
            public string spotify { get; set; }
        }

        public class Linked_From11
        {
            public Album12 album { get; set; }

            public Artist12[] artists { get; set; }

            public object[] available_markets { get; set; }

            public int disc_number { get; set; }

            public int duration_ms { get; set; }

            public bool _explicit { get; set; }

            public External_Ids12 external_ids { get; set; }

            public External_Urls35 external_urls { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public bool is_playable { get; set; }

            public Linked_From12 linked_from { get; set; }

            public Restrictions12 restrictions { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string preview_url { get; set; }

            public int track_number { get; set; }

            public string type { get; set; }

            public string uri { get; set; }

            public bool is_local { get; set; }
        }

        public class Album12
        {
            public object[] available_markets { get; set; }

            public object[] images { get; set; }

            public object[] artists { get; set; }
        }

        public class External_Ids12
        {
        }

        public class External_Urls35
        {
        }

        public class Linked_From12
        {
            public object[] artists { get; set; }

            public object[] available_markets { get; set; }
        }

        public class Restrictions12
        {
        }

        public class Artist12
        {
        }

        public class Restrictions13
        {
            public string reason { get; set; }
        }

        public class Artist13
        {
            public object[] genres { get; set; }

            public object[] images { get; set; }
        }

        public class Restrictions14
        {
            public string reason { get; set; }
        }

        public class Artist14
        {
            public External_Urls36 external_urls { get; set; }

            public Followers followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image12[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls36
        {
        }

        public class Followers
        {
        }

        public class Image12
        {
        }

        public class Restrictions15
        {
            public string reason { get; set; }
        }

        public class Artist15
        {
            public External_Urls37 external_urls { get; set; }

            public Followers1 followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image13[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls37
        {
            public string spotify { get; set; }
        }

        public class Followers1
        {
            public string href { get; set; }

            public int total { get; set; }
        }

        public class Image13
        {
        }

        public class Restrictions16
        {
            public string reason { get; set; }
        }

        public class Artist16
        {
            public External_Urls38 external_urls { get; set; }

            public Followers2 followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image14[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls38
        {
            public string spotify { get; set; }
        }

        public class Followers2
        {
            public string href { get; set; }

            public int total { get; set; }
        }

        public class Image14
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Restrictions17
        {
            public string reason { get; set; }
        }

        public class Artist17
        {
            public External_Urls39 external_urls { get; set; }

            public Followers3 followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image15[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls39
        {
            public string spotify { get; set; }
        }

        public class Followers3
        {
            public string href { get; set; }

            public int total { get; set; }
        }

        public class Image15
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Restrictions18
        {
            public string reason { get; set; }
        }

        public class Artist18
        {
            public External_Urls40 external_urls { get; set; }

            public Followers4 followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image16[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls40
        {
            public string spotify { get; set; }
        }

        public class Followers4
        {
            public string href { get; set; }

            public int total { get; set; }
        }

        public class Image16
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Restrictions19
        {
            public string reason { get; set; }
        }

        public class Artist19
        {
            public External_Urls41 external_urls { get; set; }

            public Followers5 followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image17[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls41
        {
            public string spotify { get; set; }
        }

        public class Followers5
        {
            public string href { get; set; }

            public int total { get; set; }
        }

        public class Image17
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Restrictions20
        {
            public string reason { get; set; }
        }

        public class Artist20
        {
            public External_Urls42 external_urls { get; set; }

            public Followers6 followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image18[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls42
        {
            public string spotify { get; set; }
        }

        public class Followers6
        {
            public string href { get; set; }

            public int total { get; set; }
        }

        public class Image18
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Restrictions21
        {
            public string reason { get; set; }
        }

        public class Artist21
        {
            public External_Urls43 external_urls { get; set; }

            public Followers7 followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image19[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls43
        {
            public string spotify { get; set; }
        }

        public class Followers7
        {
            public string href { get; set; }

            public int total { get; set; }
        }

        public class Image19
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Restrictions22
        {
            public string reason { get; set; }
        }

        public class Artist22
        {
            public External_Urls44 external_urls { get; set; }

            public Followers8 followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image20[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls44
        {
            public string spotify { get; set; }
        }

        public class Followers8
        {
            public string href { get; set; }

            public int total { get; set; }
        }

        public class Image20
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Restrictions23
        {
            public string reason { get; set; }
        }

        public class Artist23
        {
            public External_Urls45 external_urls { get; set; }

            public Followers9 followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image21[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls45
        {
            public string spotify { get; set; }
        }

        public class Followers9
        {
            public string href { get; set; }

            public int total { get; set; }
        }

        public class Image21
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Restrictions24
        {
            public string reason { get; set; }
        }

        public class Artist24
        {
            public External_Urls46 external_urls { get; set; }

            public Followers10 followers { get; set; }

            public string[] genres { get; set; }

            public string href { get; set; }

            public string id { get; set; }

            public Image22[] images { get; set; }

            public string name { get; set; }

            public int popularity { get; set; }

            public string type { get; set; }

            public string uri { get; set; }
        }

        public class External_Urls46
        {
            public string spotify { get; set; }
        }

        public class Followers10
        {
            public string href { get; set; }

            public int total { get; set; }
        }

        public class Image22
        {
            public string url { get; set; }

            public int height { get; set; }

            public int width { get; set; }
        }

        public class Actions
        {
            public bool interrupting_playback { get; set; }

            public bool pausing { get; set; }

            public bool resuming { get; set; }

            public bool seeking { get; set; }

            public bool skipping_next { get; set; }

            public bool skipping_prev { get; set; }

            public bool toggling_repeat_context { get; set; }

            public bool toggling_shuffle { get; set; }

            public bool toggling_repeat_track { get; set; }

            public bool transferring_playback { get; set; }
        }
    }
}