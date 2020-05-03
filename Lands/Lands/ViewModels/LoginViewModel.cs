using System;
using System.Collections.Generic;
using System.Text;


namespace Lands.ViewModels
{
    
    using System.Windows.Input;
    
    public class LoginViewModel
    {
        #region properties
        public string Email 
        { 
            get; set; 
        }

        public string Passwrod
        {
            get; set;
        }

        public bool IsRuning
        {
            get; set;
        }

        public bool IsRemembered
        {
            get; set;
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        { 
            get; set; 
        }
        #endregion
    }
}
