using System;
using ZerosAndHashtags.UI;

namespace ZerosAndHashtags
{
    internal class Card
    {
        Healthbar healthbar;

        public string name;
        public int hp;
        public int maxHp;
        public string type;

        public string spritePath;
        public string colorMap;

        public Card(string name, int health, string spritePath, string colorMap) 
        {
            type = GetType().Name;

            this.name = name;
            hp = health;
            maxHp = hp;

            this.spritePath = spritePath;
            this.colorMap = colorMap;

            healthbar = new Healthbar(this);
        }

        public Card()
        {
            type = GetType().Name;

            name = type;
            hp = 1;
            maxHp = hp;

            this.spritePath = Resources.Sprites.Player.PlayerTMP;
            this.colorMap = Resources.Colormaps.Player.PlayerTMP;

            healthbar = new Healthbar(this);
        }

        public virtual void takeDmg(int dmg)
        {
            if (hp - dmg < 0)
                hp = 0;
            else
                hp -= dmg;
        }

        public virtual void Heal(int heal)
        {
            if (hp + heal > maxHp)
                hp = maxHp;
            else
                hp += heal;
        }

        public void DrawSprite(int x = 0, int y = 0, int width = 8, int height = 8,bool drawHealth = true,ConsoleColor color = ConsoleColor.White)
        {
            if(drawHealth && x + 1 < Console.WindowWidth && y - 2 >= 0)
            {
                healthbar.DrawBar(x + 1, y - 2);
            }
            Canvas.DrawRect(x, y, width, height);
            Canvas.DrawImage(spritePath, width, height, x, y, colorMap, color);
        }

        public void DrawHealth(int x = 0, int y = 0, ConsoleColor color = ConsoleColor.Green)
        {
            healthbar.DrawBar(x + 1, y - 2, color);
        }

        public void DevDisplay()
        {
            Console.WriteLine($"Name: {name}, HP: {hp}");
        }
    }
}
