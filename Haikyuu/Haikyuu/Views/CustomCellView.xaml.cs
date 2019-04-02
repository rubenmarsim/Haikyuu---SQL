using System;
using Haikyuu.Models;
using Haikyuu.ViewModels;
using Xamarin.Forms;

namespace Haikyuu.Views
{
    public partial class CustomCellView : ContentPage
    {
        private object Parameter { get; set; }

        public CustomCellView(object parameter)
        {
            InitializeComponent();

            ListaPersonajes.ItemSelected += ListaPersonajes_ItemSelected;
            BindingContext = App.Locator.CustomCellViewModel;

            Parameter = parameter;
        }

        private void ListaPersonajes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new MainView((Personaje)e.SelectedItem));
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as CustomCellViewModel;
            if (viewModel != null) viewModel.OnAppearing(Parameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as CustomCellViewModel;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}
