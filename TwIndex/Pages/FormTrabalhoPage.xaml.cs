using TWIndex.ViewModels;

namespace TwIndex.Pages;

public partial class FormTrabalhoPage : ContentPage
{
    public FormTrabalhoPage(string tipoTrabalho)
    {
        InitializeComponent();
        BindingContext = new FormTrabalhoViewModel(Navigation, tipoTrabalho);
    }

    private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        stepperLabel.Text = e.NewValue.ToString("0");
    }
}