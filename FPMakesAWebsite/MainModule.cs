using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace FPMakesAWebsite
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = _ => View["Home", HtmlPuller.CurrentHtml];

            Get["/horror"] = _ => View["Horror", HtmlPuller.CurrentHtml];
        }
    }
}
