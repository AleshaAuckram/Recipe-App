using Microsoft.Maui.Controls;
using RecipeApp.ViewModel;

namespace RecipeApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly RecipesViewModel _recipesViewModel;

        public MainPage()
        {
            InitializeComponent();
            _recipesViewModel = new RecipesViewModel();
            BindingContext = new MainPageViewModel(_recipesViewModel);
        }

        private async void OnRecipeSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Recipe selectedRecipe)
            {
                await Navigation.PushAsync(new RecipeDetailPage(selectedRecipe));
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
