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
    using Services;
    using Helpers;

    public class LoginViewModel : BaseViewModel
    {

        #region Services
        private ApiService apiService;
        #endregion

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
            this.apiService = new ApiService();

            this.IsRemembered = true;
            this.isEnabled = true;

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
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.passwordValidation,
                    Languages.Accept);
                return;
            }
            this.IsRuning = true;
            this.IsEnabled = false;

            if (this.Email != "pablo@gmail.com" || this.Password != "1234")
            {
                this.IsRuning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailPasswordValidation,
                    Languages.Accept);
                this.Password = string.Empty;
                return;
            }

            #region Code login with services
            /*var connection = await this.apiService.CheckConnection();
                if (!connection.IsSuccess)
                {
                    this.IsRuning = false;
                    this.IsEnabled = true;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        connection.Message,
                        "Aceptar");
                    return;
                }

                var token = await this.apiService.GetToken(
                "", 
                this.Email, 
                this.Password);

                 if(token == null)
                 {
                    this.IsRuning = false;
                    this.IsEnabled = true;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Somthing were wrong, please try again",
                        "Aceptar");
                        return;
                 }

                 if(string.IsNullOrEmpty(token.AccessToken))
                 {
                    this.IsRuning = false;
                    this.IsEnabled = true;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        token.ErrorDescription,
                        "Aceptar");
                    this.Password = string.Empty;
                    return;
                 }

                 var  mainViewModel = MainViewModel.GetInstance();
                 mainViewModel.Token = token;
                 mainViewModel.Lands = new LandsViewModel();
                 await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());*/ 
            #endregion

            this.IsRuning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.password = string.Empty;

            var mainViewModel = MainViewModel.GetInstance();
            //mainViewModel.Token = Token;
            mainViewModel.Lands = new LandsViewModel();
            Application.Current.MainPage = new MasterPage();
            
           /* MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
            */

        }
        #endregion
    }
}
