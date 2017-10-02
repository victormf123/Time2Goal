using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using Time2Goal.Models;
using Time2Goal.View;
using Xamarin.Forms;

namespace Time2Goal.ViewModel
{
    public class LoginViewModel
    {
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntraCommand).ChangeCanExecute();
            }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntraCommand).ChangeCanExecute();
            }
        }

        public ICommand EntraCommand { get; private set; }
        public ICommand CadastrarCommand { get; private set; }

        public LoginViewModel()
        {
            var loginService = new LoginService();
            EntraCommand = new Command(async () =>
            {              
                await loginService.FazerLogin(new Login(usuario, senha));
            }, () =>
            {
                return !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha);


            });
        }
    }
}
