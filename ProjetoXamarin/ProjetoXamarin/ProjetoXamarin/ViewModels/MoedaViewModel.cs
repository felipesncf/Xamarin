using Acr.UserDialogs;
using ProjetoXamarin.Models;
using ProjetoXamarin.Services.Http;
using ProjetoXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetoXamarin.ViewModels
{
    class MoedaViewModel : BaseViewModel
    {
        public ObservableCollection<Cambio> Cambios { get; set; }
        public Cambio cambio;
        public TesteAPI api;
        public Command LoadItemsCommand { get; set; }

        public MoedaViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            GetCambio();
        }

        public async void GetCambio()
        {
            UserDialogs.Instance.ShowLoading("Carregando...");
            api = new TesteAPI();
            Cambios = new ObservableCollection<Cambio>();
            cambio = await api.GetCambios();
            foreach (var item in cambio.Cambios)
            {
                Cambios.Add(item);
            }
            UserDialogs.Instance.HideLoading();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Cambios.Clear();
                api = new TesteAPI();
                cambio = await api.GetCambios();
                foreach (var item in cambio.Cambios)
                {
                    Cambios.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
