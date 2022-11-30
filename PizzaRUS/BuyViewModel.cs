using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PizzaRUS
{
    public class BuyViewModel
    {
        public ObservableCollection<Orders> Orders { get; set; } = new();
        public double fullprice { get; set; }

        
    }
}
