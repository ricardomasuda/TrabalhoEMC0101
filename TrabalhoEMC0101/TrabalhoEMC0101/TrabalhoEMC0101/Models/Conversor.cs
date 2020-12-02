using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrabalhoEMC0101.Models
{
    public static class Conversor
    {
        public static int BinarioDecimal(string numeroBinario)
        {
            int expoente = 0;
            int numero;
            int soma = 0;
            string numeroInvertido = ReverteString(numeroBinario);
            for (int i = 0; i < numeroInvertido.Length; i++)
            {
                numero = Convert.ToInt32(numeroInvertido.Substring(i, 1));
                soma += numero * (int)Math.Pow(2, expoente);
                expoente++;
            }
            return soma;
        }
        public static string DecimalBinario(string numeroDecimal)
        {
            string valor = "";
            int dividendo = Convert.ToInt32(numeroDecimal);
            if (dividendo == 0 || dividendo == 1)
            {
                return Convert.ToString(dividendo);
            }
            else
            {
                while (dividendo > 0)
                {
                    valor += Convert.ToString(dividendo % 2);
                    dividendo = dividendo / 2;
                }
                return ReverteString(valor);
            }
        }
        public static string ReverteString(string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }
}
