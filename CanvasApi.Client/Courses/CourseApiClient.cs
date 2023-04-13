using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CanvasApi.Client._Base;
using CanvasApi.Client.Attributes;
using CanvasApi.Client.Courses.Models;
using CanvasApi.Client.Courses.Models.Concrete;
using CanvasApi.Client.Extentions;
using JetBrains.Annotations;

namespace CanvasApi.Client.Courses
{
    public class CourseApiClient : ApiClientBase, ICourseApiClient
    {
        public CourseApiClient(CanvasApiClient parent) : base(parent) { }

        //[Flags]
        //[PublicAPI]
        //public enum IndividualLevelCourseIncludes : uint {
        //    [ApiRepresentation("syllabus_body")]
        //    SyllabusBody = 1 << 0,
        //    [ApiRepresentation("term")]
        //    Term = 1 << 1,
        //    [ApiRepresentation("course_progress")]
        //    CourseProgress = 1 << 2,
        //    [ApiRepresentation("storage_quota_used_mb")]
        //    StorageQuotaUsedMb = 1 << 3,
        //    [ApiRepresentation("total_students")]
        //    TotalStudents = 1 << 4,
        //    [ApiRepresentation("teachers")]
        //    Teachers = 1 << 5,
        //    [ApiRepresentation("account_name")]
        //    AccountName = 1 << 6,
        //    [ApiRepresentation("concluded")]
        //    Concluded = 1 << 7,
        //    [ApiRepresentation("all_courses")]
        //    AllCourses = 1 << 8,
        //    [ApiRepresentation("permissions")]
        //    Permissions = 1 << 9,
        //    [ApiRepresentation("observed_users")]
        //    ObservedUsers = 1 << 10,
        //    [ApiRepresentation("course_image")]
        //    CourseImage = 1 << 11,
        //    [ApiRepresentation("needs_grading_count")]
        //    NeedsGradingCount = 1 << 12,
        //    [ApiRepresentation("public_description")]
        //    PublicDescription = 1 << 13,
        //    [ApiRepresentation("total_scores")]
        //    TotalScores = 1 << 14,
        //    [ApiRepresentation("current_grading_period_scores")]
        //    CurrentGradingPeriodScores = 1 << 15,
        //    [ApiRepresentation("account")]
        //    Account = 1 << 16,
        //    [ApiRepresentation("sections")]
        //    Sections = 1 << 17,
        //    [ApiRepresentation("passback_status")]
        //    PassbackStatus = 1 << 18,
        //    [ApiRepresentation("favorites")]
        //    Favorites = 1 << 19,
        //    Everything = uint.MaxValue
        //}

        public async Task<IEnumerable<ICourse>> List(Action<IListOptions> optionsFactory)
        {
            var options = new ListOptions();
            optionsFactory?.Invoke(options);

            return await this.ApiClient.PagableApiOperation<Course, IListOptions>(HttpMethod.Get, "/api/v1/courses", options);
        }

        //public async Task<IEnumerable<ICourse>> List ( IndividualLevelCourseIncludes? includes ) {
        //    var args = new List<(string, string)>();
        //    includes?.GetFlagsApiRepresentations()
        //        .Select(r => ("include[]", r))
        //        .Peek(t => args.Add(t));

        //    return await this.ApiClient.PagableApiOperation<Course, ICourse>(HttpMethod.Get, "/api/v1/courses", BuildQueryString(args.ToArray());
        //}

        public async Task<IEnumerable<ICourse>> List(long userId, Action<IListOptions> optionsFactory)
        {
            var options = new ListOptions();
            optionsFactory?.Invoke(options);

            return await this.ApiClient.PagableApiOperation<Course, IListOptions>(HttpMethod.Get, $"/api/v1/accounts/{userId}/courses", options);
        }

        public Task<ICourseProgress> Progress(long courseId, long userId)
        {
            throw new NotImplementedException();
        }
    }
}
