using TwIndex.Models;
using TWIndex.ViewModels;

namespace TwIndex.Pages;

public partial class TipoTrabalhoPage : ContentPage
{
    public TipoTrabalhoPage()
    {
        InitializeComponent();
        BindingContext = new TipoTrabalhoViewModel();
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var tipoSelecionado = e.CurrentSelection[0] as Tipo;
            if (tipoSelecionado != null)
            {
                // Limpa a seleção
                ((CollectionView)sender).SelectedItem = null;

                // Navega
                await Navigation.PushAsync(new FormTrabalhoPage(tipoSelecionado.Nome));
            }
        }
    }
}