using _6002AndroidApp.ViewModels;

namespace _6002AndroidApp.Views;

public partial class ChooseImage : ContentPage
{
	public ChooseImage(ImageViewModel imageViewModel)
	{
		InitializeComponent();
		BindingContext = imageViewModel;
	}
}