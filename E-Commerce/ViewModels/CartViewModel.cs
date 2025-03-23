using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using E_Commerce.Shared.Dtos;
using Models;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public event EventHandler<int> CartCountUpdated;
        public event EventHandler<CartItem> CartItemUpdated;
        public event EventHandler<int> CartItemRemoved;
        public ObservableCollection<CartItem> CartItems { get; set; } = new();
        [ObservableProperty]
        private int _count;

        [ObservableProperty]
        private decimal _total;
        private void RecalculateTotalAmount() => Total = CartItems.Sum(i => i.Amount);

        [RelayCommand]
        private void IncreaseCart(Guid id)
        {
            var item = CartItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Quantity++;
                CartItemUpdated?.Invoke(this, item);
                RecalculateTotalAmount();
            }
        }

        [RelayCommand]
        private void AddToCart(ProductDto product)
        {
            var item = CartItems.FirstOrDefault(p => p.ProductId == product.Id);
            if (item != null)
            {
                item.Quantity++;
                CartItemUpdated?.Invoke(this, item);
            }
            else
            {
                item = new CartItem
                {
                    Id = Guid.NewGuid(),
                    ProductName = product.Name,
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = product.Price,
                };
                CartItems.Add(item);
                Count = CartItems.Count;

                CartItemUpdated?.Invoke(this, item);
                CartCountUpdated?.Invoke(this, Count);
            }
            CartItemUpdated?.Invoke(this, item);
            RecalculateTotalAmount();
        }
        [RelayCommand]
        private void RemoveFromCart(int id)
        {
            var item = CartItems.FirstOrDefault(c => c.ProductId == id);
            if (item != null)
            {
                if (item.Quantity == 1)
                {
                    CartItems.Remove(item);
                    Count = CartItems.Count;
                    CartItemRemoved?.Invoke(this, id);
                    CartCountUpdated?.Invoke(this, Count);
                }
                else
                {
                    item.Quantity--;
                    CartItemUpdated?.Invoke(this, item);
                }
            }
            RecalculateTotalAmount();
        }
        private void ClearCart()
        {
            CartItems.Clear();
            Count = 0;
            RecalculateTotalAmount();
        }
    }
}