using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Refit;
using TwIndex.Models;
using TwIndex.Services;

namespace TwIndex.ViewModels
{

    public partial class ResultadoViewModel : ObservableObject
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

        private readonly List<string> _palavras;

        public ResultadoViewModel(List<string> palavras)
        {
            // Filtra palavras vazias
            _palavras = palavras.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();

            // Inicia a consulta
            _ = ConsultaPytrendsAsync();
        }

        private async Task ConsultaPytrendsAsync()
        {
            Show = false;
            IsBusy = true;
            HasError = false;

            try
            {
                var pytrends = RestService.For<IRestApi>(EndPoints.BaseUrl);
                var response = await pytrends.Request(_palavras);
                Resultado = response;
                Show = true;
            }
            catch (Exception ex)
            {
                HasError = true;
                ErrorMessage = "Erro de Conexão, tente novamente mais tarde!";

                // Notifica a View sobre o erro
                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Falha na Conexão",
                        ErrorMessage,
                        "OK");
                }
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
                
                await Shell.Current.GoToAsync(nameof(GraficoPage), navigationParameter);
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
                
                await Shell.Current.GoToAsync(nameof(GraficoPage), navigationParameter);
            }
        }
    }
}
