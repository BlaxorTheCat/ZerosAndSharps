using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;
using ZerosAndHashtags.Items;

namespace ZerosAndHashtags.Cards
{
    internal class Crate:Chest
    {
        Skill[] lootPool =
            {
                new InstantHeal(10),
                new InstantHeal(10),
                new InstantHeal(5),
                new InstantHeal(5),
                new DefenseCharm("Mystic Diamond",10),
                new DmgCharm("Binoculars",8),
                new Attack("Broken Bootle", 8, 2, 50)
            };

        int[] used = new int[3];

        public Crate() : base("Supply Crate", 5, Resources.Sprites.Items.Crate, Resources.Colormaps.Items.Crate)
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
