using Microsoft.Maui.Controls;
using RecipeApp.ViewModel;

namespace RecipeApp.Views
{
    public partial class AddRecipePage : ContentPage
    {
        private readonly RecipesViewModel _recipesViewModel;

        public AddRecipePage(INavigation navigation, RecipesViewModel recipesViewModel)
        {
            InitializeComponent();
            _recipesViewModel = recipesViewModel;
            BindingContext = new AddRecipeViewModel(navigation, _recipesViewModel);
        }
    }
}
