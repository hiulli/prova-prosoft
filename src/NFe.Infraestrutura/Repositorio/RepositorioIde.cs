using Microsoft.Extensions.Options;
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;

namespace NFe.Infraestrutura.Repositorio
{
    public class RepositorioIde : Repositorio<Ide>, IRepositorioIde
    {
        public RepositorioIde(IOptions<ConfiguracaoSqlServer> configuracaoSqlServer) : base(configuracaoSqlServer)
        {
        }
    }
}
