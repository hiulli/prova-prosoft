using Microsoft.Extensions.Options;
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;

namespace NFe.Infraestrutura.Repositorio
{
    public class RepositorioNFeProcessada : Repositorio<NFeProcessada>, IRepositorioNFeProcessada
    {
        public RepositorioNFeProcessada(IOptions<ConfiguracaoSqlServer> configuracaoSqlServer) : base(configuracaoSqlServer)
        {
        }
    }
}
