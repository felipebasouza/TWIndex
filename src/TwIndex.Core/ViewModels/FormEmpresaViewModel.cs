using CommunityToolkit.Mvvm.ComponentModel;

namespace TwIndex.Core.ViewModels;

public partial class FormEmpresaViewModel : ObservableObject
{
    [ObservableProperty]
    private string segmento = string.Empty;

    [ObservableProperty]
    private string nome = string.Empty;

    [ObservableProperty]
    private string cidade = string.Empty;

    [ObservableProperty]
    private string estado = string.Empty;

    [ObservableProperty]
    private double valorStepper = 4;

    [ObservableProperty]
    private bool isFormValid;

    partial void OnSegmentoChanged(string value) => UpdateIsFormValid();
    partial void OnNomeChanged(string value) => UpdateIsFormValid();

    private void UpdateIsFormValid()
    {
        IsFormValid = IsValid();
    }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Segmento) &&
               !string.IsNullOrWhiteSpace(Nome);
    }
}

