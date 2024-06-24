using Newtonsoft.Json;

namespace CanvasApi.Client.Reports.Models.Concretes {
    public class Enrollments : IEnrollments {
        [JsonProperty("course_id")]
        public string Course_Id { get; set; }

        [JsonProperty("user_id")]
        public string? User_Id { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("role_id")]
        public ulong Role_Id { get; set; }

        [JsonProperty("section_id")]
        public string Section_Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("associated_user_id")]
        public string? Associated_User_Id { get; set; }

        [JsonProperty("limit_section_privileges")]
        public bool? LimitSectionPrivileges { get; set; }
    }
}