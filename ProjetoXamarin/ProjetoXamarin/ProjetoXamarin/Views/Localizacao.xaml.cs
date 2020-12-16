using Acr.UserDialogs;
using Plugin.Geolocator;
using ProjetoXamarin.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Localizacao : ContentPage
    {
        public Localizacao()
        {
            InitializeComponent();
        }

        private async void GetPosition(object sender, EventArgs e)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando...");
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(15));
                LongitudeLabel.Text = string.Format("{0:0.0000000}", position.Longitude);
                LatitudeLabel.Text = string.Format("{0:0.0000000}", position.Latitude);
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void Mapa(object obj, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Mapa()));
        }
    }
}