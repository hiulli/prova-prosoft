using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;

namespace NFeInternas.Core.Servicos
{
    public class ServicoDestinatario: Servico<Destinatario>, IServicoDestinatario
    {
        public ServicoDestinatario(IRepositorioDestinatario repositorio) : base(repositorio)
        { 
            
        }
    }
}
