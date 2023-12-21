using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerosAndHashtags.Attacks;
using ZerosAndHashtags.UI;

namespace ZerosAndHashtags.Cards
{
    internal abstract class Chest : Entity
    {
        public Skill[] loot = new Skill[3];

        public bool notUsed = true;

        public Chest(string name, int hp, string spritePath, string colorMap) : base(name, hp, spritePath, colorMap)
        {
            type = "Chest";
        }

        public Chest() : base()
        {
            type = "Chest";
        }

        public override void Think(Player player)
        {
            if(hp <= 0 && notUsed)
            {
                AudioPlaybackEngine.Instance.PlaySound(@"Assets/Sound/SFX\loot.wav");
                DrawSprite(GameVars.enemyPos[id, 0], GameVars.enemyPos[id, 1], 8, 8, true);
                ChooseLoot(player);
                notUsed = false;
            }
        }

        public override void CheackDead()
        {
            return;
        }

        string skillType;
        public void ChooseLoot(Player player)
        {
            DisplayLoot();
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        if (loot[0] == null)
                        {
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                            break;
                        }


                        if (loot[0].type == "InstantHeal")
                        {
                            loot[0].Use(player);
                            player.usedSkill = loot[0];
                            AudioPlaybackEngine.Instance.PlaySound(SFX.heal);
                        }
                        else
                            ChangeSkill(loot[0], player);

                        return;
                    case ConsoleKey.D2:
                        if (loot[1] == null)
                        {
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                            break;
                        }

                        if (loot[1].type == "InstantHeal")
                        {
                            AudioPlaybackEngine.Instance.PlaySound(SFX.heal);
                            loot[1].Use(player);
                            player.usedSkill = loot[1];
                        }
                        else
                            ChangeSkill(loot[1], player);

                        return;
                    case ConsoleKey.D3:
                        if (loot[2] == null)
                        {
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                            break;
                        }

                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);

                        if (loot[2].type == "InstantHeal")
                        {
                            AudioPlaybackEngine.Instance.PlaySound(SFX.heal);
                            loot[2].Use(player);
                            player.usedSkill = loot[2];
                        }
                        else
                            ChangeSkill(loot[2], player);

                        return;
                    case ConsoleKey.Escape:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        return;
                }
            }
        }

        public void ChangeSkill(Skill skill, Player player)
        {
            Canvas.DrawRect(0, 32, 40, 8);
            if (skill.type == "Attack")
            {
                Console.SetCursorPosition(0, 32);
                Console.WriteLine("Select a slot to store your Loot! (Attacks)");
                player.DisplayAttack(0, 33);
                while (true)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            AudioPlaybackEngine.Instance.PlaySound(SFX.attackSelect);

                            player.attacks[0] = skill;
                            player.SetSkillOwner(0,true);

                            return;
                        case ConsoleKey.D2:
                            AudioPlaybackEngine.Instance.PlaySound(SFX.attackSelect);

                            player.attacks[1] = skill;
                            player.SetSkillOwner(1, true);

                            return;
                        case ConsoleKey.D3:
                            AudioPlaybackEngine.Instance.PlaySound(SFX.attackSelect);

                            player.attacks[2] = skill;
                            player.SetSkillOwner(2, true);

                            return;
                        case ConsoleKey.D4:
                            AudioPlaybackEngine.Instance.PlaySound(SFX.attackSelect);

                            player.attacks[3] = skill;
                            player.SetSkillOwner(3, true);

                            return;
                        case ConsoleKey.Escape:
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                            ChooseLoot(player);
                            return;
                    }
                }
            }
            else if(skill.type == "Heal")
            {
                Console.SetCursorPosition(0, 32);
                Console.WriteLine("Select a slot to store your Loot! (Heals)");
                player.DisplayHeal(0, 33);
                while (true)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                            AudioPlaybackEngine.Instance.PlaySound(SFX.healSelect);

                            player.heals[0] = skill;
                            player.SetSkillOwner(0, false);

                            return;
                        case ConsoleKey.D2:
                            AudioPlaybackEngine.Instance.PlaySound(SFX.healSelect);

                            player.heals[1] = skill;
                            player.SetSkillOwner(1, false);

                            return;
                        case ConsoleKey.Escape:
                            AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                            ChooseLoot(player);
                            return;
                    }
                }
            }
            else
            {
                if(player.charm != null)
                {
                    Console.SetCursorPosition(0, 32);
                    Console.WriteLine("Are you Sure you want to swap your Charm?");
                    Console.WriteLine("[1] Yes \n[2] No");
                    while (true)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                AudioPlaybackEngine.Instance.PlaySound(SFX.charmSelect);
                                player.charm = skill;
                                return;
                            case ConsoleKey.D2:
                                AudioPlaybackEngine.Instance.PlaySound(SFX.nullsfx);
                                ChooseLoot(player);
                                return;
                        }
                    }
                }
                else
                {
                    AudioPlaybackEngine.Instance.PlaySound(SFX.charmSelect);
                    player.charm = skill;
                }
            }
        }

        public void DisplayLoot() 
        {
            Random random = new Random();
            string[] useless = {"Cobwebs","Some Bones","Useless Crap","Dead Rat"};

            Canvas.DrawRect(0, 32, 40, 8);
            Console.SetCursorPosition(0, 32);
            Console.WriteLine("Chose your loot!");
            for (int i = 0; i < loot.Length; i++)
            {
                Console.Write($"[{i+1}] ");
                if (loot[i] != null)
                    loot[i].Display();
                else
                    Console.Write(useless[random.Next(0,useless.Length)]);
            }
            Console.WriteLine("[ESC] to take nothing");
        }
    }
}
