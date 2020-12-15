using ProjetoXamarin.Models;
using ProjetoXamarin.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoedaPage : ContentPage
    {
        MoedaViewModel viewModel;
        ObservableCollection<Cambio> cambios = new ObservableCollection<Cambio>();
        public MoedaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MoedaViewModel();
            cambios = viewModel.Cambios;
        }

        public async void CancelButton(object obj, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Cambio;
            if (item == null)
                return;

            await Navigation.PushAsync(new MoedaDetailPage(new MoedaDetailViewModel(item)));

            // Manually deselect item.
            MoedasListView.SelectedItem = null;
        }

        public void FilterFunction(object sender, TextChangedEventArgs args)
        {
            var texto = SearchBarMoeda.Text.Replace(".", "").Replace(".", "");
            bool isNumber = Regex.IsMatch(texto, @"^\d{9}$");
            if (texto.All(char.IsDigit))
            {
                MoedasListView.ItemsSource = cambios.Where(x => x.Valor.ToString().Replace(".", "").Replace(".", "").Contains(texto));
            }
            else
            {
                MoedasListView.ItemsSource = cambios.Where(x => x.Sigla.ToLower().Contains(texto.ToLower()));
            }
        }
    }
}