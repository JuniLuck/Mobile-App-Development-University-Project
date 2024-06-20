using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6002AndroidApp.Models;
using _6002AndroidApp.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _6002AndroidApp.ViewModels
{
    public partial class CharacterViewModel
    {
        private readonly IDataService _service;

        public ObservableCollection<Character> Characters { get; set; } = new();

        public CharacterViewModel(IDataService service)
        {
            _service = service;
        }

        private string _NewCharName = "";
        public string NewCharName
        {
            get { return _NewCharName; }
            set { _NewCharName = value; }
        }

        [RelayCommand]
        public async Task GetCharacters()
        {
            Characters.Clear();

            try
            {
                var characters = await _service.GetCharacters();

                if (characters.Any())
                {
                    foreach (var character in characters)
                    {
                        Characters.Add(character);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task<List<Character>> GetAccountCharacters()
        {
            var chars = await _service.GetAccountCharacters();
            return chars;
        }

        [RelayCommand]
        public async Task<int> GetAccountQuantity()
        {
            var chars = await _service.GetAccountCharacters();
            return chars.Count;
        }

        [RelayCommand]
        public async Task NewCharacter()
        {
            try
            {
                if (await GetAccountQuantity() >= 7)
                {
                    await Shell.Current.DisplayAlert("Too many characters", "You must delete a character before creating more", "Ok");
                    return;
                }
                Character newChar = new()
                {
                    Name = NewCharName,
                };
                await _service.CreateNewCharacter(newChar);
                Character chara  = await _service.GetCharacter(newChar.Name);
                if(chara != null) 
                {
                    Preferences.Default.Set("CharacterID", chara.Id);
                    Preferences.Default.Set("CurrentCharacter", chara.Name);
                    Preferences.Default.Set("CharacterImage", chara.ImageURL);
                    Preferences.Default.Set("CharacterDescription", chara.Description);
                    Preferences.Default.Set("Stat1", chara.stat1);
                    Preferences.Default.Set("Stat2", chara.stat2);
                    Preferences.Default.Set("Stat3", chara.stat3);
                    Preferences.Default.Set("Stat4", chara.stat4);
                    Preferences.Default.Set("Stat5", chara.stat5);
                    Preferences.Default.Set("Stat6", chara.stat6);
                    Preferences.Default.Set("StatName1", chara.statName1);
                    Preferences.Default.Set("StatName2", chara.statName2);
                    Preferences.Default.Set("StatName3", chara.statName3);
                    Preferences.Default.Set("StatName4", chara.statName4);
                    Preferences.Default.Set("StatName5", chara.statName5);
                    Preferences.Default.Set("StatName6", chara.statName6);
                    if (Preferences.Default.Get("CharacterSelected",false) == true)
                    {
                        Preferences.Default.Set("CharacterSelected", true);
                        (Application.Current as App).MainPage = new AppShell();
                    }
                    else
                    {
                        Preferences.Default.Set("CharacterSelected", true);
                        App.Current.MainPage = new AppShell();
                    }
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task ChooseCharacter(int id)
        {
            Character chara = await _service.GetCharacterByID(id);
            if (chara != null)
            {
                if (Preferences.Default.Get("CharacterID", 0) != chara.Id)
                {
                    Preferences.Default.Set("CharacterID", chara.Id);
                    Preferences.Default.Set("CurrentCharacter", chara.Name);
                    Preferences.Default.Set("CharacterImage", chara.ImageURL);
                    Preferences.Default.Set("CharacterDescription", chara.Description);
                    Preferences.Default.Set("Stat1", chara.stat1);
                    Preferences.Default.Set("Stat2", chara.stat2);
                    Preferences.Default.Set("Stat3", chara.stat3);
                    Preferences.Default.Set("Stat4", chara.stat4);
                    Preferences.Default.Set("Stat5", chara.stat5);
                    Preferences.Default.Set("Stat6", chara.stat6);
                    Preferences.Default.Set("StatName1", chara.statName1);
                    Preferences.Default.Set("StatName2", chara.statName2);
                    Preferences.Default.Set("StatName3", chara.statName3);
                    Preferences.Default.Set("StatName4", chara.statName4);
                    Preferences.Default.Set("StatName5", chara.statName5);
                    Preferences.Default.Set("StatName6", chara.statName6);
                    if (Preferences.Default.Get("CharacterSelected", false) == true)
                    {
                        Preferences.Default.Set("CharacterSelected", true);
                        (Application.Current as App).MainPage = new AppShell();
                    }
                    else
                    {
                        Preferences.Default.Set("CharacterSelected", true);
                        (Application.Current as App).MainPage = new AppShell();
                    }
                }
                else { (Application.Current as App).MainPage = new AppShell(); }
            }
        }

        [RelayCommand]
        public async Task DeleteCharacter(int id)
        {
            if (id == Preferences.Default.Get("CharacterID", 0))
            {
                Preferences.Default.Set("CharacterSelected", false);
            }
            await _service.DeleteCharacter(id);
            (Application.Current as App).MainPage = new AppShell();
            await Shell.Current.GoToAsync($"//{nameof(Views.CharacterSelect)}", false);
        }
    }
}
