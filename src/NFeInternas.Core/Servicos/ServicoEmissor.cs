using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;

namespace NFeInternas.Core.Servicos
{
    public class ServicoEmissor: Servico<Emissor>, IServicoEmissor
    {
        public ServicoEmissor(IRepositorioEmissor repositorio) : base(repositorio)
        {   
        }
    }
}
