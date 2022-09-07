using Dapper.Contrib.Extensions;

namespace NFeInternas.Core.Entidades
{
    [Table("[LogNFeProcessada]")]
    public class LogNFeProcessada : EntidadeBase<LogNFeProcessada>
    {
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public int IdNotaInicial { get; set; }
        public int IdNotaFinal { get; set; }

        [Write(false)]
        public List<LogAlteracaoNFeProcessada> LogsAlteracaoNfeProcessada { get; set; }
    }
}
