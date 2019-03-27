using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HW2_Kushnir_Apriorit
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static string FilePath { get; } = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\RequestHistory.log";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void Init()
        {
            BeginRequest += new EventHandler(GlobalBeginRequest);
            base.Init();
        }


        private void GlobalBeginRequest(object sender, EventArgs e)
        {
            if (!File.Exists(FilePath))
            {
                StreamWriter sw = File.CreateText(FilePath);
                sw.Close();
            }

            using (StreamWriter sw = File.AppendText(FilePath))
            {
                var request = ((System.Web.HttpApplication)sender).Request;
                StringBuilder sb = new StringBuilder();
                sb.Append("method = " + request.HttpMethod);
                sb.Append(" ip = " + request.UserHostAddress);
                sb.Append(" url = " + request.Url.ToString());
                sw.WriteLine(sb.ToString());
            }
        }
    }
}
