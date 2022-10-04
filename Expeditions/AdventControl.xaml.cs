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
            RowBox.ItemsSource = Enum.GetValues(typeof(Row));
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
            var item = Items.SelectedItem as Item;
            item?.Unequip(Adventurer);
        }

        private void Use_Click(object sender, RoutedEventArgs e)
        {
            var item = Items.SelectedItem as Consumable;
            item?.Use(Adventurer);
        }
    }
}
