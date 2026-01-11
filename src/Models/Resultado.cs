using System.Text.Json.Serialization;

namespace TwIndex.Models
{
    public class Resultado
    {
        [JsonPropertyName("desempenho-anual-palavra")]
        public Dictionary<string, float> DesempenhoAnualPalavra { get; set; } = [];

        [JsonPropertyName("desempenho-mensal-palavra")]
        public Dictionary<string, Dictionary<string, float>> DesempenhoMensalPalavra { get; set; } = [];

        [JsonPropertyName("desempenho-mensal-conjunto")]
        public Dictionary<string, float> DesempenhoMensalConjunto { get; set; } = [];

        [JsonPropertyName("desempenho-anual-conjunto")]
        public float DesempenhoAnualConjunto { get; set; }
    }
}
