using TwIndex.Core.Models;
using TwIndex.Core.Services;
using TwIndex.Core.ViewModels;

namespace TwIndex.Pages;

public partial class TipoTrabalhoPage : ContentPage
{
    private readonly INavigationService _navigation;

    public TipoTrabalhoPage(INavigationService navigation)
    {
        InitializeComponent();
        _navigation = navigation;
        BindingContext = new TipoTrabalhoViewModel();
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            if (e.CurrentSelection[0] is Tipo tipoSelecionado)
            {
                // Limpa a seleção
                ((CollectionView)sender).SelectedItem = null;

                // Navega usando INavigationService
                var parameters = new Dictionary<string, object>
                {
                    { "TipoTrabalho", tipoSelecionado.Nome }
                };

                await _navigation.GoToAsync(nameof(FormTrabalhoPage), parameters);
            }
        }
    }
}