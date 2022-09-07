using System.ComponentModel.DataAnnotations.Schema;

namespace NFeInternas.Core.Entidades
{
    [Table("[LogAlteracaoNFeProcessada]")]
    public class LogAlteracaoNFeProcessada : EntidadeBase<LogAlteracaoNFeProcessada>
    {
        public int IdLogNFeProcessada { get; set; }
        public int IdNFeProcessada { get; set; }
        public string Campo { get; set; }
        public string? ValorNovo { get; set; }
        public string? ValorAntigo { get; set; }
    }
}
