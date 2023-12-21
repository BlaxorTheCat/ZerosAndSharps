using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class GlowShroom:Mushroom
    {
        public GlowShroom():base("Glowshroom", 6, Resources.Sprites.Enemy.Mushroom, Resources.Colormaps.Enemy.BlueMushroom)
        {
            attacks = new Attack[1];
            attacks[0] = new Attack("Glow Shot", 10, 0, 10);
        }
    }
}
