using Haikyuu.Models;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Haikyuu.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SplashPage : ContentPage
	{
		Image splashImage;
		public SplashPage ()
		{
			InitializeComponent();


			List<Personaje> listaPersonaje;

			listaPersonaje = App.Database.GetItemsAsyncPersonaje().Result;

			if (listaPersonaje.Count == 0)
			{
				Personaje personaje1 = new Personaje();

				personaje1.Name = "Flash";
				personaje1.Location = "Supervelocidad";
				personaje1.Details = "La historia se basa en el superhéroe de DC Comics, Flash, específicamente en Barry Allen, el segundo individuo en tomar dicha identidad. Se trata además de un spin-off de Arrow, serie de televisión basada en Flecha Verde, por lo cual comparten el mismo universo de ficción";
				personaje1.numPuntuacion = "5";
				personaje1.Image = "https://www.technobuffalo.com/wp-content/uploads/2016/06/The-Flash-200x200.jpg";

				App.Database.SaveItemAsyncPersonaje(personaje1);


				Personaje personaje2 = new Personaje();

				personaje2.Name = "Superman";
				personaje2.Location = "OP";
				personaje2.Details = "Superman (cuyo nombre kryptoniano es Kal-El y su nombre terrestre es Clark Kent) es un personaje ficticio, un superhéroe de los cómics que aparece en las publicaciones de DC Comics";
				personaje2.numPuntuacion = "5";
				personaje2.Image = "https://screenanarchy.com/assets_c/2017/05/superman-the-movie-1978-photo-01-630-thumb-860xauto-39193-thumb-200x200-66859.jpg";

				App.Database.SaveItemAsyncPersonaje(personaje2);


				Personaje personaje3 = new Personaje();

				personaje3.Name = "Batman";
				personaje3.Location = "Es rico";
				personaje3.Details = "Batman (conocido inicialmente como The Bat-Man) es un personaje creado por los estadounidenses Bob Kane y Bill Finger,4​ y propiedad de DC Comics";
				personaje3.numPuntuacion = "5";
				personaje3.Image = "https://www.technobuffalo.com/wp-content/uploads/2015/04/batman-suit-002-200x200.jpg";

				App.Database.SaveItemAsyncPersonaje(personaje3);


				Personaje personaje4 = new Personaje();

				personaje4.Name = "Wonder Woman";
				personaje4.Location = "Super vuelo, súper fuerza, inmortalidad, factor de curación, super velocidad, reflejos, resistencia, brazaletes que repelen cualquier tipo de arma, habilidad de lucha altamente desarrollada y posee un lazo mágico";
				personaje4.Details = "La Mujer Maravilla (en inglés: Wonder Woman) es una superheroína ficticia creada por William Moulton Marston para la editorial DC Comics";
				personaje4.numPuntuacion = "5";
				personaje4.Image = "https://todatecnologia.com/wp-content/uploads/2016/07/Wonder-Woman-200x200.jpg";

				App.Database.SaveItemAsyncPersonaje(personaje4);


				Personaje personaje5 = new Personaje();

				personaje5.Name = "Linterna Verde";
				personaje5.Location = "Uso de la luz para crear objetos";
				personaje5.Details = "Linterna Verde (en inglés: Green Lantern) es el alias de varios superhéroes de la ficción del Universo DC";
				personaje5.numPuntuacion = "5";
				personaje5.Image = "https://images-eu.ssl-images-amazon.com/images/I/412X7C8-G+L._AC_US200_.jpg";

				App.Database.SaveItemAsyncPersonaje(personaje5);


				Personaje personaje6 = new Personaje();

				personaje6.Name = "Aquaman";
				personaje6.Location = "Dominio del agua";
				personaje6.Details = "Aquaman (cuyo verdadero nombre es Arthur Curry) es un superhéroe que aparece en los cómics estadounidenses publicados por DC Comics";
				personaje6.numPuntuacion = "5";
				personaje6.Image = "https://todatecnologia.com/wp-content/uploads/2017/03/Jason-Momoa-como-Aquaman-200x200.jpg";

				App.Database.SaveItemAsyncPersonaje(personaje6);
				
			}



			NavigationPage.SetHasNavigationBar(this, false);

			var sub = new AbsoluteLayout();
			splashImage = new Image
			{
				Source = "bgDC.jpg",
				Aspect = Aspect.Fill,
				WidthRequest = 380
			};

			AbsoluteLayout.SetLayoutFlags(splashImage,
				AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(splashImage,
				new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			sub.Children.Add(splashImage);

			this.BackgroundColor = Color.FromHex("#4286f4");
			this.Content = sub;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await splashImage.ScaleTo(1, 2000);
			//await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
			//await splashImage.ScaleTo(150, 1200, Easing.Linear);
			Application.Current.MainPage = new NavigationPage(new CustomCellView(null));
		}

	}
}