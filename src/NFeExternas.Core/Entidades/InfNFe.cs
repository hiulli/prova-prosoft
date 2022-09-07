using Newtonsoft.Json;

namespace NFeExternas.Core.Entidades
{
    public class InfNFe
    {
        [JsonProperty("@Id")]
        public string Id { get; set; }

        [JsonProperty("@versao")]
        public string Versao { get; set; }
        public Ide ide { get; set; }
        public Emit emit { get; set; }
        public Dest dest { get; set; }
        public List<Det> det { get; set; }
    }
}
