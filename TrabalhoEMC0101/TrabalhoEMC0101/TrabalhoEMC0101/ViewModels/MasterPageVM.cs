﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TrabalhoEMC0101.Models;
using TrabalhoEMC0101.Views;
using Xamarin.Forms;

namespace TrabalhoEMC0101.ViewModels
{
    class MasterPageVM : INotifyPropertyChanged
    {

        private int _numeroBinario;
        public int numeroBinario { get { return _numeroBinario; } set { _numeroBinario = value; OnPropertyChanged("numeroBinario"); } }
        public int _numeroDecimal { get; set; }
        public int numeroDecimal { get { return _numeroDecimal; } set { _numeroDecimal = value; OnPropertyChanged("numeroDecimal"); } }
        public string _Texto { get; set; }
        public string Texto { get { return _Texto; } set { _Texto = value; OnPropertyChanged("Texto"); } }
        public Command ConverterCMD { get; set; }
        public Command ThingspeakCMD { get; set; }
        public Command ConfingurarCMD { get; set; }
        public thingspeak thingspeak { get; set; } = new thingspeak();
        Page Page;
        public MasterPageVM(Page page)
        {
            Page = page;
            ConverterCMD = new Command(Converter);
            ThingspeakCMD = new Command(BuscaThigs);
            ConfingurarCMD = new Command(ConfigurarURL);
            BuscaThigs();
            Texto = "Converter";
        }
        
        public async void ConfigurarURL()
        {
           await Page.Navigation.PushAsync(new ConfigurarURL());
        }

        public async void BuscaThigs()
        {
            //thingspeak things = new thingspeak();
            var feed=  await thingspeak.BuscarInfo();
            numeroDecimal = Convert.ToInt32(feed.field1);
        }


        public async void Converter()
        {
            if (Texto == "Converter")
            {
                if (await Validar())
                {
                    if (numeroBinario != 0)
                    {
                        numeroDecimal = Conversor.BinarioDecimal(numeroBinario.ToString());
                    }
                    else
                    {
                        numeroBinario = Convert.ToInt32(Conversor.DecimalBinario(numeroDecimal.ToString()));
                    }
                    Texto = Texto == "Converter" ? "Limpar" : "Converter";
                }
            }
            else
            {
                numeroDecimal = 0;
                numeroBinario = 0;
                Texto = Texto == "Converter" ? "Limpar" : "Converter";
            }
        }

        public async Task<bool> Validar()
        {
            if (numeroBinario == 0 && numeroDecimal == 0)
            {
                await Page.DisplayAlert("Erro","Insira ao menos um valor","Ok");
                return false;
            }
           
            for (int i = 2; i<=9; i++)
            {
                if( numeroBinario.ToString().Contains(i.ToString()))
                {
                    await Page.DisplayAlert("Erro", "Insira apenas valores 1 e 0", "Ok");
                    return false;
                }
            }
            if (numeroBinario == 0 || numeroDecimal == 0)
            {
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
