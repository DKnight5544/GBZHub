using System;
using System.Web.UI.HtmlControls;

namespace Hub.UserControls
{
    public partial class MenuControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void SetTitle(string title)
        {
            MenuTitle.Text = title;
        }

        public void ConfigureButtonOne(string onclick, string text)
        {
            ConfigureButton(ButtonOne, onclick, text);
        }

        public void ConfigureButtonTwo(string onclick, string text)
        {
            ConfigureButton(ButtonTwo, onclick, text);
        }

        public void ConfigureButtonThree(string onclick, string text)
        {
            ConfigureButton(ButtonThree, onclick, text);
        }

        public void ConfigureButtonFour(string onclick, string text)
        {
            ConfigureButton(ButtonFour, onclick, text);
        }

        public void ConfigureButtonFive(string onclick, string text)
        {
            ConfigureButton(ButtonFive, onclick, text);
        }

        public void ConfigureButtonSix(string onclick, string text)
        {
            ConfigureButton(ButtonSix, onclick, text);
        }

        private void ConfigureButton(HtmlButton button, string onclick, string text)
        {
            if (!string.IsNullOrWhiteSpace(onclick))
            {
                button.Attributes.Add("onclick", onclick);
                button.Disabled = false;
            }
            button.InnerText = text;

        }
    }
}