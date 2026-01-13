using System.Collections.ObjectModel;
using TwIndex.Core.Models;

namespace TwIndex.Core.ViewModels;

public class TipoTrabalhoViewModel
{
    public ObservableCollection<Tipo> TiposTrabalho { get; }

    public TipoTrabalhoViewModel()
    {
        TiposTrabalho =
        [
            new() { Nome = "Doutorado" },
            new() { Nome = "Mestrado" },
            new() { Nome = "Trabalho de Conclusão de Curso" },
            new() { Nome = "Relatório Técnico" },
            new() { Nome = "Relatório Científico" },
            new() { Nome = "Iniciação Tecnológica" },
            new() { Nome = "Iniciação Científica" },
            new() { Nome = "Patente" }
        ];
    }
}