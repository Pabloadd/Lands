using System;

using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Lands.ViewModels
{
    using System.Collections.Generic;
    using Models;
    public class MainViewModel 
    {
        #region constructor
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        } 
        #endregion

        #region ViewModels
        public LoginViewModel Login { get; set; }
        
        public LandsViewModel Lands { get; set; }

        public LandViewModel Land { get; set; }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return instance;
        }
        #endregion

        #region Properties
        public List<Land> LandsList
        { 
            get; 
            set; 
        }
        #endregion
    }
}