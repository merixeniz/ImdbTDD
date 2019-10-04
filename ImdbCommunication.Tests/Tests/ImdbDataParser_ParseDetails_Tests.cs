using ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace ImdbCommunication.Tests
{
    public class ImdbDataParser_ParseDetails_Tests
    {
        private ImdbDataParser parser;

        public ImdbDataParser_ParseDetails_Tests() // konstruktor w klasie z testami oznacza wspolna inicjalizajcje calego srodowiska
        {
            parser = new ImdbDataParser();
        }

        Movie execute(string json)
        {
            return parser.ParseDetails(json);
        }

        [Fact]
        public void parses_movie_title()
        {
            //var result = execute(new ImdbRawCommunication().Search("Batman"));
            var movieResult = execute(new ImdbRawCommunication().Details("tt0103776"));

            var result = new ImdbRawCommunication().Search("Batman");
            
            Assert.NotNull(result);

            Assert.NotNull(movieResult.Title); //sparsował poprawnie
        }

    }
}
