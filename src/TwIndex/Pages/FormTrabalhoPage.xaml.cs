using TwIndex.Core.Services;
using TwIndex.Core.ViewModels;

namespace TwIndex.Pages;

[QueryProperty(nameof(TipoTrabalho), "TipoTrabalho")]
public partial class FormTrabalhoPage : ContentPage
{
    private FormTrabalhoViewModel? _viewModel;
    private readonly INavigationService _navigation;

    public FormTrabalhoPage(INavigationService navigation)
    {
        InitializeComponent();
        _navigation = navigation;
    }

    public string TipoTrabalho
    {
        set
        {
            _viewModel = new FormTrabalhoViewModel(value);
            BindingContext = _viewModel;
        }
    }

    private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        stepperLabel.Text = e.NewValue.ToString("0");
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        if (_viewModel == null || !_viewModel.IsValid())
            return;

        int quantidadePalavras = (int)_viewModel.ValorStepper;

        var parameters = new Dictionary<string, object>
        {
            { "QuantidadePalavras", quantidadePalavras }
        };

        await _navigation.GoToAsync(nameof(FormPalavrasPage), parameters);
    }
}