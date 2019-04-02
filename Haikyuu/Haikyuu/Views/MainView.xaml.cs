using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Haikyuu.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Haikyuu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
	{
        public MainView(Personaje parameter)
        {
            InitializeComponent();

            Name.Text = parameter.Name;
            Location.Text = parameter.Location;
            Details.Text = parameter.Details;
            numPuntuacion.Text = parameter.numPuntuacion;
            Foto.Source = parameter.Image;

            obtenirPuntuacio();

            sliderPuntuacion.ValueChanged += SliderPuntuacion_ValueChanged;

            BindingContext = App.Locator.MainViewModel;
        }

        private void obtenirPuntuacio()
        {
            List<Personaje> personaje;

            personaje = App.Database.GetItemsAsyncPersonaje().Result;
            personaje = personaje.Where(r => r.Name == Name.Text).ToList();

            Personaje psj = personaje.FirstOrDefault();

            numPuntuacion.Text = psj.numPuntuacion.ToString();
            sliderPuntuacion.Value = Double.Parse(psj.numPuntuacion);
        }

        private void SliderPuntuacion_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            numPuntuacion.Text = (Convert.ToInt32(sliderPuntuacion.Value)).ToString();

            List<Personaje> listaPersonaje;

            listaPersonaje = App.Database.GetItemsAsyncPersonaje().Result;

            Personaje personaje = listaPersonaje.Where(a => a.Name == Name.Text).FirstOrDefault();

            personaje.numPuntuacion = numPuntuacion.Text.ToString();

            App.Database.SaveItemAsyncPersonaje(personaje);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            //listView.ItemsSource = await App.Database.GetItemsAsync();

            List<Comentario> listaComentarios;

            listaComentarios = App.Database.GetItemsAsync().Result;

            listaComentarios = listaComentarios.Where( a => a.NameCharacter == Name.Text ).ToList();

            listView.ItemsSource = listaComentarios;


            List<Personaje> listaPersonaje;

            listaPersonaje = App.Database.GetItemsAsyncPersonaje().Result;

            Personaje personaje = listaPersonaje.Where(a => a.Name == Name.Text).FirstOrDefault();

            numPuntuacion.Text = personaje.numPuntuacion.ToString();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HaikyuuItemPage(Name.Text)
            {
                BindingContext = new Comentario()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID

            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new HaikyuuItemPage(Name.Text)
                {
                    BindingContext = e.SelectedItem as Comentario
                });
            }
        }
    }
}