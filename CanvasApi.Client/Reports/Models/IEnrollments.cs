namespace CanvasApi.Client.Reports.Models {

    public interface IEnrollments {
        public string Course_Id { get; set; }
        public string? User_Id { get; set; }
        public string Role { get; set; }
        public ulong Role_Id { get; set; }
        public string Section_Id { get; set; }
        public string Status { get; set; }
        public string? Associated_User_Id { get; set; }
        public bool? LimitSectionPrivileges { get; set; }
    }
}