using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;

namespace NFeInternas.Core.Servicos
{
    public class ServicoLogNFeProcessada : Servico<LogNFeProcessada>, IServicoLogNFeProcessada
    {
        readonly IRepositorioLogNFeProcessada _repositorio;

        public ServicoLogNFeProcessada(IRepositorioLogNFeProcessada repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public void Alterar(LogNFeProcessada logNFeProcessada)
        {
            _repositorio.Alterar(logNFeProcessada);
        }

        public LogNFeProcessada ObtemUltimoOuNulo()
        {
            return _repositorio.ObtemUltimoOuNulo();
        }

        public Resultado ObterDetalheImportacaoPorId(int id)
        {
            return new Resultado(_repositorio.ObterDetalheImportacaoPorId(id), true);
        }

        public Resultado ObterDetalheImportacaoTodos()
        {
            return new Resultado(_repositorio.ObterDetalheImportacaoTodos(), true);
        }
    }
}
