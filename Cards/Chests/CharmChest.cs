using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;
using ZerosAndHashtags.Items;

namespace ZerosAndHashtags.Cards
{
    internal class CharmChest:Chest
    {
        Skill[] lootPool =
            {
                new InstantHeal(20),
                new InstantHeal(25),
                new InstantHeal(15),
                new DmgCharm("Red Quartz Ring",4),
                new HealCharm("Duck herbs",5),
                new DefenseCharm("Dragon belt", 3),
                new DefenseCharm("Blue Quartz Ring", 4),
                new DmgCharm("Wooden spoon", 6),
            };

        int[] used = new int[3];

        public CharmChest():base("Charm Chest", 8, Resources.Sprites.Items.Chest, Resources.Colormaps.Items.CharmChest)
        {
            SetLoot();
        }

        public void SetLoot()
        {
            for (int i = 0; i < 3; i++)
            {
                SetLootSlot(i);
            }
        }

        void SetLootSlot(int i)
        {
            var rng = random.Next(0, lootPool.Length);
            bool canBe = false;

            do
            {
                if (rng == used[0] || rng == used[1])
                    rng = random.Next(0, lootPool.Length);
                else
                    canBe = true;

            } while (!canBe);

            loot[i] = lootPool[rng];
            used[i] = rng;
        }
    }
}
