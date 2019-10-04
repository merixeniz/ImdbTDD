using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Xunit;

namespace ImdbCommunication.Tests
{
    public class ImdbMovieDetails
    {
        string execute(string imdbId)
        {
            string apikey = "apikey=af0e2d3b";

            string url = "http://www.omdbapi.com/?i=" + imdbId + "&" + apikey;

            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }               

        private static dynamic desierialize_json(string results)
        {
            return new JavaScriptSerializer().Deserialize<dynamic>(results);
        }

        [Fact]
        public void returns_json_string()
        {
            string result = execute("tt0103776");

            var ex = Record.Exception(() => new JavaScriptSerializer().Deserialize<dynamic>(result)); 

            Assert.Null(ex); // sprawdzanie czy to nie jest wyjatek
        }

        [Fact]
        public void returns_details_about_BatmanReturns_when_given_its_id()
        {
            string result = execute("tt0103776");

            dynamic batman_returns_details = desierialize_json(result);

            Assert.Equal("Batman Returns", batman_returns_details["Title"]);
            Assert.Equal("Tim Burton", batman_returns_details["Director"]);
            Assert.Equal("movie", batman_returns_details["Type"]);
            Assert.Equal("126 min", batman_returns_details["Runtime"]);
            Assert.NotNull(batman_returns_details["imdbRating"]);            
        }             

       

    }
   
}
