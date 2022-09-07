using Dapper.Contrib.Extensions;

namespace NFeInternas.Core.Entidades
{
    [Table("[NFeProcessada]")]
    public class NFeProcessada : EntidadeBase<NFeProcessada>
    {
        public int IdLogNFeProcessada { get; set; }
        public int IdOriginal { get; set; }
        public string? Versao { get; set; }
        public string? Xmlns { get; set; }        

        [Write(false)]
        public InformacaoNFe? InformacoesNFe { get; set; }
    }
}
