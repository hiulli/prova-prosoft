using Dapper.Contrib.Extensions;

namespace NFeInternas.Core.Entidades
{
    [Table("[Emissor]")]
    public class Emissor : EntidadeBase<Emissor>
    {
        public int IdNFeProcessada { get; set; }
        public int IdEndereco { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }

        [Write(false)]
        public Endereco Endereco { get; set; }
        public string IE { get; set; }
        public string CRT { get; set; }
    }
}
