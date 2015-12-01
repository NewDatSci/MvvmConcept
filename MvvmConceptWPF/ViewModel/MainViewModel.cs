using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MvvmConceptWPF.Model;
using MvvmConceptWPF.Helpers;
using System.Threading.Tasks;
using System.Windows;
using System;


namespace MvvmConceptWPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {

        private IFoodItemsService _dataService;
        private IDialogService _dialogService;
        private INavigationService _navigationService;

        public ObservableCollection<FoodItem> FoodItems
        {
            get;
            private set;
        }

        public MainViewModel(
            IFoodItemsService dataService,
            IDialogService dialogService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _navigationService = navigationService;
            FoodItems = new ObservableCollection<FoodItem>();
        }

        public MainViewModel()
            :this(
                 new FoodItemsService(),
                 new DialogService(),
                 new NavigationService())
        {

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
                if (_selectedFoodItem == value)
                {
                    return;
                }
                _selectedFoodItem = value;
                RaisePropertyChanged("SelectedFoodItem");
            }
        }

    private RelayCommand _refreshCommand;

    public RelayCommand RefreshCommand
    {
        get
        {
            return _refreshCommand
                ?? (_refreshCommand = new RelayCommand(
                   () => Refresh()));
        }
    }

    private void Refresh()
    {
        FoodItems.Clear();

        var fooditems = _dataService.Refresh();

        foreach (var fooditem in fooditems)
        {
            FoodItems.Add(fooditem);
        }

    }

    private RelayCommand<FoodItem> _saveCommand;

    public RelayCommand<FoodItem> SaveCommand
    {
        get
        {
            return _saveCommand
                ?? (_saveCommand = new RelayCommand <FoodItem> (
                    fooditem =>
                    {
                        try
                        {
                            var service = _dataService;
                            var result = service.Save(fooditem);

                            if (!result)
                            {
                                _dialogService.ShowMessage("Error");
                            }
                        }
                        catch (Exception ex)
                        {
                            _dialogService.ShowMessage(ex.Message);
                        }

                    }));
        }
    }

    private RelayCommand<FoodItem> _showDetailsCommand;

    public  RelayCommand<FoodItem> showDetailsCommand
    {
        get
        {
            return _showDetailsCommand
                ?? (_showDetailsCommand = new RelayCommand<FoodItem>(
                                        fooditem =>
                                        {
                                            SelectedFoodItem = fooditem;
                                            _navigationService.NavigateTo();
                                        }
                    ));
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
