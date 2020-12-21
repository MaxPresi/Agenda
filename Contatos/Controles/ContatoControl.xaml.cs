using Contatos.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Contatos.Controles
{
    /// <summary>
    /// Interação lógica para ContatoControl.xam
    /// </summary>
    public partial class ContatoControl : UserControl
    {


        public Contato Contato
        {
            get { return (Contato)GetValue(ContatoProperty); }
            set { SetValue(ContatoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contato.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContatoProperty =
            DependencyProperty.Register("Contato", typeof(Contato), typeof(ContatoControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContatoControl controle = d as ContatoControl;
            if (controle != null)
            {
                controle.NameTb.Text = (e.NewValue as Contato).Nome;
                controle.EmailTb.Text = (e.NewValue as Contato).Email;
                controle.TelTb.Text = (e.NewValue as Contato).Tel;
            }
        }

        public ContatoControl()
        {
            InitializeComponent();
        }
    }
}
