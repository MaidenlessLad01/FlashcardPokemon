using MauiApp9.MVVM.Views;

namespace FlashcardPokemon
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new FlashcardView());
        }
    }
}