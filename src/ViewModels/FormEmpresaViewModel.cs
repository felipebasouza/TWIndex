using CommunityToolkit.Mvvm.ComponentModel;

namespace TwIndex.ViewModels
{
    public partial class FormEmpresaViewModel : ObservableObject
    {
        [ObservableProperty]
        private string segmento = string.Empty;

        [ObservableProperty]
        private string nome = string.Empty;

        [ObservableProperty]
        private string cidade = string.Empty;

        [ObservableProperty]
        private string estado = string.Empty;

        [ObservableProperty]
        private double valorStepper = 4;

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Segmento) &&
                   !string.IsNullOrWhiteSpace(Nome);
        }
    }
}
