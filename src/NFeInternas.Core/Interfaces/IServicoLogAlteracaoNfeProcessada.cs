using NFeInternas.Core.Entidades;
using NFeInternas.Core.Modelo;

namespace NFeInternas.Core.Interfaces
{
    public interface IServicoLogAlteracaoNfeProcessada : IServico<LogAlteracaoNFeProcessada>
    {
        void AdicionarVarios(List<LogAlteracaoNFeProcessada> listaLogAlteracoesNFeProcessada);

        Resultado ObtemAlteracoesPorIdNotaFiscal(int id);

        Resultado ObtemTodas();
    }
}
