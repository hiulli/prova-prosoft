using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using NFeExternas.Core.Entidades;
using NFeExternas.Core.Interface;
using NFeInternas.Core.Entidades;
using NFeInternas.Core.Interfaces;
using System;
using System.Linq;

namespace Function.LoadInvoces
{
    public class LoadInvoces
    {
        private readonly IServicoNFeExterna _servicoNFeExterna;
        private readonly IServicoLogNFeProcessada _servicoLogNFeProcessada;
        private readonly IServicoNFeProcessada _servicoNFeProcessada;
        private readonly IServicoInformacaoNFe _servicoInformacaoNFe;
        private readonly IServicoIde _servicoIde;
        private readonly IServicoEmissor _servicoEmissor;
        private readonly IServicoEndereco _servicoEndereco;
        private readonly IServicoDestinatario _servicoDestintario;
        private readonly IServicoProdutoNFe _servicoProdutoNFe;

        public LoadInvoces(IServicoNFeExterna servicoNFeExterna,
            IServicoLogNFeProcessada servicoLogNFeProcessada,
            IServicoNFeProcessada servicoNFeProcessada,
            IServicoInformacaoNFe servicoInformacaoNFe,
            IServicoIde servicoIde,
            IServicoEmissor servicoEmissor,
            IServicoEndereco servicoEndereco,
            IServicoDestinatario servicoDestintario,
            IServicoProdutoNFe servicoProdutoNFe)
        {
            _servicoNFeExterna = servicoNFeExterna;
            _servicoLogNFeProcessada = servicoLogNFeProcessada;
            _servicoNFeProcessada = servicoNFeProcessada;
            _servicoInformacaoNFe = servicoInformacaoNFe;
            _servicoIde = servicoIde;
            _servicoEmissor = servicoEmissor;
            _servicoEndereco = servicoEndereco;
            _servicoDestintario = servicoDestintario;
            _servicoProdutoNFe = servicoProdutoNFe;
        }

        [FunctionName("functionnfe")]
        public void Run([TimerTrigger("0 */10 * * * *")] TimerInfo myTimer, ILogger log)
        {
            Processar();
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }

        private void Processar()
        {
            var ultimoLogNFeProcessada = _servicoLogNFeProcessada.ObtemUltimoOuNulo();

            if (ultimoLogNFeProcessada == null)
            {
                ultimoLogNFeProcessada = new LogNFeProcessada();
            }

            _servicoNFeExterna.ObterNotasServicoExterno(ultimoLogNFeProcessada.IdNotaFinal);

            var listaDadoNFeExterna = _servicoNFeExterna.ObterNotasMaioresQueId(ultimoLogNFeProcessada.IdNotaFinal);

            if (listaDadoNFeExterna.Any())
            {
                var novoLog = new LogNFeProcessada
                {
                    DataHoraInicio = DateTime.Now,
                    IdNotaInicial = listaDadoNFeExterna.First().id,
                    IdNotaFinal = listaDadoNFeExterna.Last().id,
                };

                _servicoLogNFeProcessada.Adicionar(novoLog);

                foreach (var DadoNFeExterna in listaDadoNFeExterna)
                {
                    var idNFeProcessada = CriarNovaNFeProcessada(DadoNFeExterna, novoLog.Id);
                    CriarNovaInformacaoNFe(DadoNFeExterna.nfeProc.NFe.infNFe, idNFeProcessada);
                    CriarNovaIde(DadoNFeExterna, idNFeProcessada);
                    CriarNovoEmissor(DadoNFeExterna, idNFeProcessada);
                    CriarNovoDestinatario(DadoNFeExterna, idNFeProcessada);
                    CriarNovoProdutoNFe(DadoNFeExterna, idNFeProcessada, novoLog.Id);
                }

                novoLog.DataHoraFim = DateTime.Now;

                _servicoLogNFeProcessada.Alterar(novoLog);
            }
        }

        private int CriarNovaNFeProcessada(DadoNFeExterna dadoNFeExterna, int idLogNFeProcessada)
        {
            try
            {
                var novaNFeProcessada = new NFeProcessada
                {
                    IdOriginal = dadoNFeExterna.id,
                    Versao = dadoNFeExterna.nfeProc.Versao,
                    Xmlns = dadoNFeExterna.nfeProc.Xmlns,
                    IdLogNFeProcessada = idLogNFeProcessada
                };

                _servicoNFeProcessada.Adicionar(novaNFeProcessada);

                return novaNFeProcessada.Id;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void CriarNovaInformacaoNFe(InfNFe infNFe, int idNFeProcessada)
        {
            _servicoInformacaoNFe.Adicionar(new InformacaoNFe
            {
                IdNFeProcessada = idNFeProcessada,
                IdOriginal = infNFe.Id,
                Versao = infNFe.Versao,
            });
        }

        private void CriarNovaIde(DadoNFeExterna dadoNFeExterna, int idNFeProcessada)
        {
            _servicoIde.Adicionar(new NFeInternas.Core.Entidades.Ide
            {
                IdNFeProcessada = idNFeProcessada,
                cUF = dadoNFeExterna.nfeProc.NFe.infNFe.ide.cNF,
                cNF = dadoNFeExterna.nfeProc.NFe.infNFe.ide.cNF,
                natOp = dadoNFeExterna.nfeProc.NFe.infNFe.ide.natOp,
                mod = dadoNFeExterna.nfeProc.NFe.infNFe.ide.mod,
                serie = dadoNFeExterna.nfeProc.NFe.infNFe.ide.serie,
                nNF = dadoNFeExterna.nfeProc.NFe.infNFe.ide.nNF,
                dhEmi = dadoNFeExterna.nfeProc.NFe.infNFe.ide.dhEmi,
                tpNF = dadoNFeExterna.nfeProc.NFe.infNFe.ide.tpNF,
                idDest = dadoNFeExterna.nfeProc.NFe.infNFe.ide.idDest,
                cMunFG = dadoNFeExterna.nfeProc.NFe.infNFe.ide.cMunFG,
                tpImp = dadoNFeExterna.nfeProc.NFe.infNFe.ide.tpImp,
                tpEmis = dadoNFeExterna.nfeProc.NFe.infNFe.ide.tpEmis,
                cDV = dadoNFeExterna.nfeProc.NFe.infNFe.ide.cDV,
                tpAmb = dadoNFeExterna.nfeProc.NFe.infNFe.ide.tpAmb,
                finNFe = dadoNFeExterna.nfeProc.NFe.infNFe.ide.finNFe,
                indFinal = dadoNFeExterna.nfeProc.NFe.infNFe.ide.indFinal,
                indPres = dadoNFeExterna.nfeProc.NFe.infNFe.ide.indPres,
                procEmi = dadoNFeExterna.nfeProc.NFe.infNFe.ide.procEmi,
                verProc = dadoNFeExterna.nfeProc.NFe.infNFe.ide.verProc,
                dhSaiEnt = dadoNFeExterna.nfeProc.NFe.infNFe.ide.dhSaiEnt,
            });
        }

        private void CriarNovoEmissor(DadoNFeExterna dadoNFeExterna, int idNFeProcessada)
        {  
            var idEndereco = CriarNovoEndereco(dadoNFeExterna.nfeProc.NFe.infNFe.emit.enderEmit);

            _servicoEmissor.Adicionar(new Emissor
            {
                CNPJ = dadoNFeExterna.nfeProc.NFe.infNFe.emit.CNPJ,
                Nome = dadoNFeExterna.nfeProc.NFe.infNFe.emit.xNome,
                Fantasia = dadoNFeExterna.nfeProc.NFe.infNFe.emit.xFant,
                IE = dadoNFeExterna.nfeProc.NFe.infNFe.emit.IE,
                CRT = dadoNFeExterna.nfeProc.NFe.infNFe.emit.CRT,
                IdEndereco = idEndereco,
                IdNFeProcessada = idNFeProcessada
            });
        }

        private void CriarNovoDestinatario(DadoNFeExterna dadoNFeExterna, int idNFeProcessada)
        {   
            var idEndereco = CriarNovoEndereco(dadoNFeExterna.nfeProc.NFe.infNFe.dest.enderDest);

            _servicoDestintario.Adicionar(new Destinatario
            {
                IdNFeProcessada = idNFeProcessada,
                CPF = dadoNFeExterna.nfeProc.NFe.infNFe.dest.CPF,
                IdEndereco = idEndereco,
                Nome = dadoNFeExterna.nfeProc.NFe.infNFe.dest.xNome,
                indIEDest = dadoNFeExterna.nfeProc.NFe.infNFe.dest.indIEDest,
            });
        }

        private void CriarNovoProdutoNFe(DadoNFeExterna dadoNFeExterna, int idNFeProcessada, int idLogNFeProcessada)
        {   
            foreach (var detalhe in dadoNFeExterna.nfeProc.NFe.infNFe.det)
            {
                _servicoProdutoNFe.AdicionarProduto(new ProdutoNFe
                {
                    IdNFeProcessada = idNFeProcessada,
                    Codigo = detalhe.prod.cProd,
                    cEAN = detalhe.prod.cEAN,
                    Desricao = detalhe.prod.xProd,
                    NCM = detalhe.prod.NCM,
                    CFOP = detalhe.prod.CFOP,
                    uCom = detalhe.prod.uCom,
                    qCom = detalhe.prod.qCom,
                    vUnCom = detalhe.prod.vUnCom,
                    Valor = detalhe.prod.vProd,
                    cEANTrib = detalhe.prod.cEANTrib,
                    uTrib = detalhe.prod.uTrib,
                    qTrib = detalhe.prod.qTrib,
                    vUnTrib = detalhe.prod.vUnTrib,
                    indTot = detalhe.prod.indTot,
                    Preco = Convert.ToDecimal(detalhe.prod.preco),
                    Marca = detalhe.prod.marca,
                    NumeroItem = detalhe.NItem
                }, idLogNFeProcessada);
            }
        }

        private int CriarNovoEndereco(EnderDest endereco)
        {
            var novoEndereco = new Endereco
            {
                Logradouro = endereco.xLgr,
                Numero = endereco.nro.ToString(),
                Bairro = endereco.xBairro,
                CodigoMunicipio = endereco.cMun,
                Municipio = endereco.xMun,
                UF = endereco.UF,
                CEP = endereco.CEP,
                CodigoPais = endereco.cPais,
                Pais = endereco.xPais,
                Complemento = endereco.xCpl,
                Telefone = endereco.fone,
            }
           ;
            _servicoEndereco.Adicionar(novoEndereco);

            return novoEndereco.Id;
        }

        private int CriarNovoEndereco(EnderEmit endereco)
        {
            var novoEndereco = new Endereco
            {
                Logradouro = endereco.xLgr,
                Numero = endereco.nro.ToString(),
                Bairro = endereco.xBairro,
                CodigoMunicipio = endereco.cMun,
                Municipio = endereco.xMun,
                UF = endereco.UF,
                CEP = endereco.CEP,
                CodigoPais = endereco.cPais,
                Pais = endereco.xPais,
            }
            ;
            _servicoEndereco.Adicionar(novoEndereco);

            return novoEndereco.Id;
        }
    }
}
