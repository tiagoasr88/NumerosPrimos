using System.Collections.Generic;

namespace NumerosPrimos.Service.Interfaces
{
    public interface INumeroDivisor
    {
        List<int> CalcularDivisores(int numero);
    }
}
