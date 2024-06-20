using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6002AndroidApp.Models;
using _6002AndroidApp.Services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Supabase;

namespace _6002AndroidApp.ViewModels
{
    public partial class LoginViewModel
    {
        private readonly IDataService _service;

        public ObservableCollection<Account> Accounts { get; set; } = new();

        public LoginViewModel(IDataService service)
        {
            _service = service;
        }

        private string _AccountEmail = "";
        public string AccountEmail
        {
            get { return _AccountEmail; }
            set { _AccountEmail = value; }
        }

        private string _AccountPassword = "";
        public string AccountPassword
        {
            get { return _AccountPassword; }
            set { _AccountPassword = value; }
        }


        private string _NewAccountEmail = "";
        public string NewAccountEmail
        {
            get { return _NewAccountEmail; }
            set { _NewAccountEmail = value; }
        }

        private string _NewAccountUsername = "";
        public string NewAccountUsername
        {
            get { return _NewAccountUsername; }
            set { _NewAccountUsername = value; }
        }

        private string _NewAccountPassword1 = "";
        public string NewAccountPassword1
        {
            get { return _NewAccountPassword1; }
            set { _NewAccountPassword1 = value; }
        }

        private string _NewAccountPassword2 = "";
        public string NewAccountPassword2
        {
            get { return _NewAccountPassword2; }
            set { _NewAccountPassword2 = value; }
        }

        [RelayCommand]
        public async Task GetAccounts()
        {
            Accounts.Clear();

            try
            {
                var accounts = await _service.GetAccounts();

                if (accounts.Any())
                {
                    foreach(var account in accounts)
                    {
                        Accounts.Add(account);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task CheckAccountLogIn()
        {
            try
            {
                await _service.CheckAccountLogIn(AccountEmail, AccountPassword);
                var acc = await _service.FetchAccount();
                if (acc != null)
                {
                    Preferences.Default.Set("email", AccountEmail);
                    Preferences.Default.Set("password", AccountPassword);
                    Preferences.Default.Set("SignedIn", true);
                    Preferences.Default.Set("AccountID", acc.AccountId);
                    Preferences.Default.Set("AccountName", acc.Username);
                    Preferences.Default.Remove("CharacterID");
                    Preferences.Default.Remove("CurrentCharacter");
                    Preferences.Default.Remove("CharacterImage");
                    Preferences.Default.Remove("CharacterSelected");
                    (Application.Current as App).MainPage = new AppShell();
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task CreateAccount()
        {
            try 
            {
                if (NewAccountUsername == string.Empty || NewAccountPassword1 == string.Empty) { await Shell.Current.DisplayAlert("Error", "Please fill all fields", "Try again"); return; }
                else if (NewAccountPassword1 != NewAccountPassword2) { await Shell.Current.DisplayAlert("Error", "Passwords do not match", "Try again"); return; }
                else if (await _service.CheckForAccount(NewAccountUsername)) { await Shell.Current.DisplayAlert("Error", "That username is already taken", "Try again"); return;  }

                {
                    await _service.NewAccount(NewAccountEmail, NewAccountUsername, NewAccountPassword1);
                    Account acc = await _service.FetchAccount();
                    Preferences.Default.Set("email", NewAccountEmail);
                    Preferences.Default.Set("password", NewAccountPassword1);
                    Preferences.Default.Set("SignedIn", true);
                    Preferences.Default.Set("AccountID", acc.AccountId);
                    Preferences.Default.Set("AccountName", acc.Username);
                    Preferences.Default.Remove("CharacterID");
                    Preferences.Default.Remove("CurrentCharacter");
                    Preferences.Default.Remove("CharacterImage");
                    Preferences.Default.Remove("CharacterSelected");
                    (Application.Current as App).MainPage = new AppShell();

                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
