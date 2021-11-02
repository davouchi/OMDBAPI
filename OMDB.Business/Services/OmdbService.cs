using Newtonsoft.Json;
using OMDBAPI.Business.Interfaces;
using OMDBAPI.Domain.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OMDBAPI.Business.Services
{
    public class OmdbService : IOmdbService
    {
        public static string EndPointUrl = Environment.GetEnvironmentVariable("OMDBUrl");


        public async Task<OmdbResponse> GetOmdbResponseAsync(string title)
        {
            var response = new OmdbResponse();
            try
            {
                var request = EndPointUrl + "s=" + title;

                using (var httpClient = new HttpClient())
                {
                    using (var apiResponse = await httpClient.GetAsync(request))
                    {
                        string omdbResp = await apiResponse.Content.ReadAsStringAsync();
                        response = JsonConvert.DeserializeObject<OmdbResponse>(omdbResp);
                    }
                }

               
            }
            catch (Exception ex)
            {
            }
            return response;
        }
    }
}