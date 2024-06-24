using Newtonsoft.Json;

namespace CanvasApi.Client.Reports.Models.Concretes {
    public class CrossListCourses : ICrossListCourses{
        [JsonProperty("xlist_course_id")]
        public string Xlist_Course_Id { get; set; }

        [JsonProperty("section_id")]
        public string Section_Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}