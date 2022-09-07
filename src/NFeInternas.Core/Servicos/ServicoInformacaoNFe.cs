using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;

namespace NFeInternas.Core.Servicos
{
    public class ServicoInformacaoNFe: Servico<InformacaoNFe>, IServicoInformacaoNFe
    {
        public ServicoInformacaoNFe(IRepositorioInformacaoNFe repositorio) : base(repositorio)
        {   
        }
    }
}
