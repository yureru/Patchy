using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeDateClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DateClient();
            Console.WriteLine("The current date from the service is: " + client.GetCurrentDate());
        }
    }
}
