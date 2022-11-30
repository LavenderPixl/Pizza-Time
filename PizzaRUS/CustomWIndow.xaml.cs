using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PizzaRUS
{
    /// <summary>
    /// Interaction logic for Custom.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        public CustomViewModel viewModel;
        private bool _closedManually;

        public CustomWindow(ObservableCollection<Pizza> Pizza, double Price, CustomViewModel customViewModel, Orders order)
        {
            InitializeComponent();            
            viewModel = customViewModel;
            DataContext = viewModel;
            viewModel.pizza = Pizza;
            viewModel.selected = order;         //Changed Pizza
            viewModel.fortryd = order.Copy();   //Original Pizza
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            viewModel.RemovePresetToppings();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (!_closedManually)
            {
                viewModel.Fortryd();
            }
            base.OnClosed(e);
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            _closedManually = true;
            DialogResult = true;
        }

        private void btn_OffPizza_Click(object sender, RoutedEventArgs e) //Button for left side, aka adding to the pizza
        {
            Button b = (Button)sender;
            if (b != null) 
            {
                Toppings SelectedTopping = (Toppings)b.DataContext;
                if (SelectedTopping != null)
                {
                    viewModel.AddTopping(SelectedTopping);
                }
            }
        }

        private void btn_OnPizza_Click(object sender, RoutedEventArgs e) //Button for right side, aka taking off of on pizza
        {
            Button b = (Button)sender;
            if (b != null)
            {
                Toppings SelectedTopping = (Toppings)b.DataContext;
                if (SelectedTopping != null)
                {
                    viewModel.RemoveTopping(SelectedTopping);
                }
            }            
        }        

        private void btn_Fortryd_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fortryd();
            this.Close();
        }
    }
}
