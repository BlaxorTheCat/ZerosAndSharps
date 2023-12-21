using System;
using ZerosAndHashtags.Attacks;
using ZerosAndHashtags.Cards;
using ZerosAndHashtags.Items;
using ZerosAndHashtags.UI;

namespace ZerosAndHashtags
{
    internal class Entity : Card
    {
        protected Random random = new Random();

        public int id = 0;

        public Skill[] attacks = new Skill[4];
        public Skill[] heals = new Skill[2];
        public Skill charm;

        public Entity(string name, int health, string spritePath, string colorMap) : base(name, health, spritePath, colorMap)
        {
            usedSkill = null;
        }

        public Entity() : base()
        {
            usedSkill = null;
        }

        public Skill usedSkill = new Attack();
        public Entity dmagedEnemy = GameVars.enemyTeritory[0];

        public void Attack(Entity target)
        {
            int attackID = random.Next(0, attacks.Length);
            attacks[attackID].Use(target);
            usedSkill = attacks[attackID];
            dmagedEnemy = target;
        }

        public void Attack(Entity target, int attackID)
        {
            attacks[attackID].Use(target);
            usedSkill = attacks[attackID];
            dmagedEnemy = target;
        }

        public void UseHeal()
        {
            int healID = random.Next(0, heals.Length);
            heals[healID].Use(this);
            usedSkill = heals[healID];
        }

        bool notdied = true;

        public virtual void CheackDead()
        {
            if (hp <= 0 && notdied)
            {
               notdied = false;
               GameVars.killedEnemys++;
            }
        }

        public virtual void Think(Player player)
        {
            if (hp <= 0)
                return;

            if (hp <= maxHp / 2 && heals.Length > 0)
            {
                int rng = random.Next(0, 2);
                if (rng == 0)
                    Attack(player);
                else
                    UseHeal();
            }
            else
                Attack(player);
        }

        public virtual void UpdateCoolDowns()
        {
            foreach (var item in attacks)
            {
                if (item != null)
                    item.countDown();
            }

            foreach (var item in heals)
            {
                if (item != null)
                    item.countDown();
            }
        }

        public virtual void DisplayActions(int x = 0, int y = 33)
        {
            Canvas.DrawRect(x, y, 40, 1);
            if (usedSkill == null)
                return;

            if (usedSkill.type == "Attack")
            {
                Console.SetCursorPosition(x, y);
                if(usedSkill.valueGiven == 0)
                    Console.Write($"{this.name} used {usedSkill.name}, but missed! [pos: {id + 1}]");
                else
                    Console.Write($"{this.name} used {usedSkill.name}, dealing {usedSkill.valueGiven} dmg to {dmagedEnemy.name} [pos: {id + 1}]");
            }
            else
            {
                Console.SetCursorPosition(x, y);
                if (usedSkill.valueGiven == 0)
                    Console.Write($"{this.name} used {usedSkill.name}, but missed! [pos: {id + 1}]");
                else
                    Console.Write($"{this.name} used {usedSkill.name}, healing for {usedSkill.valueGiven} hp [pos: {id + 1}]");
            }
        }

        public virtual void DisplayActionNumbers()
        {
            if (usedSkill == null)
                return;

            if (usedSkill.type == "Attack")
            {
                if (usedSkill.valueGiven != 0)
                {
                    var dmgPosX = 0;
                    var dmgPosY = 15;
                    string dmgTxt = $" -{usedSkill.valueGiven}hp";
                    Canvas.DrawText(dmgTxt, dmgPosX, dmgPosY, ConsoleColor.DarkRed);
                }
            }
            else
            {
                if (usedSkill.valueGiven != 0)
                {
                    var healPosX = GameVars.enemyPos[id, 0] + 9;
                    var healPosY = GameVars.enemyPos[id, 1] + 4;
                    string healTxt = $"+{usedSkill.valueGiven}hp";
                    Canvas.DrawText(healTxt, healPosX, healPosY, ConsoleColor.Green);
                }
            }

        }
    }
}
