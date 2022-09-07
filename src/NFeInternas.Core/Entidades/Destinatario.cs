using Dapper.Contrib.Extensions;

namespace NFeInternas.Core.Entidades
{
    [Table("[Destinatario]")]
    public class Destinatario : EntidadeBase<Destinatario>
    {
        public int IdNFeProcessada { get; set; }
        public int IdEndereco { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        [Write(false)]
        public Endereco Endereco { get; set; }
        public string indIEDest { get; set; }
    }
}
