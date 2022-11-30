using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRUS
{
    public class Toppings
    {

        public int ID { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public Toppings(int iD, string name, double price)
        {
            ID = iD;
            Name = name;
            Price = price;
        }
    }
}
