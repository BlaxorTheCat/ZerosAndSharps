using System;
using System.Collections.Generic;
using System.Linq;
using ZerosAndHashtags.Cards;
using ZerosAndHashtags.Cards.Monsters;
using ZerosAndHashtags.UI;

enum CaveEntitys
{
    Bat,
    StrongBat,
    Slime,
    BasicChest,
    BlueSlime,
    Bomber,
    Skeleton,
    Mushroom,
    Glowshroom,
    Eye,
    RedEye,
    BlueEye,
    CharmChest,
    HealChest
}

enum ForestEntitys
{
    Slime,
    BasicChest,
    BlueSlime,
    Bomber,
    Skeleton,
    Mushroom,
    Glowshroom,
    CharmChest,
    HealChest,
    Tree,
    StrongTree,
    Crate,
    Mimic
}

enum LavaEntitys
{
    LavaSlime,
    Skeleton,
    StrongBat,
    Crate,
    Mimic,
    BasicChest,
    Fire,
    Wizard
}

namespace ZerosAndHashtags
{
    internal class GameManager
    {
        static Random random = new Random();

        public static void CheckIfDead()
        {
            for(int i = 0; i<3; i++)
            {
                GameVars.enemyTeritory[i].CheackDead();
            }
        }

        public static void RespawnEnemys()
        {
            for (int i = 0; i < 3; i++)
            {
                if (GameVars.enemyTeritory[i].hp <= 0 && GameVars.respawnWave == 0)
                {
                    SetEnemy(i);
                    DrawEnemy(i);
                }
            }
        }

        public static void SetAllEnemys()
        {
            AddCaveEnemys();
            AddForestEnemys();
            AddLavaEnemys();
            for (int i = 0; i < GameVars.enemyTeritory.Length; i++)
            {
                SetEnemy(i);
                DrawEnemy(i);
            }
        }

        static List<CaveEntitys> caveEnti = new List<CaveEntitys>();
        static List<ForestEntitys> forestEnti = new List<ForestEntitys>();
        static List<LavaEntitys> lavaEnti = new List<LavaEntitys>();

        public static CaveEntitys RollEnemy()
        {
            int n = random.Next(0,caveEnti.Count());
            return caveEnti[n];
        }

        public static ForestEntitys RollEnemyF()
        {
            int n = random.Next(0, forestEnti.Count());
            return forestEnti[n];
        }

        public static LavaEntitys RollEnemyL()
        {
            int n = random.Next(0, lavaEnti.Count());
            return lavaEnti[n];
        }

        public static void SetEnemy(int i)
        {
            if (GameVars.gameLevel == GameLevel.Cave)
            {
                var rolledEnemy = RollEnemy();
                switch (rolledEnemy)
                {
                    case 0:
                        GameVars.enemyTeritory[i] = new Bat();
                        break;
                    case (CaveEntitys)1:
                        GameVars.enemyTeritory[i] = new StrongBat();
                        break;
                    case (CaveEntitys)2:
                        GameVars.enemyTeritory[i] = new Slime();
                        break;
                    case (CaveEntitys)3:
                        GameVars.enemyTeritory[i] = new BasicChest();
                        break;
                    case (CaveEntitys)4:
                        GameVars.enemyTeritory[i] = new BlueSlime();
                        break;
                    case (CaveEntitys)5:
                        GameVars.enemyTeritory[i] = new Bomber();
                        break;
                    case (CaveEntitys)6:
                        GameVars.enemyTeritory[i] = new Skeleton();
                        break;
                    case (CaveEntitys)7:
                        GameVars.enemyTeritory[i] = new Mushroom();
                        break;
                    case (CaveEntitys)8:
                        GameVars.enemyTeritory[i] = new GlowShroom();
                        break;
                    case (CaveEntitys)9:
                        GameVars.enemyTeritory[i] = new Eye();
                        break;
                    case (CaveEntitys)10:
                        GameVars.enemyTeritory[i] = new RedEye();
                        break;
                    case (CaveEntitys)11:
                        GameVars.enemyTeritory[i] = new BlueEye();
                        break;
                    case (CaveEntitys)12:
                        GameVars.enemyTeritory[i] = new CharmChest();
                        break;
                    case (CaveEntitys)13:
                        GameVars.enemyTeritory[i] = new HealChest();
                        break;
                }
            }
            else if(GameVars.gameLevel == GameLevel.Forest)
            {
                //Slime,
                //BasicChest,
                //BlueSlime,
                //Bomber,
                //Skeleton,
                //Mushroom,
                //Glowshroom,
                //CharmChest,
                //HealChest,
                //Tree
                var rolledEnemy = RollEnemyF();
                switch (rolledEnemy)
                {
                    case 0:
                        GameVars.enemyTeritory[i] = new Slime();
                        break;
                    case (ForestEntitys)1:
                        GameVars.enemyTeritory[i] = new BasicChest();
                        break;
                    case (ForestEntitys)2:
                        GameVars.enemyTeritory[i] = new BlueSlime();
                        break;
                    case (ForestEntitys)3:
                        GameVars.enemyTeritory[i] = new Bomber();
                        break;
                    case (ForestEntitys)4:
                        GameVars.enemyTeritory[i] = new Skeleton();
                        break;
                    case (ForestEntitys)5:
                        GameVars.enemyTeritory[i] = new Mushroom();
                        break;
                    case (ForestEntitys)6:
                        GameVars.enemyTeritory[i] = new GlowShroom();
                        break;
                    case (ForestEntitys)7:
                        GameVars.enemyTeritory[i] = new CharmChest();
                        break;
                    case (ForestEntitys)8:
                        GameVars.enemyTeritory[i] = new HealChest();
                        break;
                    case (ForestEntitys)9:
                        GameVars.enemyTeritory[i] = new Tree();
                        break;
                    case (ForestEntitys)10:
                        GameVars.enemyTeritory[i] = new StrongTree();
                        break;
                    case (ForestEntitys)11:
                        GameVars.enemyTeritory[i] = new Crate();
                        break;
                    case (ForestEntitys)12:
                        GameVars.enemyTeritory[i] = new Mimic();
                        break;
                }
            }
            else if(GameVars.gameLevel == GameLevel.LavaLake)
            {
                //LavaSlime,
                //Skeleton,
                //StrongBat,
                //Crate,
                //Mimic,
                //BasicChest,
                //Fire,
                //Wizard
                var rolledEnemy = RollEnemyL();
                switch (rolledEnemy)
                {
                    case 0:
                        GameVars.enemyTeritory[i] = new LavaSlime();
                        break;
                    case (LavaEntitys)1:
                        GameVars.enemyTeritory[i] = new Skeleton();
                        break;
                    case (LavaEntitys)2:
                        GameVars.enemyTeritory[i] = new StrongBat();
                        break;
                    case (LavaEntitys)3:
                        GameVars.enemyTeritory[i] = new Crate();
                        break;
                    case (LavaEntitys)4:
                        GameVars.enemyTeritory[i] = new Mimic();
                        break;
                    case (LavaEntitys)5:
                        GameVars.enemyTeritory[i] = new BasicChest();
                        break;
                    case (LavaEntitys)6:
                        GameVars.enemyTeritory[i] = new Fire();
                        break;
                    case (LavaEntitys)7:
                        GameVars.enemyTeritory[i] = new Wizard();
                        break;
                }
            }
            GameVars.enemyTeritory[i].id = i;
        }

        public static void Draw()
        {
            for (int i = 0; i < 3; i++)
            {
                DrawEnemyHealth(i);
            }
        }

        //Draw whole enemy with health
        public static void DrawEnemy(int i)
        {
            GameVars.enemyTeritory[i].DrawSprite(GameVars.enemyPos[i,0], GameVars.enemyPos[i, 1], 8, 8, false);
        }

        //draw only health
        public static void DrawEnemyHealth(int i)
        {
            GameVars.enemyTeritory[i].DrawHealth(GameVars.enemyPos[i, 0], GameVars.enemyPos[i, 1]);
        }

        static public int choosenEnemy = 0;

        public static void UseEnemys(Player player)
        {
            List<int> deadEnemys = new List<int>();

            bool[] dead = {false, false, false};
            //check for dead enemys
            for (int i = 0; i < 3; i++)
            {
                if(GameVars.enemyTeritory[i].hp <= 0 || GameVars.enemyTeritory[i].type == "Chest")
                {
                    deadEnemys.Add(i);
                    dead[i] = true;
                }
                
                if(GameVars.enemyTeritory[i].type == "Chest")
                {
                    GameVars.enemyTeritory[i].Think(player);
                }
            }

            //if all dead just Die
            if (deadEnemys.Count >= 3)
            {
                Canvas.DrawRect(0, 33, 32, 1);
                return;
            }

            int rng = random.Next(0, 3);
            if(deadEnemys.Count == 1)
            {
                switch(deadEnemys[0])
                {
                    case 0:
                        rng = random.Next(1, 3);
                        break;
                    case 1:
                        rng = random.Next(0, 2);
                        if (rng == 1)
                            rng++;
                        break;
                    case 2:
                        rng = random.Next(0, 2);
                        break;
                }
            }else if(deadEnemys.Count == 2)
            {
                if (dead[0] && dead[1])
                {
                    rng = 2;
                }
                else if (dead[1] && dead[2])
                {
                    rng = 0;
                }
                else if (dead[0] && dead[2])
                {
                    rng = 1;
                }
            }

            GameVars.enemyTeritory[rng].Think(player);
            choosenEnemy = rng;
        }

        static public void DisplayActivity()
        {
            if (Options.dmgNumb)
                GameVars.enemyTeritory[choosenEnemy].DisplayActionNumbers();

            if (Options.dmgText)
                GameVars.enemyTeritory[choosenEnemy].DisplayActions();
        }

        static public void SwapEnemy(int id, Entity entity)
        {
            GameVars.enemyTeritory[id] = entity;
            GameVars.enemyTeritory[id].id = id;
            GameVars.enemyTeritory[id].DrawSprite(GameVars.enemyPos[id,0], GameVars.enemyPos[id, 1], 8, 8, true);
        }

        //Enemy Add function for levels
        private static void AddCaveEnemys()
        {
            for (int i = 0; i < 45; i++)
            {
                caveEnti.Add(CaveEntitys.BlueSlime);
                caveEnti.Add(CaveEntitys.Bat);
                caveEnti.Add(CaveEntitys.Slime);
            }
            for(int i = 0; i < 35; i++)
            {
                caveEnti.Add(CaveEntitys.Eye);
            }
            for (int i = 0; i < 25; i++)
            {
                caveEnti.Add(CaveEntitys.StrongBat);
                caveEnti.Add(CaveEntitys.Skeleton);
                caveEnti.Add(CaveEntitys.Mushroom);
                caveEnti.Add(CaveEntitys.RedEye);
            }
            for (int i = 0; i < 20; i++)
            {
                caveEnti.Add(CaveEntitys.Glowshroom);
                caveEnti.Add(CaveEntitys.BlueEye);
                caveEnti.Add(CaveEntitys.HealChest);
            }
            for (int i = 0; i < 15; i++)
            {
                caveEnti.Add(CaveEntitys.BasicChest);
                caveEnti.Add(CaveEntitys.CharmChest);
            }
            for (int i = 0; i < 5; i++)
            {
                caveEnti.Add(CaveEntitys.Bomber);
            }
        }

        private static void AddForestEnemys()
        {
            for (int i = 0; i < 45; i++)
            {
                forestEnti.Add(ForestEntitys.Slime);
                forestEnti.Add(ForestEntitys.BlueSlime);
            }
            for (int i = 0; i < 35; i++)
            {
                forestEnti.Add(ForestEntitys.Skeleton);
                forestEnti.Add(ForestEntitys.Mushroom);
                forestEnti.Add(ForestEntitys.Glowshroom);
                forestEnti.Add(ForestEntitys.StrongTree);
            }
            for (int i = 0; i < 25; i++)
            {
                forestEnti.Add(ForestEntitys.Tree);
                forestEnti.Add(ForestEntitys.HealChest);
                forestEnti.Add(ForestEntitys.BasicChest);
            }
            for (int i = 0; i < 20; i++)
            {
                forestEnti.Add(ForestEntitys.Bomber);
                forestEnti.Add(ForestEntitys.Mimic);
            }
            for (int i = 0; i < 15; i++)
            {
                forestEnti.Add(ForestEntitys.CharmChest);
                forestEnti.Add(ForestEntitys.Crate);
            }
        }

        private static void AddLavaEnemys()
        {
            for (int i = 0; i < 45; i++)
            {
                lavaEnti.Add(LavaEntitys.Fire);
                lavaEnti.Add(LavaEntitys.Skeleton);
            }
            for (int i = 0; i < 35; i++)
            {
                lavaEnti.Add(LavaEntitys.StrongBat);
                lavaEnti.Add(LavaEntitys.Mimic);
            }
            for (int i = 0; i < 30; i++)
            {
                lavaEnti.Add(LavaEntitys.Wizard);
                lavaEnti.Add(LavaEntitys.LavaSlime);
            }
            for(int i = 0; i < 8; i++)
            {
                lavaEnti.Add(LavaEntitys.Crate);
                lavaEnti.Add(LavaEntitys.BasicChest);
            }
        }

    }

    enum GameLevel
    {
        Cave,
        Forest,
        LavaLake
    }

    class LevelMenager
    {
        public LevelMenager() { }

        static Random random = new Random();
        static int medowKills = random.Next(20, 31);
        static int lavaKills = random.Next(30, 36);
        static int caveKills = random.Next(30, 46);

        public static void ChangeLevel()
        {
            if(GameVars.gameLevel == GameLevel.Cave)
            {
                if (GameVars.killedEnemys == medowKills)
                {
                    GameVars.gameLevel = GameLevel.Forest;
                    GameVars.killedEnemys = 0;
                }
            }
            else
            if (GameVars.gameLevel == GameLevel.Forest)
            {
                if (GameVars.killedEnemys == lavaKills)
                {
                    GameVars.gameLevel = GameLevel.LavaLake;
                    GameVars.killedEnemys = 0;
                }
            }
            else
            if (GameVars.gameLevel == GameLevel.LavaLake)
            {
                if (GameVars.killedEnemys == caveKills)
                {
                    GameVars.gameLevel = GameLevel.Cave;
                    GameVars.killedEnemys = 0;
                }
            }
        }
    }
}