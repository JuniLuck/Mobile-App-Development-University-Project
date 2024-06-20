using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6002AndroidApp.Services;
using _6002AndroidApp.Models;
using System.Collections.ObjectModel;

namespace _6002AndroidApp.ViewModels
{
    public partial class SheetViewModel
    {
        private readonly IDataService _service;

        public ObservableCollection<Character> Accounts { get; set; } = new();

        public SheetViewModel(IDataService service)
        {
            _service = service;
        }
        
        private string _charImg = Preferences.Default.Get("CharacterImage", "logo.png");
        private string _charName = Preferences.Default.Get("CurrentCharacter", "No Character");
        private string _charDesc = Preferences.Default.Get("CharacterDescription", "");
        private int _stat1 = Preferences.Default.Get("Stat1", 0);
        private int _stat2 = Preferences.Default.Get("Stat2", 0);
        private int _stat3 = Preferences.Default.Get("Stat3", 0);
        private int _stat4 = Preferences.Default.Get("Stat4", 0);
        private int _stat5 = Preferences.Default.Get("Stat5", 0);
        private int _stat6 = Preferences.Default.Get("Stat6", 0);
        private string _statName1 = Preferences.Default.Get("StatName1", "");
        private string _statName2 = Preferences.Default.Get("StatName2", "");
        private string _statName3 = Preferences.Default.Get("StatName3", "");
        private string _statName4 = Preferences.Default.Get("StatName4", "");
        private string _statName5 = Preferences.Default.Get("StatName5", "");
        private string _statName6 = Preferences.Default.Get("StatName6", "");

        public string CharImg
        {
            get { return _charImg; }
            set { _charImg = value; }
        }

        public string CharName
        {
            get { return _charName; }
            set { _charName = value; }
        }

        public string CharDesc
        {
            get { return _charDesc; }
            set { _charDesc = value; }
        }

        public int Stat1
        {
            get { return _stat1; }
            set { _stat1 = value; }
        }
        public int Stat2
        {
            get { return _stat2; }
            set { _stat2 = value; }
        }
        public int Stat3
        {
            get { return _stat3; }
            set { _stat3 = value; }
        }
        public int Stat4
        {
            get { return _stat4; }
            set { _stat4 = value; } 
        }
        public int Stat5
        {
            get { return _stat5; }
            set { _stat5 = value; } 
        }
        public int Stat6
        {
            get { return _stat6; }
            set { _stat6 = value; } 
        }
        public string StatName1
        {
            get { return _statName1; }
            set { _statName1 = value; } 
        }
        public string StatName2
        {
            get { return _statName2; }
            set { _statName2 = value; }
        }
        public string StatName3
        {
            get { return _statName3; }
            set { _statName3 = value; }
        }
        public string StatName4
        {
            get { return _statName4; }
            set { _statName4 = value; }
        }
        public string StatName5
        {
            get { return _statName5; }
            set { _statName5 = value; }
        }
        public string StatName6
        {
            get { return _statName6; }
            set { _statName6 = value; }
        }



        [RelayCommand]
        public async Task SaveChanges()
        {
            Character chara = new Character();
            chara.Name = CharName;
            chara.ImageURL = CharImg;
            chara.Description = CharDesc;
            chara.stat1 = Stat1;
            chara.stat2 = Stat2;
            chara.stat3 = Stat3;
            chara.stat4 = Stat4;
            chara.stat5 = Stat5;
            chara.stat6 = Stat6;
            chara.statName1 = StatName1;
            chara.statName2 = StatName2;
            chara.statName3 = StatName3;
            chara.statName4 = StatName4;
            chara.statName5 = StatName5;
            chara.statName6 = StatName6;
            await _service.UpdateCharacter(chara, Preferences.Default.Get("CharacterID",0));
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
            Application.Current.MainPage = new AppShell();
        }

        [RelayCommand]
        public async Task ChooseImage()
        {
            await Shell.Current.GoToAsync("chooseimage");
        }
    }
}
