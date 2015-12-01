using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using MvvmConceptWPF.ViewModel;

namespace MvvmConceptWPF.Model
{
    public class FoodItem: INotifyPropertyChanged
    {

        public int Id
        {
            get;
            set;
        }

        private string _foodname;
        
        public string FoodName
        {
            get
            {
                return _foodname;
            }

            set
            {
                if (_foodname == value)
                {
                    return;
                }
                _foodname = value;
                RaisePropertyChanged("FoodName");
            }
        }

        private decimal _itemprice;
        public decimal ItemPrice
        {
            get
            {
                return _itemprice;
            }

            set
            {
                if (_itemprice == value)
                {
                    return;
                }
                _itemprice = value;
                RaisePropertyChanged("ItemPrice");
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

        public FoodItem()
        {
        }

        public FoodItem(int id, string foodName, decimal itemPrice)
        {
            Id = id;
            FoodName = foodName;
            ItemPrice = itemPrice;
        }

        public void CopyProduct(FoodItem f)
        {
            this.Id = f.Id;
            this.FoodName = f.FoodName;
            this.ItemPrice = f.ItemPrice;
        }
    }

    public class sqlFoodItem
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public decimal ItemPrice { get; set; }

        public sqlFoodItem() { }

        public sqlFoodItem(int id, string foodName, decimal itemPrice)
        {
            Id = id;
            FoodName = foodName;
            ItemPrice = itemPrice;
        }

        public sqlFoodItem(FoodItem f)
        {
            Id = f.Id;
            FoodName = f.FoodName;
            ItemPrice = f.ItemPrice;
        }

        public FoodItem sqlFoodItem2FoodItem()
        {
            return new FoodItem(Id,FoodName,ItemPrice);
        } //sqlFoodItem2FoodItem()

    }
}
