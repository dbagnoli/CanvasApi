using Newtonsoft.Json;

namespace CanvasApi.Client.SisImports.Models.Concretes {
    
    public class SisImportStatistic {
        
        [JsonProperty("created")]
        public ulong? Created { get; set; }
        
        [JsonProperty("concluded")]
        public ulong? Concluded { get; set; }
        
        [JsonProperty("deactivated")]
        public ulong? Deactivated { get; set; }
        
        [JsonProperty("restored")]
        public ulong? Restored { get; set; }
        
        [JsonProperty("deleted")]
        public ulong? Deleted { get; set; }
    }
}
