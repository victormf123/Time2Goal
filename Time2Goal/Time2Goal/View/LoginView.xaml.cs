using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time2Goal.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Time2Goal.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin", async (exc) =>
            {
                await DisplayAlert("Atenção!", exc.Message, "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }


        private void cadastrar(object sender, EventArgs e)
        {

            Navigation.PushAsync(new CadastroView());
        }
    }
}