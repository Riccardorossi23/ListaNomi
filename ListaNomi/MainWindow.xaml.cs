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

namespace ListaNomi
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
        List<string> frasi = new List<string>(5); int i;
        private void btnInsersci_Click(object sender, RoutedEventArgs e)
        {
            frasi.Add(txtInserisci.Text);
            i++;
            if (i == 5)
            {
                btnInsersci.IsEnabled = false;
                btnPubblica.IsEnabled = true;
                btnStampa.IsEnabled = true;
            }
            txtInserisci.Clear();
        }
        private void btnStampa_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < frasi.Count; i++)
            {
                lblRisultato.Content += $"{frasi[i]}\n";
            }

        }
        private void btnOrdina_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < frasi.Count; i++)
            {
                frasi.Sort();
                lblOrdina.Content += $"{frasi[i]}\n";
            }
        }

        private void btnPubblica_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter w = new StreamWriter("PubblicaOrdinamento.txt", false, Encoding.UTF8);
            for (int i = 0; i < frasi.Count; i++)
            {
                w.WriteLine($"-{i + 1}°  messaggio: {frasi[i]} \n");
            }

            w.Flush();
            w.Close();



        }
    }
}
    