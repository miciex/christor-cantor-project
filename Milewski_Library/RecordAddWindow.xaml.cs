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
    /// Logika interakcji dla klasy BookAddWindow.xaml
    /// </summary>
    public partial class BookAddWindow : Window
    {
        public Record Book { get; set; }

        public BookAddWindow()
        {
            InitializeComponent();
            Book = new Record("", "", "", Record.Type.None, 0);
            DataContext = Book;
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book = new Record(authorTextBox.Text, titleTextBox.Text, genreTextBox.Text, Record.StringToRecordType(((ComboBoxItem)typeComboBox.SelectedItem).Content.ToString()), int.Parse(yearTextBox.Text));
                DialogResult = true;
            }
            catch (Exception)
            {
                errorMessage.Text = "Wszystkie pola są wymagane!";
            }
        }
    }
}
