using Acr.UserDialogs;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ProjetoXamarin.Models;
using ProjetoXamarin.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Camera : ContentPage
    {
        public Camera()
        {
            InitializeComponent();
        }

        public void GetMedia(object obj, EventArgs e)
        {
            var actionSheetConfig = new ActionSheetConfig().SetTitle("Selecione um método").SetUseBottomSheet(true).SetCancel("Cancelar");
            actionSheetConfig.Add("Tirar Foto", new Action(() => { OpenCamera(); }), "camera.png");
            actionSheetConfig.Add("Selecionar uma imagem", new Action(() => { Galeria(); }), "camera.png");
            UserDialogs.Instance.ActionSheet(actionSheetConfig);
        }

        public async void OpenCamera()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
                {
                    await DisplayAlert("Ops", "Nenhuma câmera detectada.", "OK");

                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        Directory = "Demo",
                    });

                if (file == null)
                    return;

                imgFoto.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async void Galeria()
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                var imagem = await CrossMedia.Current.PickPhotoAsync();
                if (imagem != null)
                {
                    imgFoto.Source = ImageSource.FromStream(() =>
                    {
                        var stream = imagem.GetStream();
                        imagem.Dispose();
                        return stream;
                    });
                }
            }
        }

        public void OptionsImage(object obj, EventArgs e)
        {
            var actionSheetConfig = new ActionSheetConfig().SetTitle("Selecione uma opção").SetUseBottomSheet(true).SetCancel("Cancelar");
            actionSheetConfig.Add("Remover Foto", new Action(() => { imgFoto.Source = null; }));
            UserDialogs.Instance.ActionSheet(actionSheetConfig);
        }

        public async void GoToTextoPage(object obj, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MoedaPage()));
        }
        public async void GoToFormPage(object obj, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Formulario()));
        }
        public async void GoToLocalizacaoPage(object obj, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Localizacao()));
        }
    }
}