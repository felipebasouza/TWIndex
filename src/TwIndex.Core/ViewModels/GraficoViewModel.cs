using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.ObjectModel;
using TwIndex.Core.Models;

namespace TwIndex.Core.ViewModels;


public partial class GraficoViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    private string titulo = string.Empty;

    [ObservableProperty]
    private string subtitulo = string.Empty;

    private ObservableCollection<ISeries> _series = [];
    public ObservableCollection<ISeries> Series
    {
        get => _series;
        set => SetProperty(ref _series, value);
    }

    private ObservableCollection<Axis> _xAxes = [];
    public ObservableCollection<Axis> XAxes
    {
        get => _xAxes;
        set => SetProperty(ref _xAxes, value);
    }

    private Resultado? _resultado;
    private string? _palavraChave;


    // Implementação do IQueryAttributable para receber parâmetros via Shell Navigation
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Resultado", out object? value))
        {
            _resultado = value as Resultado;
        }

        if (query.TryGetValue("Palavra", out object? value1))
        {
            _palavraChave = value1 as string;
        }

        // Inicializa o gráfico com base nos parâmetros recebidos
        if (_resultado != null)
        {
            if (!string.IsNullOrEmpty(_palavraChave))
            {
                // Gráfico de palavra específica
                Titulo = _palavraChave;
                Subtitulo = "Desempenho da palavra-chave por mês ao longo do último ano";
                CriarGraficoPalavra(_palavraChave);
            }
            else
            {
                // Gráfico do conjunto
                Titulo = "Conjunto de todas as palavras-chave";
                Subtitulo = "Desempenho do conjunto por mês ao longo do último ano";
                CriarGraficoConjunto();
            }
        }
    }

    private void CriarGraficoConjunto()
    {
        if (_resultado?.DesempenhoMensalConjunto != null)
        {
            var dados = _resultado.DesempenhoMensalConjunto;
            CriarGrafico(dados);
        }
    }

    private void CriarGraficoPalavra(string palavra)
    {
        if (_resultado?.DesempenhoMensalPalavra != null &&
            _resultado.DesempenhoMensalPalavra.TryGetValue(palavra, out var dados))
        {
            CriarGrafico(dados);
        }
    }

    private void CriarGrafico(Dictionary<string, float> dados)
    {
        // Ordena os meses do último ano até o mês atual
        var mesesOrdenados = OrdenarMesesUltimoAno(dados);

        // Extrai valores e labels
        var valores = mesesOrdenados.Select(m => (double)dados[m]).ToArray();
        var labels = mesesOrdenados.ToArray();

        // Cria a série de linha
        Series =
        [
            new LineSeries<double>
            {
                Values = valores,
                Name = "ITW",
                Fill = null,
                Stroke = new SolidColorPaint(SKColors.Purple) { StrokeThickness = 4 },
                GeometrySize = 12,
                GeometryStroke = new SolidColorPaint(SKColors.Purple) { StrokeThickness = 4 },
                GeometryFill = new SolidColorPaint(SKColors.White),
                LineSmoothness = 0 // 0 = linha reta, 1 = linha suave
            }
        ];

        // Configura o eixo X com os labels dos meses
        XAxes =
        [
            new() {
                Labels = labels,
                LabelsRotation = 45,
                TextSize = 12,
                SeparatorsPaint = new SolidColorPaint(SKColors.LightGray) { StrokeThickness = 1 }
            }
        ];
    }

    private static List<string> OrdenarMesesUltimoAno(Dictionary<string, float> dados)
    {
        // Mapeamento de nomes completos para abreviações
        var mesesMap = new Dictionary<string, string>
        {
            { "Janeiro", "Jan" }, { "Jan", "Jan" },
            { "Fevereiro", "Fev" }, { "Fev", "Fev" },
            { "Março", "Mar" }, { "Mar", "Mar" },
            { "Abril", "Abr" }, { "Abr", "Abr" },
            { "Maio", "Mai" }, { "Mai", "Mai" },
            { "Junho", "Jun" }, { "Jun", "Jun" },
            { "Julho", "Jul" }, { "Jul", "Jul" },
            { "Agosto", "Ago" }, { "Ago", "Ago" },
            { "Setembro", "Set" }, { "Set", "Set" },
            { "Outubro", "Out" }, { "Out", "Out" },
            { "Novembro", "Nov" }, { "Nov", "Nov" },
            { "Dezembro", "Dez" }, { "Dez", "Dez" }
        };

        var mesAtual = DateTime.Now.Month;
        var ordemMeses = new List<string>();

        // Cria lista de meses do ano passado até agora
        for (int i = mesAtual + 1; i <= 12; i++)
            ordemMeses.Add(ObterNomeMes(i));

        for (int i = 1; i <= mesAtual; i++)
            ordemMeses.Add(ObterNomeMes(i));

        // Filtra apenas os meses que existem nos dados
        var mesesDisponiveis = dados.Keys.ToList();
        var resultado = new List<string>();

        foreach (var mes in ordemMeses)
        {
            // Tenta encontrar o mês nos dados (pode estar abreviado ou completo)
            var mesEncontrado = mesesDisponiveis.FirstOrDefault(m =>
                mesesMap.ContainsKey(m) && mesesMap[m] == mes);

            if (mesEncontrado != null)
                resultado.Add(mesEncontrado);
        }

        return resultado;
    }

    private static string ObterNomeMes(int mes)
    {
        return mes switch
        {
            1 => "Jan",
            2 => "Fev",
            3 => "Mar",
            4 => "Abr",
            5 => "Mai",
            6 => "Jun",
            7 => "Jul",
            8 => "Ago",
            9 => "Set",
            10 => "Out",
            11 => "Nov",
            12 => "Dez",
            _ => ""
        };
    }
}