using NumerosPrimos.Service.Implementacoes;
using System;
using Xunit;

namespace NumerosPrimos.Test.Service
{
    public class NumeroPrimoTests
    {
        [Theory]
        [InlineData(5, true)]
        [InlineData(8, false)]
        public void DeveRetornarTrueQuandoNumeroForPrimo(int numero, bool resultadoEsperado)
        {
            //arrange
            var service = new NumeroPrimo();

            //act
            var resultadoObtido = service.VerificarPrimo(numero);

            //assert
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }

        [Fact]
        public void DeveRetornarErroQuandoNumeroForNegativo()
        {
            //arrange
            const int NUMERO = -12;
            var service = new NumeroPrimo();

            //act + assert
            Assert.Throws<ArgumentException>(() => service.VerificarPrimo(NUMERO));

        }

        [Fact]
        public void DeveRetornarMensagemQuandoNumeroForNegativo()
        {
            //arrange
            const string MENSAGEM = "Favor informar um número maior que 0. (Parameter 'numero')";
            const int NUMERO = -12;
            var service = new NumeroPrimo();

            //act
            var ex = Assert.Throws<ArgumentException>(() => service.VerificarPrimo(NUMERO));

            //assert
            Assert.Equal(MENSAGEM, ex.Message);

        }
    }
}
