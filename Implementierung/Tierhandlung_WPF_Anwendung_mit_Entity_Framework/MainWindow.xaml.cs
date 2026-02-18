using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

        Tierheim tierheim { get; set; }
        public Account? Benutzer { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();
            var database_context = new TierheimContext();
            tierheim = new Tierheim(database_context);
            DataContext = tierheim;
        }


        private void filter_for_query(object sender, KeyEventArgs e)
        {
            tierheim.filter(filter_query_name.Text);
        }

        private void tier_liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = tier_liste.SelectedItem as Tiere;
            if (t != null)
                selected.DataContext = t;
        }

        private void anmelden_Click(object sender, RoutedEventArgs e)
        {
            string name = login_user_name.Text;
            string passwd = login_user_password.Text;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(passwd))
            {
                var user = tierheim.context.Account.FirstOrDefault(a => a.Benutzername == name && a.Passwort == a.Passwort);
                if (user != null)
                {
                    Benutzer = user;
                    user_name_show.Text = $"Angemeldet als Benutzer: {user.Benutzername}";
                    login_field.Visibility = Visibility.Hidden;
                    abmelden.Visibility = Visibility.Visible;

                    var alle_anfragen = tierheim.context.Anfragen.Include(a => a.Tier);
                    foreach (var a in alle_anfragen)
                    {
                        if (a.NutzerId == Benutzer.NutzerId)
                            tierheim.deine_anfragen.Add(a);
                    }
                }
                else
                {
                    user_name_show.Text = "Falscher Benutzername oder Passwort";
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Benutzer != null)
            {
                var ausgewähltes_tier = tier_liste.SelectedItem as Tiere;
                if (ausgewähltes_tier != null)
                {
                    int tierId = ausgewähltes_tier.TierId;
                    int benutzerId = Benutzer.NutzerId;
                    if (tierheim.context.Anfragen.Any(a => a.TierId == tierId && a.NutzerId == benutzerId))
                    {
                        anfrage_info.Text = "Anfrage exisitiert bereits";
                    }
                    else
                    {
                        tierheim.anfrage_stellen(benutzerId, tierId);
                        anfrage_info.Text = $"Anfrage gestellt von dem Benutzer {Benutzer.Benutzername} an das Tier {ausgewähltes_tier.Tiername} erfolgreich erstellt";
                    }

                }
            }
            else
            {
                anfrage_info.Text = "Sie müssen sich anmelden um Anfragen stellen zu können";
            }
        }

        private void abmelden_Click(object sender, RoutedEventArgs e)
        {
            login_field.Visibility = Visibility.Visible;
            abmelden.Visibility = Visibility.Hidden;
            login_user_name.Text = "";
            login_user_password.Text = "";
            tierheim.deine_anfragen.Clear();
            Benutzer = null;
        }

        private void acc_erstellen_Click(object sender, RoutedEventArgs e)
        {
            {
                Account neuer_account = new Account();
                neuer_account.Benutzername = login_user_name.Text;
                neuer_account.Passwort = login_user_password.Text;
                if (tierheim.context.Account.Any(a => a.Benutzername == neuer_account.Benutzername))
                {
                    user_name_show.Text = $"Der Benutzername {neuer_account.Benutzername} existiert bereits";
                }
                else
                {
                    tierheim.context.Account.Add(neuer_account);
                    tierheim.context.SaveChanges();
                    user_name_show.Text = $"Neuer Account mit dem Benutzernamen {neuer_account.Benutzername} wurde erstellt\b" +
                        $"Sie können sich einloggen";
                }
            }
        }
    }
}