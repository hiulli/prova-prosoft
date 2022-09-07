namespace NFeInternas.Core.Modelo
{
    public class ResultadoDetalheLogNFeProcessada
    {
        public int Id { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public int IdNotaInicial { get; set; }
        public int IdNotaFinal { get; set; }
        public int QuantidadeDeNotasProcessadas { get; set; }
        public int QuantidadeDeNotasAlteradas { get; set; }
    }
}
