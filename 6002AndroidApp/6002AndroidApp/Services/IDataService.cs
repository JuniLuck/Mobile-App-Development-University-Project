using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6002AndroidApp.Models;

namespace _6002AndroidApp.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task CheckAccountLogIn(string email, string pass);
        Task<bool> CheckForAccount(string user);
        Task NewAccount(string email, string username, string pass);
        Task<Account> FetchAccount();

        Task<IEnumerable<Character>> GetCharacters();
        Task<List<Character>> GetAccountCharacters();
        Task CreateNewCharacter(Character newChar);
        Task<Character> GetCharacter(string name);
        Task<Character> GetCharacterByID(int id);
        Task UpdateCharacter(Character chara, int id);
        Task DeleteCharacter(int id);
        Task UpdateImage(string image, int id);

        Task<List<InventoryItem>> GetInventory(int id);
        Task DeleteInventoryItem(int id);
        Task<InventoryItem> AddInventoryItem(InventoryItem item);
    }
}
