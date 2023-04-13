using Newtonsoft.Json;

namespace CanvasApi.Client.Reports.Models.Concretes {
    internal class ReportParameterDescription : IReportParameterDescription {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }
    }
}