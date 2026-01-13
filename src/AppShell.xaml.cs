using TwIndex.Pages;

namespace TwIndex;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        // Registra a rota para navegação
        Routing.RegisterRoute(nameof(GraficoPage), typeof(GraficoPage));
        Routing.RegisterRoute(nameof(TipoTrabalhoPage), typeof(TipoTrabalhoPage));
        Routing.RegisterRoute(nameof(FormEmpresaPage), typeof(FormEmpresaPage));
        Routing.RegisterRoute(nameof(FormTrabalhoPage), typeof(FormTrabalhoPage));
        Routing.RegisterRoute(nameof(FormPalavrasPage), typeof(FormPalavrasPage));
        Routing.RegisterRoute(nameof(ResultadoPage), typeof(ResultadoPage));
        Routing.RegisterRoute(nameof(Sobre), typeof(Sobre));

    }
}
