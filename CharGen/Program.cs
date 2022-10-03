using System;
using System.Collections.Generic;
using System.Text;
using VentureCore;
using Newtonsoft.Json;
using System.IO;
using VentureCore.Items;
using VentureCore.Weapons;

namespace CharGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var adv = CharGen();
            Console.WriteLine(adv.Print(300));
            Save(adv);
            PrintStore();
            Console.ReadKey();
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

        static void PrintStore()
        {
            Console.WriteLine(new Stick().Print(1));
            Console.WriteLine(new Crossbow().Print(1));
            Console.WriteLine(new LockPick().Print(1));
            Console.WriteLine(new Crowbar().Print(1));
        }

        static Adventurer CharGen()
        {
            var random = new Random();
            var adventurer = new Adventurer();
            adventurer.Agility = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            adventurer.Constitution = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            adventurer.Dexterity = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            adventurer.Strength = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            adventurer.Hp = adventurer.HpMax = random.Next(1, 7)+ConstCorrection(adventurer);
            adventurer.Level = 1;
            adventurer.Xp = 0;
            adventurer.CarryCapacity = random.Next(3, 10);
            adventurer.Servitude = random.Next(10, 40);
            adventurer.Armor = 0;
            adventurer.Encumbrance = 0;
            adventurer.Items = new List<Item>();
            adventurer.Name = NameGen();
            return adventurer;
        }

        static int ConstCorrection (Adventurer adventurer)
        {
            if (adventurer.Constitution < 7)
                return -1;
            else if (adventurer.Constitution < 13)
                return 0;
            else if (adventurer.Constitution < 16)
                return 1;
            else
                return 2;
        }

        static readonly List<string> Honorific = new List<string> { "Mr.", "Ms.", "Dr.", "Pvt."};
        static readonly List<string> FirstNames = new List<string> { "Ally", "Aschleigh","Beto","Carbon","Delany","Effoy", "Fitz",
        "Georg", "Heiger" , "Inns", "Jocel", "Kathode", "Llamas", "Manos", "Oper", "Percy", "Quimby", "Rostish", "Statos", "Tallhearth",
        "Vivi", "West", "Yvonne", "Zachar"};
        static readonly List<string> LastNames = new List<string> { "Aral", "Bean", "Cage", "Deft", "Envin", "Frakes", "Golen",
        "Hyun", "Iverson", "Jackson", "Kath", "Leguin", "Minster", "O'Mann", "Price", "Questor", "Reiff", "St.Quinn",
        "Teviegh", "Vronsky", "West", "Xanadu"};

        static string NameGen()
        {
            var random = new Random();
            return Honorific[random.Next(Honorific.Count)] + " " + FirstNames[random.Next(FirstNames.Count)] + " " + LastNames[random.Next(LastNames.Count)];
        }
    }
}
