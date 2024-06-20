using _6002AndroidApp.Views;

namespace _6002AndroidApp;

public partial class AccountSettings : ContentPage
{
	public AccountSettings()
	{
		InitializeComponent();
	}
    private async void LogOutButton(object sender, EventArgs e)
    {
        Preferences.Default.Set("SignedIn", false);
        Preferences.Default.Set("AccountID", 0);
        Preferences.Default.Remove("email");
        Preferences.Default.Remove("password");
        Preferences.Default.Remove("AccountName");
        Preferences.Default.Remove("CharacterID");
        Preferences.Default.Remove("CurrentCharacter");
        Preferences.Default.Remove("CharacterImage");
        Preferences.Default.Remove("CharacterSelected");
        (Application.Current as App).MainPage = new AppShell();
    }
}