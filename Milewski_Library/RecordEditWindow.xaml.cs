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

namespace Wolska_BookManager
{
    /// <summary>
    /// Logika interakcji dla klasy BookEditWindow.xaml
    /// </summary>
    public partial class BookEditWindow : Window
    {
        public Record Book { get; set; }

        public BookEditWindow()
        {
            InitializeComponent();
            InitializeTypeComboBox();
            Book = new Record("", "", "", Record.Type.None, 0);
            DataContext = Book;
        }

        public BookEditWindow(Record book)
        {
            InitializeComponent();
            InitializeTypeComboBox();
            Book = book;
            DataContext = Book;
            typeComboBox.SelectedItem = Record.TypeToString(Book.RecordType);
        }

        private void InitializeTypeComboBox()
        {
            typeComboBox.Items.Add("Film");
            typeComboBox.Items.Add("Book");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string type = typeComboBox.SelectedItem.ToString();
            Book.RecordType = Record.StringToRecordType(type);
            DialogResult = true;
        }
    }
}
