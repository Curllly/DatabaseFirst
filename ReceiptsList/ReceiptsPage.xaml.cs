using Microsoft.EntityFrameworkCore;
using ReceiptsList.Database;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReceiptsList
{
    /// <summary>
    /// Логика взаимодействия для ReceiptsPage.xaml
    /// </summary>
    public partial class ReceiptsPage : Page
    {
        public ReceiptsPage()
        {
            InitializeComponent();
            using (var context = new DatabaseFirstReceiptsAgeevContext())
            {
                receiptsItemsControl.ItemsSource = context
                    .Receipts
                    .Include(r => r.ReceiptIngridients)
                    .ThenInclude(ri => ri.IngridientNavigation)
                    .ToList();
            }
        }

        private void searchReceipts(object sender, TextChangedEventArgs e)
        {
            using (var context = new DatabaseFirstReceiptsAgeevContext())
            {
                if (searchBox.Text.Length != 0)
                {
                    receiptsItemsControl.ItemsSource = context
                    .Receipts
                    .Include(r => r.ReceiptIngridients)
                    .ThenInclude(ri => ri.IngridientNavigation)
                    .Where(r => r.Name.Contains(searchBox.Text))
                    .ToList();
                }
                else
                {
                    receiptsItemsControl.ItemsSource = context
                    .Receipts
                    .Include(r => r.ReceiptIngridients)
                    .ThenInclude(ri => ri.IngridientNavigation)
                    .ToList();
                }
            }
        }
    }
}
