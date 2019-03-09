using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hub
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCSS();

            var menu = LoadControl("/UserControls/MenuControl.ascx") as UserControls.MenuControl;
            MainMenuPlaceholder.Controls.Add(menu);

            menu.SetTitle("GBZ Home Page");

            menu.ConfigureButtonOne("window.location.href='/AboutGBZ.pdf';", "About the GBZ");
            menu.ConfigureButtonTwo("window.location.href='http://paypal.me/wigiwiz';", "DONATE");
            menu.ConfigureButtonThree("window.location.href='/Farkle/Home.aspx';", "Farkle Page");
            menu.ConfigureButtonFour("", "Yahtzee Page");
        }

        private void LoadCSS()
        {
            string now = DateTime.Now.Ticks.ToString();
            DefaultCSS.Href = "/css/default.css?" + now;
            MenuCSS.Href = "/css/menu.css?" + now;
        }
    }
}