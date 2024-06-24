using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CanvasApi.Client.SisImports.Models.Concretes {

    public class SisImportStatistics {
        
        [JsonProperty("total_state_changes")]
        public ulong TotalStateChanges { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic Account { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic EnrollmentTerm { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic CommunicationChannel { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic AbstractCourse { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic Course { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic CourseSection { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic Enrollment { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic GroupCategory { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic Group { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic GroupMembership { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic Pseudonym { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic UserObserver { get; set; }
        
        [JsonProperty]
        [CanBeNull]
        public SisImportStatistic AccountUser { get; set; }
    }
}
