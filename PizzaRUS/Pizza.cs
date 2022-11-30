using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRUS
{
    public class Pizza
    {
        public int ID { get; private set; } 
        public string Name { get; private set; }
        public double Price { get; private set; }   
        public int Number { get; private set; }
        public ObservableCollection<Toppings> Toppings { get; private set; }

        public Pizza(int iD, string name, int number, double price, ObservableCollection<Toppings> Toppings)
        {
            ID = iD;
            Number = number;
            Name = name;
            Price = price;
            this.Toppings = Toppings;
        }
        public string ToppingsValues
        {
            get
            {
                return string.Join(", ", Toppings.Select(t => t.Name)); //Linq
            }
        }
    }
}
