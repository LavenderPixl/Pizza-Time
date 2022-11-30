using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PizzaRUS
{
    public class BuyViewModel
    {
        public ObservableCollection<Orders> Orders { get; set; } = new();
        public double fullprice { get; set; }

        public void OrdersJson()
        {
            var PizzaJson = JsonConvert.SerializeObject(Orders, Formatting.Indented);
            File.WriteAllText("Orders.json", PizzaJson);
        }
        
    }
}
