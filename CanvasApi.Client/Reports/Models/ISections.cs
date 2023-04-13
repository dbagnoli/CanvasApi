using System;

namespace CanvasApi.Client.Reports.Models {

    public interface ISections {
        public string Section_Id { get; set; }
        public string Course_Id { get; set; }
        public string? Integration_Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
    }
}