using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoLabi.Services
{
    public class LocalService
    {
        private string _localServiceUrl = "http://10.1.163.113:3000";
        private async Task<HttpWebResponse> GetReponseCode()
        {
            var request = WebRequest.Create(_localServiceUrl);
            var response = (HttpWebResponse)await Task.Factory
                .FromAsync<WebResponse>(request.BeginGetResponse,
                                        request.EndGetResponse,
                                        null);
            return response;
        }

        public async Task<bool> IsAccesible()
        {
            var task = GetReponseCode();
            return task.Result.StatusCode == HttpStatusCode.OK;
        }
    }
}
