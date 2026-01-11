using CommunityToolkit.Mvvm.ComponentModel;


namespace TwIndex.ViewModels
{


    public partial class FormPalavrasViewModel(int quantidadePalavras) : ObservableObject
    {
        public int QuantidadePalavras { get; set; } = quantidadePalavras;

        [ObservableProperty]
        private string palavra1 = string.Empty;

        [ObservableProperty]
        private string palavra2 = string.Empty;

        [ObservableProperty]
        private string palavra3 = string.Empty;

        [ObservableProperty]
        private string palavra4 = string.Empty;

        [ObservableProperty]
        private string palavra5 = string.Empty;

        public bool IsValid()
        {
            return QuantidadePalavras switch
            {
                1 => !string.IsNullOrWhiteSpace(Palavra1),
                2 => !string.IsNullOrWhiteSpace(Palavra1) && !string.IsNullOrWhiteSpace(Palavra2),
                3 => !string.IsNullOrWhiteSpace(Palavra1) && !string.IsNullOrWhiteSpace(Palavra2) && !string.IsNullOrWhiteSpace(Palavra3),
                4 => !string.IsNullOrWhiteSpace(Palavra1) && !string.IsNullOrWhiteSpace(Palavra2) && !string.IsNullOrWhiteSpace(Palavra3) && !string.IsNullOrWhiteSpace(Palavra4),
                5 => !string.IsNullOrWhiteSpace(Palavra1) && !string.IsNullOrWhiteSpace(Palavra2) && !string.IsNullOrWhiteSpace(Palavra3) && !string.IsNullOrWhiteSpace(Palavra4) && !string.IsNullOrWhiteSpace(Palavra5),
                _ => false
            };
        }

        public List<string> GetPalavras()
        {
            var listaPalavras = new List<string>();

            if (!string.IsNullOrWhiteSpace(Palavra1)) listaPalavras.Add(Palavra1);
            if (!string.IsNullOrWhiteSpace(Palavra2)) listaPalavras.Add(Palavra2);
            if (!string.IsNullOrWhiteSpace(Palavra3)) listaPalavras.Add(Palavra3);
            if (!string.IsNullOrWhiteSpace(Palavra4)) listaPalavras.Add(Palavra4);
            if (!string.IsNullOrWhiteSpace(Palavra5)) listaPalavras.Add(Palavra5);

            return listaPalavras;
        }
    }
}
