
using ZerosAndHashtags.Attacks;


namespace ZerosAndHashtags.Cards.Monsters
{
    internal class BlueSlime:Slime
    {
        public BlueSlime():base("Blue Slime", 6, Resources.Sprites.Enemy.Slime, Resources.Colormaps.Enemy.BlueSlime)
        {
            heals[0] = new Heal("Big Slime Drink", 6);
            attacks[1] = new Attack("Water Splash", 3);
        }
    }
}
