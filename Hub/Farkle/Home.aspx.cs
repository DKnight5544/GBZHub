using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hub.Farkle
{
    public partial class Home: System.Web.UI.Page
    {

        private static string now = DateTime.Now.Ticks.ToString();
        //public string jsSrc = string.Format("src= 'js/Site.js?{0}'", now);
        public string cssHref1 = string.Format("href='/css/default.css?{0}'", now);
        public string cssHref2 = string.Format("href='/Farkle/css/Home.css?{0}'", now);

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}