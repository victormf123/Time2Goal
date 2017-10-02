using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Time2Goal.Models;
using Time2Goal.View;
using Xamarin.Forms;

namespace Time2Goal
{
   public class LoginService
    {
        public async Task FazerLogin( Login login)
        {
            
                using (var cliente = new HttpClient())
                {
                    var camposFormulario = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("email", login.email),
                        new KeyValuePair<string, string>("senha", login.senha)
                    });
                    cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");

                    HttpResponseMessage resultado = null;
                    try
                    {
                        resultado = await cliente.PostAsync("/login", camposFormulario);

                    }
                    catch
                    {
                        MessagingCenter.Send<LoginException>(new LoginException(@"Ocooreu um erro de comunicação com o servidor.
por favor verifique a sua conexão e tente novamente mais tarde!"), "FalhaLogin");
                    }
                if (resultado.IsSuccessStatusCode)
                        MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
                    else
                        MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha incorretos"), "FalhaLogin");
                }
            
           
        }

        public async Task cadastrar()
        {
            MessagingCenter.Send<object>(this, "SucessoCad");
        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
            
        }
    }
}
