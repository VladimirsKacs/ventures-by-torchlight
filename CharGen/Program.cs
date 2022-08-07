using System;
using System.Collections.Generic;
using System.Text;
using VentureCore;
using Newtonsoft.Json;
using System.IO;

namespace CharGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var adv = CharGen();
            Console.WriteLine(Print(adv));
            Save(adv);
            Console.ReadKey();
        }

        static string Print (Adventurer adventurer)
        {
            var sb = new StringBuilder();
            sb.AppendLine("[table]");
            sb.AppendLine("[tr][td][b]Entry Bid:[/b][/td][td]3F[/td][td][/td][td][/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b][u]Name:[/u][/b][/td][td]{adventurer.Name}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]HPMax:[/b][/td][td]{adventurer.HpMax}[/td][td]  |  [/td][td][b]Armor Class:[/b][/td][td]{adventurer.Armor}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Strength:[/b][/td][td]{adventurer.Strength}[/td][td]  |  [/td][td][b]Dexterity:[/b][/td][td]{adventurer.Dexterity}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Constitution:[/b][/td][td]{adventurer.Constitution}[/td][td]  |  [/td][td][b]Agility:[/b][/td][td]{adventurer.Agility}[/td][/tr]");
            sb.AppendLine($"[tr][td][/td][td][/td][td][b]Carry Capacity:[/b][/td][td]{adventurer.CarryCapacity}[/td][td]  |  [/td][td][b]Service Length:[/b][/td][td]{adventurer.Servitude}[/td][/tr]");
            sb.AppendLine("[/table]");
            return sb.ToString();
        }

        static void Save(Adventurer adventurer)
        {
            var fileName = adventurer.Name + ".adv";
            if (File.Exists(fileName))
                throw new Exception("file already exists");
            var stream = File.OpenWrite(fileName);
            var writer = new StreamWriter(stream);
            var advStr = JsonConvert.SerializeObject(adventurer);
            writer.Write(advStr);
            writer.Flush();
            writer.Close();
        }

        static Adventurer CharGen()
        {
            var random = new Random();
            var adventurer = new Adventurer();
            adventurer.Agility = random.Next(1, 6) + random.Next(1, 6) + random.Next(1, 6);
            adventurer.Constitution = random.Next(1, 6) + random.Next(1, 6) + random.Next(1, 6);
            adventurer.Dexterity = random.Next(1, 6) + random.Next(1, 6) + random.Next(1, 6);
            adventurer.Strength = random.Next(1, 6) + random.Next(1, 6) + random.Next(1, 6);
            adventurer.Hp = adventurer.HpMax = random.Next(1, 6);
            adventurer.Level = 1;
            adventurer.Xp = 0;
            adventurer.CarryCapacity = random.Next(3, 10);
            adventurer.Servitude = random.Next(10, 40);
            adventurer.Armor = 0;
            adventurer.Encumbrance = 0;
            adventurer.Items = new List<IItem>();
            adventurer.Name = NameGen();
            return adventurer;
        }


        static readonly List<string> honorific = new List<string> { "Mr.", "Ms.", "Dr.", "Pvt."};
        static readonly List<string> firstNames = new List<string> { "Ally", "Aschleigh","Beto","Carbon","Delany","Effoy", "Fitz",
        "Georg", "Heiger" , "Inns", "Jocel", "Kathode", "Llamas", "Manos", "Oper", "Percy", "Quimby", "Rostish", "Statos", "Tallhearth",
        "Vivi", "West", "Yvonne", "Zachar"};
        static readonly List<string> LastNames = new List<string> { "Aral", "Bean", "Cage", "Deft", "Envin", "Frakes", "Golen",
        "Hyun", "Iverson", "Jackson", "Kath", "Leguin", "Minster", "O'Mann", "Price", "Questor", "Reiff", "St.Quinn",
        "Teviegh", "Vronsky", "West", "Xanadu"};

        static string NameGen()
        {
            var random = new Random();
            return honorific[random.Next(honorific.Count)] + " " + firstNames[random.Next(firstNames.Count)] + " " + LastNames[random.Next(LastNames.Count)];
        }
    }
}
