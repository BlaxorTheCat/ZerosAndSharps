using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class Mimic : Entity
    {
        public Mimic() : base("Mimic", 12, Resources.Sprites.Items.Crate, Resources.Colormaps.Enemy.Mimic)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[3];
            attacks[0] = new Attack("Bite", 6, 2);
            attacks[1] = new Attack("Big fang", 6);
            attacks[2] = new Attack("R.N.G", 8,0,20);
            heals = new Heal[0];
        }
    }
}
