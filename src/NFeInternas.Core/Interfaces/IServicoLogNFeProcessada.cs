using NFeInternas.Core.Entidades;
using NFeInternas.Core.Modelo;

namespace NFeInternas.Core.Interfaces
{
    public interface IServicoLogNFeProcessada : IServico<LogNFeProcessada>
    {
        LogNFeProcessada ObtemUltimoOuNulo();

        Resultado ObterDetalheImportacaoTodos();

        void Alterar(LogNFeProcessada logNFeProcessada);

        Resultado ObterDetalheImportacaoPorId(int id);
    }
}
