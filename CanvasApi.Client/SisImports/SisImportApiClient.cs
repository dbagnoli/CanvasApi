using Canvas.Api.Client.SisImports.Models;
using CanvasApi.Client._Base;
using CanvasApi.Client.Extentions;
using CanvasApi.Client.SisImports.Models.Concretes;
using CanvasApi.Client.Users.Models;
using Flurl;
using JetBrains.Annotations;
using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApi.Client.SisImports {
    public class SisImportApiClient : ApiClientBase, ISisImportApiClient {
        public SisImportApiClient ( CanvasApiClient parent ) : base(parent) {
        }

        /// <summary>
        /// Returns user profile data, including user id, name, and profile pic.
        ///
        /// When requesting the profile for the user accessing the API, the user's calendar feed URL and LTI user id will be returned as well.
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns><see cref="IUserProfile"/>Profile for the requested user</returns>
        public async Task<ISisImport> ImportSisData (
            [NotNull] byte[] fileData,
            [NotNull] string fileName,
            bool batchMode = false,
            ulong? accountId = null,
            bool? overrideStickiness = null,
            string? diffingDataSetIdentifier = null,
            int? changeThreshold = null,
            bool? clearSisStickiness = null,
            bool? diffingRemasterDataSet = null, 
            string? diffingDropStatus = null
            ) {
            var contentType = MimeKit.MimeTypes.GetMimeType(fileName);

            if (fileName.EndsWith(".csv")) {
                contentType = "text/csv"; // C# doesn't understand what a csv is
            }
            var bytesContent = new ByteArrayContent(fileData);
            var queryString = "/api/v1"
                .AppendPathSegment("accounts")
                .AppendPathSegment(accountId.IdOrSelf())
                .AppendPathSegment("sis_imports")
                //.SetQueryParam("attachment", fileName)
                .SetQueryParam("import_type", "instructure_csv")
                .SetQueryParam("extension", "csv");
            //.SetQueryParam("batch_mode", batchMode);

            if (overrideStickiness != null) {
                queryString.SetQueryParam("override_sis_stickiness", overrideStickiness);
            }

            if (diffingDataSetIdentifier != null) {
                queryString.SetQueryParam("diffing_data_set_identifier", diffingDataSetIdentifier);
            }

            if (changeThreshold != null) {
                queryString.SetQueryParam("change_threshold", changeThreshold);
            }

            if (clearSisStickiness != null) {
                queryString.SetQueryParam("clear_sis_stickiness", clearSisStickiness);
            }

            if (diffingRemasterDataSet != null) {
                queryString.SetQueryParam("diffing_remaster_data_set", diffingRemasterDataSet);
            }

            if (diffingDropStatus != null) {
                queryString.SetQueryParam("diffing_drop_status", diffingDropStatus);
            }
            //var args = BuildQueryString(new[] {
            //    ("batch_mode", batchMode.ToShortString()),
            //    ("override_sis_stickiness", overrideStickiness?.ToShortString())
            //});


            bytesContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            //bytesContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

            //var clientHandler = new HttpClientHandler {
            //    UseCookies = false,
            //};



            //XmlDocument xml = new XmlDocument();
            //xml.Load(xmlFile);
            //byte[] bytes = Encoding.ASCII.GetBytes(xml.InnerXml);



            //var clientHandler = new HttpClientHandler {
            //    UseCookies = false,
            //};
            //var clientHttpclient = new HttpClient(clientHandler);
            //var contentHttpClient = await bytesContent.ReadAsByteArrayAsync();
            //var requestHttpClient = new HttpRequestMessage {
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri("https://leho-howest.test.instructure.com/api/v1/accounts/1/sis_imports?import_type=instructure_csv&extension=csv"),
            //    Headers =
            //        {                        
            //            { "Authorization", "Bearer 12401~5P6kVHINWAu539Lo0sdCTytDeBz64hMe6acvVyBP7oCDTHXGD0SO87oQgy77aYr2" }
            //        },
            //    Content = new ByteArrayContent(contentHttpClient) {
            //        Headers =
            //            {
            //                ContentType = new MediaTypeHeaderValue("text/csv")
            //            }
            //    }
            //};            

            //using (var responseHttpClient = await clientHttpclient.SendAsync(requestHttpClient)) {
            //    responseHttpClient.EnsureSuccessStatusCode();
            //    var body = await responseHttpClient.Content.ReadAsStringAsync();
            //    Console.WriteLine(body);
            //    Debug.WriteLine(body);
            //}





            // setup request
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri("https://leho-howest.test.instructure.com/api/v1/accounts/1/sis_imports?import_type=instructure_csv&extension=csv&Content-Type=text/csv"));
            ////NetworkCredential cred = new NetworkCredential(uname, cipher);
            ////CredentialCache cache = new CredentialCache {  { url, "Basic", cred } };
            //request.Headers.Add("Authorization", "Bearer 12401~5P6kVHINWAu539Lo0sdCTytDeBz64hMe6acvVyBP7oCDTHXGD0SO87oQgy77aYr2");
            //request.PreAuthenticate = true;
            ////request.Credentials = cache;
            //request.Method = "POST";
            ////request.ContentType = "application/xml; encoding='utf-8'";
            //request.ContentType = "text/csv";
            //var content = await bytesContent.ReadAsByteArrayAsync();
            //request.ContentLength = content.Length;
            
            //// stream
            //Stream requestStream = request.GetRequestStream();
            //requestStream.Write(content, 0, content.Length);
            //requestStream.Close();

            //// response        
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream responseStream = response.GetResponseStream();
            //StreamReader readStream = new StreamReader(responseStream, Encoding.Default);
            //var xmlResponse = readStream.ReadToEnd();
            //Debug.WriteLine(xmlResponse);

            ////        var clientHandler = new HttpClientHandler {
            ////            UseCookies = true,
            ////        };
            ////        var client = new HttpClient(clientHandler);
            ////        var request = new HttpRequestMessage {
            ////            Method = HttpMethod.Post,
            ////            RequestUri = new Uri("https://leho-howest.test.instructure.com/api/v1/accounts/1/sis_imports?import_type=instructure_csv&extension=csv&Content-Type=text/csv"),
            ////            Headers =
            ////            {
            ////    { "cookie", "_csrf_token=DqSghqFQxG8U2zYt4ZfLjWScqnooAHsSpF0jYWKzwEZq9sfV7wW8VlfuAF6I7Yb5MfThSB80PiTTEHNTD9%252BREQ%253D%253D; log_session_id=7c1a3a73af8cc2d6c61c1660d7a7238c; _legacy_normandy_session=IIUdAtJLReD0rti59xmC4w.is2GLpinysVcpc866_1kU_nuVkGStiNc6aQ_VDfuWNiRmM1IOS07g9ic9yNYNhF4OqAW69BEppIdp3yWBYB10envCGoQr0YAZHLWMmVsQ8SyAQxmcJF7Q0y1vk8bEvaX.u-eH0Fs5yjZ-KECc27mIxr3hD4g.YrRADQ; canvas_session=IIUdAtJLReD0rti59xmC4w.is2GLpinysVcpc866_1kU_nuVkGStiNc6aQ_VDfuWNiRmM1IOS07g9ic9yNYNhF4OqAW69BEppIdp3yWBYB10envCGoQr0YAZHLWMmVsQ8SyAQxmcJF7Q0y1vk8bEvaX.u-eH0Fs5yjZ-KECc27mIxr3hD4g.YrRADQ" },
            ////    { "Authorization", "Bearer 12401~5P6kVHINWAu539Lo0sdCTytDeBz64hMe6acvVyBP7oCDTHXGD0SO87oQgy77aYr2" },
            ////},
            ////            Content = new StringContent("Y291cnNlX2lkLHNlY3Rpb25faWQsbmFtZSxzdGF0dXMNCjg5NTY3VDIsY291cnNlc2V0ODk1NjdKSDIsQUFEIEEgSjIsYWN0aXZlDQo5MDg5N1QxLGNvdXJzZXNldDkwODk3SkgxLEFBRCBBIEoxLGFjdGl2ZQ0KODczMzlUMixjb3Vyc2VzZXQ4NzMzOUosQUFEIEEgSixhY3RpdmUNCg==") {
            ////                Headers =
            ////                {
            ////        ContentType = new MediaTypeHeaderValue("application/octet-stream")
            ////    }
            ////            }
            ////        };
            ////        using (var response = await client.SendAsync(request)) {
            ////            response.EnsureSuccessStatusCode();
            ////            var body = await response.Content.ReadAsStringAsync();
            ////            Console.WriteLine(body);
            ////            Debug.WriteLine(body);
            ////        }




            ////var clientRest1 = new RestClient("https://leho-howest.test.instructure.com/api/v1/accounts/1/sis_imports?created_since=2021-09-01");
            ////clientRest1.Options.Timeout = -1;
            ////var requestRest1 = new RestRequest();
            ////requestRest1.Method = Method.Post;
            ////requestRest1.AddHeader("Authorization", "Bearer 12401~5P6kVHINWAu539Lo0sdCTytDeBz64hMe6acvVyBP7oCDTHXGD0SO87oQgy77aYr2");
            ////requestRest1.AddHeader("Content-Type", "text/csv");
            ////requestRest1.AddHeader("Cookie", "_csrf_token=zGpqxG2B9D1OJwk4m25BnhXFXoawxeptB7HpVQ2edqSdOg%2B3H8qMXwkWTk%2FCCTSxfZ8w1%2F2snipvnphjadoizg%3D%3D; _legacy_normandy_session=8H_wUP_tY7VKHjZDdUDK9A.SuD9IH_mIX6blqu8ZMHFPeCKr9QsfwjlpfDD4twrH3yV3DSXKloCyujS5h3_DcMyhWWf6BDjuzv27ZpCIW_0VIQKuQ_tPXiKM-vpyU2dq_BUT5LcNg-1XCUmfivUv593.km4e8_6p1HkXzPySZ5srgOQr1a0.YrQJ4Q; canvas_session=8H_wUP_tY7VKHjZDdUDK9A.SuD9IH_mIX6blqu8ZMHFPeCKr9QsfwjlpfDD4twrH3yV3DSXKloCyujS5h3_DcMyhWWf6BDjuzv27ZpCIW_0VIQKuQ_tPXiKM-vpyU2dq_BUT5LcNg-1XCUmfivUv593.km4e8_6p1HkXzPySZ5srgOQr1a0.YrQJ4Q; log_session_id=fa93d374e048eafa5f36524a5a1a8fac");
            ////requestRest1.AddParameter("text/csv", "Y291cnNlX2lkLHNlY3Rpb25faWQsbmFtZSxzdGF0dXMNCjg5NTY3VDIsY291cnNlc2V0ODk1NjdKSDIsQUFEIEEgSjIsYWN0aXZlDQo5MDg5N1QxLGNvdXJzZXNldDkwODk3SkgxLEFBRCBBIEoxLGFjdGl2ZQ0KODczMzlUMixjb3Vyc2VzZXQ4NzMzOUosQUFEIEEgSixhY3RpdmUNCg==", ParameterType.RequestBody);
            ////var responseRest1 = clientRest1.Execute(requestRest1);
            ////Console.WriteLine(responseRest1.Content);




            ////var clientRest = new RestClient("https://leho-howest.test.instructure.com/api/v1/accounts/1/sis_imports?import_type=instructure_csv&extension=csv");
            ////var requestRest = new RestRequest();
            ////requestRest.Method = Method.Post;
            ////requestRest.AddHeader("Content-Type", "text/csv");
            ////requestRest.AddHeader("Authorization", "Bearer 12401~5P6kVHINWAu539Lo0sdCTytDeBz64hMe6acvVyBP7oCDTHXGD0SO87oQgy77aYr2");
            ////var content = await bytesContent.ReadAsByteArrayAsync();
            ////requestRest.AddHeader("Content-Length", content.Length);
            //////requestRest.AddHeader("Set-Cookie", "_csrf_token=mJd4QIeCwN3hNK4Sij%2BmYi7K%2FuASTGIZRSH2P20B%2FjqtwEgh4MfxrrZDyH25c%2BEzXZCW2Xc1W2N1bLNyOnmJDg%3D%3D; _legacy_normandy_session=Lt_rqMYWDywI3SrIbB6_mA.UMAXqS87MFfNOWMT-CVgxEcewGeS2Ah3nBuQ9ZcKgOYSTxYUvM7eYQBPF1GamM9YeCrSU3JA1m4D0elKiFrbm07XaZFUFVSUGj4F7koY1LpGlX13Wh9EMOGqVrEMG0Q2.iBlCtl_rYfykCBW9K8pcpRSv2Dc.YrQERw; canvas_session=Lt_rqMYWDywI3SrIbB6_mA.UMAXqS87MFfNOWMT-CVgxEcewGeS2Ah3nBuQ9ZcKgOYSTxYUvM7eYQBPF1GamM9YeCrSU3JA1m4D0elKiFrbm07XaZFUFVSUGj4F7koY1LpGlX13Wh9EMOGqVrEMG0Q2.iBlCtl_rYfykCBW9K8pcpRSv2Dc.YrQERw; log_session_id=2eaf1271e7d0c4cbb69a1914093e549f");
            ////requestRest.AddHeader("Host", "Howest");

            //////request.AddCookie("_csrf_token", "rzcMsEoUsZ6QBrdiCXSu1bNIAmaeE9RmclRkvceyd47LZWvjBEHJp9MzgRFgDuOh5iBJVKknkVAFGTSPqt4m2Q%3D%3D");
            //////request.AddCookie("log_session_id", "7c1a3a73af8cc2d6c61c1660d7a7238c");
            //////request.AddCookie("_legacy_normandy_session", "xtfJPiEgXn1KuE2xaMJoAg.vg7gWCc3NZ3boGtdo_3bbGe49eRcuQzhjhlFjDEjTvqtGef9vwopgHfSlrTOhQ2eCKYRBdI2R_cRpCaOJYIit672CpK98KIirNKUaF35gaOoMZPWvqVjBVqPFstB-rFK.QhXoPyLvup_MpkbRyN84B8VnH-Y.YrMKnA");
            //////request.AddCookie("canvas_session", "xtfJPiEgXn1KuE2xaMJoAg.vg7gWCc3NZ3boGtdo_3bbGe49eRcuQzhjhlFjDEjTvqtGef9vwopgHfSlrTOhQ2eCKYRBdI2R_cRpCaOJYIit672CpK98KIirNKUaF35gaOoMZPWvqVjBVqPFstB-rFK.QhXoPyLvup_MpkbRyN84B8VnH-Y.YrMKnA");
            ////requestRest.AddParameter("text/csv", "Y291cnNlX2lkLHNlY3Rpb25faWQsbmFtZSxzdGF0dXMNCjg5NTY3VDIsY291cnNlc2V0ODk1NjdKSDIsQUFEIEEgSjIsYWN0aXZlDQo5MDg5N1QxLGNvdXJzZXNldDkwODk3SkgxLEFBRCBBIEoxLGFjdGl2ZQ0KODczMzlUMixjb3Vyc2VzZXQ4NzMzOUosQUFEIEEgSixhY3RpdmUNCg==", ParameterType.RequestBody);

            ////var responseRest = clientRest.Execute(requestRest);





            



            return await ApiClient.ApiOperation<SisImport, ByteArrayContent>(HttpMethod.Post, queryString, bytesContent); //client.PostAsync($"accounts/{accountId.IdOrSelf()}/sis_imports" + args, bytesContent);
            //return await ApiClient.ApiOperation<SisImport>(HttpMethod.Post, queryString); //client.PostAsync($"accounts/{accountId.IdOrSelf()}/sis_imports" + args, bytesContent);
        }

        /// <summary>
        /// Return user profile data, includeing user id, name and profile pic.
        ///
        /// When requesting the profile for the user accessing the API, the user's calendar feed URL and LTI user id will be returned as well.
        ///
        /// </summary>
        /// <param name="sisUserId">The sis user identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<ISisImport> GetSisImport ( ulong id, ulong? accountId = null ) {
            var queryString = "/api/v1/"
                .AppendPathSegment("accounts")
                .AppendPathSegment(accountId.IdOrSelf())
                .AppendPathSegment("sis_imports")
                .AppendPathSegment(id);

            return await this.ApiClient.ApiOperation<SisImport>(HttpMethod.Get, queryString);
        }
    }
}