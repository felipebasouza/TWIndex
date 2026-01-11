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

    public FormTrabalhoViewModel(string tipoTrabalho)
    {
        Tipo = tipoTrabalho;
    }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Titulo) &&
               !string.IsNullOrWhiteSpace(Autor) &&
               !string.IsNullOrWhiteSpace(Origem) &&
               !string.IsNullOrWhiteSpace(Departamento);
    }
}