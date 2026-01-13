using TwIndex.Core.ViewModels;

namespace TwIndex.Pages;

[QueryProperty(nameof(Palavras), "Palavras")]
public partial class ResultadoPage : ContentPage
{
    private readonly ResultadoViewModel _viewModel;

    public ResultadoPage(ResultadoViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    public List<string> Palavras
    {
        set => _viewModel.SetPalavras(value);
    }
}
