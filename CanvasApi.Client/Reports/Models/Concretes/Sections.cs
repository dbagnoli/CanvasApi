using Newtonsoft.Json;
using System;

namespace CanvasApi.Client.Reports.Models.Concretes {
    public class Sections : ISections {
        [JsonProperty("section_id")]
        public string Section_Id { get; set; }

        [JsonProperty("course_id")]
        public string Course_Id { get; set; }

        [JsonProperty("integration_id")]
        public string? Integration_Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("start_date")]
        public DateTime? Start_Date { get; set; }

        [JsonProperty("end_date")]
        public DateTime? End_Date { get; set; }
    }
}