using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MvvmConcept.Model
{
    public class FoodItem: INotifyPropertyChanged
    {

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

        private double _itemprice;
        public double ItemPrice
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
    }
}
