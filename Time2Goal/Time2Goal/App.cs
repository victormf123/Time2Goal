using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Time2Goal.Models;
using Time2Goal.View;

using Xamarin.Forms;

namespace Time2Goal
{
    public class App : Application
    {
    
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new LoginView());
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin", (usuario) =>
            {
                //MainPage = new NavigationPage(new Principal());
                MainPage = new MasterDetailView();
            });
            MessagingCenter.Subscribe<object>(this, "SucessoCad", (usuario) =>
            {
                MainPage = new NavigationPage(new CadastroView());
            });
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
