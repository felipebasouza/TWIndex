using TwIndex.Core.ViewModels;

namespace TwIndex.Tests
{
    public class FormValidationTests
    {
        [Fact]
        public void FormEmpresaViewModel_ShouldBeValid_WhenSegmentoAndNomeAreFilled()
        {
            // Arrange
            var viewModel = new FormEmpresaViewModel();

            // Act
            viewModel.Segmento = "Tecnologia";
            viewModel.Nome = "Empresa Teste";

            // Assert
            Assert.True(viewModel.IsValid());
            Assert.True(viewModel.IsFormValid);
        }

        [Fact]
        public void FormTrabalhoViewModel_ShouldBeInvalid_WhenRequiredFieldsAreMissing()
        {
            // Arrange
            var viewModel = new FormTrabalhoViewModel("Artigo");

            // Act
            viewModel.Titulo = "Título do Trabalho";
            viewModel.Autor = "Autor Teste";
            // Origem e Departamento não preenchidos

            // Assert
            Assert.False(viewModel.IsValid());
            Assert.False(viewModel.IsFormValid);
        }
    }
}
