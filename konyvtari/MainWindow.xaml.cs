using System.ComponentModel;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace konyvtari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> nevek = [];
        
        public MainWindow()
        {
            InitializeComponent();  
            lb_nevek.ItemsSource = nevek;
            Megnyitas();
        }

        private void btn_be_Click(object sender, RoutedEventArgs e)
        {
            string nev = "";
            if (string.IsNullOrEmpty(tbox_username.Text.ToString()))
            {
                nev = "Nem lett megadva név";
            }
            else
            {
                nev = tbox_username.Text.ToString();
            }
            int kor;
            bool szamE = int.TryParse(tbox_age.Text, out kor);
            if (szamE)
            {
                kor = int.Parse(tbox_age.Text);
            }
            else
            {
                MessageBox.Show(this, "A életkorhoz számot kell megadni!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string ertesitesek = "";
            if (cb_hirlevel.IsChecked == true)
            {
                ertesitesek += "Hírlevél ";
            }
            if (cb_sms.IsChecked == true) 
            { 
                ertesitesek += "SMS"; 
            }
            if (cb_ujsag.IsChecked == true) 
            {
                ertesitesek += "Újság"; 
            }
            else
            {
                ertesitesek = "Nem kér";
            }
            string tagsag = "";
            if (rb_diak.IsChecked == true)
            {
                tagsag = "diak";
            }
            else if (rb_felnott.IsChecked == true)
            {
                tagsag = "felnőtt";
            }
            else if (rb_nyugdijas.IsChecked == true)
            {
                tagsag = "nyugdíjas";
            }
            else
            {
                tagsag = "Nincs kijelölve";
            }
            txt_confirm.Text = "Sikeres mentés";
            Olvaso olvaso = new Olvaso(nev, kor, ertesitesek, tagsag);
            Fajlkeszites(olvaso);
        }
        private void Fajlkeszites(Olvaso olvaso)
        {
            string filePath = @"S:\Petrik\12.E\csharp\konyvtari\konyvtari\olvasok.txt";
            string content = olvaso.ToString() ?? "";
            File.AppendAllText(filePath, content);
        }
        private void Megnyitas()
        {
            string filePath = @"S:\Petrik\12.E\csharp\konyvtari\konyvtari\olvasok.txt";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] reszek = line.Trim().Split(", ");
                nevek.Add(reszek[0]);
            }
            lb_nevek.Items.Refresh();
        }
    }
}