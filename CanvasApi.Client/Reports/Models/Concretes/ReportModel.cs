using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CanvasApi.Client.Reports.Models.Concretes {
    public class ReportModel: IReportModel {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("report")]
        public string Report { get; set; }

        [JsonProperty("file_url")]
        [CanBeNull]
        public string FileUrl { get; set; }

        [JsonProperty("attachment")]
        [CanBeNull]
        public Attachment Attachment { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("started_at")]
        public DateTime? StartedAt { get; set; }

        [JsonProperty("ended_at")]
        public DateTime? EndedAt { get; set; }

        [JsonProperty("parameters")]
        public Dictionary<string, JToken> Parameters { get; set; }

        [JsonProperty("progress")]
        public double? Progress { get; set; }

        [JsonProperty("current_line")]
        public ulong? CurrentLine { get; set; }
    }
}