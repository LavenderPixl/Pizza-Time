using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace PizzaDisplay
{
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : Window
    {
        DisplayViewModel viewModel = new();
        public Display()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void Indlæs_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "Select an Order file";
            ofd.Title = "Open Order file";
            ofd.InitialDirectory = @"C:\Users\Anna\source\repos\PizzaTime-master\PizzaTime-master\PizzaRUS\bin\Debug\net6.0-windows";
            ofd.Filter = "JSON documents (.json)|*.json";

            if (ofd.ShowDialog() == true)
            {
                var filePath = ofd.FileName;
                string fileText = File.ReadAllText(filePath);
                viewModel.OpenOrder(fileText);
            }
        }

        private void btn_orders_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Background = btn.Background == Brushes.Gray ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#ffded6")) : Brushes.Gray;
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (b != null)
                {
                    Bestilling o = (Bestilling)b.DataContext;
                    if (o != null)
                    {
                        viewModel.RemoveFromOrder(o);
                    }
                }
            }

        }

    }
}
