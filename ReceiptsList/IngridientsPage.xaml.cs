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
    /// Логика взаимодействия для IngridientsPage.xaml
    /// </summary>
    public partial class IngridientsPage : Page
    {
        public IngridientsPage()
        {
            InitializeComponent();
            using (var context = new DatabaseFirstReceiptsAgeevContext())
            {
                ingridientsListView.ItemsSource = context.Ingridients
                    .Include(i => i.ReceiptIngridients)
                    .ThenInclude(ri => ri.ReceiptNavigation)
                    .ToList();
            }
        }

        private void searchIngridients(object sender, TextChangedEventArgs e)
        {
            using (var context = new DatabaseFirstReceiptsAgeevContext())
            {
                if (searchBox.Text.Length != 0)
                {
                    ingridientsListView.ItemsSource = context.Ingridients
                    .Include(i => i.ReceiptIngridients)
                    .ThenInclude(ri => ri.ReceiptNavigation)
                    .Where(i => i.Name.Contains(searchBox.Text))
                    .ToList();
                }
                else
                {
                    ingridientsListView.ItemsSource = context.Ingridients
                    .Include(i => i.ReceiptIngridients)
                    .ThenInclude(ri => ri.ReceiptNavigation)
                    .ToList();
                }
            }
        }
    }
}
