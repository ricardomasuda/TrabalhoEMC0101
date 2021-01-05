using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabalhoEMC0101.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigurarURL : ContentPage
    {
        string URL { get; set; }
        public ConfigurarURL()
        {
            InitializeComponent();
            urlLayout.Text = "https://api.thingspeak.com/channels/1259096/feeds.json?api_key=IXFKZJJBUJAS3J1H&results=2";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(urlLayout.Text))
            {
                App.URL = urlLayout.Text;
                Navigation.PopAsync();
            }
        }
    }
}