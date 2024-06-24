namespace CanvasApi.Client.Reports.Models {

    internal interface IReportParameterDescription {
        public string Description { get; set; }
        public bool Required { get; set; }
    }
}