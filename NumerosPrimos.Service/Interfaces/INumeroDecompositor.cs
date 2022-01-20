using System.Collections.Generic;

namespace NumerosPrimos.Service.Interfaces
{
    public interface INumeroDecompositor
    {
        (List<int> divisores, List<int> divisoresPrimos) Decompor(int numero);
    }
}
