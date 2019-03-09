using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hub.Farkle
{
    public partial class NotAFarkleBot: System.Web.UI.Page
    {

        private static string now = DateTime.Now.Ticks.ToString();
        //public string jsSrc = string.Format("src= 'js/Site.js?{0}'", now);
        public string cssHref = string.Format("href='/default.css?{0}'", now);

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}