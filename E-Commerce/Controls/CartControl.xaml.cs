using Pages;
namespace Controls;

public partial class CartControl : ContentView
{
    public static readonly BindableProperty CountProperty = BindableProperty.Create(nameof(Count), typeof(int), typeof(CartControl), 0, propertyChanged: OnCountChanged);
    public CartControl()
    {
        InitializeComponent();
    }
    public int Count
    {
        get => (int)GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }
    private bool _allocated;
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (container != null && !_allocated)
        {
            container.Scale = 0;
            _allocated = true;
        }
    }
    private async Task AnimateContainer(AnimationType type)
    {
        switch (type)
        {
            case AnimationType.In:
                await container.ScaleTo(1.5);
                break;
            case AnimationType.Out:
                await container.ScaleTo(0);
                break;
            default:
                await Pulse();
                break;
        }
        async Task Pulse()
        {
            await container.ScaleTo(1, 180);
            await container.ScaleTo(1.2, 180);
            await container.ScaleTo(1, 180);
        }
    }
    enum AnimationType
    {
        In,
        Out,
        Pulse
    }
    private static void OnCountChanged(BindableObject bindable, object oldValue, object newValue)
    {
        int oldCount = (int)oldValue;
        int newCount = (int)newValue;
        if (oldCount != newCount)
        {
            var cartControl = (CartControl)bindable;
            if (newCount < 1)
            {
                cartControl.AnimateContainer(AnimationType.Out);
            }
            else if (oldCount < 1 && newCount > 1)
            {
                cartControl.AnimateContainer(AnimationType.In);
            }
            else
            {
                cartControl.AnimateContainer(AnimationType.Pulse);
            }
        }
    }
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CartPage));
    }
}