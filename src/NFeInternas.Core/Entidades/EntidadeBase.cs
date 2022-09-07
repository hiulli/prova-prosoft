namespace NFeInternas.Core.Entidades
{
    public abstract class EntidadeBase<TEntity>
    {
        public int Id { get; protected set; }
    }
}
