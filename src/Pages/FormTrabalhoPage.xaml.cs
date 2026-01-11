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
        await Navigation.PushAsync(new FormPalavrasPage(quantidadePalavras));
    }
}