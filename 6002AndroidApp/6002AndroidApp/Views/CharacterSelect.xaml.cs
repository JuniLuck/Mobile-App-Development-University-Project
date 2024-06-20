using _6002AndroidApp.Models;
using _6002AndroidApp.ViewModels;

namespace _6002AndroidApp.Views;

public partial class CharacterSelect : ContentPage
{
    public CharacterSelect(CharacterViewModel characterViewModel)
    {
        InitializeComponent();
        BindingContext = characterViewModel;
        MakeButtons(characterViewModel);
    }

    private async void MakeButtons(CharacterViewModel characterViewModel)
    {
        List<Character> chars = await Task.Run(() =>
        {
            return characterViewModel.GetAccountCharacters();
        });
        for (int i = 0; i<chars.Count; i++)
        {
            var idT = chars[i].Id;
            Button button = new Button
            {
                FontFamily = StaticValues.GlobalFont,
                FontSize = StaticValues.HomeFontSize,
                Text = chars[i].Name,
                BackgroundColor = Colors.Purple,
                Command = new Command(execute: async() => {
                    CharChosen(characterViewModel, idT);
                })
            };
            CharLayout.Add(button,1,(i+1));
            ImageButton delButton = new ImageButton
            {
                BackgroundColor = Colors.Red,
                Source = "bin.png",
                Command = new Command(execute: async () => {
                    DeleteChar(characterViewModel, idT);
                })
            };
            CharLayout.Add(delButton, 2, (i + 1));
            Image image = new Image
            {
                Source = chars[i].ImageURL,
            };
            CharLayout.Add(image,0,(i+1));
        }
    }

    public async void CharChosen(CharacterViewModel characterViewModel, int id)
    {
        await characterViewModel.ChooseCharacter(id);
    }

    public async void DeleteChar(CharacterViewModel characterViewModel, int id)
    {
        await characterViewModel.DeleteCharacter(id);
    }

    private async void NewCharacterButton(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("newcharacter");
    }
}