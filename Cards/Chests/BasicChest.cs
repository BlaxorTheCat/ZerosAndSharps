
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class BasicChest : Chest
    {
        Skill[] lootPool =
            {
                new InstantHeal(10),
                new Attack("Barbarians Faith", 30, 1, 1),
                new Attack("Bow Shot", 7, 0),
                new Attack("Book Cook", 6),
                new Heal("Healing Melody", 14, 8, 4),
                new Heal("Heal Potion", 7, -1, 1),
                new Attack("HARM'ony", 7,2),
                new InstantHeal(15),
                new InstantHeal(5)
            };

        int[] used = new int[3];

        public BasicChest() : base("Basic Chest", 5, Resources.Sprites.Items.Chest, Resources.Colormaps.Items.BasicChest)
        {
            SetLoot();
        }

        public void SetLoot()
        {
            for(int i = 0; i < 3; i++)
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
                if(rng == used[0] || rng == used[1])
                    rng = random.Next(0, lootPool.Length);
                else
                    canBe = true;

            } while (!canBe);

            loot[i] = lootPool[rng];
            used[i] = rng;
        }
    }
}
