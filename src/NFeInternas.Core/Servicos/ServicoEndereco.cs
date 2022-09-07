using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;

namespace NFeInternas.Core.Servicos
{
    public class ServicoEndereco: Servico<Endereco>, IServicoEndereco
    {
        public ServicoEndereco(IRepositorioEndereco repositorio) : base(repositorio)
        {   
        }
    }
}
