using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CanvasApi.Client.Reports.Models.Concretes {
    internal class ReportDescription : IReportDescription {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("report")]
        public string Report { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [CanBeNull]
        [JsonProperty("parameters")]
        public Dictionary<string, ReportParameterDescription> Parameters { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("started_at")]
        public DateTime? StartedAt { get; set; }

        [JsonProperty("ended_at")]
        public DateTime? EndedAt { get; set; }

        [JsonProperty("progress")]
        public double? Progress { get; set; }

        [JsonProperty("current_line")]
        public ulong? CurrentLine { get; set; }
    }
}