using Microsoft.AspNetCore.Mvc;
using NFeInternas.Core.Interfaces;
using NFeInternas.Core.Modelo;

namespace NFe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RelatorioController : ControllerBase
    {
        private readonly IServicoProdutoNFe _servicoProdutoNFe;
        public RelatorioController(IServicoProdutoNFe servicoProdutoNFe)
        {
            _servicoProdutoNFe = servicoProdutoNFe;
        }

        [HttpGet("valorproduto-valorimposto-por-marca/{mes}")]
        public Resultado RelatorioValorImpostoValorProdutoPorMes(string mes) => _servicoProdutoNFe.RelatorioValorImpostoValorProdutoPorMes(mes);
    }
}
