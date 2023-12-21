using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;
using ZerosAndHashtags.Cards;

namespace ZerosAndHashtags.Items
{
    class Charm:Skill
    {
        public int valueBoost;

        public Charm(string _name, int _valueBoost)
        {
            name = _name;
            valueBoost = _valueBoost;
            type = GetType().Name;
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }
        public override void Use(Entity target)
        {
            throw new NotImplementedException();
        }
        public override void countDown()
        {
            throw new NotImplementedException();
        }

        public override int RoolBoost()
        {
            return random.Next(0,valueBoost);
        }
    }

    class DefenseCharm:Charm
    {
        public DefenseCharm(string _name, int damageReduction):base(_name, damageReduction)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"{name}, Max Damage Reduction: {valueBoost} hp");
        }
    }

    class HealCharm : Charm
    {
        public HealCharm(string _name, int healthBoost) : base(_name, healthBoost)
        {
            valueBoost = healthBoost;
        }

        public override void Display()
        {
            Console.WriteLine($"{name}, Max Heal Bonus: {valueBoost} hp");
        }
    }

    class DmgCharm:Charm
    {
        public DmgCharm(string _name, int dmgBoost) : base(_name, dmgBoost)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"{name}, Max Dmg Bonus: {valueBoost} dmg");
        }
    }
}
