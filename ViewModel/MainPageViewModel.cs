// MainPageViewModel.cs
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace RecipeApp.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly RecipesViewModel _recipesViewModel;

        public MainPageViewModel(RecipesViewModel recipesViewModel)
        {
            _recipesViewModel = recipesViewModel;
            AllRecipes = _recipesViewModel.Recipes.ToList();
            FilteredRecipes = AllRecipes;
        }

        private List<Recipe> AllRecipes { get; }

        private string _searchKeyword;
        public string SearchKeyword
        {
            get => _searchKeyword;
            set
            {
                if (_searchKeyword != value)
                {
                    _searchKeyword = value;
                    OnPropertyChanged(nameof(SearchKeyword));
                    SearchRecipes();
                }
            }
        }

        private List<Recipe> _filteredRecipes;
        public List<Recipe> FilteredRecipes
        {
            get => _filteredRecipes;
            set
            {
                if (_filteredRecipes != value)
                {
                    _filteredRecipes = value;
                    OnPropertyChanged(nameof(FilteredRecipes));
                }
            }
        }

        private void SearchRecipes()
        {
            if (string.IsNullOrWhiteSpace(SearchKeyword))
            {
                FilteredRecipes = AllRecipes; // Show all recipes when the search keyword is empty
            }
            else
            {
                // Filter recipes based on the search keyword
                FilteredRecipes = AllRecipes
                    .Where(recipe => recipe.Name.Contains(SearchKeyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
