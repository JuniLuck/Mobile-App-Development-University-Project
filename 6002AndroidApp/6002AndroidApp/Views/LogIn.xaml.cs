using Supabase;
using _6002AndroidApp.Models;
using _6002AndroidApp;
using Supabase.Interfaces;
using System.Security.Cryptography.X509Certificates;
using _6002AndroidApp.Services;
using System.Collections.ObjectModel;
using _6002AndroidApp.ViewModels;

namespace _6002AndroidApp.Views;

public partial class LogIn : ContentPage
{
    public LogIn(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        BindingContext = loginViewModel;
    }

    private async void RegisterButton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("register");
    }
}