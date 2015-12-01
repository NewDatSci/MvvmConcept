using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MvvmConceptWPF.Model
{
    public interface IFoodItemsService
    {
        ObservableCollection<FoodItem> Refresh();
        bool Save(FoodItem updatedFoodItem);
    }
}
