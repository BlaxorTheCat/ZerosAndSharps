using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class Tree : Entity
    {
        public Tree(string name, int health) : base(name, health, Resources.Sprites.Enemy.Tree, Resources.Colormaps.Enemy.Tree)
        {
            setSkills();
        }

        public Tree() : base("Treman", 7, Resources.Sprites.Enemy.Tree, Resources.Colormaps.Enemy.Tree)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[2];
            attacks[0] = new Attack("Branched Out", 2);
            attacks[1] = new Attack("Leaf Slap", 4);
            heals = new Heal[1];
            heals[0] = new Heal("Not so Toxic berries", 6, 2);
        }
    }

    class StrongTree:Tree
    {
        public StrongTree() : base("Strong Treman", 10)
        {
        }
    }
}
