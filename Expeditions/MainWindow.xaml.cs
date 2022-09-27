using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using VentureCore;
using Newtonsoft.Json;
using System.Text;

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
            DestinationBox.ItemsSource= Enum.GetValues(typeof(Location));
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
            var sb = new StringBuilder();
            sb.AppendLine("[spoiler=Adventurers]");
            var separator = string.Empty;
            foreach (var adv in _adventurers)
            {
                sb.Append(separator);
                sb.Append(adv.Print());
                separator = "[hr]\n";
            }

            sb.AppendLine("[/spoiler]");
            sb.AppendLine("[spoiler=Log]");
            sb.Append(expedition.Go(_adventurers, (Location)DestinationBox.SelectedItem));
            sb.AppendLine("[/spoiler]");
            sb.AppendLine(PrintLoot(expedition.Loot));
            var log = new Log(sb.ToString());
            log.Show();
        }

        string PrintLoot(List<Item> loot)
        {
            if (loot.Count == 0)
                return "No Loot";
            loot.Sort(Comparer<Item>.Create(Compare));
            var sb = new StringBuilder();
            var counter = 0;
            var totalValue = 0;
            Item previous=loot[0];
            var type = previous.Name;
            sb.AppendLine("[spoiler=Loot]");
            foreach (var l in loot)
            {
                if (type == l.Name)
                    counter++;
                else
                {
                    sb.AppendLine("[table]");
                    sb.AppendLine($"[tr][td][b]Value:[/b][/td][td]{previous.Value / 100.0}₣[/td][/tr]");
                    sb.AppendLine($"[tr][td][b]Amount:[/b][/td][td]{counter}[/td][/tr]");
                    sb.AppendLine($"[tr][td][/td][td][/td][td][b][u]Name:[/u][/b][/td][td]{previous.Name}[/td][/tr]");
                    sb.AppendLine($"[tr][td][/td][td][/td][td][b]Encumbrance:[/b][/td][td]{previous.Weight}[/td][td] | [/td][td][b]Consumable:[/b][/td][td]No[/td][/tr]");
                    sb.AppendLine("[/table]");
                    sb.AppendLine($"    [b]Description:[/b] {previous.Description}");
                    sb.AppendLine("[hr]");
                    totalValue += counter * previous.Value;
                    counter = 1;
                    type = l.Name;
                    previous = l;
                }
            }
            sb.AppendLine("[table]");
            sb.AppendLine($"[tr][td][b]Value:[/b][/td][td]{previous.Value / 100.0}₣[/td][/tr]");
            sb.AppendLine($"[tr][td][b]Amount:[/b][/td][td]{counter}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b][u]Name:[/u][/b][/td][td]{previous.Name}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Encumbrance:[/b][/td][td]{previous.Weight}[/td][td] | [/td][td][b]Consumable:[/b][/td][td]No[/td][/tr]");
            sb.AppendLine("[/table]");
            sb.AppendLine($"    [b]Description:[/b] {previous.Description}");
            totalValue += counter * previous.Value;
            sb.AppendLine("[/spoiler]");
            sb.AppendLine($"Total Value: {totalValue / 100.0}₣");
            return sb.ToString();
        }

        int Compare(Item a, Item b)
        {
            return a.Name.CompareTo(b.Name);
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

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            Tabs.Items.Clear();
            _adventurers.Clear();
        }
    }
}
