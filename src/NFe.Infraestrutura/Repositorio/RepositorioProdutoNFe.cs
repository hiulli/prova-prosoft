using Dapper;
using Microsoft.Extensions.Options;
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;
using System.Data.SqlClient;

namespace NFe.Infraestrutura.Repositorio
{
    public class RepositorioProdutoNFe : Repositorio<ProdutoNFe>, IRepositorioProdutoNFe
    {
        private readonly SqlConnection _connection;
        public RepositorioProdutoNFe(IOptions<ConfiguracaoSqlServer> configuracaoSqlServer) : base(configuracaoSqlServer)
        {
            _connection = new SqlConnection(configuracaoSqlServer.Value.SQLConnection);
        }

        public IEnumerable<ResultadoRelatorioValorImpostoValorProdutoPorMes> RelatorioValorImpostoValorProdutoPorMes(string mes)
        {
            var query = @"SET LANGUAGE Portuguese;
                       SELECT [ProdutoNFe].[Marca] 
                             ,Sum([ProdutoNFe].[Valor]) As Valor
                             ,DateName(Month, [Ide].[dhEmi]) As Mes
	                         ,Sum([ProdutoNFe].[Imposto]) As Imposto
                         FROM [ProdutoNFe]
                        Inner Join Ide On ProdutoNFe.IdNFeProcessada = Ide.IdNFeProcessada
                        Where MONTH([Ide].[dhEmi]) = @Mes
                        Group By [ProdutoNFe].[Marca]
                                ,DateName(Month, [Ide].[dhEmi])
                        Order by [Marca]";

            return _connection.Query<ResultadoRelatorioValorImpostoValorProdutoPorMes>(query, new {mes});
        }
    }
}
