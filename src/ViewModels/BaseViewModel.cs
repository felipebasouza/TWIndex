using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwIndex.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public INavigation? Navigation { get; set; }

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string title = string.Empty;
    }
}
