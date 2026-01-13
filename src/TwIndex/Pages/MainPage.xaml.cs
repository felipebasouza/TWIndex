using TwIndex.Core.Services;

namespace TwIndex.Pages
{
    public partial class MainPage : ContentPage
    {
        private bool _isAcademic;
        private bool _isBusiness;
        private readonly INavigationService _navigation;

        public MainPage(INavigationService navigation)
        {
            InitializeComponent();
            _navigation = navigation;
            buttonNext.IsEnabled = false;
        }

        private void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!e.Value) return;

            var radioButton = sender as RadioButton;
            var content = radioButton?.Content?.ToString();

            if (content == "Acadêmico")
            {
                _isAcademic = true;
                _isBusiness = false;
            }
            else if (content == "Empresarial")
            {
                _isAcademic = false;
                _isBusiness = true;
            }

            buttonNext.IsEnabled = true;
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            if (_isAcademic)
            {
                await _navigation.GoToAsync(nameof(TipoTrabalhoPage));
            }
            else if (_isBusiness)
            {
                await _navigation.GoToAsync(nameof(FormEmpresaPage));
            }
        }

        private async void OnInfoClicked(object sender, EventArgs e)
        {
            await _navigation.GoToAsync(nameof(Sobre));
        }
    }
}
