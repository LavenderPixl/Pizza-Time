using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRUS
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        readonly DAL dal;
        private int OrderID;
        public ObservableCollection<Pizza> VM_PizzaDataBase { get; set; }
        public ObservableCollection<Drinks> VM_DrinksDataBase { get; set; }
        public ObservableCollection<Tilbehør> VM_TilbehørDataBase { get; set; }
        public ObservableCollection<Orders> VM_OrdersDataBase { get; set; }

        private double _FullPrice;

        public double FullPrice
        {
            get 
            { 
                return _FullPrice; 
            }
            set 
            { _FullPrice = value;
                OnPropertyChanged("FullPrice");
            }
        }

        public void Slet()
        {
            VM_OrdersDataBase.Clear();
            FullPrice = 0;
        }

        public MainWindowViewModel()
        {
            dal = new DAL();
            VM_PizzaDataBase = dal.GetPizzas();
            VM_DrinksDataBase = dal.GetDrinks();
            VM_TilbehørDataBase = dal.GetTilbehør();
            VM_OrdersDataBase = new ObservableCollection<Orders>();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }

        public void UpdateOrder(Orders order)
        {
            var oldOrder = VM_OrdersDataBase.FirstOrDefault(o => o.OrderID.Equals(order.OrderID));
            if (oldOrder != null)
                VM_OrdersDataBase[VM_OrdersDataBase.IndexOf(oldOrder)] = order;
        }


        public void AddToOrderPizza(Pizza pizza)
        {
            VM_OrdersDataBase.Add(new Orders(pizza.ID, pizza.Number, pizza.Name, pizza.Price, new List<string>(), new ObservableCollection<Toppings> (pizza.Toppings), OrderID++));
            FullPrice += pizza.Price;
        }
        public void AddToOrderTilbehør(Tilbehør tilbehør)
        {
            VM_OrdersDataBase.Add(new Orders(tilbehør.ID, tilbehør.Number, tilbehør.Name, tilbehør.Price, tilbehør.Info, new ObservableCollection<Toppings>(), OrderID++));
            FullPrice += tilbehør.Price;
        }
        public void AddToOrderDrinks(Drinks drinks)
        {
            VM_OrdersDataBase.Add(new Orders(drinks.ID, drinks.Number, drinks.Name, drinks.Price, new List<string>(), new ObservableCollection<Toppings>(), OrderID++));
            FullPrice += drinks.Price;
        }

        public void RemoveFromOrder(Orders orders)
        {
            VM_OrdersDataBase.Remove(orders);
            FullPrice -= orders.Price;
        }
    }
}
