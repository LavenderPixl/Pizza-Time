using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRUS
{
    public class Tilbehør
    {

        public int ID { get; private set; }
        public int Number { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public List<string> Info { get; private set; }
        public Tilbehør (int iD, int number, string name, double price, List<string> info)
        {
            ID = iD;
            Number = number;
            Name = name;
            Price = price;
            Info = info;
        }
    }
}
