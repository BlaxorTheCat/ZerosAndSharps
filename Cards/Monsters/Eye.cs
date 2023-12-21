using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class Eye:Entity
    {
        public Eye(string name, int health, string sprite, string colorMap) : base(name, health, sprite, colorMap)
        {
            setSkills();
        }

        public Eye() : base("Eye of Cyclops", 7, Resources.Sprites.Enemy.Eye, Resources.Colormaps.Enemy.BasicEye)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[2];
            attacks[0] = new Attack("Staredown", 3, 0, 50);
            attacks[1] = new Attack("Orbital fracture", 6);
            heals = new Heal[1];
            heals[0] = new Heal("God Tears", 5);
        }
    }

    internal class RedEye : Eye
    {

        public RedEye() : base("Angry Eye", 3, Resources.Sprites.Enemy.Eye, Resources.Colormaps.Enemy.RedEye)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[4];
            attacks[0] = new Attack("Staredown", 3, -1, 75);
            attacks[1] = new Attack("Orbital fracture", 6);
            attacks[2] = new Attack("Optic nerve", 4);
            attacks[3] = new Attack("Lens throw", 6, 3, 30);
            heals = new Heal[0];
        }
    }

    internal class BlueEye : Eye
    {

        public BlueEye() : base("Eye of Zeus", 10, Resources.Sprites.Enemy.Eye, Resources.Colormaps.Enemy.BlueEye)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[2];
            attacks[0] = new Attack("Staredown", 3, -1, 35);
            attacks[1] = new Attack("Thunder tears", 6, 2);
            heals = new Heal[2];
            heals[0] = new Heal("God Tears", 5);
            heals[1] = new Heal("Light heal", 8);
        }
    }
}
