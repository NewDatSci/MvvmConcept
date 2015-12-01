using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MvvmConcept.Model;


namespace MvvmConcept.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {

        private IFoodItemsService _dataService;

        public ObservableCollection<FoodItem> FoodItems
        {
            get;
            private set;
        }

        public MainViewModel(IFoodItemsService dataService)
        {
            _dataService = dataService;
            FoodItems = new ObservableCollection<FoodItem>();
        }

        private FoodItem _selectedFoodItem;

        public FoodItem SelectedFoodItem
        {
            get
            {
                return _selectedFoodItem;
            }
            set
            {
                if(_selectedFoodItem == value)
                {
                    return;
                }
                _selectedFoodItem = value;
                RaisePropertyChanged("SelectedFoodItem");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
