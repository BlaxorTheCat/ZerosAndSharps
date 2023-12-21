using System;
using ZerosAndHashtags.Cards;
using ZerosAndHashtags.Items;

namespace ZerosAndHashtags.Attacks
{
    abstract class Skill
    {
        //This class is just here for loot in chest purpuses so that attack and heal can be made from it
        //this ^^^ was my first thought it got more complicated than that... :(
        public string type;

        public string name = "Basic Attack";
        public string desc = "This is a attack";

        public int coolDown = 0;
        public bool canUse = true;
        protected int timer;


        public int dmg = 1;
        public int minDmg = -1;
        public int critChance = 0;

        public int healValue = 1;
        public int minHeal = -1;

        public int valueGiven = 0;

        public Entity owner = null;

        protected Random random = new Random();

        public Skill()
        {
            type = GetType().Name;
        }

        public abstract void Display();

        public abstract void Use(Entity target);

        public abstract void countDown();

        public abstract int RoolBoost();
    }

    struct SkillSets
    {
        static public void Warrior(Skill[] attacks, Skill[] heals)
        {
            attacks[0] = new Attack("Sword Slice", 5);
            attacks[1] = new Attack("Bow Shot", 7, 0);
            attacks[2] = new Attack("Range Ranger", 10, 1, 25);
            attacks[3] = null;

            heals[0] = new Heal("Warrior's Spirit", 6, -1, 1);
            heals[1] = null; 
        }

        static public void Bard(Skill[] attacks, Skill[] heals)
        {
            attacks[0] = new Attack("HARM'ony", 7, 2);
            attacks[1] = new Attack("Guitar Bash", 4);
            attacks[2] = null;
            attacks[3] = null;

            heals[0] = new Heal("Healing Melody", 14, 8, 4);
            heals[1] = new Heal("God's melody", 30, 5, 2);
        }

        static public void Sorcerer(Skill[] attacks, Skill[] heals, Player player)
        {
            attacks[0] = new Attack("Poison", 8, 4);
            attacks[1] = new Attack("Book Cook", 6);
            attacks[2] = null;
            attacks[3] = null;

            heals[0] = new Heal("Heal Potion", 7, -1, 1);
            heals[1] = null;

            player.charm = new DefenseCharm("Frog tooth", 4);
        }

        static public void Barbarian(Skill[] attacks, Skill[] heals)
        {
            attacks[0] = new Attack("AXE THROW!!!", 15, 8);
            attacks[1] = new Attack("Barbarians Faith", 30, 1, 1);
            attacks[2] = new Attack("Barbarian Bash", 10, 5);
            attacks[3] = null;

            heals[0] = new Heal("Warrior's Spirit", 6, -1, 1);
            heals[1] = null;
        }
    }
}