using NumerosPrimos.Service.Interfaces;
using System;

namespace NumerosPrimos.Service.Implementacoes
{
    public class NumeroPrimo : INumeroPrimo
    {
        private const string MENSAGEM_ERRO_NUMERO_MENOR_IGUAL_ZERO = "Favor informar um número maior que 0.";

        public bool VerificarPrimo(int numero)
        {
            if (numero <= 0) throw new ArgumentException(MENSAGEM_ERRO_NUMERO_MENOR_IGUAL_ZERO, nameof(numero));

            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0) return false;
            }

            return true;
        }
    }
}
