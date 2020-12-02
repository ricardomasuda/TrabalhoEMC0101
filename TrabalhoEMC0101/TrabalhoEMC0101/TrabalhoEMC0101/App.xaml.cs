﻿using System;
using TrabalhoEMC0101.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabalhoEMC0101
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            
            MainPage =new NavigationPage(new MasterPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
