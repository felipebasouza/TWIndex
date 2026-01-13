using CommunityToolkit.Mvvm.ComponentModel;


namespace TwIndex.Core.ViewModels;

public partial class FormPalavrasViewModel : ObservableObject
{
    private int _quantidadePalavras;

    [ObservableProperty]
    private string palavra1 = string.Empty;

    [ObservableProperty]
    private string palavra2 = string.Empty;

    [ObservableProperty]
    private string palavra3 = string.Empty;

    [ObservableProperty]
    private string palavra4 = string.Empty;

    [ObservableProperty]
    private string palavra5 = string.Empty;

    public void SetQuantidadePalavras(int quantidade)
    {
        _quantidadePalavras = quantidade;
    }

    public bool IsValid()
    {
        var palavras = GetPalavras();
        return palavras.Count == _quantidadePalavras;
    }

    public List<string> GetPalavras()
    {
        var palavras = new List<string>();

        if (_quantidadePalavras >= 1 && !string.IsNullOrWhiteSpace(Palavra1)) palavras.Add(Palavra1);
        if (_quantidadePalavras >= 2 && !string.IsNullOrWhiteSpace(Palavra2)) palavras.Add(Palavra2);
        if (_quantidadePalavras >= 3 && !string.IsNullOrWhiteSpace(Palavra3)) palavras.Add(Palavra3);
        if (_quantidadePalavras >= 4 && !string.IsNullOrWhiteSpace(Palavra4)) palavras.Add(Palavra4);
        if (_quantidadePalavras >= 5 && !string.IsNullOrWhiteSpace(Palavra5)) palavras.Add(Palavra5);

        return palavras;
    }
}

