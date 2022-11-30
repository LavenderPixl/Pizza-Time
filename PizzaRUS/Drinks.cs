using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRUS
{
    public class Drinks
    {
        public int ID { get; private set; }
        public int Number { get; set; }
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Drinks(int iD, int number, string name, double price)
        {
            ID = iD;
            Number = number;
            Name = name;
            Price = price;
        }
    }
    
}
