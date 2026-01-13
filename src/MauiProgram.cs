using LiveChartsCore.SkiaSharpView.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using TwIndex.Pages;
using TwIndex.Core.ViewModels;
using TwIndex.Core.Services;
using TwIndex.Navigation;

namespace TwIndex
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLiveCharts()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<INavigationService, MauiNavigationService>();

            builder.Services.AddTransient<GraficoViewModel>();
            builder.Services.AddTransient<GraficoPage>();
            builder.Services.AddTransient<ResultadoViewModel>();
            builder.Services.AddTransient<ResultadoPage>();
            builder.Services.AddTransient<FormPalavrasPage>();
            builder.Services.AddTransient<FormTrabalhoPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
