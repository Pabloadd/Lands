using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {

        #region Constructor
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            LoadLands();
        }
        #endregion

        #region Services
        private ApiService apiService;
        #endregion

        #region Methods
        private async void LoadLands()
        {
            var response = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");
            
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
            }
            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
        } 
        #endregion

        #region Attributes
        private ObservableCollection<Land> lands;

        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get { return lands; }
            set { SetValue(ref lands, value); }
        }
    
        #endregion
    }
}
