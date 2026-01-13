using TwIndex.Core.Services;
using TwIndex.Core.ViewModels;

namespace TwIndex.Pages;

[QueryProperty(nameof(QuantidadePalavras), "QuantidadePalavras")]
public partial class FormPalavrasPage : ContentPage
{
    private FormPalavrasViewModel ViewModel => (FormPalavrasViewModel)BindingContext;
    private readonly INavigationService _navigation;

    public FormPalavrasPage(INavigationService navigation)
    {
        InitializeComponent();
        _navigation = navigation;
        BindingContext = new FormPalavrasViewModel();
    }

    public int QuantidadePalavras
    {
        set
        {
            ViewModel.SetQuantidadePalavras(value);
            CriarEntriesPalavras(value);
            btnAvancar.IsEnabled = ViewModel.IsValid();

            ViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName?.StartsWith("Palavra") == true)
                {
                    btnAvancar.IsEnabled = ViewModel.IsValid();
                }
            };
        }
    }

    private void CriarEntriesPalavras(int quantidade)
    {
        Panel.Children.Clear();

        for (int i = 1; i <= quantidade; i++)
        {
            var entry = new Entry
            {
                Placeholder = $"Palavra-Chave {i}",
                PlaceholderColor = Colors.Gray
            };

            entry.SetBinding(Entry.TextProperty, $"Palavra{i}");
            Panel.Children.Add(entry);
        }
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        if (!ViewModel.IsValid())
            return;

        var palavras = ViewModel.GetPalavras();
        var parameters = new Dictionary<string, object>
        {
            { "Palavras", palavras }
        };

        await _navigation.GoToAsync(nameof(ResultadoPage), parameters);
    }
}