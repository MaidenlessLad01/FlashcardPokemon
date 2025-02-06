using FlashcardPokemon.Models;
using FlashcardPokemon.PageModels;

namespace FlashcardPokemon.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}