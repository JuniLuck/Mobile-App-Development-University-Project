using System.ComponentModel;

namespace _6002AndroidApp.Controls;

public class BindingControls : ContentView
{
    public static readonly BindableProperty SignedInProperty = BindableProperty.Create(
		nameof(SignedIn),
		typeof(bool),
		typeof(BindingControls),
		false);

	public bool SignedIn
	{
		get => (bool)GetValue(SignedInProperty);
		set => SetValue(SignedInProperty, value);
	}
}