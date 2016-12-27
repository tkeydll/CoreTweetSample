using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTweetSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Twitter();

            var screen_name = "";
            var id = 0;

            var responseId = client.QuoteTweet("hoge", screen_name, id);

            Console.WriteLine(responseId);

            Console.WriteLine("Press Enter: ");
            Console.ReadLine();
        }
    }
}
