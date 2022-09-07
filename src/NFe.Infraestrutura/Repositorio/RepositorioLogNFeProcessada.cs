using Dapper;
using Microsoft.Extensions.Options;
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;
using System.Data.SqlClient;

namespace NFe.Infraestrutura.Repositorio
{
    public class RepositorioLogNFeProcessada : Repositorio<LogNFeProcessada>, IRepositorioLogNFeProcessada
    {
        private readonly SqlConnection _connection;
        public RepositorioLogNFeProcessada(IOptions<ConfiguracaoSqlServer> configuracaoSqlServer) : base(configuracaoSqlServer)
        {
            _connection = new SqlConnection(configuracaoSqlServer.Value.SQLConnection);
        }

        public LogNFeProcessada ObtemUltimoOuNulo()
        {
            var query = @"Select Top(1) 
                                 Id
                                ,DataHoraInicio	
                                ,DataHoraFim
                                ,IdNotaInicial
                                ,IdNotaFinal 
                            From [LogNFeProcessada]
                           Order By Id Desc ";
            
            return _connection.QueryFirstOrDefault<LogNFeProcessada>(query);            
        }

        public ResultadoDetalheLogNFeProcessada ObterDetalheImportacaoPorId(int id)
        {
            var query = @"Select [LogNFeProcessada].[Id]
                                ,[LogNFeProcessada].[DataHoraInicio]
                                ,[LogNFeProcessada].[DataHoraFim]
                                ,[LogNFeProcessada].[IdNotaInicial]
                                ,[LogNFeProcessada].[IdNotaFinal]
                          	  ,[NotasAlteradas].[QuantidadeDeNotasAlteradas]
                            From [LogNFeProcessada]  
                            Left Join (Select Count(Distinct([LogAlteracaoNFeProcessada].[IdNFeProcessada])) As [QuantidadeDeNotasAlteradas]
                          		 		     ,[LogAlteracaoNFeProcessada].[IdLogNFeProcessada] 
                                         From [LogAlteracaoNFeProcessada]
                                     Group By [LogAlteracaoNFeProcessada].[IdLogNFeProcessada]) As [NotasAlteradas]
                                   On [NotasAlteradas].[IdLogNFeProcessada] = [LogNFeProcessada].[Id] 
                           Inner Join (Select COUNT(1) As QuantidadeDeNotasProcessadas
                                             ,[NFeProcessada].[IdLogNFeProcessada]
                                         From [NFeProcessada]
                                        Group by [NFeProcessada].[IdLogNFeProcessada]) As [NotasProcessadas]
                                    On [NotasProcessadas].[IdLogNFeProcessada] = [LogNFeProcessada].[Id]
                              Where [LogNFeProcessada].[Id] = @id";

            return _connection.QuerySingle<ResultadoDetalheLogNFeProcessada>(query, new { id });
        }

        public IEnumerable<ResultadoDetalheLogNFeProcessada> ObterDetalheImportacaoTodos()
        {
            var query = @"Select [LogNFeProcessada].[Id]
                                ,[LogNFeProcessada].[DataHoraInicio]
                                ,[LogNFeProcessada].[DataHoraFim]
                                ,[LogNFeProcessada].[IdNotaInicial]
                                ,[LogNFeProcessada].[IdNotaFinal]
                          	    ,[NotasAlteradas].[QuantidadeDeNotasAlteradas]
                                ,[NotasProcessadas].[QuantidadeDeNotasProcessadas]
                            From [LogNFeProcessada]  
                            Left Join (Select Count(Distinct([LogAlteracaoNFeProcessada].[IdNFeProcessada])) As [QuantidadeDeNotasAlteradas]
                          		 		     ,[LogAlteracaoNFeProcessada].[IdLogNFeProcessada] 
                                         From [LogAlteracaoNFeProcessada]
                                     Group By [LogAlteracaoNFeProcessada].[IdLogNFeProcessada]) As [NotasAlteradas]
                                   On [NotasAlteradas].[IdLogNFeProcessada] = [LogNFeProcessada].[Id] 
                           Inner Join (Select COUNT(1) As QuantidadeDeNotasProcessadas
                                             ,[NFeProcessada].[IdLogNFeProcessada]
                                         From [NFeProcessada]
                                        Group by [NFeProcessada].[IdLogNFeProcessada]) As [NotasProcessadas]
                                    On [NotasProcessadas].[IdLogNFeProcessada] = [LogNFeProcessada].[Id] ";

            return _connection.Query<ResultadoDetalheLogNFeProcessada>(query);
        }
    }
}
