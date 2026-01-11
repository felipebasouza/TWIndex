using TwIndex.ViewModels;
namespace TwIndex.Pages;


public partial class ResultadoPage : ContentPage
{
	public ResultadoPage(List<string> palavras)
	{
		InitializeComponent();
        BindingContext = new ResultadoViewModel(palavras);

    }
}