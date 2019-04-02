using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Haikyuu.Models;

namespace Haikyuu.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HaikyuuItemPage : ContentPage
	{
		string nombrePersonaje;

		public HaikyuuItemPage (string _nombrePersonaje)
		{
			InitializeComponent ();

			nombrePersonaje = _nombrePersonaje;

			Title = nombrePersonaje;
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
			var todoItem = (Comentario)BindingContext;

			todoItem.NameCharacter = nombrePersonaje;

			await App.Database.SaveItemAsync(todoItem);
			await Navigation.PopAsync();
		}

		async void OnDeleteClicked(object sender, EventArgs e)
		{
			var todoItem = (Comentario)BindingContext;

			todoItem.NameCharacter = nombrePersonaje;

			await App.Database.DeleteItemAsync(todoItem);
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}