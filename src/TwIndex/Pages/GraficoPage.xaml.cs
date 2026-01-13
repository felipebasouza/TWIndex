using TwIndex.Core.ViewModels;

namespace TwIndex.Pages;

public partial class GraficoPage : ContentPage
{
    public GraficoPage(GraficoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}