
using ZerosAndHashtags.Attacks;

namespace ZerosAndHashtags.Cards
{
    internal class Slime : Entity
    {
        public Slime(string name, int health, string sprite, string colorMap) : base(name, health, sprite, colorMap)
        {
            setSkills();
        }

        public Slime() : base("Green Slime", 10, Resources.Sprites.Enemy.Slime, Resources.Colormaps.Enemy.BasicSlime)
        {
            setSkills();
        }

        private void setSkills()
        {
            attacks = new Attack[2];
            attacks[0] = new Attack("Slime Ball", 2);
            attacks[1] = new Attack("Spit", 1);
            heals = new Heal[1];
            heals[0] = new Heal("Slime Drink",2); 
        }
    }
}
