using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class ImdbRawCommunication
    {
        string apikey = "apikey=af0e2d3b";

        public string Search(string query)
        {          
            string queryString = "?s=" + query + "&" + apikey;

            return GetHttp(queryString);
        }

        public string Details(string imdbId)
        {        
            string queryString = "?i=" + imdbId + "&" + apikey;

            return GetHttp(queryString);
        }

        private static string GetHttp(string queryString)
        {
            string url = "http://www.omdbapi.com/" + queryString;

            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

    }
}
