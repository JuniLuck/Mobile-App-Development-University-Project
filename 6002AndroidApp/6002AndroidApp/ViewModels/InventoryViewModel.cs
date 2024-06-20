using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6002AndroidApp.Models;
using _6002AndroidApp.Services;
using CommunityToolkit.Mvvm.Input;

namespace _6002AndroidApp.ViewModels
{
    public partial class InventoryViewModel : ObservableObject
    {
        private readonly IDataService _service;

        public ObservableCollection<Character> Characters { get; set; } = new();

        public InventoryViewModel(IDataService service)
        {
            _service = service;
        }


        public ObservableCollection<InventoryItem> Invent { get; set; } = new();

        [RelayCommand]
        public async Task GetInventory()
        {
            var inventory = await _service.GetInventory(Preferences.Default.Get("CharacterID",0));
            for (var i = 0; i < inventory.Count; i++)
            {
                Invent.Add(new InventoryItem
                {
                    Id = inventory[i].Id,
                    Name = inventory[i].Name,
                    Value = inventory[i].Value,
                    Weight = inventory[i].Weight
                });
            }
        }

        [RelayCommand]
        public async Task DeleteItem(int id)
        {
            for (var i = 0;i < Invent.Count;i++)
            {
                if (Invent[i].Id == id) { Invent.RemoveAt(i);}
            }
            await _service.DeleteInventoryItem(id);
        }

        [RelayCommand]
        public async Task AddItem()
        {   
            string name = await Application.Current.MainPage.DisplayPromptAsync("Item name",null);
            float value = float.Parse(await Application.Current.MainPage.DisplayPromptAsync("Item value", null, keyboard: Keyboard.Numeric));
            float weight = float.Parse(await Application.Current.MainPage.DisplayPromptAsync("Item weight", null, keyboard: Keyboard.Numeric));
            InventoryItem item = new()
            {
                Character_ID = Preferences.Default.Get("CharacterID", 0),
                Name = name,
                Value = value,
                Weight = weight
            };
            InventoryItem newItem = await _service.AddInventoryItem(item); 
            Invent.Add(new InventoryItem
            {
                Id = newItem.Id,
                Name = newItem.Name,
                Value = newItem.Value,
                Weight = newItem.Weight
            });

        }
    }
}
