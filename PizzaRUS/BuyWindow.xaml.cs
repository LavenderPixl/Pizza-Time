using System.Collections.ObjectModel;
using System.Windows;

namespace PizzaRUS
{
    /// <summary>
    /// Interaction logic for Buy.xaml
    /// </summary>
    public partial class BuyWindow : Window
    {
        readonly BuyViewModel viewModel = new();

        public BuyWindow(ObservableCollection<Orders> orders, double FullPrice)
        {
            InitializeComponent();
            viewModel.Orders = orders;
            viewModel.fullprice = FullPrice;
            this.DataContext = viewModel;
        }


        private void btn_betal_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OrdersJson();
            this.DialogResult = true;
        }

        private void btn_fortryd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
