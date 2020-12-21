using Contatos.Classes;
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

namespace Contatos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contato> contatos;
        public MainWindow()
        {
            InitializeComponent();
            contatos = new List<Contato>();
            LerDB();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NovoContato novoContato = new NovoContato();
            novoContato.ShowDialog();

            LerDB();
        }

        void LerDB()
        {            
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dbPath))
            {
                conn.CreateTable<Contato>();
                contatos = (conn.Table<Contato>().ToList()).OrderBy(c => c.Nome).ToList();
            }

            if (contatos != null)
            {
                ContatosLV.ItemsSource = contatos;                
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox buscaTb = sender as TextBox;

            var filtroLista = contatos.Where(c => c.Nome.ToLower().Contains(buscaTb.Text.ToLower())).ToList();

            ContatosLV.ItemsSource = filtroLista;
        }

        private void ContatosLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contato selContato = (Contato)ContatosLV.SelectedItem;

            if(selContato != null)
            {
                Detalhes detalhes = new Detalhes(selContato);
                detalhes.ShowDialog();

                LerDB();
            }

        }
    }
}
