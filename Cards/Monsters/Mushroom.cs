using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class Mushroom:Entity
    {
        public Mushroom(string name, int health, string sprite, string colorMap) : base(name, health, sprite, colorMap)
        {
            setSkills();
        }

        public Mushroom():base("Mushroom", 12, Resources.Sprites.Enemy.Mushroom, Resources.Colormaps.Enemy.RedMushroom)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[1];
            attacks[0] = new Attack("Spore Shot", 8, 2, 5);
            heals = new Heal[2];
            heals[0] = new Heal("Pheromones", 6, 2);
            heals[1] = new Heal("Spore Fumes", 3, 1);
        }
    }
}
