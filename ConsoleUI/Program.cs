using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImdbCommunication;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(execute("Batman"));
            Console.WriteLine(" ");
            Console.WriteLine(findFilmOverId("tt0103776"));

            string result = findFilmOverId("tt0103776");
                                
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new ImdbRawCommunication().Search("Batman"));

            Movie movie = new Movie();
            movie = gimmeMovie(new ImdbRawCommunication().Details("tt0103776"));

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(movie.Title);
            Console.WriteLine(movie.Director);
            Console.WriteLine(movie.Year);
            

            Console.ReadKey();
        }

        static string execute(string query)
        {
            string apikey = "apikey=af0e2d3b";

            string url = "http://www.omdbapi.com/?s=" + query + "&" + apikey;

            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        static string findFilmOverId(string imdbId)
        {
            string apikey = "apikey=af0e2d3b";

            string url = "http://www.omdbapi.com/?i=" + imdbId + "&" + apikey;

            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }      

        static Movie gimmeMovie(string json)
        {          
            return new ImdbDataParser().ParseDetails(json);
        }
                        
    }
}
