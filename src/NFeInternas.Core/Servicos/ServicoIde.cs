using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;

namespace NFeInternas.Core.Servicos
{
    public class ServicoIde: Servico<Ide>, IServicoIde
    {
        public ServicoIde(IRepositorioIde repositorio) : base(repositorio)
        {   
        }
    }
}
