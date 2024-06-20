using _6002AndroidApp.ViewModels;

namespace _6002AndroidApp.Views;

public partial class NewCharacter : ContentPage
{
	public NewCharacter(CharacterViewModel characterViewModel)
	{
		InitializeComponent();
		BindingContext = characterViewModel;
	}
}