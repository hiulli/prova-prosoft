using NFeInternas.Core.Entidades;

namespace NFeInternas.Core.Interfaces
{
    public interface IRepositorioLogAlteracaoNfeProcessada : IRepositorio<LogAlteracaoNFeProcessada>
    {
        IEnumerable<LogAlteracaoNFeProcessada> ObtemPorIdNotaFiscal(int id);
    }
}
