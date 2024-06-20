using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using _6002AndroidApp.Models;
using Supabase;
using Supabase.Gotrue;
using Supabase.Interfaces;

namespace _6002AndroidApp.Services
{
    public class DataService : IDataService
    {
        private readonly Supabase.Client _service;
        public DataService(Supabase.Client service)
        {
            _service = service;
        }

        //Account

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var response = await _service.From<Account>().Get();
            return response.Models.OrderByDescending(x => x.AccountId);
        }

        public async Task CheckAccountLogIn(string email, string pass)
        {
            await _service.Auth.SignIn(email, pass);
        }

        public async Task<bool> CheckForAccount(string user)
        {
            var accs = await _service.From<Account>()
                .Where(u => u.Username == user).Get();
            if (accs.Models.Count == 0) { return false; }
            else { return true; }
        }

        public async Task NewAccount(string email, string username, string pass)
        {
            var ses1 = await _service.Auth.SignUp(email, pass);
            await _service.Auth.SignIn(email, pass);
            var user = _service.Auth.CurrentUser;
            Account acc = new();
            acc.Username = username;
            acc.AccountId = user.Id;
            await _service.From<Account>().Insert(acc);
        }

        public async Task<Account> FetchAccount()
        {
            var user = _service.Auth.CurrentUser;
            var accs = await _service.From<Account>()
                .Where(u => u.AccountId == user.Id).Get();
            Account acc = accs.Models[0];
            return acc;
        }

        //Character

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            var response = await _service.From<Character>().Get();
            return response.Models.OrderByDescending(x => x.Id);
        }
        public async Task<List<Character>> GetAccountCharacters()
        {
            var user = _service.Auth.CurrentUser;
            var chars = await _service.From<Character>()
                .Where(c => c.AccountID == user.Id).Get();
            return chars.Models;
        }
        public async Task CreateNewCharacter(Character newChar)
        {
            var user = _service.Auth.CurrentUser;
            newChar.AccountID = user.Id;
            if (newChar.ImageURL == null) { newChar.ImageURL = "logo.png"; }
            await _service.From<Character>().Insert(newChar);
        }
        public async Task<Character> GetCharacter(string name)
        {
            var user = _service.Auth.CurrentUser;
            var chars = await _service.From<Character>()
                .Where(c => c.AccountID == user.Id)
                .Where(c => c.Name == name).Get();
            Character chara = chars.Models[0];
            return chara;
        }
        public async Task<Character> GetCharacterByID(int id)
        {
            var chars = await _service.From<Character>()
                .Where(c => c.Id == id).Get();
            Character chara = chars.Models[0];
            return chara;
        }
        public async Task UpdateCharacter(Character chara, int id)
        {
            await _service.From<Character>().Where(c => c.Id == id)
                .Set(c => c.Name, chara.Name)
                .Set(c => c.ImageURL, chara.ImageURL)
                .Set(c => c.Description, chara.Description)
                .Set(c => c.statName1, chara.statName1)
                .Set(c => c.statName2, chara.statName2)
                .Set(c => c.statName3, chara.statName3)
                .Set(c => c.statName4, chara.statName4)
                .Set(c => c.statName5, chara.statName5)
                .Set(c => c.statName6, chara.statName6)
                .Set(c => c.stat1, chara.stat1)
                .Set(c => c.stat2, chara.stat2)
                .Set(c => c.stat3, chara.stat3)
                .Set(c => c.stat4, chara.stat4)
                .Set(c => c.stat5, chara.stat5)
                .Set(c => c.stat6, chara.stat6)
                .Update();
        }
        public async Task DeleteCharacter(int id)
        {
            await _service.From<Character>()
                .Where(c => c.Id == id)
                .Delete();
        }
        public async Task UpdateImage(string image, int id)
        {
            await _service.From<Character>().Where(c => c.Id == id)
                .Set(c => c.ImageURL, image)
                .Update();
        }

        //inventory

        public async Task<List<InventoryItem>> GetInventory(int id)
        {
            var items = await _service.From<InventoryItem>()
                .Where(i => i.Character_ID == id).Get();
            return items.Models;
        }
        public async Task DeleteInventoryItem(int id)
        {
            await _service.From<InventoryItem>()
                .Where(i => i.Id == id)
                .Delete();
        }
        public async Task<InventoryItem> AddInventoryItem(InventoryItem item)
        {
            await _service.From<InventoryItem>().Insert(item);
            var newItem = await _service.From<InventoryItem>()
                .Where(i => i.Character_ID == item.Character_ID)
                .Where(i => i.Name == item.Name).Get();
            return newItem.Models[0];
        }
    }
}
