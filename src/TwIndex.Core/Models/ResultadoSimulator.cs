namespace TwIndex.Core.Models;

public static class ResultadoSimulator
{
    public static Resultado CriarResultadoSimulado(IList<string> palavras)
    {
        var resultado = new Resultado
        {
            DesempenhoAnualConjunto = 67.5f,

            DesempenhoAnualPalavra = new Dictionary<string, float>
                {
                    { palavras[0], 82.3f },
                    { palavras.Count > 1 ? palavras[1] : "Palavra2", 65.8f },
                    { palavras.Count > 2 ? palavras[2] : "Palavra3", 55.4f },
                    { palavras.Count > 3 ? palavras[3] : "Palavra4", 48.9f },
                    { palavras.Count > 4 ? palavras[4] : "Palavra5", 42.1f }
                },

            DesempenhoMensalPalavra = new Dictionary<string, Dictionary<string, float>>
                {
                    { palavras[0], GerarDadosMensais(82.3f) },
                    { palavras.Count > 1 ? palavras[1] : "Palavra2", GerarDadosMensais(65.8f) },
                    { palavras.Count > 2 ? palavras[2] : "Palavra3", GerarDadosMensais(55.4f) },
                    { palavras.Count > 3 ? palavras[3] : "Palavra4", GerarDadosMensais(48.9f) },
                    { palavras.Count > 4 ? palavras[4] : "Palavra5", GerarDadosMensais(42.1f) }
                },

            DesempenhoMensalConjunto = GerarDadosMensais(67.5f)
        };

        // Remove palavras que não foram fornecidas
        var palavrasReais = palavras.ToList();
        var keysToRemove = resultado.DesempenhoAnualPalavra.Keys
            .Where(k => !palavrasReais.Contains(k))
            .ToList();

        foreach (var key in keysToRemove)
        {
            resultado.DesempenhoAnualPalavra.Remove(key);
            resultado.DesempenhoMensalPalavra.Remove(key);
        }

        return resultado;
    }

    public static Dictionary<string, float> GerarDadosMensais(float valorBase)
    {
        var random = new Random();
        var dados = new Dictionary<string, float>();
        var meses = new[] { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez" };

        foreach (var mes in meses)
        {
            // Gera variação de ±20% do valor base
            var variacao = (float)(random.NextDouble() * 40 - 20);
            var valor = Math.Max(0, valorBase + variacao);
            dados[mes] = valor;
        }

        return dados;
    }
}
