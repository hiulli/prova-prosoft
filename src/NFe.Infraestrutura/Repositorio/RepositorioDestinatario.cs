using Microsoft.Extensions.Options;
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;

namespace NFe.Infraestrutura.Repositorio
{
    public class RepositorioDestinatario : Repositorio<Destinatario>, IRepositorioDestinatario
    {
        public RepositorioDestinatario(IOptions<ConfiguracaoSqlServer> configuracaoSqlServer) : base(configuracaoSqlServer)
        {
        }
    }
}
