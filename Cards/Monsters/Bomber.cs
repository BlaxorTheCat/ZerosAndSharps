using System;
using ZerosAndHashtags.Attacks;
using ZerosAndHashtags.UI;

namespace ZerosAndHashtags.Cards
{
    internal class Bomber:Entity
    {
        int explodeProc = 15;

        public Bomber(string name, int health, string sprite, string colorMap) : base(name, health, sprite, colorMap)
        {
            
        }

        public Bomber() : base("Bomber", 5, Resources.Sprites.Enemy.Bomber, Resources.Colormaps.Enemy.Bomber)
        {
            attacks = new Skill[1];
            attacks[0] = new Attack("!EXPLODE!",0);
        }

        bool died = false;

        public override void Think(Player player)
        {
            if (hp <= 0)
                return;

            int rnd = random.Next(1,100);
            if(explodeProc > rnd)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (GameVars.enemyTeritory[i] != this)
                        GameVars.enemyTeritory[i].takeDmg(GameVars.enemyTeritory[i].hp / 2);
                }

                if(player.charm != null && player.charm.type == "DefenseCharm")
                {
                    var dmg = (player.hp / 2) - player.charm.RoolBoost();

                    if (dmg < 0)
                        dmg = 0;

                    player.takeDmg(dmg);
                }else
                    player.takeDmg(player.hp / 2);

                usedSkill = attacks[0];
                hp = 0;
            }
        }

        public override void DisplayActions(int x = 0, int y = 33)
        {
            Canvas.DrawRect(x, y, 32, 1);
            Console.SetCursorPosition(x, y);
            if (usedSkill == null)
            {
                Console.Write($"{this.name} is about to blow [pos: {id + 1}]");
            }else
            {
                Console.Write($"{this.name} EXPLODED, taking half of the hp from everyone [pos: {id + 1}]");
            }
        }

        public override void DisplayActionNumbers()
        {
            if (usedSkill == null)
                return;

            var dmgPosX = GameVars.enemyPos[id, 0] + 9;
            var dmgPosY = GameVars.enemyPos[id, 1] + 2;
            string dmgTxt = $"!EXPLODE!";
            Canvas.DrawText(dmgTxt, dmgPosX, dmgPosY, ConsoleColor.Yellow);
        }
    }
}
