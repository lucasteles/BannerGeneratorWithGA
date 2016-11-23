using GeneticAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace BannerGeneratorWithGeneticAlgorithm
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static GA BannerGA { get; set; }

        protected void Application_Start()
        {
            BannerGA = new GA();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
