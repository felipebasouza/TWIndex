using TwIndex.ViewModels;

namespace TwIndex.Pages;

public partial class FormTrabalhoPage : ContentPage
{

    private readonly FormTrabalhoViewModel _viewModel;

    public FormTrabalhoPage(string tipoTrabalho)
    {
        InitializeComponent();
        _viewModel = new FormTrabalhoViewModel(tipoTrabalho);

        BindingContext = _viewModel;

        // Monitora mudanças para habilitar/desabilitar botão
        _viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(_viewModel.Titulo) ||
                e.PropertyName == nameof(_viewModel.Autor) ||
                e.PropertyName == nameof(_viewModel.Origem) ||
                e.PropertyName == nameof(_viewModel.Departamento))
            {
                btnAvancar.IsEnabled = _viewModel.IsValid();
            }
        };

        // Estado inicial do botão
        btnAvancar.IsEnabled = _viewModel.IsValid();
    }

    private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        stepperLabel.Text = e.NewValue.ToString("0");
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {


        if (!_viewModel.IsValid())
            return;

        int quantidadePalavras = (int)_viewModel.ValorStepper;

        // Navega para FormPalavrasPage
        await Navigation.PushAsync(new FormPalavrasPage(quantidadePalavras));
    }
}