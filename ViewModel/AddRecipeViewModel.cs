using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RecipeApp.ViewModel
{
    public class AddRecipeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly RecipesViewModel _recipesViewModel;
        private readonly INavigation _navigation;

        public AddRecipeViewModel(INavigation navigation, RecipesViewModel recipesViewModel)
        {
            _navigation = navigation;
            _recipesViewModel = recipesViewModel;
            AddRecipeCommand = new Command(AddRecipe);
            SelectImageCommand = new Command(async () => await SelectImage());
        }

        public ICommand AddRecipeCommand { get; }

        private string _recipeName;
        public string RecipeName
        {
            get => _recipeName;
            set
            {
                if (_recipeName != value)
                {
                    _recipeName = value;
                    OnPropertyChanged(nameof(RecipeName));
                }
            }
        }

        private string _ingredients;
        public string Ingredients
        {
            get => _ingredients;
            set
            {
                if (_ingredients != value)
                {
                    _ingredients = value;
                    OnPropertyChanged(nameof(Ingredients));
                }
            }
        }

        private string _instructions;
        public string Instructions
        {
            get => _instructions;
            set
            {
                if (_instructions != value)
                {
                    _instructions = value;
                    OnPropertyChanged(nameof(Instructions));
                }
            }
        }

        private void AddRecipe()
        {
            Recipe newRecipe = new Recipe
            {
                Name = RecipeName,
                Ingredients = Ingredients,
                Instructions = Instructions
            };

            _recipesViewModel.AddRecipe(newRecipe);

            // Navigate back to MainPage
            _navigation.PopAsync();
        }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private byte[] _recipeImage;
        public byte[] RecipeImage
        {
            get => _recipeImage;
            set
            {
                if (_recipeImage != value)
                {
                    _recipeImage = value;
                    OnPropertyChanged(nameof(RecipeImage));
                }
            }
        }

        public ICommand SelectImageCommand { get; }

        private async Task SelectImage()
        {
            // Implement logic to allow users to select or capture an image
            // For simplicity, you can use a library or Xamarin.Essentials.MediaPicker

            // Example using Xamarin.Essentials.MediaPicker
            var result = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            if (result != null)
            {
                using (var stream = await result.OpenReadAsync())
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    RecipeImage = memoryStream.ToArray();
                }
            }
        }

        
    }
}
