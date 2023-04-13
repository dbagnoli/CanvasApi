using CanvasApi.Client.Reports.Models;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace CanvasApi.Client.Reports {

    public interface IReportApiClient {
        Task<IReportModel> StartReport (
            [NotNull] string reportType,
            [NotNull] Action<IReportStartParameterListOptions> parameters,
            ulong? accountId = null );

        Task<IReportModel> GetReportStatus (
            [NotNull] string reportType,
            [NotNull] ulong reportId,
            ulong? accountId = null );

        Task<T> GetDownloadedCsvAsObjectList<T> (
            [NotNull] string url );
    }
}