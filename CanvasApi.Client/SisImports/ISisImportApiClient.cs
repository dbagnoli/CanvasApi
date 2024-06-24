using Canvas.Api.Client.SisImports.Models;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace CanvasApi.Client.SisImports {

    public interface ISisImportApiClient {
        Task<ISisImport> ImportSisData (
            [NotNull] byte[] file,
            [NotNull] string filePath,
            bool batchMode = false,
            ulong? accountId = null,            
            bool? overrideStickiness = null,
            string? diffingDataSetIdentifier = null,
            int? changeThreshold = null,
            bool? clearSisStickiness = null,
            bool? diffingRemasterDataSet = null,
            string? diffingDropStatus = null);

        Task<ISisImport> GetSisImport (
            ulong id,
            ulong? accountId = null );
    }
}