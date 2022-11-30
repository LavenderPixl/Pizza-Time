using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRUS
{
    public class Orders : INotifyPropertyChanged
    {
        public int ID { get; private set; }
        public int Number { get; private set; }
        public string Name { get; private set; }
        
        private double price2;

        public double Price
        {
            get 
            { 
                return price2; 
            }
            set 
            { 
                price2 = value; 
                OnPropertyChanged("Price");
                OnPropertyChanged("ToppingsValues");
            }
        }

        public List<string> Info { get; private set; }

        private ObservableCollection<Toppings> toppings;
        public ObservableCollection<Toppings> Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                toppings = value;
                OnPropertyChanged("Toppings");
            }
        }

        public int OrderID { get; set; }


        public string ToppingsValues
        {
            get
            {
                return string.Join(", ", Toppings.Select(t => t.Name)); //Linq
            }
        }

        public Orders(int iD, int number, string name, double price, List<string> info, ObservableCollection<Toppings> toppings, int orderID)
        {
            ID = iD;
            Number = number;
            Name = name;
            Price = price;
            Info = info;
            Toppings = toppings;
            OrderID = orderID;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }

        public Orders Copy()
        {
            return new Orders(ID, Number, Name, Price, new List<string>(Info), new ObservableCollection<Toppings>(Toppings), OrderID);
        }
    }
}
