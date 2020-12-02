using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TrabalhoEMC0101.ViewModels
{
    class MasterPageVM
    {
        public int numeroBinario { get; set; }
        public int numeroDecimal { get; set; }
        public Command ConverterCMD { get; set; }
        public  MasterPageVM()
        {
            ConverterCMD = new Command(Converter);
        }

        public void Converter()
        {
            
        }
    }
}
