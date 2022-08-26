using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using VentureCore;
using Newtonsoft.Json;

namespace Expeditions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Adventurer> _adventuers= new List<Adventurer>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var advJson = File.ReadAllText(openFileDialog.FileName);
                var adventurer = JsonConvert.DeserializeObject<Adventurer>(advJson);
                Tabs.Items.Add(new TabItem { Content = new AdventControl(adventurer, openFileDialog.FileName) { DataContext = adventurer }, Header = adventurer.Name });
                _adventuers.Add(adventurer);
            }
        }

    }
}
