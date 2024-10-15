using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialTheGame
{
    class Enemy
    {
        // Alla fiender ska ha detta gemensamt:
        public string Name { get; set; }
        public int Health { get; set; }
        public int BaseDamage { get; set; }
        public int Armor { get; set; }
        public int ExpReward { get; set; }

        // Metoder som alla fiender ska ha. Dessa anropas med hjälp av polymorfism:

        // En metod för att ge info information om fienden
        public virtual string GetInfo() // ?
        {
            return $"{Name} have {Health} HP";
        }

        // Fienden attackerar.
        public virtual int Attack()
        {
            return 0;
        }

        // Fienden försvarar sig.
        public virtual void Defend(int damage)
        {
            int totalDamage = damage - Armor;
            System.Console.WriteLine($"{Name} takes {totalDamage} damage");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Health -= totalDamage;
        }
    }
}
