using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using PizzaRUS;
using System.Diagnostics;
using System.ComponentModel;

namespace PizzaDisplay
{
    public class DisplayViewModel : INotifyPropertyChanged
    {
        int ID = 1;


        private ObservableCollection<Orders> orders;

        public ObservableCollection<Orders> Orders
        {
            get { return orders; }
            set { orders = value; OnPropertyChanged("Orders"); }
        }


        private ObservableCollection<Bestilling> bestillinger;

        public ObservableCollection<Bestilling> Bestillinger
        {
            get { return bestillinger; }
            set { bestillinger = value; OnPropertyChanged("Bestillinger"); }
        }



        public DisplayViewModel()
        {
            Orders = new ObservableCollection<Orders>();
            bestillinger = new ObservableCollection<Bestilling>();
        }
        public void OpenOrder(string fileText)
        {
            var OrdersPlaceholder = JsonConvert.DeserializeObject<ObservableCollection<Orders>>(fileText);
            Orders = OrdersPlaceholder;

            Bestillinger.Add(new Bestilling(ID++, new ObservableCollection<Orders> (Orders)));

            Debug.WriteLine("ooga booga");

        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }

    }
}
