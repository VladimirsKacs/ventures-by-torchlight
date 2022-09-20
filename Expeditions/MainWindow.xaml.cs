using System;
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
        List<Adventurer> _adventurers= new List<Adventurer>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var advJson = File.ReadAllText(openFileDialog.FileName);
                var adventurer = JsonConvert.DeserializeObject<Adventurer>(advJson, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
                Tabs.Items.Add(new TabItem { Content = new AdventControl(adventurer, openFileDialog.FileName) { DataContext = adventurer }, Header = adventurer.Name });
                _adventurers.Add(adventurer);
            }
        }

        private void Button_Adventure(object sender, RoutedEventArgs e)
        {
            var expedition = new Expedition();
            //TODO: get this from a drop-down list.
            var log = new Log(expedition.Go(_adventurers, Location.Basic_1));
            log.Show();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            foreach (var adventurer in _adventurers)
            {
                var fileName = adventurer.Name + ".adv";
                var advStr = JsonConvert.SerializeObject(adventurer, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
                File.WriteAllText(fileName, advStr);
            }
        }
    }
}
