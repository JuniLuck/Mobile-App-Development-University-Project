using _6002AndroidApp.ViewModels;

namespace _6002AndroidApp.Views;

public partial class Register : ContentPage
{
	public Register(LoginViewModel loginViewModel)
	{ 
		InitializeComponent();
		BindingContext = loginViewModel; 
	}
}