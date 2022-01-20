using Microsoft.Extensions.DependencyInjection;
using NumerosPrimos.Service.Implementacoes;
using NumerosPrimos.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace NumerosPrimos.Application
{
    internal class Program
    {
        private const string MENSAGEM_ENCERRAMENTO = "Encerrando o programa.";
        private const string MENSAGEM_DIGITE_NUMERO = "Digite um número: ";
        private const string MENSAGEM_ERRO_NUMERO_INFORMADO = "Problemas com o número informado. Por favor informe um número entre 1 e 2147483646.";
        private const string MENSAGEM_NUMERO_ENTRADA = "Número de Entrada:";
        private const string MENSAGEM_NUMEROS_DIVISORES = "Números divisores:";
        private const string MENSAGEM_NUMEROS_PRIMOS = "Números primos:";

        static void Main(string[] args)
        {
            try
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);

                var serviceProvider = serviceCollection.BuildServiceProvider();
                var numeroDecompositor = serviceProvider.GetService<INumeroDecompositor>();

                DecomporNumero(numeroDecompositor);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            EncerrarPrograma();
        }

        private static void EncerrarPrograma()
        {
            Console.WriteLine();
            Console.WriteLine(MENSAGEM_ENCERRAMENTO);
        }

        private static void DecomporNumero(INumeroDecompositor numeroDecompositor)
        {
            Console.Write(MENSAGEM_DIGITE_NUMERO);

            if (!int.TryParse(Console.ReadLine(), out var numero)) throw new ArgumentException(MENSAGEM_ERRO_NUMERO_INFORMADO);

            var resultado = numeroDecompositor.Decompor(numero);

            ExibirResultado(numero, resultado);
        }

        private static void ExibirResultado(int numero, (List<int> divisores, List<int> divisoresPrimos) resultado)
        {
            Console.WriteLine(MENSAGEM_NUMERO_ENTRADA + $" {numero}");

            Console.Write(MENSAGEM_NUMEROS_DIVISORES);

            foreach (var item in resultado.divisores)
            {
                Console.Write($" {item}");
            }

            Console.WriteLine();

            Console.Write(MENSAGEM_NUMEROS_PRIMOS);
            foreach (var item in resultado.divisoresPrimos)
            {
                Console.Write($" {item}");
            }
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INumeroDecompositor, NumeroDecompositor>();
            services.AddScoped<INumeroDivisor, NumeroDivisor>();
            services.AddScoped<INumeroPrimo, NumeroPrimo>();
        }
    }
}