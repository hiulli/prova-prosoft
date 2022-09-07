using Dapper.Contrib.Extensions;

namespace NFeInternas.Core.Entidades
{
    [Table("[Endereco]")]
    public class Endereco : EntidadeBase<Endereco>
    {
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? CodigoMunicipio { get; set; }
        public string? Municipio { get; set; }
        public string? UF { get; set; }
        public string? CEP { get; set; }
        public string? CodigoPais { get; set; }
        public string? Pais { get; set; }
        public string? Complemento { get; set; }
        public string? Telefone { get; set; }
    }
}
