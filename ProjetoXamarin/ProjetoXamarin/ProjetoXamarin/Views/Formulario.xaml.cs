using ProjetoXamarin.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Formulario : ContentPage
    {
        public Formulario()
        {
            InitializeComponent();
        }

        private bool ValidarNomeDoUsuario()
        {
            var isValid = (Nome.Text ?? "").Length > 0;

            var state = isValid ? "Valid" : "Invalid";

            VisualStateManager.GoToState(Nome, state);
            VisualStateManager.GoToState(NomeMsg, state);

            return isValid;
        }

        private bool ValidarEmailInformado()
        {
            string email = Email.Text ?? "";
            var isValid = email.Contains("@");

            var state = isValid ? "Valid" : "Invalid";

            VisualStateManager.GoToState(Email, state);
            VisualStateManager.GoToState(EmailMsg, state);

            return isValid;
        }

        private bool ValidarSenhaInformada()
        {
            string senha = Senha.Text ?? "";
            var isValid = senha.Length > 6;

            var state = isValid ? "Valid" : "Invalid";

            VisualStateManager.GoToState(Senha, state);
            VisualStateManager.GoToState(SenhaMsg, state);

            return isValid;
        }

        private void Nome_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarNomeDoUsuario();
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarEmailInformado();
        }

        private void Senha_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarSenhaInformada();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Pessoa pessoa = new Pessoa(Nome.Text, Email.Text, Senha.Text);
                DisplayAlert("Cadastrado", "Nome: "+pessoa.Nome+", Email: "+pessoa.Email+", Senha "+pessoa.Senha, "OK");
            }
            else
                DisplayAlert("Erro", "Por favor, verifique os campos informados.", "OK");
        }

        bool IsValid()
        {
            var nomeValid = ValidarNomeDoUsuario();
            var emailValid = ValidarEmailInformado();
            var senhaValid = ValidarSenhaInformada();

            return nomeValid && emailValid && senhaValid;
        }
    }
}