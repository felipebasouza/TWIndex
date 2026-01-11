using CommunityToolkit.Mvvm.ComponentModel;

namespace TwIndex.ViewModels;

public partial class FormTrabalhoViewModel : ObservableObject
{
    [ObservableProperty]
    private string tipo = string.Empty;

    [ObservableProperty]
    private string titulo = string.Empty;

    [ObservableProperty]
    private string autor = string.Empty;

    [ObservableProperty]
    private string origem = string.Empty;

    [ObservableProperty]
    private string departamento = string.Empty;

    [ObservableProperty]
    private double valorStepper = 4;

    [ObservableProperty]
    private bool isFormValid;

    public FormTrabalhoViewModel(string tipoTrabalho)
    {
        Tipo = tipoTrabalho;
        ValidateForm();
    }

    partial void OnTituloChanged(string value) => ValidateForm();

    partial void OnAutorChanged(string value) => ValidateForm();

    partial void OnOrigemChanged(string value) => ValidateForm();

    partial void OnDepartamentoChanged(string value) => ValidateForm();

    private void ValidateForm() => IsFormValid = !string.IsNullOrWhiteSpace(Titulo) &&
                      !string.IsNullOrWhiteSpace(Autor) &&
                      !string.IsNullOrWhiteSpace(Origem) &&
                      !string.IsNullOrWhiteSpace(Departamento);

    public bool IsValid() => IsFormValid;
}