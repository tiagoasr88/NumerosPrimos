using NumerosPrimos.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace NumerosPrimos.Service.Implementacoes
{
    public class NumeroDecompositor : INumeroDecompositor
    {
        private const string MENSAGEM_ERRO_NUMERO_MENOR_IGUAL_ZERO = "Favor informar um número maior que 0.";

        private INumeroDivisor _numeroDivisor;
        private INumeroPrimo _numeroPrimo;

        public NumeroDecompositor(INumeroDivisor numeroDivisor, INumeroPrimo numeroPrimo)
        {
            _numeroDivisor = numeroDivisor;
            _numeroPrimo = numeroPrimo;
        }

        public (List<int> divisores, List<int> divisoresPrimos) Decompor(int numero)
        {
            if (numero <= 0) throw new ArgumentException(MENSAGEM_ERRO_NUMERO_MENOR_IGUAL_ZERO, nameof(numero));

            var divisoresPrimos = new List<int>();
            var divisores = _numeroDivisor.CalcularDivisores(numero);

            foreach (var item in divisores)
            {
                if (_numeroPrimo.VerificarPrimo(item))
                    divisoresPrimos.Add(item);
            }

            return (divisores, divisoresPrimos);
        }
    }
}
