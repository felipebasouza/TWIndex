using TwIndex.ViewModels;

namespace TwIndex.Pages;

public partial class FormPalavrasPage : ContentPage
{
    private FormPalavrasViewModel ViewModel => (FormPalavrasViewModel)BindingContext;

    public FormPalavrasPage(int quantidadePalavras)
    {
        InitializeComponent();

        var viewModel = new FormPalavrasViewModel(quantidadePalavras);
        BindingContext = viewModel;

        // Cria os Entry dinamicamente baseado na quantidade
        CriarEntriesPalavras(quantidadePalavras);

        // Monitora mudanças para habilitar/desabilitar botão
        viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName?.StartsWith("Palavra") == true)
            {
                btnAvancar.IsEnabled = viewModel.IsValid();
            }
        };

        // Estado inicial do botão
        btnAvancar.IsEnabled = viewModel.IsValid();
    }

    private void CriarEntriesPalavras(int quantidade)
    {
        for (int i = 1; i <= quantidade; i++)
        {
            var entry = new Entry
            {
                Placeholder = $"Palavra-Chave {i}",
                PlaceholderColor = Colors.Gray
            };

            // Cria o binding para Palavra1, Palavra2, etc.
            entry.SetBinding(Entry.TextProperty, $"Palavra{i}");

            Panel.Children.Add(entry);
        }
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        if (!ViewModel.IsValid())
            return;

        var palavras = ViewModel.GetPalavras();

        // TODO: Quando ResultadoPage estiver pronta:
        // await Navigation.PushAsync(new ResultadoPage(palavras));

        // Temporário para testar:
        await DisplayAlert(
            "Sucesso!",
            $"Palavras validadas:\n{string.Join("\n", palavras)}",
            "OK");
    }
}