using CanvasApi.Client._Base;
using CanvasApi.Client.Extentions;
using CanvasApi.Client.Reports.Models;
using CanvasApi.Client.Reports.Models.Concretes;
using Flurl;
using JetBrains.Annotations;
using Newtonsoft.Json;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CanvasApi.Client.Reports {
    public class ReportApiClient : ApiClientBase, IReportApiClient {
        public ReportApiClient ( CanvasApiClient parent ) : base(parent) {
        }

        ///// <summary>
        ///// Return user profile data, includeing user id, name and profile pic.
        /////
        ///// When requesting the profile for the user accessing the API, the user's calendar feed URL and LTI user id will be returned as well.
        /////
        ///// </summary>
        ///// <param name="sisUserId">The sis user identifier.</param>
        ///// <returns>
        /////   <br />
        ///// </returns>
        //public async Task<ISisImport> GetSisImport ( ulong id, ulong? accountId = null ) {
        //    var queryString = "/api/v1/"
        //        .AppendPathSegment("accounts")
        //        .AppendPathSegment(accountId.IdOrSelf())
        //        .AppendPathSegment("sis_imports")
        //        .AppendPathSegment(id);

        //    return await this.ApiClient.ApiOperation<SisImport>(HttpMethod.Get, queryString);
        //}

        /// <summary>
        /// Starts the report.
        /// </summary>
        /// <param name="reportType">Type of the report.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        public async Task<IReportModel> StartReport ( [NotNull] string reportType, Action<IReportStartParameterListOptions> options, ulong? accountId = null ) { //[NotNull] string reportType, [NotNull] IEnumerable<(string, object)> parameters, ulong? accountId = null ) {
            //var content = this.ApiClient.BuildMultipartHttpArguments(
            //    parameters.ValSelect(JsonConvert.SerializeObject)
            //        .KeySelect(s => $"parameters[{s}")
            //        .ValSelect(s => s.Replace("\"", string.Empty).Trim())
            //        );



            var queryString = "/api/v1/"
                .AppendPathSegment("accounts")
                .AppendPathSegment(accountId.IdOrSelf())
                .AppendPathSegment("reports")
                .AppendPathSegment(reportType);

            return await this.ApiClient.ApiOperation<ReportModel, IReportStartParameterListOptions>(
                verb: HttpMethod.Post,
                url: queryString,
                body: options.GetOptions<IReportStartParameterListOptions, ReportStartParameterListOptions>()
                );
        }

        /// <summary>
        /// Gets the report status.
        /// When starting a report it could take a while. Therefore you need to check the status to see if it finished before you can retreive the report data.
        /// </summary>
        /// <param name="reportType">Type of the report.</param>
        /// <param name="reportId">The report identifier.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        public async Task<IReportModel> GetReportStatus ( [NotNull] string reportType, [NotNull] ulong reportId, ulong? accountId = null ) {
            var queryString = "/api/v1/"
                .AppendPathSegment("accounts")
                .AppendPathSegment(accountId.IdOrSelf())
                .AppendPathSegment("reports")
                .AppendPathSegment(reportType)
                .AppendPathSegment(reportId);

            return await ApiClient.ApiOperation<ReportModel>(
                HttpMethod.Get,
                queryString
                );
        }

        /// <summary>
        /// Gets the downloaded CSV as object list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public async Task<T> GetDownloadedCsvAsObjectList<T> ( [NotNull] string url ) {
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            var csvText = response.Content.ReadAsStringAsync();

            return csvText.Result.FromCsv<T>();
        }
    }
}