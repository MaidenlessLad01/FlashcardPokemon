using CommunityToolkit.Mvvm.Input;
using FlashcardPokemon.Models;

namespace FlashcardPokemon.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}