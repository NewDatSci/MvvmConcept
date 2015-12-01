using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace MvvmConceptWPF.Model
{
    public class FoodItemsService: IFoodItemsService
    {

        public bool hasError = false;
        public string errorMessage;

        private string conString = Properties.Settings.Default.FoodOrderConnectionString;

        public ObservableCollection<FoodItem> Refresh()
        {
            hasError = false;
            ObservableCollection<FoodItem> fooditems = new ObservableCollection<FoodItem>();
            try
            {
                FoodItemLINQDataContext dc = new FoodItemLINQDataContext();
                var query = from q in dc.MenuItems
                            select new sqlFoodItem
                            {
                                Id = q.ItemId, FoodName = q.FoodName, ItemPrice = Convert.ToDecimal(q.Price1)
                            };
                foreach (sqlFoodItem sp in query)
                    fooditems.Add(sp.sqlFoodItem2FoodItem());
            }
            catch(Exception ex)
            {
                errorMessage = "Refresh() error, " + ex.Message;
                hasError = true;
            }
            return fooditems;
        }

        public bool Save (FoodItem selectedFoodItem)
        {
            hasError = false;
            try
            {
                sqlFoodItem f = new sqlFoodItem(selectedFoodItem);
                FoodItemLINQDataContext dc = new FoodItemLINQDataContext();
                dc.UpdateFoodItem(selectedFoodItem.FoodName, selectedFoodItem.ItemPrice, selectedFoodItem.Id);
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
            return (!hasError);
        }
    }
}
