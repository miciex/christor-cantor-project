using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Wolska_BookManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Record> records = new List<Record>();

        public MainWindow()
        {
            InitializeComponent();
            LoadData(); 
        }

        private void LoadData()
        {
            records.Add(new Record("Bracia Karamazow", "Fiodor Dostojewski", "psychologiczny", Record.Type.Book, 1880));
            records.Add(new Record("Foundation", "Isaac Asimov", "science fiction", Record.Type.Book, 1951));
            records.Add(new Record("Władca Pierścieni", "J.R.R. Tolkien", "fantasy", Record.Type.Book, 1954));
            records.Add(new Record("Dune", "Frank Herbert", "science fiction", Record.Type.Book, 1965));
            records.Add(new Record("1984", "George Orwell", "dystopia", Record.Type.Book, 1949));
            records.Add(new Record("Zbrodnia i kara", "Fiodor Dostojewski", "psychologiczny", Record.Type.Book, 1866));
            records.Add(new Record("Wojna i pokój", "Lew Tołstoj", "historyczny", Record.Type.Book, 1869));
            records.Add(new Record("Fight Club", "David Ficher", "Dark Comedy", Record.Type.Film, 1999));
            records.Add(new Record("Pulp Fiction", "Quentin Tarantino", "Crime", Record.Type.Film, 1994));
            records.Add(new Record("The Godfather", "Francis Ford Coppola", "Crime", Record.Type.Film, 1972));
            records.Add(new Record("The Shawshank Redemption", "Frank Darabont", "Drama", Record.Type.Film, 1994));
            records.Add(new Record("The Dark Knight", "Christopher Nolan", "Action", Record.Type.Film, 2008));


            bookDataGrid.ItemsSource = records;
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            BookAddWindow addWindow = new BookAddWindow();
            addWindow.ShowDialog();
            if (addWindow.DialogResult == true)
            {
                records.Add(addWindow.Book);
                bookDataGrid.Items.Refresh();
            }
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (bookDataGrid.SelectedItem != null)
            {
                Record selectedBook = (Record)bookDataGrid.SelectedItem;
                BookEditWindow bookWindow = new BookEditWindow(selectedBook);
                bookWindow.ShowDialog();
                if (bookWindow.DialogResult == true)
                {
                    int index = records.IndexOf(selectedBook);
                    records[index] = bookWindow.Book;
                    bookDataGrid.Items.Refresh();
                }
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (bookDataGrid.SelectedItem != null)
            {
                Record selectedBook = (Record)bookDataGrid.SelectedItem;
                records.Remove(selectedBook);
                bookDataGrid.Items.Refresh();
            }
        }
        private void ExportToTXT_Click(object sender, RoutedEventArgs e)
        {
            ExportToFile("TXT Files (*.txt)|*.txt", ExportToText);
        }

        private void ExportToCSV_Click(object sender, RoutedEventArgs e)
        {
            ExportToFile("CSV Files (*.csv)|*.csv", ExportToCSV);
        }

        private void ExportToFile(string filter, Action<string> exportMethod)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    exportMethod(saveFileDialog.FileName);
                    MessageBox.Show("Lista recodów została pomyślnie wyeksportowana.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas eksportowania listy recordów: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ExportToText(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var book in records)
                {
                    writer.WriteLine($"Tytuł: {book.Title}, Autor: {book.Author}, Gatunek: {book.Genre}, Typ: {Record.TypeToString(book.RecordType)}, Rok wydania: {book.Year}");
                }
            }
        }
        private void ExportToCSV(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("Tytuł,Autor,Gatunek,Typ,Rok wydania,Liczba tomów");
                foreach (var book in records)
                {
                    writer.WriteLine($"{book.Title},{book.Author},{book.Genre},{Record.TypeToString(book.RecordType)},{book.Year}");
                }
            }
        }
    }
}