using CanvasApi.Client.SisImports.Models.Concretes;
using System.Collections.Generic;

namespace CanvasApi.Client.SisImports.Models {

    public interface ISisImportData {
        string ImportType { get; set; }
        IEnumerable<string> SuppliedBatches { get; set; }
        SisImportCounts Counts { get; set; }
    }
}