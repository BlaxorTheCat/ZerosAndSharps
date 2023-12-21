using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class Bat:Entity
    {
        public Bat(string name, int health) : base(name, health, Resources.Sprites.Enemy.Bat, Resources.Colormaps.Enemy.Bat)
        {
            setSkills();
        }

        public Bat() : base("Bat", 5, Resources.Sprites.Enemy.Bat, Resources.Colormaps.Enemy.Bat)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[3];
            attacks[0] = new Attack("Bite", 2);
            attacks[1] = new Attack("Small fang", 4);
            attacks[2] = new Attack("Big fang", 6);
            heals = new Heal[0];
        }
    }
}
