using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    using Models;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel : BaseViewModel
    {
        #region Attribute
        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;
        #endregion

        #region Properties
        public Land Land
        {
            get; set;
        }

        public ObservableCollection<Border> Borders
        {
            get { return borders; }
            set { SetValue(ref borders, value); }
        }

        public ObservableCollection<Currency> Currencies
        {
            get { return currencies; }
            set { SetValue(ref currencies, value); }
        }
        public ObservableCollection<Language> Languages
        {
            get { return languages; }
            set { SetValue(ref languages, value); }
        }
        #endregion

        #region constructor
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(Land.Currencies);
            this.Languages = new ObservableCollection<Language>(Land.Languages);
        }


        #endregion

        #region Methods
        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().
                    LandsList.Where(l => l.Alpha3Code == border).FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name,
                    });
                }
            }
        }
        #endregion
    }
}
