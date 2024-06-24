using CanvasApi.Client.Reports.Models.Concretes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CanvasApi.Client.Reports.Models {

    public interface IReportModel {
        public ulong Id { get; set; }
        public string Report { get; set; }
        public string FileUrl { get; set; }
        public Attachment Attachment { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }        
        public Dictionary<string, JToken> Parameters { get; set; }
        public double? Progress { get; set; }
        public ulong? CurrentLine { get; set; }
    }
}