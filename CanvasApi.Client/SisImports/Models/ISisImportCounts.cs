namespace CanvasApi.Client.SisImports.Models {

    public interface ISisImportCounts {
        ulong Accounts { get; set; }
        ulong Terms { get; set; }
        ulong AbstractCourses { get; set; }
        ulong Courses { get; set; }
        ulong Sections { get; set; }
        ulong CrossLists { get; set; }
        ulong Users { get; set; }
        ulong Enrollments { get; set; }
        ulong Groups { get; set; }
        ulong GroupMemberships { get; set; }
        ulong GradePublishingResults { get; set; }
        ulong? BatchCoursesDeleted { get; set; }
        ulong? BatchSectionsDeleted { get; set; }
        ulong? BatchEnrollmentsDeleted { get; set; }
        ulong Errors { get; set; }
        ulong Warnings { get; set; }
    }
}