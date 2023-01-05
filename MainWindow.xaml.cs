using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
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

namespace notatnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ZapiszClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog oknoZapisu = new SaveFileDialog();
            oknoZapisu.Filter = "PlainText | *.txt";
            oknoZapisu.Title = "Zapisz jako";
            if (oknoZapisu.ShowDialog() == true)
            {
                // zapisywanie do pliku
                File.WriteAllText(oknoZapisu.FileName,TextBox.Text);
                //TODO nazwa pliku jako nazwa okna
            }
        }

        private void OtworzClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oknoOtworz = new OpenFileDialog();
            oknoOtworz.Filter = "PlainText | *.txt";
            oknoOtworz.Title = "Otwieranie pliku";
            if(oknoOtworz.ShowDialog() == true)
            {
                //otwiranie pliku
                TextBox.Text = File.ReadAllText(oknoOtworz.FileName);
            }
        }

        private void NowyClick(object sender, RoutedEventArgs e)
        {
            /*
             sprawdz czy cos jest zapisane w textbox
            jezeli tak to zapytaj czy to wczesniej zapisywac
            zrob ewentualnie zapisywanie
            wyczysc textbox
             */
            if (TextBox.Text !=null)
            {
              MessageBoxResult czyZapisac= MessageBox.Show("Czy chcesz zapisać?", "Zapisać",MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (czyZapisac == MessageBoxResult.Yes)
                {
                    SaveFileDialog oknoZapisu = new SaveFileDialog();
                    oknoZapisu.Filter = "PlainText | *.txt";
                    oknoZapisu.Title = "Czy zapisać?";
                    if (oknoZapisu.ShowDialog() == true)
                    {
                        // zapisywanie do pliku
                        File.WriteAllText(oknoZapisu.FileName, TextBox.Text);
                        //TODO nazwa pliku jako nazwa okna
                        TextBox.Text = null;

                    }
                }
                else
                    TextBox.Clear();

            }
        }

        private void Zapisz2Click(object sender, RoutedEventArgs e)
        {
            //jezeli jeszcze nie zapisano to to samo co w zapisz jako
            //jezeli plik jest juz zapisany to tylko zapisujemy bez okna dialogu
        }

        private void AutorModalneClick(object sender, RoutedEventArgs e)
        {
            Window okno = new Window();
            okno.ShowDialog();
        }

        private void AutorNieModalneClick(object sender, RoutedEventArgs e)
        {
            Window okno = new Window();
            okno.Show();
        }

        private void InfoClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("testowanie operacji na plikach","Info o programie",MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CopyClick(object sender, RoutedEventArgs e)
        {
            TextBox.Copy();
        }

        private void CutClick(object sender, RoutedEventArgs e)
        {
            TextBox.Cut();
        }

        private void PasteClick(object sender, RoutedEventArgs e)
        {
            TextBox.Paste();
        }

        private void RedClick(object sender, RoutedEventArgs e)
        {
            TextBox.Foreground = Brushes.Red;
        }

        private void PlusClick(object sender, RoutedEventArgs e)
        {
            TextBox.FontSize += 1;
        }

        private void MinusClick(object sender, RoutedEventArgs e)
        {
            TextBox.FontSize -= 1;
        }

        private void DayAndNigthClick(object sender, RoutedEventArgs e)
        {
            if (dn!=checked())
            {
                TextBox.Background = Brushes.Black;
                TextBox.Foreground = Brushes.White;
            }
            else
            {
                TextBox.Background = Brushes.White;
                TextBox.Foreground = Brushes.Black;
            }
        }
    }
}
