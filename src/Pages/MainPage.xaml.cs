namespace TwIndex.Pages
{
    public partial class MainPage : ContentPage
    {
        private bool _isAcademic;
        private bool _isBusiness;

        public MainPage()
        {
            InitializeComponent();
            
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
                await Navigation.PushAsync(new TipoTrabalhoPage());
            }
            else if (_isBusiness)
            {
                await Navigation.PushAsync(new FormEmpresaPage());
            }
        }

        private async void OnInfoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sobre());
        }
    }
}
