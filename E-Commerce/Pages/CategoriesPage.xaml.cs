using Models;
using Services;
using System.Collections.ObjectModel;

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
}