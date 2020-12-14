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
    public partial class Texto : ContentPage
    {
        public Texto()
        {
            InitializeComponent();
        }

        public async void CancelButton(object obj, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}