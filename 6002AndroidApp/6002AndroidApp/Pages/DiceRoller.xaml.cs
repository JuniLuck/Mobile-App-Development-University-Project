using _6002AndroidApp.ViewModels;

namespace _6002AndroidApp;

public partial class DiceRoller : ContentPage
{
	public DiceRoller(DiceViewModel diceViewModel)
	{
		InitializeComponent();
		BindingContext = diceViewModel;
	} 
}