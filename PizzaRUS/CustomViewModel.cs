using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace PizzaRUS
{

    public class CustomViewModel : INotifyPropertyChanged
    {
        readonly DAL dal = new DAL();
        public ObservableCollection<Pizza> pizza { get; set; } = new();
        public ObservableCollection<Toppings> Toppings { get; set; } = new();

        List<string> names = new List<string>();

        public Orders fortryd;

        private Orders Selected;
        public Orders selected //Shows the selected pizzas' topping
        {
            get
            {
                return Selected;
            }
            set
            {
                Selected = value;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }


        public CustomViewModel()
        {
            Toppings = dal.GetToppings();
        }

        public void RemovePresetToppings()
        {
            var toppingToRemove = new HashSet<Toppings>();

            foreach (var topping in Toppings)
            {
                if (selected.Toppings.Any(t => t.ID.Equals(topping.ID)))
                    toppingToRemove.Add(topping);
            }

            foreach (var topping in toppingToRemove)
            {
                Toppings.Remove(topping);
            }
        }

        public void AddTopping(Toppings SelectedTopping) //Removes Toppings from left side(Not on pizza) to right side (On pizza)
        {
            
            Toppings.Remove(SelectedTopping);
            selected.Toppings.Add(SelectedTopping);
            selected.Price += SelectedTopping.Price;
        }
        public void RemoveTopping(Toppings SelectedTopping) //Adds Topping selected from right side (On pizza), to left side (Not on pizza)
        {
            
            if (selected.Toppings.Count > 1)
            { 
                selected.Toppings.Remove(SelectedTopping);
                Toppings.Add(SelectedTopping);
                selected.Price -= SelectedTopping.Price;
            }

        }
        public void Fortryd()
        {
            selected = fortryd;
        }
    }


}
