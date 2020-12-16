using Acr.UserDialogs;
using Plugin.Geolocator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace ProjetoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        Pin pin;
        public Mapa()
        {
            InitializeComponent();
            Localizacao();
            map.MyLocationEnabled = true;
            map.UiSettings.MyLocationButtonEnabled = true;
        }

        public async void Localizacao()
        {
            UserDialogs.Instance.ShowLoading("Carregando...");
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(15));
            AddPin(position.Latitude, position.Longitude);
            UserDialogs.Instance.HideLoading();
        }

        public void AddPin(double latitude, double longitude)
        {
            pin = new Pin
            {
                Type = PinType.SearchResult,
                Position = new Position(latitude, longitude),
                Label = "Teste"
            };
            map.Pins.Add(pin);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMeters(1000)), true);
        }
    }
}