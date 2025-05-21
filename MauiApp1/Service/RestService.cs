using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Service
{
    internal class RestService
    {

        private const string REST_URL = "https://ddbvx87f-7040.euw.devtunnels.ms/Car/GetCars";
        private HttpClient _client = new HttpClient();


        public async Task<HttpResponseMessage> GetCars()
        {
            return await _client.GetAsync(REST_URL);
        }



    }
}
