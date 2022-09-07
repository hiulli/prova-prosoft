using Microsoft.Extensions.Options;
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;

namespace NFe.Infraestrutura.Repositorio
{
    public class RepositorioInformacaoNFe : Repositorio<InformacaoNFe>, IRepositorioInformacaoNFe
    {
        public RepositorioInformacaoNFe(IOptions<ConfiguracaoSqlServer> configuracaoSqlServer) : base(configuracaoSqlServer)
        {
        }
    }
}
