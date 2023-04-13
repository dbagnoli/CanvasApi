using Newtonsoft.Json;

namespace CanvasApi.Client.Reports.Models.Concretes {
    public class Attachment : IAttachment {
        [JsonProperty("id")]
        ulong IAttachment.Id { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }
    }
}