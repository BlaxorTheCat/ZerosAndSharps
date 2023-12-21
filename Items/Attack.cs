using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZerosAndHashtags.Attacks
{
    internal class Attack:Skill
    {
        public Attack(string name, int dmg, int minDmg = -1, int cc = 0, Entity owner = null):base()
        {
            this.name = name;
            this.dmg = dmg;
            this.minDmg = minDmg;
            critChance = cc;
            this.owner = owner;
        }

        public Attack() : base() { }

        public override int RoolBoost()
        {
            throw new NotImplementedException();
        }

        public override void Use(Entity target)
        {
            if(Options.instakill && target.type != "Player")
            {
                target.takeDmg(999);
                valueGiven = 999;
                return;
            }

            int dmg = this.dmg;

            if (minDmg > -1)
            {
                dmg = random.Next(minDmg, this.dmg + 1);
            }

            if (critChance > 0)
            {
                int roll = random.Next(1, 101);
                if (roll <= critChance)
                    dmg *= 2;
            }

            if(owner != null && owner.charm != null && owner.charm.type == "DmgCharm")
            {
                var dmgBoost = owner.charm.RoolBoost();
                dmg += dmgBoost;
            }

            if (target.charm != null && target.charm.type == "DefenseCharm")
            {
                var dmgRed = target.charm.RoolBoost();
                dmg -= dmgRed;

                if (dmg < 0)
                    dmg = 0;
            }

            target.takeDmg(dmg);
            valueGiven = dmg;
        }

        public override void Display()
        {
            string md = $", Minimal DMG: {minDmg}";
            string cd = $", Cool down after use: {coolDown}";
            string cc = $", Crit Chance: {critChance}%";

            if (minDmg <= -1)
                md = "";

            if (critChance <= 0)
                cc = "";

            if (coolDown <= 0)
                cd = "";

            Console.WriteLine($"{name}, DMG:{dmg}{md}{cc}{cd}");
        }

        public override void countDown() { }
    }
}
