using Dapper.Contrib.Extensions;

namespace NFeInternas.Core.Entidades
{
    [Table("[InformacaoNFe]")]
    public class InformacaoNFe : EntidadeBase<InformacaoNFe>
    {
        public int IdNFeProcessada { get; set; }
        public string Versao { get; set; }
        public string IdOriginal { get; set; }

        [Write(false)]
        public Ide ide { get; set; }

        [Write(false)]
        public Emissor Emissor { get; set; }

        [Write(false)]
        public Destinatario Destinatario { get; set; }

        [Write(false)]
        public List<ProdutoNFe> Produtos { get; set; }
    }
}
