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
    /// Interaction logic for AddOrModifyAuthor.xaml
    /// </summary>
    public partial class AddOrModifyAuthor : Window
    {
        public Author ChosenAuthor { get => (this.DataContext as Author);}
        public AddOrModifyAuthor()
        {
            InitializeComponent();
            this.DataContext = new Author();
        }
        public AddOrModifyAuthor(Author author): this()
        {
            this.DataContext = author;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
