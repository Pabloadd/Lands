using System;
using Xamarin.Forms.Xaml;

namespace Lands
{
    using Views;
    using Xamarin.Forms;
    public partial class App : Application
    {
        #region Properties
        public static NavigationPage Navigator { get; internal set; } 
        #endregion

        #region Constructor
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

            //this.MainPage = new MasterPage();
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        } 
        #endregion
    }
}
