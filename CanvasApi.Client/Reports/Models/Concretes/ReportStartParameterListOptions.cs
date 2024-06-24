using System.Collections.Generic;

namespace CanvasApi.Client.Reports.Models.Concretes {
    public class ReportParameterOptions: IReportParameterOptions {
        public string EnrollmentTermId { get; set; }
        public string Xlist { get; set; }
        public string Term { get; set; }
        public string ExtraText { get; set; }
        public string Sections { get; set; }
        public string IncludeDeleted { get; set; }
        public string Enrollments { get; set; }
    }

    public class ReportStartParameterListOptions : IReportStartParameterListOptions {
        //public string ReportType { get; set; }
        public IReportParameterOptions Parameters { get; set; }

        //public int AccountId { get; set; }
    }
}