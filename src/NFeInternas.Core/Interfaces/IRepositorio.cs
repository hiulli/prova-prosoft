using NFeInternas.Core.Entidades;

namespace NFeInternas.Core.Interfaces
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        void Adicionar(T entidade);

        void Remover(T entidade);        

        void Alterar(T entidade);

        T ObterPor(int id);

        IEnumerable<T> ObterTodos();
    }
}
