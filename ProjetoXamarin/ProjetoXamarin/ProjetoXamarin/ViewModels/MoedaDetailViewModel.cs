using ProjetoXamarin.Models;

namespace ProjetoXamarin.ViewModels
{
    public class MoedaDetailViewModel : BaseViewModel
    {
        public Cambio Cambio { get; set; }
        public MoedaDetailViewModel(Cambio cambio = null)
        {
            Title = cambio?.Sigla;
            this.Cambio = cambio;
        }
    }
}
