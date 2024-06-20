using _6002AndroidApp.ViewModels;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using _6002AndroidApp.Views;

namespace _6002AndroidApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            mainPageViewModel.GoToLogin();
            mainPageViewModel.SelectCharacter();
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }
        private async void HomeCharacters(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Views.CharacterSelect)}");
        }
        private async void HomeDice(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(DiceRoller)}");
        }
        private async void HomeChar(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(CharacterSheet)}");
        }
        private async void HomeSpells(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(SpellBook)}");
        }
        private async void HomeNotes(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Notes)}");
        }
        private async void HomeInvent(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Inventory)}");
        }
        private async void HomeSett(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(AccountSettings)}");
        }
    }

}
