using NFeInternas.Core.Entidades;

namespace NFeInternas.Core.Interfaces
{
    public interface IServico<TEntity> where TEntity : EntidadeBase<TEntity>
    {
        void Adicionar(TEntity entity);
    }
}
