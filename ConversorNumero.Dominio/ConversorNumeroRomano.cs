using System;
using System.Collections.Generic;

namespace ConversorNumero.Dominio
{
    public class ConversorNumeroRomano
    {
        Dictionary<string, int> numeros = new Dictionary<string, int>();

        public ConversorNumeroRomano()
        {
            string[] unidadesRomanas = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            ConfigurarUnidadesRomanas(unidadesRomanas);

            string[] dezenasRomanas = { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };

            ConfigurarDezenasRomanas(dezenasRomanas);

            string[] centenasRomanas = { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };

            ConfigurarCentenasRomanas(centenasRomanas, dezenasRomanas);

            string[] milhares = { "M", "MM", "MMM", "ĪV̄", "V̄", "V̄Ī", "V̄ĪĪ", "V̄ĪĪĪ", "ĪX̄" };
        }
       
        public int ConverterParaArabico(string numeroRomano)
        {
            string numeroEsquerda = ObterNumeroEsquerda(numeroRomano);

            string numeroDireita = ObterNumeroDireita(numeroRomano, numeroEsquerda);

            return numeros[numeroEsquerda] + numeros[numeroDireita];
        }

        private static string ObterNumeroDireita(string numeroRomano, string numeroEsquerda)
        {
            return numeroRomano.Substring(numeroEsquerda.Length);
        }

        private static string ObterNumeroEsquerda(string numeroRomano)
        {
            return numeroRomano
                            .Replace("IX", "")
                            .Replace("VIII", "")
                            .Replace("VII", "")
                            .Replace("VI", "")
                            .Replace("IV", "")
                            .Replace("V", "")
                            .Replace("III", "")
                            .Replace("II", "")
                            .Replace("I", "");
        }

        private void ConfigurarDezenasRomanas(string[] dezenasRomanas)
        {
            for (int i = 0; i < dezenasRomanas.Length; i++)
            {
                numeros.Add(dezenasRomanas[i], (i + 1) * 10);
            }
        }

        private void ConfigurarUnidadesRomanas(string[] unidadesRomanas)
        {
            for (int i = 0; i < unidadesRomanas.Length; i++)
                numeros.Add(unidadesRomanas[i], i);
        }

        private void ConfigurarCentenasRomanas(string[] centenasRomanas, string[] dezenasRomanas)
        {
            for (int i = 0; i < centenasRomanas.Length; i++)
            {
                var valorCentena = (i + 1) * 100;

                numeros.Add(centenasRomanas[i], valorCentena);

                for (int j = 0; j < dezenasRomanas.Length; j++)
                {
                    var valorCentenaDezena = ((j + 1) * 10) + valorCentena;
                    numeros.Add(centenasRomanas[i] + dezenasRomanas[j], valorCentenaDezena);
                }
            }
        }
    }
}
