using CommunityToolkit.Mvvm.Input;
using E_Commerce.Shared.Dtos;

namespace Controls;

public class ProductCartItemChangeEventArgs : EventArgs
{
    public int ProductId { get; set; }
    public int Count { get; set; }

    public ProductCartItemChangeEventArgs(int productId, int count)
    {
        ProductId = productId;
        Count = count;
    }
}
public partial class ProductsListControl : ContentView
{
    public static readonly BindableProperty ProductsProperty =
        BindableProperty.Create(nameof(Products), typeof(IEnumerable<ProductDto>), typeof(ProductsListControl), Enumerable.Empty<ProductDto>());
    public static BindableProperty IsSmallProperty = BindableProperty.Create(nameof(IsSmall), typeof(bool), typeof(ProductsListControl), false);
    public ProductsListControl()
    {
        InitializeComponent();
    }
    public event EventHandler<ProductCartItemChangeEventArgs> AddRemoveCartClicked;

    public IEnumerable<ProductDto> Products
    {
        get => (IEnumerable<ProductDto>)GetValue(ProductsProperty);
        set => SetValue(ProductsProperty, value);
    }
    public bool IsSmall
    {
        get => (bool)GetValue(IsSmallProperty);
        set => SetValue(IsSmallProperty, value);
    }
    public bool IsDefault => !IsSmall;
    //public IList<string> CartButtonStyles { get; set; } = new List<string>()
    //{
    //    "CartBtn","DefaultCartBtn"
    //};
    private static void OnIsSmallPropertyChanged(BindableObject bindable, object _old, object _new)
    {
        if (bindable is ProductsListControl control)
        {
            if (_old != _new)
            {
                control.OnPropertyChanged(nameof(ProductsListControl.IsDefault));
            }
        }
    }
    [RelayCommand]
    private void AddToCart(int productId) => AddRemoveCartClicked?.Invoke(this, new ProductCartItemChangeEventArgs(productId, 1));

    [RelayCommand]
    private void RemoveFromCart(int productId) => AddRemoveCartClicked?.Invoke(this, new ProductCartItemChangeEventArgs(productId, -1));
}