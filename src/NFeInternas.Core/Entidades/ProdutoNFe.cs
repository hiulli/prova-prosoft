using Dapper.Contrib.Extensions;

namespace NFeInternas.Core.Entidades
{

    [Table("[ProdutoNFe]")]
    public class ProdutoNFe : EntidadeBase<ProdutoNFe>
    {
        public int IdNFeProcessada { get; set; }
        public int NumeroItem { get; set; }
        public string Codigo { get; set; }
        public string cEAN { get; set; }
        public string Desricao { get; set; }
        public int NCM { get; set; }
        public int CFOP { get; set; }
        public string uCom { get; set; }
        public int qCom { get; set; }
        public decimal vUnCom { get; set; }
        public decimal Valor { get; set; }
        public int cEANTrib { get; set; }
        public string uTrib { get; set; }
        public decimal qTrib { get; set; }
        public decimal vUnTrib { get; set; }
        public string indTot { get; set; }
        public decimal Preco { get; set; }
        public decimal Imposto { get; set; }
        public string Marca { get; set; }
    }
}