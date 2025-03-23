using CommunityToolkit.Mvvm.ComponentModel;
using E_Commerce.Shared.Dtos;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.Input;

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

        }
        public ObservableCollection<Category> Categories { get; set; } = new();
        public ObservableCollection<Offer> Offers { get; set; } = new();
        public ObservableCollection<ProductDto> PopularProducts { get; set; } = new();

        [ObservableProperty]
        private bool _isBusy = true;
        [ObservableProperty]
        private int _cartCount;
        public async Task InitalizeAsync()
        {
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
            }
            finally
            {
                IsBusy = false;
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
        }
    }
}