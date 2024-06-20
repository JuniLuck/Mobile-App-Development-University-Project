using _6002AndroidApp.ViewModels;

namespace _6002AndroidApp;

public partial class CharacterSheet : ContentPage
{
	public CharacterSheet(SheetViewModel sheetViewModel)
	{
		InitializeComponent();
		BindingContext = sheetViewModel;
	}
}