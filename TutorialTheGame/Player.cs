//using System;

//class Player
//{
//    public string Name { get; set; } // Spelarens namn
//    public int BaseHealth { get; private set; } = 5000; // Grundhälsa som påverkas av Stamina
//    public int Health { get; set; }  // Hälsan kan modifieras under spelets gång
//    public int Stamina { get; set; } // Stamina påverkar spelarens hälsopool
//    public int Mana { get; set; }    // Mana påverkar spelarens mana pool
//    public int Strength { get; set; } // Strength påverkar spelarens attack power
//    public int AttackPower { get; private set; } // Attack Power beräknas från Strength
//    public int BaseDamage { get; private set; } = 20; // Grundskada innan Strength påverkar
//    public int ManaPool { get; private set; } // Beräknas baserat på Mana
//    public int Level { get; set; }  // Spelarens nuvarande nivå
//    public int Experience { get; set; } // Spelarens nuvarande erfarenhetspoäng
//    public int ExperienceToNextLevel { get; set; } // Hur mycket erfarenhet som krävs för nästa nivå

//    // Konstruktor där spelaren sätter namn och startstats
//    public Player(string name, int stamina, int mana, int strength)
//    {
//        Name = name;
//        Stamina = stamina;
//        Mana = mana;
//        Strength = strength;
//        Level = 1;
//        Experience = 0;
//        ExperienceToNextLevel = 100; // Exempel: 100 EXP för att nå level 2

//        UpdateStats(); // Uppdaterar hälsa, attack power och mana baserat på stats
//    }

//    // Uppdaterar spelarens attribut baserat på stats
//    private void UpdateStats()
//    {
//        Health = BaseHealth + (Stamina * 10); // Varje poäng i Stamina ger +10 HP
//        ManaPool = Mana * 10; // Varje poäng i Mana ger +10 till mana pool
//        AttackPower = Strength * 10; // Varje poäng i Strength ger +10 attack power
//    }

//    // Lägg till erfarenhet och kontrollera om spelaren går upp i nivå
//    public void AddExperience(int amount)
//    {
//        Experience += amount;
//        Console.WriteLine($"{Name} gained {amount} EXP!");

//        if (Experience >= ExperienceToNextLevel)
//        {
//            LevelUp(); // Om erfarenheten är tillräcklig går spelaren upp i nivå
//        }
//    }

//    // Nivå-upplogik: Spelaren får stat points att allokera och stats uppdateras
//    private void LevelUp()
//    {
//        Level++;
//        Experience -= ExperienceToNextLevel;
//        ExperienceToNextLevel += 100; // Nästa nivå kräver mer EXP
//        Console.WriteLine($"{Name} leveled up! You are now level {Level}.");
//        AllocateStatPoints(); // Låter spelaren fördela stat points
//        UpdateStats(); // Uppdaterar stats efter att spelaren har allokerat poäng
//    }

//    // Låt spelaren allokera stat points i större mängder
//    private void AllocateStatPoints()
//    {
//        int statPoints = 5;  // Exempel: 5 poäng per level-up
//        Console.WriteLine($"{Name}, you have {statPoints} stat points to allocate.");

//        // Så länge spelaren har poäng kvar att allokera
//        while (statPoints > 0)
//        {
//            Console.WriteLine($"Remaining stat points: {statPoints}");
//            Console.WriteLine("How many points would you like to allocate?");
//            Console.WriteLine("(1. Stamina, 2. Mana, 3. Strength)");

//            string choice = Console.ReadLine(); // Låt spelaren välja vilken stat de vill öka
//            Console.WriteLine("Enter the number of points to allocate:");

//            int pointsToAllocate;
//            if (!int.TryParse(Console.ReadLine(), out pointsToAllocate) || pointsToAllocate <= 0 || pointsToAllocate > statPoints)
//            {
//                Console.WriteLine("Invalid number of points. Try again.");
//                continue; // Gå tillbaka om input är ogiltig
//            }

//            // Fördela poäng beroende på spelarens val
//            switch (choice)
//            {
//                case "1": // Stamina
//                    Stamina += pointsToAllocate;
//                    Console.WriteLine($"Stamina increased by {pointsToAllocate}.");
//                    statPoints -= pointsToAllocate;
//                    break;

//                case "2": // Mana
//                    Mana += pointsToAllocate;
//                    Console.WriteLine($"Mana increased by {pointsToAllocate}.");
//                    statPoints -= pointsToAllocate;
//                    break;

//                case "3": // Strength
//                    Strength += pointsToAllocate;
//                    Console.WriteLine($"Strength increased by {pointsToAllocate}.");
//                    statPoints -= pointsToAllocate;
//                    break;

//                default:
//                    Console.WriteLine("Invalid choice. Try again.");
//                    break;
//            }
//        }

//        UpdateStats(); // Uppdaterar spelarens attribut efter att stat points har fördelats
//    }

//    // Beräkna spelarens skada baserat på Strength
//    public int CalculateDamage()
//    {
//        return BaseDamage + AttackPower; // Basdamage + attack power från Strength
//    }

//    // Visar spelarens status under varje runda
//    public void DisplayPlayerStatus()
//    {
//        Console.WriteLine("========================================");
//        Console.WriteLine($"Player Information for {Name}:");
//        Console.WriteLine($"Level: {Level}");
//        Console.WriteLine($"HP: {Health}");
//        Console.WriteLine($"Mana Pool: {ManaPool}");
//        Console.WriteLine($"Strength (Attack Power): {Strength} (+{AttackPower} damage)");
//        Console.WriteLine($"EXP: {Experience}/{ExperienceToNextLevel} to next level");
//        Console.WriteLine("========================================");
//    }
//}
