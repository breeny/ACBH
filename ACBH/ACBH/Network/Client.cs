using ACBH.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ACBH.Network
{
    class Client
    {
        string baseUrl;

        public Client(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        const string GET = "GET";
        const string PUT = "PUT";
        const string POST = "POST";

        const string CONTENT_TYPE = "application/json";
        const string BEER_URL = "/beers";

        public async Task<ICollection<BeerEntry>> RetrieveBeers(int year)
        {
            var yearRequest = Request(year.ToString());
            yearRequest.Method = GET;

            var yearResponse = await SendRequest<JObject>(yearRequest);
            var keys = yearResponse.Properties().Select(x => x.Name.ToString());

            var beers = new List<BeerEntry>();

            foreach (var key in keys)
            {
                var yearDetails =  JsonConvert.DeserializeObject<YearDetails>(yearResponse[key].ToString());
                var beerEntry = new BeerEntry();
                beerEntry.YearDetails = yearDetails;
                var beerRequest = Request(string.Format("beer/{0}", yearDetails.BeerID));
                beerRequest.Method = GET;
                beerEntry.Beer = await SendRequest<Beer>(beerRequest);
                beers.Add(beerEntry);
            }

            return beers;
        }

        public bool RegisterUser(UserRegistration user)
        {
            return true;
        }

        HttpWebRequest Request(string path)
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(new Uri(string.Format("{0}/{1}.json", baseUrl, path)));
            request.ContentType = CONTENT_TYPE;
            return request
        }

        async Task<JObject> SendRequest(HttpWebRequest request)
        {
            return await SendRequest<JObject>(request);
        }

        async Task<T> SendRequest<T>(HttpWebRequest request)
        {
            using (var response = await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new JsonTextReader(new StreamReader(stream)))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<T>(reader);
            }
        }
    }
}
