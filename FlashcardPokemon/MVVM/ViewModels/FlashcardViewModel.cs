using MauiApp9.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;
using Android.Provider;

namespace FlashcardPokemon.MVVM.ViewModels
{
    

    internal class FlashcardViewModel : INotifyPropertyChanged
    {
        public List<FlashcardModel> Pokemonlist { get; set; }
        public ICommand SelectPokemonCommand { get; private set; }
        private Random _random = new Random();
        private FlashcardModel _currentPokemon;
        public FlashcardModel CurrentPokemon
        {
            get => _currentPokemon;
            set
            {
                _currentPokemon = value;
                OnPropertyChanged(nameof(CurrentPokemon));
                Answer = CurrentPokemon.NormalImage;
            }
        }
        private string _answer;
        public string Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                OnPropertyChanged(nameof(Answer));
            }
        }
        // New property to control the tint color
        private Color _tintColor = Colors.Black;
       
        public FlashcardViewModel()
        {
            Pokemonlist = new List<FlashcardModel>
            {
                new FlashcardModel { Name = "Chimchar", TintedImage = "chimchar.png" , NormalImage = "nobgtintchimchar.png"},
                new FlashcardModel { Name = "Mew", TintedImage = "mew.png" , NormalImage = "nobgtintmew.png"},
                new FlashcardModel { Name = "Jigglypuff", TintedImage = "jigglypuff.png" , NormalImage = "nobgjigglypuff.png" },
                new FlashcardModel { Name = "Haunter", TintedImage = "haunter.png" , NormalImage = "nobgtinthaunter.png" },
                new FlashcardModel { Name = "Jigglypuff", TintedImage = "squirtle.png" , NormalImage = "nobgtintsquirtle.png" }

            };

            SelectPokemonCommand = new Command<string>(OnPokemonSelected);
            RandomizePokemon();
        }

        private void RandomizePokemon()
        {
            CurrentPokemon = Pokemonlist[_random.Next(Pokemonlist.Count)]; // Randomly choose the correct Pokémon

            // Create a list of two incorrect Pokémon
            var incorrectChoices = Pokemonlist
                .Where(p => p.Name != CurrentPokemon.Name)
                .OrderBy(p => _random.Next())
                .Take(2)
                .Select(p => p.Name)
                .ToList();

            // Add the correct answer to the list
            incorrectChoices.Add(CurrentPokemon.Name);

            // Shuffle the list to randomize the choices
            incorrectChoices = incorrectChoices.OrderBy(x => _random.Next()).ToList();

            // Assign the randomized choices and correct answer to the model
            CurrentPokemon.Choices = incorrectChoices;
            CurrentPokemon.Answer = CurrentPokemon.Name;

            // Notify that the current Pokémon has changed
            OnPropertyChanged(nameof(CurrentPokemon));
        }

        private async void OnPokemonSelected(string selectedName)
        {
            if (selectedName == CurrentPokemon.Answer)
            {
                // Correct answer logic
                Answer = CurrentPokemon.TintedImage;
                await Task.Delay(1000);
                RandomizePokemon(); 
               
            }
            else
            {
                RandomizePokemon();
            }
        }
       

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
