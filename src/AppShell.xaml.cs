using TwIndex.Pages;

namespace TwIndex;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        // Registra a rota para navegação
        Routing.RegisterRoute(nameof(Pages.GraficoPage), typeof(Pages.GraficoPage));
    }
}
