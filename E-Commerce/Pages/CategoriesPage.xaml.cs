using Models;
using Services;
using System.Collections.ObjectModel;
using ViewModels;

namespace Pages;

public partial class CategoriesPage : ContentPage
{
    private readonly CategoryService _categoryService;
	public CategoriesPage(CategoryService categoryService)
	{
		InitializeComponent();
        BindingContext = this;
        _categoryService = categoryService;
	}
    public ObservableCollection<Category> AllCategories { get; set; } = new();
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        AllCategories.Clear();
        foreach (var category in await _categoryService.GetCategoriesAsync())
        {
            AllCategories.Add(category);
        }
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection.Count > 0)
        {
            if (e.CurrentSelection?[0] is Category categories)
            {
                var param = new Dictionary<string, object>()
                {
                    [nameof(CategoryProductsViewModel.SelectedCategory)] = categories
                };
                await Shell.Current.GoToAsync(nameof(CategoryProductsPage),animate:true,param);
            }
        }
    }
}