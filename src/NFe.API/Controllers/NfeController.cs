using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;

namespace NFe.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [Produces("application/json")]
    public class NfeController : ControllerBase
    {
        private readonly IServicoLogNFeProcessada _servicoLogNFeProcessada;
        private readonly IServicoLogAlteracaoNfeProcessada _servicoLogAlteracaoNfeProcessada;

        public NfeController(IServicoLogNFeProcessada servicoLogNFeProcessada,
            IServicoLogAlteracaoNfeProcessada servicoLogAlteracaoNfeProcessada)
        {
            _servicoLogNFeProcessada = servicoLogNFeProcessada;
            _servicoLogAlteracaoNfeProcessada = servicoLogAlteracaoNfeProcessada;
        }

        [HttpGet("log-processamento")]
        public Resultado ObtemTodosLog() => _servicoLogNFeProcessada.ObterDetalheImportacaoTodos();

        [HttpGet("{id}/log-processamento")]
        public Resultado ObtemDetalhe(int id) => _servicoLogNFeProcessada.ObterDetalheImportacaoPorId(id);

        [HttpGet("alteracao-pos-processamento")]
        public Resultado ObtemAlteracoes() => _servicoLogAlteracaoNfeProcessada.ObtemTodas();

        [HttpGet("{id}/alteracao-pos-processamento")]
        public Resultado ObtemAlteracoesPorIdNotaFiscal(int id) => _servicoLogAlteracaoNfeProcessada.ObtemAlteracoesPorIdNotaFiscal(id);
    }
}
