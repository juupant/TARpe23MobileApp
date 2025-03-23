using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using E_Commerce.Shared.Dtos;
using Models;
using Pages;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly CategoryService _categoryService;
        private readonly OffersService _offersService;
        private readonly ProductsService _productsService;
        private readonly CartViewModel _cartViewModel;
        public HomePageViewModel(CategoryService categoryService, OffersService offersService, ProductsService productsService, CartViewModel cartViewModel)
        {
            _categoryService = categoryService;
            _offersService = offersService;
            _productsService = productsService;
            _cartViewModel = cartViewModel;


            _cartViewModel.CartItemUpdated += CartViewModel_CartItemUpdated;
            _cartViewModel.CartItemRemoved += CartViewModel_CartItemRemoved;
            _cartViewModel.CartCountUpdated += CartViewModel_CartCountUpdated;


        }
        public void Dispose()
        {
            _cartViewModel.CartItemUpdated -= CartViewModel_CartItemUpdated;
            _cartViewModel.CartItemRemoved -= CartViewModel_CartItemRemoved;
            _cartViewModel.CartCountUpdated -= CartViewModel_CartCountUpdated;
        }
        private void ModifyProductQuantity(int id, int quantity)
        {
            var product = PopularProducts.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.CartQuantity = quantity;
            }
        }
        private void CartViewModel_CartItemRemoved(object? sender, int id) => ModifyProductQuantity(id, 0);

        private void CartViewModel_CartItemUpdated(object? sender, CartItem e) => ModifyProductQuantity(e.ProductId, e.Quantity);

        private void CartViewModel_CartCountUpdated(object? sender, int count) => CartCount = count;

        public ObservableCollection<Category> Categories { get; set; } = new();
        public ObservableCollection<Offer> Offers { get; set; } = new();
        public ObservableCollection<ProductDto> PopularProducts { get; set; } = new();

        [ObservableProperty]
        private bool _isBusy = true;
        [ObservableProperty]
        private int _cartCount;

        private bool _isInitialized = false;
        public async Task InitalizeAsync()
        {
            if (_isInitialized) return;
            try
            {
                foreach (var cat in await _categoryService.GetMainCategoriesAsync())
                {
                    Categories.Add(cat);
                }
                foreach (var off in await _offersService.GetActiveOffersAsync())
                {
                    Offers.Add(off);
                }
                foreach (var prod in await _productsService.GetPopularProductsAsync())
                {
                    PopularProducts.Add(prod);
                }
                _isInitialized = true;
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private void AddToCart(int productId) => UpdateCart(productId, 1);


        [RelayCommand]
        private void RemoveFromCart(int productId) => UpdateCart(productId, -1);
        private void UpdateCart(int productId, int count)
        {
            var product = PopularProducts.FirstOrDefault(P => P.Id == productId);
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
        [RelayCommand]
        private async Task GoToCategory(Category category)
        {
            var param = new Dictionary<string, object>()
            {
                [nameof(CategoryProductsViewModel.SelectedCategory)] = category
            };
            await Shell.Current.GoToAsync(nameof(CategoryProductsPage), animate: true, param);
        }
    }
}