using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace ConsoleUI
{
    public class ImdbDataParser
    {
        public Movie ParseDetails(string json)
        {
            return new JavaScriptSerializer().Deserialize<Movie>(json);
        }

        private static dynamic desierialize_json(string results)
        {
            return new JavaScriptSerializer().Deserialize<dynamic>(results);
        }
    }
}
