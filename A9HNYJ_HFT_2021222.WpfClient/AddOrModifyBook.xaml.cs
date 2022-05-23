using A9HNYJ_HFT_2021221.Models;
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

namespace A9HNYJ_HFT_2021222.WpfClient
{
    /// <summary>
    /// Interaction logic for AddOrModifyBook.xaml
    /// </summary>
    public partial class AddOrModifyBook : Window
    {
        public Book ChosenBook { get => (this.DataContext as Book); }
        public AddOrModifyBook()
        {
            InitializeComponent();
        }
        public AddOrModifyBook(Book Book): this()
        {
            this.DataContext = Book;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
