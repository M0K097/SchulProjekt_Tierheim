using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Tierhandlung_WPF_Anwendung_mit_Entity_Framework.DbModels;
using Tierhandlung_WPF_Anwendung_mit_Entity_Framework.Services;

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework
{
    public partial class MainWindow : Window
    {
        Tierheim tierheim { get; set; }
        public Account? Benutzer { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();
            var database = new TierheimContext();
            DbSeeder.Seed(database);
            tierheim = new Tierheim(database);
            tierheim.load_animals();
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
            {
                selected.DataContext = t;

                if (t.Picture != null && t.Picture.Length > 0)
                {
                    using var ms = new MemoryStream(t.Picture);
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    bitmap.Freeze();
                    selectedTierImage.Source = bitmap;
                }
                else
                {
                    selectedTierImage.Source = null;
                }
            }
        }
        private void admin_alle_tiere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = admin_alle_tiere.SelectedItem as Tiere;
            if (t == null) return;

            admin_selected.DataContext = t;

            if (t.Picture != null && t.Picture.Length > 0)
            {
                using var ms = new MemoryStream(t.Picture);
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                bitmap.Freeze();

                adminSelectedTierImage.Source = bitmap;
            }
            else
            {
                adminSelectedTierImage.Source = null;
            }
        }


        private void anmelden_Click(object sender, RoutedEventArgs e)
        {
            string name = login_user_name.Text;
            string passwd = login_user_password.Password;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(passwd))
            {
                user_name_show.Text = "Benutzernamen oder Passwort eingeben";
                return;
            }

            var user = tierheim.get_user(name, passwd);
            if (user != null)
            {
                Benutzer = user;
                user_name_show.Text = $"Angemeldet als Benutzer: {user.Benutzername}";
                login_field.Visibility = Visibility.Hidden;
                abmelden.Visibility = Visibility.Visible;

                if (user.IsAdmin == true)
                {
                    admin_anfragen_pannel.Visibility = Visibility.Visible;
                    liste_anfragen.Visibility = Visibility.Visible;
                    user_pannel.Visibility = Visibility.Collapsed;
                    admin_pannel.Visibility = Visibility.Visible;
                    tierdetails.Visibility = Visibility.Collapsed;
                    admin_tierdetails.Visibility = Visibility.Visible;
                    tierheim.load_anfragen();
                }
                else
                {
                    admin_anfragen_pannel.Visibility = Visibility.Collapsed;
                    liste_anfragen.Visibility = Visibility.Collapsed;
                    admin_pannel.Visibility = Visibility.Collapsed;
                    user_pannel.Visibility = Visibility.Visible;
                    tierdetails.Visibility = Visibility.Visible;
                    admin_tierdetails.Visibility = Visibility.Collapsed;
                    tierheim.load_animals();
                }

                tierheim.load_nutzer_anfragen(user);
            }
            else
            {
                user_name_show.Text = "Falscher Benutzername oder Passwort";
            }
        }
        private void Status_Setzen_Click(object sender, RoutedEventArgs e)
        {
            var selectedAnfrage = liste_anfragen.SelectedItem as Anfragen;
            if (selectedAnfrage == null)
            {
                MessageBox.Show("Bitte wählen Sie eine Anfrage aus.");
                return;
            }

            if (status_dropdown.SelectedItem is ComboBoxItem selectedItem)
            {
                string neuerStatus = selectedItem.Content.ToString();
                selectedAnfrage.Status = neuerStatus;

                // Update database
                tierheim.UpdateAnfrageStatus(selectedAnfrage.AnfrageId, neuerStatus);

                // Refresh DataGrid
                liste_anfragen.Items.Refresh();
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Benutzer == null)
            {
                anfrage_info.Text = "Sie müssen sich anmelden, um Anfragen stellen zu können";
                return;
            }

            var ausgewähltes_tier = tier_liste.SelectedItem as Tiere;
            if (ausgewähltes_tier == null)
            {
                anfrage_info.Text = "Kein Tier ausgewählt";
                return;
            }

            if (string.IsNullOrWhiteSpace(anfrage_text.Text))
            {
                anfrage_info.Text = "Bitte geben Sie einen Kommentar ein, bevor Sie die Anfrage stellen";
                return;
            }

            int tierId = ausgewähltes_tier.TierId;
            int benutzerId = Benutzer.NutzerId;

            if (tierheim.check_if_request_exists(tierId, benutzerId))
            {
                anfrage_info.Text = "Anfrage existiert bereits";
            }
            else
            {
                tierheim.anfrage_stellen(benutzerId, tierId, anfrage_text.Text);
                anfrage_info.Text = $"Anfrage gestellt von {Benutzer.Benutzername} an das Tier {ausgewähltes_tier.Tiername} erfolgreich erstellt";
                anfrage_text.Clear();
            }
        }


        private void abmelden_Click(object sender, RoutedEventArgs e)
        {
            login_field.Visibility = Visibility.Visible;
            abmelden.Visibility = Visibility.Hidden;
            liste_anfragen.Visibility = Visibility.Collapsed;
            admin_pannel.Visibility = Visibility.Hidden;
            user_pannel.Visibility = Visibility.Visible;
            admin_anfragen_pannel.Visibility = Visibility.Collapsed;
            user_name_show.Text = "Sie sind abgemeldet";
            login_user_name.Text = "";
            login_user_password.Password = "";
            tierheim.deine_anfragen.Clear();
            Benutzer = null;
        }

        private void acc_erstellen_Click(object sender, RoutedEventArgs e)
        {
            {
                if(string.IsNullOrEmpty(login_user_name.Text) || string.IsNullOrEmpty(login_user_password.Password))
                {
                    user_name_show.Text = "Weder Benutzername noch Passwort dürfen leer sein";
                    return;
                }

                var name = login_user_name.Text;
                var password = login_user_password.Password;

                if (!tierheim.create_new_account(name, password,false))
                {
                    user_name_show.Text = $"Der Benutzername {name} existiert bereits";
                }
                else
                {
                    user_name_show.Text = $"Neuer Account mit dem Benutzernamen {name} wurde erstellt\b" +
                        $"Sie können sich einloggen";
                }
            }
        }
        private void admin_erstellen(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrEmpty(login_user_name.Text) || string.IsNullOrEmpty(login_user_password.Password))
                {
                    user_name_show.Text = "Weder Benutzername noch Passwort dürfen leer sein";
                    return;
                }

                var name = admin_login_name.Text;
                var password = admin_login_password.Password;

                if (!tierheim.create_new_account(name, password, true))
                {
                    user_name_show.Text = $"Der Administrator {name} existiert bereits";
                }
                else
                {
                    user_name_show.Text = $"Neuer Administrator mit dem Benutzernamen {name} wurde erstellt\b" +
                        $"Sie können sich einloggen";
                }
            }
        }

        private void tier_entfernen_Click(object sender, RoutedEventArgs e)
        {
            var animal_to_remove = admin_alle_tiere.SelectedItem as Tiere;
            if (animal_to_remove == null)
            {
                bearbeitungs_info.Text = "Kein Tier zum entfernen gefunden";
                return;
            }
            tierheim.remove_animal(animal_to_remove);
            bearbeitungs_info.Text = $"Tier entfernt => {animal_to_remove.TierId}-{animal_to_remove.Tiername}";
        }
        private void bild_hochladen_Click(object sender, RoutedEventArgs e)
        {
            var selectedAnimal = admin_alle_tiere.SelectedItem as Tiere;

            if (selectedAnimal == null)
            {
                bearbeitungs_info.Text = "Bitte zuerst ein Tier auswählen";
                return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Bilddateien (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (dialog.ShowDialog() == true)
            {
                byte[] imageBytes = File.ReadAllBytes(dialog.FileName);
                

                selectedAnimal.Picture = imageBytes;
                if (selectedAnimal.Picture != null && selectedAnimal.Picture.Length > 0)
                {
                    using var ms = new MemoryStream(selectedAnimal.Picture);
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    bitmap.Freeze();
                    adminSelectedTierImage.Source = bitmap;
                }
                else
                {
                    adminSelectedTierImage.Source = null;
                }
                

                tierheim.tiere_ändern();

                bearbeitungs_info.Text = "Bild erfolgreich hochgeladen";
            }
        }

        private void tier_hinzufügen_click(object sender, RoutedEventArgs e)
        {
            string name = animal_name_to_add.Text;
            string art = animal_species_to_add.Text;
            string beschreibung = animal_info_to_add.Text;
            DateTime? geburtsdatum = animal_birthday_to_add.SelectedDate;

            if(geburtsdatum == null)
            {
                bearbeitungs_info.Text = "Kein Geburtsdatum ausgewählt";
                return;
            }
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(art) || string.IsNullOrEmpty(beschreibung))
            {
                bearbeitungs_info.Text = "Alle Felder müssen ausgefüllt sein";
                return;
            }

            tierheim.add_animal(name, art, (DateTime)geburtsdatum, beschreibung);
            bearbeitungs_info.Text = $"Tier hinzugefügt => {name}-{art}-{geburtsdatum}-{beschreibung}";
        }

        private void tier_ändern_click(object sender, RoutedEventArgs e)
        {
            tierheim.tiere_ändern();
            bearbeitungs_info.Text = "Alle änderungen erfolgreich durchgeführt";
        }
    }
}