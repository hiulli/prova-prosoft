using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;

namespace NFeInternas.Core.Servicos
{
    public class ServicoLogAlteracaoNfeProcessada : Servico<LogAlteracaoNFeProcessada>, IServicoLogAlteracaoNfeProcessada
    {
        private readonly IRepositorioLogAlteracaoNfeProcessada _repositorio;

        public ServicoLogAlteracaoNfeProcessada(IRepositorioLogAlteracaoNfeProcessada repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public void AdicionarVarios(List<LogAlteracaoNFeProcessada> listaLogAlteracoesNFeProcessada)
        {
            foreach (var logAlteracoesNFeProcessada in listaLogAlteracoesNFeProcessada)
            {
                _repositorio.Adicionar(logAlteracoesNFeProcessada);
            }
        }

        public Resultado ObtemAlteracoesPorIdNotaFiscal(int id)
        {
            return new Resultado(_repositorio.ObtemPorIdNotaFiscal(id), true);
        }

        public Resultado ObtemTodas()
        {
            return new Resultado(_repositorio.ObterTodos(), true);
        }
    }
}
