using LiveChartsCore.SkiaSharpView.Maui;
using MauiIcons.Material;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using TwIndex.Pages;
using TwIndex.ViewModels;

namespace TwIndex
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMaterialMauiIcons()
                .UseLiveCharts()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<GraficoViewModel>();
            builder.Services.AddTransient<GraficoPage>();
            builder.Services.AddTransient<ResultadoViewModel>();
            builder.Services.AddTransient<ResultadoPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
