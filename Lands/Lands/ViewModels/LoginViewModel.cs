using System;
using System.Collections.Generic;
using System.Text;


namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class LoginViewModel : BaseViewModel
    {

        

        #region Attributes
        private bool isRunnig;
        private string email;
        private string password;

        private bool isEnabled;
        #endregion

        #region properties
        public string Email 
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }

        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }

        public bool IsRuning
        {
            get { return isRunnig; }
            set { SetValue(ref isRunnig, value); }
        }

        public bool IsRemembered
        {
            get; set;
        }

        public bool IsEnabled {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;

            this.Email = "dom@gmail.com";
            this.Password = "1234";


        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        { 
            get
            {
                return new RelayCommand(Login);
            }
        }

        

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes insertar un Email",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes insertar su contrasena",
                    "Aceptar");
                return;
            }
            this.IsRuning = true;
            this.IsEnabled = false;
            if (this.Email != "dom@gmail.com" || this.Password != "1234")
            {
                this.IsRuning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email o contrasena incorrecta",
                    "Aceptar");
                this.Password = string.Empty;
                return;
            }
            
            this.IsRuning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.password = string.Empty;
            
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());


        }
        #endregion
    }
}
