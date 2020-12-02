using System;
using System.Collections.Generic;
using System.Text;
using TrabalhoEMC0101.Models;
using Xamarin.Forms;

namespace TrabalhoEMC0101.ViewModels
{
    class MasterPageVM
    {
        public int numeroBinario { get; set; }
        public int numeroDecimal { get; set; }
        public Command ConverterCMD { get; set; }
        public MasterPageVM()
        {
            ConverterCMD = new Command(Converter);
        }

        public void Converter()
        {
            if (Validar())
            {
                if (numeroBinario == 0)
                {
                    numeroBinario = Conversor.BinarioDecimal(numeroBinario.ToString());
                }
                else
                {
                    numeroDecimal = Convert.ToInt32(Conversor.DecimalBinario(numeroDecimal.ToString()));
                }
            }
        }

        public bool Validar()
        {
            if (numeroBinario == 0 && numeroDecimal == 0)
            {
                return false;
            }
            if (numeroBinario == 0 || numeroDecimal == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
