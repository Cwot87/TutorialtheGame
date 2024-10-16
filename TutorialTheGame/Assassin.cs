﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialTheGame
{
    class Assassin : Enemy
    {
        // Förutom de egenskaper som finns i basklassen Enemy, har lönnmördaren möjligheten
        // att vara osynlig
        bool isVisible;

        // Konstruktor
        public Assassin(string name)
        {
            Random random = new Random();
            Health = 20 + random.Next(0, 80);
            BaseDamage = 20;
            Armor = 15;
            isVisible = false; // TODO: random på/av???
            Name = name;
            //ExpReward = 5; //Får bestämma ;)
        }

        // Ger information om lönnmördaren.
        public override string GetInfo() /*?*/
        {
            if (isVisible)
                return base.GetInfo();
            else
                return null;
        }

        // lönnmördaren attackerar olika beroende på om den är synlig eller inte:
        public override int Attack()
        {
            int damage;
            // if it is visible, it will attack
            Random random = new Random();

            if (isVisible)
            {
                damage = BaseDamage + random.Next(0, 30);
                Console.WriteLine($"{Name} Stabs you with it's dagger for {damage} damage");
                Console.WriteLine("---------------------------");

                isVisible = false;
                return damage;
            }
            else
            {
                damage = BaseDamage + random.Next(0, 10);
                Console.WriteLine($"A arrow shoots from somewhere for {damage} damage");
                Console.WriteLine("---------------------------");

                isVisible = true;
                return damage;
            }
        }

        // lönnmördaren försvarar sig men bara om den är synlig, annars tar den ingen skada 
        public override void Defend(int damage)
        {
            if (isVisible)
            {
                base.Defend(damage);
            }
        }
    }
}