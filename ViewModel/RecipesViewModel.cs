// RecipesViewModel.cs
using System.Collections.ObjectModel;

namespace RecipeApp.ViewModel
{
    public class RecipesViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();

        public RecipesViewModel()
        {
            AddInitialRecipes();
        }

        private void AddInitialRecipes()
        {
            Recipe recipe1 = new Recipe
            {
                Name = "Pasta Carbonara",
                Ingredients = "Spaghetti, eggs, pancetta, Parmesan cheese, black pepper",
                Instructions = "Cook spaghetti. Fry pancetta. Mix eggs with Parmesan. Combine all ingredients.",
            };

            Recipe recipe2 = new Recipe
            {
                Name = "Chicken Alfredo",
                Ingredients = "Fettuccine, chicken breast, heavy cream, Parmesan cheese, butter",
                Instructions = "Cook fettuccine. Grill chicken. Mix heavy cream, Parmesan, and butter. Combine all ingredients.",
            };

            Recipe recipe3 = new Recipe
            {
                Name = "Another Recipe",
                Ingredients = "Ingredient 1, Ingredient 2",
                Instructions = "Mix the ingredients and cook",
            };

            Recipes.Add(recipe1);
            Recipes.Add(recipe2);
            Recipes.Add(recipe3);
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }
    }
}
