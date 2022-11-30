using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PizzaRUS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MainWindowViewModel viewModel = new();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void btn_Køb_Click(object sender, RoutedEventArgs e) //Buy button - Shows the Buy tab.
        {
            if (viewModel.VM_OrdersDataBase.Count != 0)
            {
                BuyWindow buy = new BuyWindow(viewModel.VM_OrdersDataBase, viewModel.FullPrice);

                if (buy.ShowDialog() == true)
                {
                    viewModel.Slet();
                }
            }
        }

        private void btn_CustomPizza_Click(object sender, RoutedEventArgs e) //Makes new, customizable pizza.
        {


        }
        private void btn_Edit_Click(object sender, RoutedEventArgs e) //Edit button - Shows the Custom page, specified Pizza can be edited.
        {
            if (sender is Button b)
            {
                if (b.DataContext is Orders order)
                    if (order.Toppings.Count > 0)
                    {
                        {
                            var customViewModel = new CustomViewModel();
                            CustomWindow custom = new CustomWindow(viewModel.VM_PizzaDataBase, viewModel.FullPrice, customViewModel, order);
                            custom.ShowDialog();


                            viewModel.FullPrice = 0;
                            for (int i = 0; i < viewModel.VM_OrdersDataBase.Count; i++) //Adds the price of items in Order, to FullPrice.
                            {
                                viewModel.FullPrice += customViewModel.selected.Price;
                            }
                            viewModel.UpdateOrder(customViewModel.selected);
                        }
                    }
            }
        }

        private void btn_Pizza_Click(object sender, RoutedEventArgs e) //Adds pizza to the order
        {
            Button b = (Button)sender;
            if (b != null)
            {
                Pizza o = (Pizza)b.DataContext;
                if (o != null)
                {
                    viewModel.AddToOrderPizza(o);
                }
            }
        }

        private void btn_Tilbehør_Click(object sender, RoutedEventArgs e) //Adds sides to the order
        {
            Button b = (Button)sender;
            if (b != null)
            {
                Tilbehør o = (Tilbehør)b.DataContext;
                if (o != null)
                {
                    viewModel.AddToOrderTilbehør(o);
                }
            }
        }

        private void btn_Drinks_Click(object sender, RoutedEventArgs e) //Adds drinks to the order
        {
            Button b = (Button)sender;
            if (b != null)
            {
                Drinks o = (Drinks)b.DataContext;
                if (o != null)
                {
                    viewModel.AddToOrderDrinks(o);
                }
            }
        }


        private void btn_Delete(object sender, MouseButtonEventArgs e) //Takes item off of the order
        {
            Button b = (Button)sender;
            if (b != null)
            {
                Orders o = (Orders)b.DataContext;
                if (o != null)
                {
                    viewModel.RemoveFromOrder(o);
                    viewModel.FullPrice = 0;
                    for (int i = 0; i < viewModel.VM_OrdersDataBase.Count; i++) //Looks at 
                    {
                        viewModel.FullPrice += viewModel.VM_OrdersDataBase[i].Price;
                    }
                }
            }
        }
    }
}
