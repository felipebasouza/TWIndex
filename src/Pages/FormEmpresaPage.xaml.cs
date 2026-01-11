
using TwIndex.ViewModels;

namespace TwIndex.Pages;

public partial class FormEmpresaPage : ContentPage
{
    private FormEmpresaViewModel ViewModel => (FormEmpresaViewModel)BindingContext;

    public FormEmpresaPage()
    {
        InitializeComponent();
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

        await Navigation.PushAsync(new FormPalavrasPage(quantidadePalavras));

    }
}