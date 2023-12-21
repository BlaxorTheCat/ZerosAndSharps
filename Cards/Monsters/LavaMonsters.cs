using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class Fire:Entity
    {
        public Fire() : base("Spark", 3, Resources.Sprites.Enemy.Fire, Resources.Colormaps.Enemy.Fire)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[1];
            attacks[0] = new Attack("Fire Ball", 6, 5);
            heals = new Heal[0];
        }
    }

    class LavaSlime : Slime
    {
        public LavaSlime() : base("Lava Slime", 6, Resources.Sprites.Enemy.LavaSlime, Resources.Colormaps.Enemy.LavaSlime)
        {
            attacks = new Attack[2];
            attacks[0] = new Attack("Lava Ball", 4);
            attacks[1] = new Attack("Spark attack!", 2);
            heals = new Heal[1];
            heals[0] = new Heal("Lava Regen", 6, 3);
        }
    }

    class Wizard : Entity
    {
        public Wizard() : base("Fire Mage", 12, Resources.Sprites.Player.Sorcerer, Resources.Colormaps.Enemy.Wizard)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[2];
            attacks[0] = new Attack("Fire Ball", 6, 3);
            attacks[0] = new Attack("Ice Ball", 4);
            heals = new Heal[1];
            heals[0] = new Heal("Lava Potion", 10, 3);
        }
    }
}
