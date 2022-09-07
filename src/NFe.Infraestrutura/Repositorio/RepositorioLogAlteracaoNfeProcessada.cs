using Dapper;
using Microsoft.Extensions.Options;
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;
using System.Data.SqlClient;

namespace NFe.Infraestrutura.Repositorio
{
    public class RepositorioLogAlteracaoNFeProcessada : Repositorio<LogAlteracaoNFeProcessada>, IRepositorioLogAlteracaoNfeProcessada
    {
        private readonly SqlConnection _connection;

        public RepositorioLogAlteracaoNFeProcessada(IOptions<ConfiguracaoSqlServer> configuracaoSqlServer) : base(configuracaoSqlServer)
        {
            _connection = new SqlConnection(configuracaoSqlServer.Value.SQLConnection);
        }

        public IEnumerable<LogAlteracaoNFeProcessada> ObtemPorIdNotaFiscal(int id)
        {
            var query = @"Select [Id]
                                ,[IdNFeProcessada]
                                ,[IdLogNFeProcessada]
                                ,[Campo]
                                ,[ValorAntigo]
                                ,[ValorNovo]
                            From [LogAlteracaoNFeProcessada]
                           Where [IdNFeProcessada] = @id";

            return _connection.Query<LogAlteracaoNFeProcessada>(query, new { id });
        }
    }
}
