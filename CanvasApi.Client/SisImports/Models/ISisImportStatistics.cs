using CanvasApi.Client.SisImports.Models.Concretes;

namespace CanvasApi.Client.SisImports.Models {

    public interface ISisImportStatisticsModel {
        ulong TotalStateChanges { get; set; }
        SisImportStatistic Account { get; set; }
        SisImportStatistic EnrollmentTerm { get; set; }
        SisImportStatistic CommunicationChannel { get; set; }
        SisImportStatistic AbstractCourse { get; set; }
        SisImportStatistic Course { get; set; }
        SisImportStatistic CourseSection { get; set; }
        SisImportStatistic Enrollment { get; set; }
        SisImportStatistic GroupCategory { get; set; }
        SisImportStatistic Group { get; set; }
        SisImportStatistic GroupMembership { get; set; }
        SisImportStatistic Pseudonym { get; set; }
        SisImportStatistic UserObserver { get; set; }
        SisImportStatistic AccountUser { get; set; }
    }
}