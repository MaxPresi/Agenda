using Contatos.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Contatos
{
    /// <summary>
    /// Lógica interna para NovoContato.xaml
    /// </summary>
    public partial class NovoContato : Window
    {
        
        public NovoContato()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            Contato contato = new Contato()
            {
                Nome = NomeTb.Text,
                Email = EmailTb.Text,
                Tel = TelTb.Text
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<Contato>();
                connection.Insert(contato);
            }

            Close();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
