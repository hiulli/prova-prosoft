using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;

namespace NFeInternas.Core.Servicos
{
    public class ServicoNFeProcessada : Servico<NFeProcessada>, IServicoNFeProcessada
    {
        public ServicoNFeProcessada(IRepositorioNFeProcessada repositorio) : base(repositorio)
        {   
        }
    }
}
