using NFeInternas.Core.Entidades;
using NFeInternas.Core.Modelo;

namespace NFeInternas.Core.Interfaces
{
    public interface IServicoProdutoNFe : IServico<ProdutoNFe>
    {
        void AdicionarProduto(ProdutoNFe produtoNFe, int idLogNFeProcessada);
        Resultado RelatorioValorImpostoValorProdutoPorMes(string mes);
    }
}
