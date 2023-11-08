using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        static Random random = new Random();
        static void Main(string[] args)
        {
            var adv = CharGen();
            Console.WriteLine(adv.Print(300));
            Save(adv);
            adv = CharGen(2);
            Console.WriteLine(adv.Print(450));
            Save(adv);
            adv = CharGen(2);
            Console.WriteLine(adv.Print(450));
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
            Console.WriteLine(new Shortbow().Print(1));
        }

        static Adventurer CharGen(int level = 1)
        {
            var adventurer = new Adventurer
            {
                Agility = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7),
                Constitution = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7),
                Dexterity = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7),
                Strength = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7),
                Level = level,
                Xp = 0,
                CarryCapacity = random.Next(3, 10),
                Armor = 0,
                Items = new ObservableCollection<Item>(),
                Name = NameGen()
            };
            adventurer.Hp = adventurer.HpMax = random.Next(1, 7);
            for (var i = 1; i < adventurer.Level; i++)
            {
                var hpAdd = random.Next(1, 7);
                adventurer.Hp += hpAdd;
                adventurer.HpMax += hpAdd;
                switch (random.Next(5))
                {
                    case 0:
                        adventurer.Agility++;
                        break;
                    case 1:
                        adventurer.Constitution++;
                        break;
                    case 2:
                        adventurer.Dexterity++;
                        break;
                    case 3:
                        adventurer.Strength++;
                        break;
                    case 4:
                        adventurer.CarryCapacity++;
                        break;
                }
            }
            adventurer.Hp += ConstCorrection(adventurer)*level;
            adventurer.HpMax += ConstCorrection(adventurer)*level;
            switch (level)
                {
                case 1:
                    adventurer.Xp = 0; break;
                case 2:
                    adventurer.Xp = 1000; break;
                case 3:
                    adventurer.Xp = 3000; break;
                case 4:
                    adventurer.Xp = 6000; break;
                case 5:
                    adventurer.Xp = 11000; break;
                default:
                    throw new Exception("level too high");
            }
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
        "Vivi", "West", "Yvonne", "Zachar", "Agnie", "Berth", "Ched", "Darth", "Essa", "Frud", "Gumbo", "Hollie", "Isken", "Jalin","Katniss",
        "Loizh", "Mursy", "Olybeth", "Pawn", "Rotmund", "Serge", "Trilby", "Ugnan", "Veresk", "Wass", "Yalda", "Siegjarl"};
        static readonly List<string> LastNames = new List<string> { "Aral", "Bean", "Cage", "Deft", "Envin", "Frakes", "Golen",
        "Hyun", "Iverson", "Jackson", "Kath", "Leguin", "Minster", "O'Mann", "Price", "Questor", "Reiff", "St.Quinn",
        "Teviegh", "Vronsky", "West", "Xanadu", "Zapata", "Azer", "Bizzt", "Cerg", "Dreary", "Esthman", "Firm", "Grimm", "Heiger",
        "Iskra", "Jay", "Kell", "L'Etarto","Magimann","Orkin", "Pigmen", "Roald", "Severus", "Trata", "Urist", "Vexler", "Worclaw", "Xander",
        "Yersika", "Zeit" };

        static string NameGen()
        {
            return Honorific[random.Next(Honorific.Count)] + " " + FirstNames[random.Next(FirstNames.Count)] + " " + LastNames[random.Next(LastNames.Count)];
        }
    }
}
