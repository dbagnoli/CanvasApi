using JetBrains.Annotations;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CanvasApi.Client.SisImports.Models.Concretes {
    public class SisImportData : ISisImportData {
        [JsonProperty("import_type")]
        public string ImportType { get; set; }

        [JsonProperty("supplied_batches")]
        public IEnumerable<string> SuppliedBatches { get; set; }

        [JsonProperty("counts")]
        [CanBeNull]
        public SisImportCounts Counts { get; set; }
    }
}