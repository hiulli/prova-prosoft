using Newtonsoft.Json;

namespace NFeExternas.Core.Entidades
{
    public class NfeProc
    {
        [JsonProperty("@versao")]
        public string Versao { get; set; }

        [JsonProperty("@xmlns")]
        public string Xmlns { get; set; }
        public NFe NFe { get; set; }
    }
}
