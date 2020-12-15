using ProjetoXamarin.Models;
using ProjetoXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoedaPage : ContentPage
    {
        MoedaViewModel viewModel;
        public MoedaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MoedaViewModel();
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
            ItemsListView.SelectedItem = null;
        }
    }
}