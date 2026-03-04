using System;
using System.Text.Json.Serialization;

namespace YTXDL
{
    public class VideoInfo
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author_name")]
        public string AuthorName { get; set; }

        [JsonPropertyName("provider_name")]
        public string ProviderName { get; set; }

        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }
    }
}
