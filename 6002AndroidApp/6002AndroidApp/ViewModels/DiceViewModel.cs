using CommunityToolkit.Mvvm.Input;
using _6002AndroidApp;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design.Serialization;

namespace _6002AndroidApp.ViewModels
{
    public partial class DiceViewModel : ObservableObject
    {
        Random random = new Random();

        [ObservableProperty]
        public string total = "0";

        [RelayCommand]
        public void Reset()
        {
            Total = "0";
        }

        [ObservableProperty]
        public Color d20col = Colors.Magenta.AddLuminosity((float)-0.2);

        [ObservableProperty]
        public string d20val = "20";

        [RelayCommand]
        public async Task D20Roll()
        {
            int num;
            D20col = Colors.Magenta;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(25 * i);
                num = random.Next(1, 21);
                D20val = num.ToString();
                D20col = D20col.AddLuminosity((float)-0.02);
            }
            Total = (int.Parse(Total) + int.Parse(D20val)).ToString();
        }

        [ObservableProperty]
        public Color d12col = Colors.Magenta.AddLuminosity((float)-0.2);

        [ObservableProperty]
        public string d12val = "12";

        [RelayCommand]
        public async Task D12Roll()
        {
            D12col = Colors.Magenta;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(25 * i);
                int num = random.Next(1, 13);
                D12val = num.ToString();
                D12col = D12col.AddLuminosity((float)-0.02);
            }
            Total = (int.Parse(Total) + int.Parse(D12val)).ToString();
        }

        [ObservableProperty]
        public Color d10col = Colors.Magenta.AddLuminosity((float)-0.2);

        [ObservableProperty]
        public string d10val = "10";

        [RelayCommand]
        public async Task D10Roll()
        {
            D10col = Colors.Magenta;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(25 * i);
                int num = random.Next(1, 11);
                D10val = num.ToString();
                D10col = D10col.AddLuminosity((float)-0.02);
            }
            Total = (int.Parse(Total) + int.Parse(D10val)).ToString();
        }

        [ObservableProperty]
        public Color d8col = Colors.Magenta.AddLuminosity((float)-0.2);

        [ObservableProperty]
        public string d8val = "8";

        [RelayCommand]
        public async Task D8Roll()
        {
            D8col = Colors.Magenta;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(25 * i);
                int num = random.Next(1, 9);
                D8val = num.ToString();
                D8col = D8col.AddLuminosity((float)-0.02);
            }
            Total = (int.Parse(Total) + int.Parse(D8val)).ToString();
        }

        [ObservableProperty]
        public Color d6col = Colors.Magenta.AddLuminosity((float)-0.2);

        [ObservableProperty]
        public string d6val = "6";

        [RelayCommand]
        public async Task D6Roll()
        {
            D6col = Colors.Magenta;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(25 * i);
                int num = random.Next(1, 7);
                D6val = num.ToString();
                D6col = D6col.AddLuminosity((float)-0.02);
            }
            Total = (int.Parse(Total) + int.Parse(D6val)).ToString();
        }

        [ObservableProperty]
        public Color d4col = Colors.Magenta.AddLuminosity((float)-0.2);

        [ObservableProperty]
        public string d4val = "4";

        [RelayCommand]
        public async Task D4Roll()
        {
            D4col = Colors.Magenta;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(25 * i);
                int num = random.Next(1, 5);
                D4val = num.ToString();
                D4col = D4col.AddLuminosity((float)-0.02);
            }
            Total = (int.Parse(Total) + int.Parse(D4val)).ToString();
        }
    }
}