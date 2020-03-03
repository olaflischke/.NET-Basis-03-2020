using EierfarmBl;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Xml.Serialization;

namespace EierfarmUi
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

        private void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            Henne henne = new Henne();
            cbxTiere.Items.Add(henne);
            cbxTiere.SelectedItem = henne;

            henne.EigenschaftGeaendert += Gefluegel_EigenschaftGeaendert;
        }

        private void Gefluegel_EigenschaftGeaendert(object sender, GefluegelEventArgs e)
        {
            //MessageBox.Show($"Huhn {(sender as Henne).Name} hat Eigenschaft {e.GeaenderteProperty} geändert.");
        }

        private void btnFuettern_Click(object sender, RoutedEventArgs e)
        {
            Gefluegel tier = cbxTiere.SelectedItem as Gefluegel;   // SafeCast - liefert null, wenn Cast fehlschlägt.

            if (tier!=null)
            {
                tier.Fressen();
            }

        }

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTiere.SelectedItem is Gefluegel tier)
            {
                tier.EiLegen();
            }

            //(cbxTiere.SelectedItem as Gefluegel)?.EiLegen();

        }

        private void btnNeueGans_Click(object sender, RoutedEventArgs e)
        {
            Gans gans = new Gans();
            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Gefluegel tier = cbxTiere.SelectedItem as Gefluegel;

            using (StreamWriter writer = new StreamWriter(@"C:\tmp\Tier.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(tier.GetType());
                serializer.Serialize(writer, tier);

                MessageBox.Show("Tier gespeichert.");
            }
        }
    }
}
