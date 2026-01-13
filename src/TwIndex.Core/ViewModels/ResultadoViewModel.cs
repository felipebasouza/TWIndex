using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Refit;
using TwIndex.Core.Models;
using TwIndex.Core.Services;

namespace TwIndex.Core.ViewModels;

public partial class ResultadoViewModel(INavigationService navigation) : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private bool show;

    [ObservableProperty]
    private Resultado? resultado;

    [ObservableProperty]
    private bool hasError;

    [ObservableProperty]
    private string errorMessage = string.Empty;

    private List<string> _palavras = [];
    private readonly INavigationService _navigation = navigation;

    public void SetPalavras(List<string> palavras)
    {
        _palavras = [.. palavras.Where(p => !string.IsNullOrWhiteSpace(p))];
        _ = ConsultaPytrendsAsync();
    }

    private async Task ConsultaPytrendsAsync()
    {
        Show = false;
        IsBusy = true;
        HasError = false;

        try
        {
            await Task.Delay(3000); // Simula tempo de requisição

            //var pytrends = RestService.For<IRestApi>(EndPoints.BaseUrl);
            //var response = await pytrends.Request(_palavras);
            //Resultado = response;

            Resultado = ResultadoSimulator.CriarResultadoSimulado(_palavras);

            Show = true;
        }
        catch
        {
            HasError = true;
            ErrorMessage = "Erro de Conexão, tente novamente mais tarde!";
            Show = false;
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task PushAsyncGraficoConjunto()
    {
        if (Resultado != null)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Resultado", Resultado }
            };

            await _navigation.GoToAsync("GraficoPage", navigationParameter);
        }
    }

    [RelayCommand]
    private async Task PushAsyncGraficoPalavra(string palavra)
    {
        if (Resultado != null && !string.IsNullOrEmpty(palavra))
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Resultado", Resultado },
                { "Palavra", palavra }
            };

            await _navigation.GoToAsync("GraficoPage", navigationParameter);
        }
    }

    [RelayCommand]
    private async Task TentarNovamente()
    {
        await ConsultaPytrendsAsync();
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await _navigation.GoBackAsync();
    }
}
