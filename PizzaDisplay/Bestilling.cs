using PizzaRUS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDisplay
{
    public class Bestilling
    {
        public int Nummer { get; set; }
        public ObservableCollection<Orders> Orders { get; set; }

        public Bestilling(int Nummer, ObservableCollection<Orders> Orders)
        {
            this.Nummer = Nummer;
            this.Orders = Orders;
        }
    }
}
