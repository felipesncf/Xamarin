using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjetoXamarin.Models;
using ProjetoXamarin.ViewModels;

namespace ProjetoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoedaDetailPage : ContentPage
    {
        MoedaDetailViewModel viewModel;
        public MoedaDetailPage(MoedaDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public MoedaDetailPage()
        {
            InitializeComponent();

            var item = new Cambio
            {
                Sigla = "Nenhum item selecionado",
                Valor = 0
            };

            viewModel = new MoedaDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}