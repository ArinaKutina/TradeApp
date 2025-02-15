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
using TradeApp.DB;

namespace TradeApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        TradeBaseEntities tradeBase = new TradeBaseEntities();
        int idUser {  get; set; }
        int idRole { get; set; }
        public ClientWindow(int UserID, int RoleID)
        {
            InitializeComponent();
            idUser = UserID;
            idRole = RoleID;
            ProductGrid.ItemsSource = tradeBase.Product.ToList();
        }

        private void AscentDescentPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
            var k = comboBox.SelectedIndex.ToString();

            switch (k)
            {
                case "0":
                    ProductGrid.ItemsSource = tradeBase.Product.ToList();
                    break;
                case "1":
                    ProductGrid.ItemsSource = tradeBase.Product.OrderBy(r=>r.ProductCost).ToList();
                    break;
                case "2":
                    ProductGrid.ItemsSource = tradeBase.Product.OrderByDescending(r => r.ProductCost).ToList();
                    break;
            }
        }

        private void ManufacturerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
            var k = comboBox.SelectedIndex.ToString();

            switch (k)
            {
                case "0":
                    ProductGrid.ItemsSource = tradeBase.Product.ToList();
                    break;
                case "1":
                    ProductGrid.ItemsSource = tradeBase.Product.Where(p=>p.ManufacturerID == 1).ToList();
                    break;
                case "2":
                    ProductGrid.ItemsSource = tradeBase.Product.Where(p => p.ManufacturerID == 2).ToList();
                    break;
            }
        }
    }
}
