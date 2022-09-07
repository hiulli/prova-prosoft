using NFeInternas.Core.Entidades;
using NFeInternas.Core.Modelo;

namespace NFeInternas.Core.Interfaces
{
    public interface IRepositorioLogNFeProcessada : IRepositorio<LogNFeProcessada>
    {
        LogNFeProcessada ObtemUltimoOuNulo();

        IEnumerable<ResultadoDetalheLogNFeProcessada> ObterDetalheImportacaoTodos();

        ResultadoDetalheLogNFeProcessada ObterDetalheImportacaoPorId(int id);
    }
}
