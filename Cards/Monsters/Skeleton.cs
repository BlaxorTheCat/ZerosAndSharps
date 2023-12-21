using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class Skeleton:Entity
    {
        public Skeleton() : base("Skeleton", 8, Resources.Sprites.Enemy.Skeleton, Resources.Colormaps.Enemy.Skeleton)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[3];
            attacks[0] = new Attack("Bone throw",6,2);
            attacks[1] = new Attack("Bone bash", 4);
            attacks[2] = new Attack("Calcium overdose", 3,0);
            heals = new Heal[1];
            heals[0] = new Heal("Calcium drink",5);
        }
    }
}
