using Newtonsoft.Json;

namespace NFeExternas.Core.Entidades
{

    public class Det
    {
        [JsonProperty("@nItem")]
        public int NItem { get; set; }
        public Prod prod { get; set; }
    }
}
