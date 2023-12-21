using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class HealChest:Chest
    {
        Skill[] lootPool =
            {
                new InstantHeal(10),
                new InstantHeal(20),
                new InstantHeal(15),
                new InstantHeal(5),
                new Heal("Bottle of ???", 20, 1, 3)
            };

        bool used = false;

        public HealChest() : base("Heal Chest", 3, Resources.Sprites.Items.Chest, Resources.Colormaps.Items.HealChest)
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
            int rng;

            if (used)
                rng = random.Next(0, lootPool.Length - 1);
            else
                rng = random.Next(0, lootPool.Length);

            if (rng == lootPool.Length - 1)
                used = true;

            loot[i] = lootPool[rng];
        }
    }
}
