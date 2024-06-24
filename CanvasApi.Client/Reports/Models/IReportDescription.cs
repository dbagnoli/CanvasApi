using CanvasApi.Client.Reports.Models.Concretes;
using System;
using System.Collections.Generic;

namespace CanvasApi.Client.Reports.Models {

    internal interface IReportDescription {
        public ulong Id { get; set; }
        public string Report { get; set; }
        public string Title { get; set; }
        public Dictionary<string, ReportParameterDescription> Parameters { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public double? Progress { get; set; }
        public ulong? CurrentLine { get; set; }
    }
}