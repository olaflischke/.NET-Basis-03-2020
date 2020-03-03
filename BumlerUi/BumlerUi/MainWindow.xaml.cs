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

namespace BumlerUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bummler bummler = new Bummler();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btn1_Click(object sender, RoutedEventArgs e)
        {
            //lbl1.Content = bummler.Bummeln();
            lbl1.Content = await bummler.BummelnAsnyc();
        }

        private async void btn2_Click(object sender, RoutedEventArgs e)
        {
            lb2.Content = await bummler.TroedelnAsync();
        }
    }
}
