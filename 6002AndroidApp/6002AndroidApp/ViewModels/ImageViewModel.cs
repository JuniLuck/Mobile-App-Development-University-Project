using _6002AndroidApp.Models;
using _6002AndroidApp.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6002AndroidApp.ViewModels
{
    public partial class ImageViewModel
    {
        private readonly IDataService _service;

        public ObservableCollection<Character> Characters { get; set; } = new();

        public ImageViewModel(IDataService service)
        {
            _service = service;
        }

        [RelayCommand]
        public async Task ImageChosen1()
        {
            await Imaging("character_image_1.png");
        }
        [RelayCommand]
        public async Task ImageChosen2()
        {
            await Imaging("character_image_2.png");
        }
        [RelayCommand]
        public async Task ImageChosen3()
        {
            await Imaging("character_image_3.png");
        }
        [RelayCommand]
        public async Task ImageChosen4()
        {
            await Imaging("character_image_4.png");
        }
        [RelayCommand]
        public async Task ImageChosen5()
        {
            await Imaging("character_image_5.png");
        }
        [RelayCommand]
        public async Task ImageChosen6()
        {
            await Imaging("character_image_6.png");
        }
        [RelayCommand]
        public async Task ImageChosen7()
        {
            await Imaging("default_char.png");
        }


        public async Task Imaging(string image)
        {
            Preferences.Default.Set("CharacterImage", image);
            await _service.UpdateImage(image, Preferences.Default.Get("CharacterID", 0));
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync($"//{nameof(CharacterSheet)}");
        }
    }
}
