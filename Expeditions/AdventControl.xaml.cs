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
using VentureCore;

namespace Expeditions
{
    /// <summary>
    /// Interaction logic for AdventControl.xaml
    /// </summary>
    public partial class AdventControl : UserControl
    {
        public AdventControl(Adventurer adventurer, string path)
        {
            Adventurer = adventurer;
            PathToFile = path;
            InitializeComponent();
        }

        private void Equip_Click(object sender, RoutedEventArgs e)
        {
            var equipDlg = new Equip();
            if (equipDlg.ShowDialog() == true)
                equipDlg.Selected.Equip(Adventurer);
        }

        Adventurer Adventurer { get; }
        public string PathToFile { get; }

        private void Enequip_Click(object sender, RoutedEventArgs e)
        {
            if (Items.SelectedItem != null)
                (Items.SelectedItem as Item).Unequip(Adventurer);
        }
    }
}
