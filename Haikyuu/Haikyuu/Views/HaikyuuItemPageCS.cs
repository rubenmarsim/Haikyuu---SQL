using Xamarin.Forms;

using Haikyuu.Models;

namespace Haikyuu.Views
{
    public class HaikyuuItemPageCS : ContentPage
    {
        public HaikyuuItemPageCS()
        {
            Title = "Haikyuu Item";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var comment = (Comentario)BindingContext;
                await App.Database.SaveItemAsync(comment);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var comment = (Comentario)BindingContext;
                await App.Database.DeleteItemAsync(comment);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                    notesEntry,
                    saveButton,
                    deleteButton,
                    cancelButton
                }
            };
        }
    }
}
