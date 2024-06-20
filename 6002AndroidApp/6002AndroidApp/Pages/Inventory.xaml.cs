using _6002AndroidApp.ViewModels;

namespace _6002AndroidApp;

public partial class Inventory : ContentPage
{
	public Inventory(InventoryViewModel inventoryViewModel)
	{
		InitializeComponent();
		BindingContext = inventoryViewModel;
        inventoryViewModel.GetInventory();
	}
}