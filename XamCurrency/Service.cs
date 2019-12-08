using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamCurrency
{
    public class Service
    {
        HttpClient httpClient;

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            if (Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet)
            {
                try
                {
                    httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await httpClient.GetAsync(uri);
                    string serialized = await response.Content.ReadAsStringAsync();
                    TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    }));

                    return result;
                }
                catch (Exception e)
                {
                    return default(TResult);
                }
            }
            else
            {
                return default(TResult);
            }
        }
    }
}
