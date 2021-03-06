﻿using System;

using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Lands.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;
    using Helpers;
    public class MainViewModel 
    {
        #region constructor
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
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

        public TokenResponse Token
        {
            get;
            set;
        }

        public ObservableCollection<MenuItemViewModel> Menus 
        { 
            get; 
            set; 
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_account",
                PageName = "MyProfilePage",
                Title = Languages.MyProfile,
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_chart",
                PageName = "StatisticsPage",
                Title = Languages.Statistics,
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit",
                PageName = "LoginPage",
                Title = Languages.Logout,
            });
        }
        #endregion
    }
}