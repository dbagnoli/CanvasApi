namespace CanvasApi.Client.Reports.Models {

    public interface IReportParameterOptions {
        string EnrollmentTermId { get; set; }
        string Xlist { get; set; }
        string Term { get; set; }
        string ExtraText { get; set; }
        string Sections { get; set; }
        string IncludeDeleted { get; set; }
        string Enrollments { get; set; }
    }

    public interface IReportStartParameterListOptions {
        //string ReportType { get; set; }
        IReportParameterOptions Parameters { get; set; }

        //int AccountId { get; set; }
    }
}