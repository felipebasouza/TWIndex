using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TwIndex.Models;
using TwIndex.Pages;
using TwIndex.ViewModels;


namespace TWIndex.ViewModels;

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