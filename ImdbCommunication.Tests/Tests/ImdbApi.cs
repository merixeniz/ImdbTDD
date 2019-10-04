using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using System.Diagnostics;
using System.Web;
using System.Web.Script.Serialization;



namespace ImdbCommunication.Tests
{
    public class ImdbApi
    {
        string apikey = "apikey=af0e2d3b";

        string execute(string query)
        {
            string url = "http://www.omdbapi.com/?s=" + query + "&" + apikey;

            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        [Fact]
        public void FactMethodName()
        {
            
        }

        [Fact]
        public void returns_response()
        {
            string results = execute("Batman");
            
            Console.WriteLine(results);
            //Debug.Print(results);

            Assert.NotEmpty(results);
        }

        [Fact]
        public void returns_json_response()
        {
            string results = execute("Batman");

            var ex = Record.Exception( () => new JavaScriptSerializer().Deserialize<dynamic>(results)); //proba zainicjalizowana obiektu z wyjatkiem

            Assert.Null(ex); // sprawdzanie czy referencja jest pusta
        }

        [Fact]
        public void returns_BatmanReturns_among_other_results_when_searching_for_Batman()
        {
            string json = execute("Batman"); 

            dynamic deserializedJson = desierialize_json(json);

            dynamic[] search_result = deserializedJson["Search"];

            Assert.True(search_result.Length > 1);
            
            dynamic batman_returns = search_result.SingleOrDefault(a => a["Title"] == "Batman Returns");

            Assert.NotNull(batman_returns);

            Assert.Equal("Batman Returns", batman_returns["Title"]);

            Assert.Equal("1992", batman_returns["Year"]);
        }

        private static dynamic desierialize_json(string results)
        {
            return new JavaScriptSerializer().Deserialize<dynamic>(results);
        }

    }
}
