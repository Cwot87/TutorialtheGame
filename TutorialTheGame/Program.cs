//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//// -------TO DO LIST---------
////--------Welcome to the Tutorial---------
//// 10 levels
//// Easy, intermediate, hardcore
//// exp från att döda och gå upp i levels
//// får sätta ut 10 stat points i början på sin karaktär (stamina, mana, strength), för om man vill vara warrior, mage eller assasin
//// stats som man kan öka på sin karaktär
//// utrustning, vapen, drops?
//// 
////
////
//// Klasser, Warrior, Mage, Assasin, shaman? 
//// Spells, mortal strike, fireball / cc?, sneack attack?, healar andra/lågt hp?
////
//// confuse? random attack
//// crit chanse?


//// Fixes :
//// Shaman healar inte?
//// Justera Stat/skada samt enemy hp
//// ha random enemies istället för samma 
//namespace TutorialTheGame
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Välkomna spelaren och låt dem skapa sin karaktär
//            Console.WriteLine("Welcome to the game! Please enter your player name:");
//            string playerName = Console.ReadLine();

//            // Låt spelaren allokera stat points i början av spelet
//            int initialStatPoints = 10;
//            int stamina = 0;
//            int mana = 0;
//            int strength = 0;

//            while (initialStatPoints > 0)
//            {
//                Console.WriteLine($"You have {initialStatPoints} stat points to allocate.");
//                Console.WriteLine("Which stat would you like to increase? (1. Stamina, 2. Mana, 3. Strength)");
//                string choice = Console.ReadLine();

//                Console.WriteLine("How many points would you like to allocate?");
//                int pointsToAllocate;
//                if (!int.TryParse(Console.ReadLine(), out pointsToAllocate) || pointsToAllocate <= 0 || pointsToAllocate > initialStatPoints)
//                {
//                    Console.WriteLine("Invalid number of points. Try again.");
//                    continue;
//                }

//                switch (choice)
//                {
//                    case "1":
//                        stamina += pointsToAllocate;
//                        Console.WriteLine($"Stamina increased by {pointsToAllocate}.");
//                        initialStatPoints -= pointsToAllocate;
//                        break;

//                    case "2":
//                        mana += pointsToAllocate;
//                        Console.WriteLine($"Mana increased by {pointsToAllocate}.");
//                        initialStatPoints -= pointsToAllocate;
//                        break;

//                    case "3":
//                        strength += pointsToAllocate;
//                        Console.WriteLine($"Strength increased by {pointsToAllocate}.");
//                        initialStatPoints -= pointsToAllocate;
//                        break;

//                    default:
//                        Console.WriteLine("Invalid choice. Try again.");
//                        break;
//                }
//            }

//            // Skapa spelaren baserat på de allokerade stat points
//            Player player = new Player(playerName, stamina, mana, strength);

//            // Sätt spelets nivåsystem
//            int currentLevel = 1;
//            int maxLevel = 10;

//            // Spelloop som går igenom alla nivåer
//            while (currentLevel <= maxLevel && player.Health > 0)
//            {
//                Console.WriteLine($"You are now on Level {currentLevel}!");

//                // Generera fiender för den aktuella nivån
//                List<Enemy> enemies = GenerateEnemiesForLevel(currentLevel);

//                // Nivåns spelloop, så länge det finns fiender kvar
//               while (enemies.Count > 0 && player.Health > 0)
//{
//    player.DisplayPlayerStatus(); // Visa spelarens stats

//    // Skriv ut en meny med alternativen för attack, heal eller avsluta
//    Console.WriteLine("========================================");
//    Console.WriteLine($"You have {player.Health} HP");
//    Console.WriteLine("---------------------------");
//    Console.WriteLine("Existing enemies:");
//    for (int i = 0; i < enemies.Count; i++)
//    {
//        Console.WriteLine($"{i + 1}. {enemies[i].Name} ({enemies[i].Health} HP)");
//    }
//    Console.WriteLine("---------------------------");
//    Console.WriteLine("Commands:");
//    Console.WriteLine("1. Attack");
//    Console.WriteLine("2. Heal");
//    Console.WriteLine("3. End the game");
//    Console.Write("Choose 1-3:");
//    string input = Console.ReadLine();

//    Random random = new Random();
//    switch (input)
//    {
//        case "1": // Attackera en viss fiende
//            Console.Write("Who do you want to attack:");
//            int enemyIndex = int.Parse(Console.ReadLine()) - 1;
//            if (enemyIndex >= 0 && enemyIndex < enemies.Count)
//            {
//                Enemy enemy = enemies[enemyIndex];
//                int damage = player.CalculateDamage();
//                Console.WriteLine($"You attack {enemy.Name} for {damage} damage.");
//                enemy.Defend(damage);
//                if (enemy.Health <= 0)
//                {
//                    // Fiende besegrad, ge EXP till spelaren
//                    Console.WriteLine($"{enemy.Name} has been defeated! You earned {enemy.ExpReward} EXP.");
//                    player.AddExperience(enemy.ExpReward); // Lägg till EXP
//                    enemies.RemoveAt(enemyIndex); // Ta bort fienden från listan
//                }
//            }
//            else
//            {
//                Console.WriteLine("Invalid enemy number.");
//            }
//            break;

//        case "2": // Heala spelaren
//            Console.WriteLine("You heal yourself for:");
//            player.Health += 50 + random.Next(0, 50);
//            break;

//        case "3": // Avsluta spelet
//            Console.WriteLine("You ended the game.");
//            return;

//        default:
//            Console.WriteLine("Invalid choice.");
//            break;
//    }

//    // Fiendernas tur att attackera spelaren
//    foreach (var enemy in enemies)
//    {
//        player.Health -= enemy.Attack();
//        if (player.Health <= 0)
//        {
//            Console.WriteLine("You have been defeated!");
//            return;
//        }
//    }
//}


//                // Om alla fiender är besegrade, gå till nästa nivå
//                if (enemies.Count == 0)
//                {
//                    Console.WriteLine($"Level {currentLevel} cleared!");
//                    currentLevel++;
//                }

//                // Om spelaren har klarat alla nivåer
//                if (currentLevel > maxLevel)
//                {
//                    Console.WriteLine("Congratulations! You have cleared all 10 levels and won the game!");
//                }
//            }
//        }

//        // Exempelmetod för att generera fiender för varje nivå
//        static List<Enemy> GenerateEnemiesForLevel(int level)
//        {
//            List<Enemy> enemies = new List<Enemy>();

//            // Generera olika typer av fiender beroende på nivå
//            for (int i = 0; i < level; i++) // Antalet fiender ökar per nivå
//            {
//                switch (level % 4)
//                {
//                    case 0:
//                        enemies.Add(new Mage($"Mage Level {level}"));
//                        break;
//                    case 1:
//                        enemies.Add(new Assassin($"Assassin Level {level}"));
//                        break;
//                    case 2:
//                        enemies.Add(new Warrior($"Warrior Level {level}"));
//                        break;
//                    case 3:
//                        enemies.Add(new Shaman($"Shaman Level {level}"));
//                        break;
//                }
//            }

//            return enemies;
//        }
//    }
//}
