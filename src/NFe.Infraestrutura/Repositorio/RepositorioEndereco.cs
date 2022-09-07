using Microsoft.Extensions.Options;
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;

namespace NFe.Infraestrutura.Repositorio
{
    public class RepositorioEndereco : Repositorio<Endereco>, IRepositorioEndereco
    {
        public RepositorioEndereco(IOptions<ConfiguracaoSqlServer> configuracaoSqlServer) : base(configuracaoSqlServer)
        {
        }
    }
}
