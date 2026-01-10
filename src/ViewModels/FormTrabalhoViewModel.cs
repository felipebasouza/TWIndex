using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TwIndex.ViewModels;

namespace TWIndex.ViewModels;

public partial class FormTrabalhoViewModel : BaseViewModel
{
    [ObservableProperty]
    private string tipo = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ConfirmarCommand))]
    private string titulo = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ConfirmarCommand))]
    private string autor = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ConfirmarCommand))]
    private string origem = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ConfirmarCommand))]
    private string departamento = string.Empty;

    [ObservableProperty]
    private double valorStepper = 4;

    public FormTrabalhoViewModel(INavigation navigation, string tipoTrabalho)
    {
        Navigation = navigation;
        Tipo = tipoTrabalho;
    }

    [RelayCommand(CanExecute = nameof(CanConfirmar))]
    private async Task Confirmar()
    {
        int quantidadePalavras = (int)ValorStepper;

        //if (Navigation != null)
        //{
        //    await Navigation.PushAsync(new FormPalavrasPage(quantidadePalavras));
        //}

        // TODO: Implementar navegação para FormPalavrasPage
        if (Application.Current?.MainPage != null)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Sucesso!",
                $"Formulário validado!\nTipo: {Tipo}\nTítulo: {Titulo}\nAutor: {Autor}\nPalavras-chave: {quantidadePalavras}",
                "OK");
        }
    }

    private bool CanConfirmar()
    {
        return !string.IsNullOrWhiteSpace(Titulo) &&
               !string.IsNullOrWhiteSpace(Autor) &&
               !string.IsNullOrWhiteSpace(Origem) &&
               !string.IsNullOrWhiteSpace(Departamento);
    }
}