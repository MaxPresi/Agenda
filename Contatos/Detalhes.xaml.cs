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
    /// Lógica interna para Detalhes.xaml
    /// </summary>
    public partial class Detalhes : Window
    {
        Contato contato;
        public Detalhes(Contato contato)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.contato = contato;

            NomeTb.Text = contato.Nome;
            EmailTb.Text = contato.Email;
            TelTb.Text = contato.Tel;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir esse contato?" + "\n" + "Ele não poderá ser recuperado depois!!!", "Tem certeza disso?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
                {
                    connection.CreateTable<Contato>();
                    connection.Delete(contato);
                    Close();
                }
            }
            
        }

        private void upBtn_Click(object sender, RoutedEventArgs e)
        {
            contato.Nome = NomeTb.Text;
            contato.Email = EmailTb.Text;
            contato.Tel = TelTb.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<Contato>();
                connection.Update(contato);
            }

            Close();
        }
    }
}
