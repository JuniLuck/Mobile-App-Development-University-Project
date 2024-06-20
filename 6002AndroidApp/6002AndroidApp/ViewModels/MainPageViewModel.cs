using _6002AndroidApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6002AndroidApp.Models;

namespace _6002AndroidApp.ViewModels
{
    public partial class MainPageViewModel
    {
        private readonly IDataService _service;

        public MainPageViewModel(IDataService service)
        {
            _service = service;
        }

        public async void GoToLogin()
        {
            if (Preferences.Default.Get("SignedIn", false) == false)
            {
                await Shell.Current.GoToAsync($"//{nameof(Views.LogIn)}");
            }
        }
        public async void SelectCharacter()
        {
            if (Preferences.Default.Get("SignedIn", false) == true)
            {
                string email = Preferences.Default.Get("email", "");
                string password = Preferences.Default.Get("password", "");
                await _service.CheckAccountLogIn(email, password);
            }
            if (Preferences.Default.Get("CharacterSelected", false) == false && Preferences.Default.Get("SignedIn", false) == true)
            {
                await Shell.Current.GoToAsync($"//{nameof(Views.CharacterSelect)}", false);
            }
        }
        public string AccountName
        {
            get { return Preferences.Get("AccountName", ""); }
        }
        public string CurrentCharacter
        {
            get { return Preferences.Get("CurrentCharacter", "Select Character"); }
        }
        public string CharacterImage
        {
            get { return Preferences.Get("CharacterImage", "logo.png"); }
        }
    }
}
