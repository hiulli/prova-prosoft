using NFeInternas.Core.Entidades;
using NFeInternas.Core.Modelo;

namespace NFeInternas.Core.Interfaces
{
    public interface IRepositorioProdutoNFe : IRepositorio<ProdutoNFe>
    {
        IEnumerable<ResultadoRelatorioValorImpostoValorProdutoPorMes> RelatorioValorImpostoValorProdutoPorMes(string mes);
    }
}
