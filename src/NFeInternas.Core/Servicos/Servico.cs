
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;

namespace NFeInternas.Core.Servicos
{
    public class Servico<TEntity> : IServico<TEntity> where TEntity : EntidadeBase<TEntity>
    {
        readonly IRepositorio<TEntity> _repositorio;

        public Servico(IRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(TEntity entity)
        {
            _repositorio.Adicionar(entity);
        }        
    }
}
