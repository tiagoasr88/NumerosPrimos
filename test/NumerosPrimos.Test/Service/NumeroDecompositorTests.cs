using Moq;
using NumerosPrimos.Service.Implementacoes;
using NumerosPrimos.Service.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace NumerosPrimos.Test.Service
{
    public class NumeroDecompositorTests
    {
        [Fact]
        public void DeveRetornar3DivisoresE2DivisoresPrimosQuandoReceber4()
        {
            //arrange
            const int NUMERO = 4;
            Mock<INumeroDivisor> moqDivisor = PrepararMoqDivisor(NUMERO);
            Mock<INumeroPrimo> moqPrimo = PrepararMoqPrimo();

            var service = new NumeroDecompositor(moqDivisor.Object, moqPrimo.Object);

            //act
            var resultado = service.Decompor(NUMERO);

            //assert
            Assert.Equal(3, resultado.divisores.Count);
            Assert.Equal(2, resultado.divisoresPrimos.Count);
        }

        [Fact]
        public void DeveRetornarDivisores12E4QuandoReceber4()
        {
            //arrange
            const int NUMERO = 4;
            Mock<INumeroDivisor> moqDivisor = PrepararMoqDivisor(NUMERO);
            Mock<INumeroPrimo> moqPrimo = PrepararMoqPrimo();

            var service = new NumeroDecompositor(moqDivisor.Object, moqPrimo.Object);

            //act
            var resultado = service.Decompor(NUMERO);

            //assert
            Assert.Collection(resultado.divisores,
                              item => Assert.Equal(1, item),
                              item => Assert.Equal(2, item),
                              item => Assert.Equal(4, item));
        }

        [Fact]
        public void DeveRetornarDivisoresPrimos1E2QuandoReceber4()
        {
            //arrange
            const int NUMERO = 4;
            Mock<INumeroDivisor> moqDivisor = PrepararMoqDivisor(NUMERO);
            Mock<INumeroPrimo> moqPrimo = PrepararMoqPrimo();

            var service = new NumeroDecompositor(moqDivisor.Object, moqPrimo.Object);

            //act
            var resultado = service.Decompor(NUMERO);

            //assert
            Assert.Collection(resultado.divisoresPrimos,
                              item => Assert.Equal(1, item),
                              item => Assert.Equal(2, item));
        }

        private static Mock<INumeroPrimo> PrepararMoqPrimo()
        {
            var moqPrimo = new Mock<INumeroPrimo>();
            moqPrimo.Setup(p => p.VerificarPrimo(4)).Returns(false);
            moqPrimo.Setup(p => p.VerificarPrimo(2)).Returns(true);
            moqPrimo.Setup(p => p.VerificarPrimo(1)).Returns(true);
            return moqPrimo;
        }

        private static Mock<INumeroDivisor> PrepararMoqDivisor(int NUMERO)
        {
            var moqDivisor = new Mock<INumeroDivisor>();
            moqDivisor.Setup(p => p.CalcularDivisores(NUMERO)).Returns(new List<int>() { 1, 2, 4 });
            return moqDivisor;
        }
    }
}
