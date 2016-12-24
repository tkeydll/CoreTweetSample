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

            var id = client.Tweet("hoge");

            Console.WriteLine(id);

            Console.WriteLine("Press Enter: ");
            Console.ReadLine();
        }
    }
}
