using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;

namespace NFeInternas.Core.Servicos
{
    public class ServicoProdutoNFe : Servico<ProdutoNFe>, IServicoProdutoNFe
    {
        IRepositorioProdutoNFe _repositorio;
        IServicoLogAlteracaoNfeProcessada _servicoLogAlteracaoNfeProcessada;

        private List<LogAlteracaoNFeProcessada> _alteracoes;

        public ServicoProdutoNFe(IRepositorioProdutoNFe repositorio,
            IServicoLogAlteracaoNfeProcessada servicoLogAlteracaoNfeProcessada) : base(repositorio)
        {
            _repositorio = repositorio;
            _servicoLogAlteracaoNfeProcessada = servicoLogAlteracaoNfeProcessada;
            _alteracoes = new List<LogAlteracaoNFeProcessada>();
        }

        public void AdicionarProduto(ProdutoNFe produtoNFe, int idLogNFeProcessada)
        {
            _alteracoes = new List<LogAlteracaoNFeProcessada>();

            CorrigirMarca(produtoNFe, idLogNFeProcessada);
            produtoNFe.Imposto = CalcularImposto(produtoNFe.Valor);
            AdicionarLog("Imposto", null, produtoNFe.Imposto.ToString(), idLogNFeProcessada, produtoNFe.IdNFeProcessada);

            _repositorio.Adicionar(produtoNFe);
            _servicoLogAlteracaoNfeProcessada.AdicionarVarios(_alteracoes);
        }

        private void AdicionarLog(string campo, string? valorAntigo, string? valorNovo, int idLogNFeProcessada, int idNFeProcessada)
        {
            _alteracoes.Add(new LogAlteracaoNFeProcessada
            {
                Campo = campo,
                ValorAntigo = valorAntigo,
                ValorNovo = valorNovo,
                IdLogNFeProcessada = idLogNFeProcessada,
                IdNFeProcessada = idNFeProcessada,
            });
        }

        private void CorrigirMarca(ProdutoNFe produtoNFe, int idLogNFeProcessada)
        {
            var marcaNova = produtoNFe.Desricao.Split(' ')[0];
            var marcaAntiga = produtoNFe.Marca;

            produtoNFe.Marca = marcaNova;

            AdicionarLog("Marca", marcaAntiga, produtoNFe.Marca, idLogNFeProcessada, produtoNFe.IdNFeProcessada);
        }

        private decimal CalcularImposto(decimal valor)
        {
            return valor * (0.15M);
        }

        public Resultado RelatorioValorImpostoValorProdutoPorMes(string mes)
        {
            return new Resultado(_repositorio.RelatorioValorImpostoValorProdutoPorMes(mes), true);
        }
    }
}
