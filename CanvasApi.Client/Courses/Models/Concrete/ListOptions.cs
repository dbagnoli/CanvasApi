using CanvasApi.Client.Enrollments.Enums;

namespace CanvasApi.Client.Courses.Models.Concrete
{
    public class ListOptions : ListOptionsBasic, IListOptions
    {
        public EnrollmentTypes? EnrollmentType { get; set; }
        public string EnrollmentRole { get; set; }
        public long? EnrollmentRoleId { get; set; }
        public bool? ExcludeBlueprintCourses { get; set; }
        public bool? Published { get; set; }
        public int? Per_Page { get; set; }
        public int? Page { get; set; }
        public int? EnrollmentTermId { get; set; }
    }
}
