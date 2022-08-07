using System;
using System.Collections.Generic;
using VentureCore;

namespace CharGen
{
    class Program
    {
        static void Main(string[] args)
        {
            
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
