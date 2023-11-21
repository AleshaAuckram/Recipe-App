// RecipeDetailPage.xaml.cs
using Microsoft.Maui.Controls;
using RecipeApp.ViewModel;

namespace RecipeApp.Views
{
    public partial class RecipeDetailPage : ContentPage
    {
        public RecipeDetailPage()
        {
            InitializeComponent();
        }

        public RecipeDetailPage(Recipe selectedRecipe) : this()
        {
            BindingContext = new RecipeDetailViewModel
            {
                Name = selectedRecipe.Name,
                Instructions = selectedRecipe.Instructions
            };
        }

        private void OnIngredientCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Handle the checkbox state change here
        }
    }
}
