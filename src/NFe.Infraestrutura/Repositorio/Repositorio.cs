using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Options;
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;
using System.Data.SqlClient;

namespace NFe.Infraestrutura.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : EntidadeBase<T>
    {
        private readonly SqlConnection _connection;
        public Repositorio(IOptions<ConfiguracaoSqlServer> configuracaoSqlServer)
        {
            _connection = new SqlConnection(configuracaoSqlServer.Value.SQLConnection);
        }

        public void Adicionar(T entidade) => _connection.Insert(entidade);

        public void Alterar(T entidade) => _connection.Update(entidade);

        public T ObterPor(int id) => _connection.Get<T>(id);

        public IEnumerable<T> ObterTodos() => _connection.GetAll<T>();

        public void Remover(T entidade) => _connection.Delete(entidade);
    }
}
