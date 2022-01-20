using NumerosPrimos.Service.Implementacoes;
using System;
using Xunit;

namespace NumerosPrimos.Test.Service
{
    public class NumerosDivisoresTests
    {
        [Fact]
        public void DeveRetornar3ItensQuandoReceber4()
        {
            //arrange
            const int NUMERO = 4;
            var service = new NumeroDivisor();

            //act
            var resultado = service.CalcularDivisores(NUMERO);

            //assert
            Assert.Equal(3, resultado.Count);
        }

        [Fact]
        public void DeveRetornarValores124QuandoReceber4()
        {
            //arrange
            const int NUMERO = 4;
            var service = new NumeroDivisor();

            //act
            var resultado = service.CalcularDivisores(NUMERO);

            //assert
            Assert.Collection(resultado,
                              item => Assert.Equal(1, item),
                              item => Assert.Equal(2, item),
                              item => Assert.Equal(4, item));
        }

        [Fact]
        public void DeveRetornarErroQuandoNumeroForNegativo()
        {
            //arrange
            const int NUMERO = -12;
            var service = new NumeroDivisor();

            //act + assert
            Assert.Throws<ArgumentException>(() => service.CalcularDivisores(NUMERO));

        }

        [Fact]
        public void DeveRetornarMensagemQuandoNumeroForNegativo()
        {
            //arrange
            const string MENSAGEM = "Favor informar um número maior que 0. (Parameter 'numero')";
            const int NUMERO = -12;
            var service = new NumeroDivisor();

            //act
            var ex = Assert.Throws<ArgumentException>(() => service.CalcularDivisores(NUMERO));

            //assert
            Assert.Equal(MENSAGEM, ex.Message);

        }

    }
}
