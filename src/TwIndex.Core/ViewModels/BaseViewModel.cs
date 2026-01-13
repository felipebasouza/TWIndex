using CommunityToolkit.Mvvm.ComponentModel;

namespace TwIndex.Core.ViewModels;


public partial class BaseViewModel : ObservableObject
{
    public INavigation? Navigation { get; set; }

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string title = string.Empty;
}

