using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Items;

namespace ZerosAndHashtags.Attacks
{
    internal class Heal:Skill
    {
        public Heal(string name, int healValue, int minHeal = -1, int coolDown = 0) : base()
        {
            this.name = name;
            this.healValue = healValue;
            this.minHeal = minHeal;
            this.coolDown = coolDown;
            timer = coolDown + 1;
        }

        public override int RoolBoost()
        {
            throw new NotImplementedException();
        }

        public override void Use(Entity target)
        {
            if (!canUse) return;

            int heal = healValue;
            if(minHeal > -1)
            {
                heal = random.Next(minHeal, healValue + 1);
            }

            if (target.charm != null && target.charm.type == "HealCharm")
            {
                var boost = target.charm.RoolBoost();
                heal += boost;
            }

            target.Heal(heal);
            valueGiven = heal;

            if(coolDown > 0)
            {
                canUse = false;
            }
        }

        public override void Display()
        {
            string mh = $", Minimal Heal: {minHeal}";
            string durn = coolDown > 1 ? "turns" : "turn";
            string cd = $", Cool down after use: {coolDown} {durn}";

            if (minHeal <= -1)
                mh = "";

            if (coolDown <= 0)
                cd = "";

            if (canUse)
                Console.WriteLine($"{name}, Heal Value:{healValue}{mh}{cd}");
            else
            {
                string turn = timer > 1 ? "turns" : "turn";
                Console.WriteLine($"{name}, Heal Value: {healValue}{mh} [Avaible in {timer} {turn}]");
            }

        }

        public override void countDown()
        {
            if (canUse) return;

            timer--;

            if(timer <= 0)
            {
                canUse = true;
                timer = coolDown + 1;
            }
        }
    }

    internal class InstantHeal : Heal
    {
        public InstantHeal(int healValue) : base("Instant heal", healValue, -1, 0)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"{name} for {healValue} hp");
        }
    }
}
