using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using CsQuery;
using CsQuery.Web;

namespace FPMakesAWebsite
{
    //SINGLETONS ARE FINE
    public static class HtmlPuller
    {
        public static string CurrentHtml { get; set; }
        private static Timer timer;

        public static void StartUpdater()
        {
            PullNewCode();

            timer = new Timer(30000);
            timer.Elapsed += PullNewCode();
            timer.Start();
        }

        private static ElapsedEventHandler PullNewCode()
        {
            Console.WriteLine("[{0}] Pulling newest code...", DateTime.Now);
            CQ doc = CQ.CreateFromUrl("http://facepunch.com/showthread.php?t=1469381", new ServerConfig
            {
                //I don't think FP likes bots...
                UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.81 Safari/537.36",
                TimeoutSeconds = 5
            });

            CurrentHtml = doc[".bbcode_code"].Last().Text();

            return null;
        }
    }
}
