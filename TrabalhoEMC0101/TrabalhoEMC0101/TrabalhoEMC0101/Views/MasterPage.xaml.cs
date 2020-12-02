using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoEMC0101.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabalhoEMC0101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new MasterPageVM();
        }

    }
}