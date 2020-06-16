using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using System.Net.Http;
using System.Threading.Tasks;

using TestsSystem.Core.Security;
using TestsSystem.Web.Extensions;
using TestsSystem.Web.Models.REST;

namespace TestsSystem.Web.Models.VO
{
    public class HttpContext
    {
        private readonly string _apiVers;
        private readonly HttpClient _client;

        public HttpContext(
            HttpClient client,
            IOptions<ApiCredentials> options)
        {
            _client = client;
            _apiVers = options.Value.ApiVersion;
        }

        public async Task<T> HttpGetAsync<T>(RequestBase request)
        {
            var resp = await _client.With(request.Headers).GetAsync(request
                .Endpoint.WithVers(_apiVers));

            return await UnpackedAnswerAsync<T>(resp);
        }

        public async Task<T> HttpPostAsync<T>(RequestBase request)
        {
            var resp = await _client.With(request.Headers).PostAsync(request
                .Endpoint.WithVers(_apiVers), request.ContentBody);

            return await UnpackedAnswerAsync<T>(resp);
        }

        public async Task<T> HttpPutAsync<T>(RequestBase request)
        {
            var resp = await _client.With(request.Headers).PutAsync(request
                .Endpoint.WithVers(_apiVers), request.ContentBody);

            return await UnpackedAnswerAsync<T>(resp);
        }

        public async Task<T> HttpDeleteAsync<T>(RequestBase request)
        {
            var resp = await _client.With(request.Headers).DeleteAsync(request
                .Endpoint.WithVers(_apiVers));

            return await UnpackedAnswerAsync<T>(resp);
        }

        private async Task<T> UnpackedAnswerAsync<T>(HttpResponseMessage response)
        {
            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
