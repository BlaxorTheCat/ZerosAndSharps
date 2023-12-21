using System;
using ZerosAndHashtags.Attacks;
using ZerosAndHashtags.Items;
using ZerosAndHashtags.UI;

namespace ZerosAndHashtags.Cards
{
    internal class Player : Entity
    {
        public StartSet set;

        public Player(string name, int health, StartSet set = StartSet.Warrior) : base(name, health, Resources.Sprites.Player.PlayerTMP, Resources.Colormaps.Player.PlayerTMP)
        {
            this.set = set;
            charm = null;

            switch (set)
            {
                case StartSet.Warrior:
                    hp = 20;
                    SkillSets.Warrior(attacks, heals);
                    spritePath = Resources.Sprites.Player.Warrior;
                    colorMap = Resources.Colormaps.Player.Warrior;
                    break;
                case StartSet.Bard:
                    hp = 30;
                    SkillSets.Bard(attacks, heals);
                    spritePath = Resources.Sprites.Player.Bard;
                    colorMap = Resources.Colormaps.Player.Bard;
                    break;
                case StartSet.Sorcerer:
                    hp = 12;
                    SkillSets.Sorcerer(attacks, heals, this);
                    spritePath = Resources.Sprites.Player.Sorcerer;
                    colorMap = Resources.Colormaps.Player.Sorcerer;
                    break;
                case StartSet.Barbarian:
                    hp = 15;
                    SkillSets.Barbarian(attacks, heals);
                    spritePath = Resources.Sprites.Player.Barbarian;
                    colorMap = Resources.Colormaps.Player.Barbarian;
                    break;
                default:
                    break;
            }

            maxHp = hp;
            usedSkill = null;
            SetSkillOwner();
        }

        public Player()
        {
        }

        public void SetSkillOwner()
        {
            foreach(var item in attacks)
            {
                if(item != null)
                    item.owner = this;
            }
            foreach (var item in heals)
            {
                if (item != null)
                    item.owner = this;
            }
        }

        public void SetSkillOwner(int id, bool attack)
        {
            if(attack)
                attacks[id].owner = this;
            else
                heals[id].owner = this;
        }

        public void UseSkills()
        {
            DisplaySkills();
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        DisplayAttack();
                        PlayerAttack();
                        return;
                    case ConsoleKey.D2:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        DisplayHeal();
                        PlayerHeal();
                        return;
                    case ConsoleKey.Escape:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        return;
                }
            }
        }

        int attack = 0;

        public void PlayerAttack()
        {
            bool isAttacking = true;
            while (isAttacking)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        if (attacks[0] != null)
                        {
                            AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                            attack = 0;
                            isAttacking = false;
                        }else
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);

                        break;
                    case ConsoleKey.D2:
                        if (attacks[1] != null)
                        {
                            AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                            attack = 1;
                            isAttacking = false;
                        }
                        else
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        break;
                    case ConsoleKey.D3:
                        if (attacks[2] != null)
                        {
                            AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                            attack = 2;
                            isAttacking = false;
                        }
                        else
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        break;
                    case ConsoleKey.D4:
                        if (attacks[3] != null)
                        {
                            AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                            attack = 3;
                            isAttacking = false;
                        }
                        else
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        break;
                    case ConsoleKey.Escape:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        UseSkills();
                        return;
                }
            }
            DisplayEnemys();
            ChooseEnemy();
        }

        public void PlayerHeal()
        {
            bool isHealing = true;
            while (isHealing)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        if (heals[0] != null)
                        {
                            if (heals[0].canUse)
                            {
                                AudioPlaybackEngine.Instance.PlaySound(SFX.heal);
                                heals[0].Use(this);
                                usedSkill = heals[0];
                                isHealing = false;
                            }
                            else
                                AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        }
                        else
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        break;
                    case ConsoleKey.D2:
                        if (heals[1] != null)
                        {
                            if (heals[1].canUse)
                            {
                                AudioPlaybackEngine.Instance.PlaySound(SFX.heal);
                                heals[1].Use(this);
                                usedSkill = heals[1];
                                isHealing = false;
                            }
                            else
                                AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        }
                        else
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        break;
                    case ConsoleKey.Escape:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        UseSkills();
                        return;
                }
            }
        }

        public void ChooseEnemy()
        {
            bool isChoosing = true;
            while (isChoosing)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        if(GameVars.enemyTeritory[0].hp > 0)
                        {
                            AudioPlaybackEngine.Instance.PlayRandom(SFX.hits);
                            attacks[attack].Use(GameVars.enemyTeritory[0]);
                            usedSkill = attacks[attack];
                            dmagedEnemy = GameVars.enemyTeritory[0];
                            isChoosing = false;
                        }
                        else
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        break;
                    case ConsoleKey.D2:
                        if (GameVars.enemyTeritory[1].hp > 0)
                        {
                            AudioPlaybackEngine.Instance.PlayRandom(SFX.hits);
                            attacks[attack].Use(GameVars.enemyTeritory[1]);
                            usedSkill = attacks[attack];
                            dmagedEnemy = GameVars.enemyTeritory[1];
                            isChoosing = false;
                        }
                        else
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        break;
                    case ConsoleKey.D3:
                        if (GameVars.enemyTeritory[2].hp > 0)
                        {
                            AudioPlaybackEngine.Instance.PlayRandom(SFX.hits);
                            attacks[attack].Use(GameVars.enemyTeritory[2]);
                            usedSkill = attacks[attack];
                            dmagedEnemy = GameVars.enemyTeritory[2];
                            isChoosing = false;
                        }
                        else
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        break;
                    case ConsoleKey.Escape:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                        UseSkills();
                        return;
                }
            }
        }

        public override void takeDmg(int dmg)
        {
            if (Options.buddha)
                return;

            //if (charm != null && charm.type == "DefenseCharm")
            //{
            //    //if(dmg >= charm.dmgReduction)
            //    //{

            //    //}
            //    var dmgRed = charm.RoolBoost();
            //    dmg -= dmgRed;

            //    if (dmg < 0)
            //        dmg = 0;
            //}

            if (hp - dmg < 0)
                hp = 0;
            else
                hp -= dmg;
        }

        //Display Functions
        public void DisplaySkillsDev()
        {
            Console.SetCursorPosition(0, 32);
            Console.WriteLine("Attacks");
            for (int i = 1; i <= attacks.Length; i++)
            {
                Skill attack = attacks[i - 1];
                if (attack != null)
                {
                    string md = $", Minimal DMG: {attack.minDmg}";
                    string cc = $", Crit Chance:{attack.critChance}%";

                    if (attack.minDmg <= -1)
                        md = "";

                    if (attack.critChance <= 0)
                        cc = "";

                    Console.WriteLine($"[{i}] {attack.name}, DMG:{attack.dmg}{md}{cc}");
                }
                else
                    Console.WriteLine($"[{i}] No Item");
            }
            Console.WriteLine("Heals");
            for (int i = 1; i <= heals.Length; i++)
            {
                Skill heal = heals[i - 1];
                if (heal != null)
                {
                    string mh = $", Minimal Heal: {heal.minHeal}";

                    if (heal.minHeal <= -1)
                        mh = "";

                    Console.WriteLine($"[{i + attacks.Length}] {heal.name}, Heal Value:{heal.healValue}{mh}");
                }
                else
                    Console.WriteLine($"[{i + attacks.Length}] No Item");
            }
        }

        public void DisplaySkills(int x = 0, int y = 34)
        {
            Canvas.DrawRect(x, y, 40, 8);
            Console.SetCursorPosition(x, y);
            Console.WriteLine("[1] Attack!");
            Console.WriteLine("[2] Heal!");
            Console.Write("Charm: ");
            if (charm != null)
                charm.Display();
            else
                Console.Write("No Charm\n");
            Console.WriteLine("[ESC] Skip");
        }

        public void DisplayAttack(int x = 0, int y = 34)
        {
            Canvas.DrawRect(x, y, 40, 8);
            Console.SetCursorPosition(x, y);
            for (int i = 1; i <= attacks.Length; i++)
            {
                Skill attack = attacks[i - 1];
                if (attack != null)
                {
                    Console.Write($"[{i}] ");
                    attack.Display();
                }
                else
                    Console.WriteLine($"[{i}] No Item");

            }
            Console.WriteLine($"[ESC] To Go Back");
        }

        public void DisplayHeal(int x = 0,int  y = 34)
        {
            Canvas.DrawRect(x, y, 40, 8);
            Console.SetCursorPosition(x, y);
            for (int i = 1; i <= heals.Length; i++)
            {
                Skill heal = heals[i - 1];
                if (heal != null)
                {
                    Console.Write($"[{i}] ");
                    heal.Display();
                }
                else
                    Console.WriteLine($"[{i}] No Item");
            }
            Console.WriteLine($"[ESC] To Go Back");
        }

        public void DisplayEnemys(int x = 0, int y = 34)
        {
            Canvas.DrawRect(x, y, 40, 8);
            Console.SetCursorPosition(x, y);
            for (int i = 1; i <= GameVars.enemyTeritory.Length; i++)
            {
                var cur = GameVars.enemyTeritory[i - 1];
                Console.WriteLine($"[{i}] {cur.name} {cur.hp}hp / {cur.maxHp}hp");
            }
            Console.WriteLine($"[ESC] To Go Back");
        }

        public void DisplayActionMode()
        {
            if (Options.dmgNumb)
                DisplayActionNumbers();

            if (Options.dmgText)
                DisplayActions();

            usedSkill = null;
            dmagedEnemy = null;
        }
        
        public override void DisplayActions(int x = 0, int y = 32)
        {
            Canvas.DrawRect(x,y,40,1);
            if (usedSkill == null)
                return;

            if (usedSkill.type == "Attack")
            {
                Console.SetCursorPosition(x, y);

                if (usedSkill.valueGiven == 0)
                    Console.Write($"Used {usedSkill.name}, but missed!");
                else
                    Console.Write($"Used {usedSkill.name}, dealing {usedSkill.valueGiven} dmg to {dmagedEnemy.name} [pos: {dmagedEnemy.id + 1}]");
            }
            else
            {
                Console.SetCursorPosition(x, y);

                if (usedSkill.valueGiven == 0)
                    Console.Write($"Used {usedSkill.name}, but missed!");
                else
                    Console.Write($"Used {usedSkill.name}, healing for {usedSkill.valueGiven} hp");
            }
        }

        public override void DisplayActionNumbers()
        {
            if (usedSkill == null)
                return;

            if (usedSkill.type == "Attack")
            {
                if (usedSkill.valueGiven != 0)
                {
                    var dmgPosX = GameVars.enemyPos[dmagedEnemy.id, 0] + 9;
                    var dmgPosY = GameVars.enemyPos[dmagedEnemy.id, 1] + 2;
                    string dmgTxt = $"-{usedSkill.valueGiven}hp";
                    Canvas.DrawText(dmgTxt, dmgPosX, dmgPosY, ConsoleColor.DarkRed);
                }
            }
            else
            {
                if (usedSkill.valueGiven != 0)
                {
                    var healPosX = 0;
                    var healPosY = 17;
                    string healTxt = $" +{usedSkill.valueGiven}hp";
                    Canvas.DrawText(healTxt, healPosX, healPosY, ConsoleColor.Green);
                }
            }
        }
    }
}
