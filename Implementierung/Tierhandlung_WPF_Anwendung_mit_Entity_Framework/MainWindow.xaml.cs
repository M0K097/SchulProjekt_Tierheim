using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
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
using Tierhandlung_WPF_Anwendung_mit_Entity_Framework.DbModels;
using Tierhandlung_WPF_Anwendung_mit_Entity_Framework.Models;

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework
{
    public partial class MainWindow : Window
    {

        Tierheim Tierheim { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Tierheim = new Tierheim();
            DataContext = Tierheim;
        }


        private void filter_for_query(object sender, KeyEventArgs e)
        {
            Tierheim.filter(filter_query_name.Text);
        }

        private void tier_liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = tier_liste.SelectedItem as Tiere;

            if (t != null)
                selected.DataContext = t;
        }
    }
}