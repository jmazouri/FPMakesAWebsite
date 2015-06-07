using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;

namespace FPMakesAWebsite
{
    class Program
    {
        static void Main(string[] args)
        {
            #if DEBUG
                string hostname = "http://localhost:8080/";
            #else
                string hostname = "http://fp.jmazouri.com:81/";
            #endif

            using (NancyHost host = new NancyHost(new Uri(hostname)))
            {
                host.Start();
                HtmlPuller.StartUpdater();

                Console.WriteLine("This dumb thing is running. Push enter to kill it.");
                Console.ReadLine();
                Console.WriteLine("I HAD SO MUCH TO LIVE FOR");
            }
        }
    }
}
