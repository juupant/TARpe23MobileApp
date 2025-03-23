using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using E_Commerce.Shared.Dtos;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModels
{
    [QueryProperty(nameof(SelectedCategory), nameof(SelectedCategory))]
    public partial class CategoryProductsViewModel : ObservableObject
    {
        private readonly CategoryService _categoryService;
        private readonly ProductsService _productsService;
        private readonly CartViewModel _cartViewModel;
        public CategoryProductsViewModel(CategoryService categoryService, ProductsService productsService, CartViewModel cartViewModel)
        {
            _categoryService = categoryService;
            _productsService = productsService;
            _cartViewModel = cartViewModel;


            _cartViewModel.CartItemUpdated += CartViewModel_CartItemUpdated;
            _cartViewModel.CartItemRemoved += CartViewModel_CartItemRemoved;
            _cartViewModel.CartCountUpdated += CartViewModel_CartCountUpdated;
        }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(PageTitle))]
        private Category _selectedCategory;
        public string PageTitle => $"{SelectedCategory?.Name ?? "Category"} Products";
        [ObservableProperty]
        public IEnumerable<Category> _categories = Enumerable.Empty<Category>();
        [ObservableProperty]
        public IEnumerable<ProductDto> _products = Enumerable.Empty<ProductDto>();
        //public ObservableCollection<Category> Categories { get; set; } = new();
        //public ObservableCollection<ProductDto> Products { get; set; } = new();

        [ObservableProperty]
        private bool _isBusy = true;
        [ObservableProperty]
        private int _cartCount;
        public async Task InitializeAsync()
        {
            await Task.Delay(100);
            try
            {
                //Categories.Clear();
                //foreach(var category in await _categoryService.GetSubCategories(SelectedCategory.Id))
                //{
                //    Categories.Add(category);
                //}
                //Products.Clear();
                //foreach(var product in await _productsService.GetCategoryProductsAsync(SelectedCategory.Id))
                //{
                //    Products.Add(product);
                //}
                Categories = await _categoryService.GetSubCategories(SelectedCategory.Id);
                Products = await _productsService.GetCategoryProductsAsync(SelectedCategory.Id);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private void ModifyProductQuantity(int id, int quantity)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.CartQuantity = quantity;
            }
        }
        private void CartViewModel_CartItemRemoved(object? sender, int id) => ModifyProductQuantity(id, 0);

        private void CartViewModel_CartItemUpdated(object? sender, CartItem e) => ModifyProductQuantity(e.ProductId, e.Quantity);

        private void CartViewModel_CartCountUpdated(object? sender, int count) => CartCount = count;

        public void Dispose()
        {
            _cartViewModel.CartItemUpdated -= CartViewModel_CartItemUpdated;
            _cartViewModel.CartItemRemoved -= CartViewModel_CartItemRemoved;
            _cartViewModel.CartCountUpdated -= CartViewModel_CartCountUpdated;
        }
        [RelayCommand]
        private void AddToCart(int productId) => UpdateCart(productId, 1);


        [RelayCommand]
        private void RemoveFromCart(int productId) => UpdateCart(productId, -1);
        private void UpdateCart(int productId, int count)
        {
            var product = Products.FirstOrDefault(P => P.Id == productId);
            if (product != null)
            {
                product.CartQuantity += count;
                if (count == -1)
                {
                    _cartViewModel.RemoveFromCartCommand.Execute(product.Id);
                }
                else
                {
                    _cartViewModel.AddToCartCommand.Execute(product);
                }
                CartCount = _cartViewModel.Count;
            }
        }
    }
}