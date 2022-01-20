using NumerosPrimos.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace NumerosPrimos.Service.Implementacoes
{
    public class NumeroDivisor : INumeroDivisor
    {
        private const string MENSAGEM_ERRO_NUMERO_MENOR_IGUAL_ZERO = "Favor informar um número maior que 0.";

        public List<int> CalcularDivisores(int numero)
        {
            if (numero <= 0) throw new ArgumentException(MENSAGEM_ERRO_NUMERO_MENOR_IGUAL_ZERO, nameof(numero));

            var divisores = new List<int>();

            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0)
                    divisores.Add(i);
            }

            return divisores;
        }
    }
}
