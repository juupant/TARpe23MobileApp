namespace E_Commerce
    using Pages;
{
    public partial class AppShell : Shell
    {
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
    }
    }

    
}
