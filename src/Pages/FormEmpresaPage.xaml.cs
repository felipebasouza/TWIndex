using TwIndex.Core.Services;
using TwIndex.Core.ViewModels;


namespace TwIndex.Pages;

public partial class FormEmpresaPage : ContentPage
{
    private FormEmpresaViewModel ViewModel => (FormEmpresaViewModel)BindingContext;
    private readonly INavigationService _navigation;

    public FormEmpresaPage(INavigationService navigation)
    {
        InitializeComponent();
        _navigation = navigation;
        BindingContext = new FormEmpresaViewModel();

        // Monitora mudanças nas propriedades para habilitar/desabilitar botão
        ViewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(ViewModel.Segmento) ||
                e.PropertyName == nameof(ViewModel.Nome))
            {
                btnAvancar.IsEnabled = ViewModel.IsValid();
            }
        };

        // Estado inicial do botão
        btnAvancar.IsEnabled = ViewModel.IsValid();
    }

    private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        stpLabel.Text = e.NewValue.ToString("0");
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        if (!ViewModel.IsValid())
            return;

        int quantidadePalavras = (int)ViewModel.ValorStepper;

        var parameters = new Dictionary<string, object>
        {
            { "QuantidadePalavras", quantidadePalavras }
        };

        await _navigation.GoToAsync(nameof(FormPalavrasPage), parameters);
    }
}