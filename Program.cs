using System;
using System.IO;
using System.Linq;
using ZerosAndHashtags.Cards;
using ZerosAndHashtags.UI;

namespace ZerosAndHashtags
{
    enum StartSet
    {
        Warrior,    // basic type
        Bard,       // Low Damage, High Heals, High HP
        Sorcerer,   // Idk
        Barbarian   // High Damage, Bad Heals, low Hp
    }

    struct Options
    {
        //FUCK U RESX
        static public bool enableMusic = Convert.ToBoolean(File.ReadLines(@"Settings.txt").Take(1).First().ToLower());
        static public bool enableSFX = Convert.ToBoolean(File.ReadLines(@"Settings.txt").Skip(1).Take(1).First().ToLower());
        static public bool dmgNumb = Convert.ToBoolean(File.ReadLines(@"Settings.txt").Skip(2).Take(1).First().ToLower());
        static public bool dmgText = Convert.ToBoolean(File.ReadLines(@"Settings.txt").Skip(3).Take(1).First().ToLower());
        //ONLY FOR DEBUG DISABLE IN FINAL RELASE
        static public bool buddha = false;
        static public bool instakill = false;
    }

    struct GameVars
    {
        static public Entity[] enemyTeritory = new Entity[3];

        static public int[,] enemyPos = { 
            {34, 2},
            {34, 13},
            {34, 24} 
        };
            
        static public GameLevel gameLevel = GameLevel.Cave;

        static public StartSet playerSet = StartSet.Warrior;

        static public int respawnWave = 3;
        static readonly public int maxRespawnWave = 3;

        static public bool mainmenu = true;

        static public int killedEnemys = 0;
    }

    struct SFX
    {
        static public CachedSound select = new CachedSound(@"Assets\Sound\UI\select.wav");

        static public CachedSound heal = new CachedSound(@"Assets/Sound/Skills/Heal/heal.wav");

        static public CachedSound hit0 = new CachedSound(@"Assets/Sound/Skills/Attack/hit0.wav");
        static public CachedSound hit1 = new CachedSound(@"Assets/Sound/Skills/Attack/hit1.wav");
        static public CachedSound hit2 = new CachedSound(@"Assets/Sound/Skills/Attack/hit2.wav");
        static public CachedSound hit3 = new CachedSound(@"Assets/Sound/Skills/Attack/hit3.wav");
        static public CachedSound hit4 = new CachedSound(@"Assets/Sound/Skills/Attack/hit4.wav");

        static public CachedSound charmSelect = new CachedSound(@"Assets/Sound/SFX/charmselect.wav");
        static public CachedSound healSelect = new CachedSound(@"Assets/Sound/SFX/healselect.wav");
        static public CachedSound attackSelect = new CachedSound(@"Assets/Sound/SFX/attackselect.wav");
        static public CachedSound nullsfx = new CachedSound(@"Assets/Sound/SFX/null.wav");

        static public CachedSound[] hits = {hit0, hit1, hit2, hit3, hit4};
    }

    struct Music
    {
        static public string XYIsland = @"Assets/Sound/Music/XYIsland.wav";
        static public string MenuMain = @"Assets/Sound/Music/MenuMain.wav";
        static public string AdventureNew = @"Assets/Sound/Music/Adventure.New.wav";
        static public string TuffChoice = @"Assets/Sound/Music/TuffChoice.wav";
        static public string battleOne = @"Assets/Sound/Music/battleOne.wav";
        static public string Wonky = @"Assets/Sound/Music/Wonky.wav";
        static public string GayOver = @"Assets/Sound/Music/GameOver.wav";
    }

    //TODO: player charms

    internal class Program
    {
        static void Main(string[] args)
        {
            //First Basic Stuff
            Console.Title = "Zeros and Sharps";
            Console.CursorVisible = false;

            if (!File.Exists(@"Settings.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"Settings.txt"))
                {
                    writer.WriteLine(true);
                    writer.WriteLine(true);
                    writer.WriteLine(true);
                    writer.WriteLine(true);
                }
            }

            Menus.Fullscreen();
            
            do
            {
                if (GameVars.mainmenu)
                {
                    Menus.MainMenu();
                }
                //Music for player select
                AudioPlaybackEngine.MusicInstance.PlayLooping(Music.AdventureNew);

                Menus.SetPlayerSet(GameVars.playerSet);

                AudioPlaybackEngine.MusicInstance.StopLooping();

                //Remember about render order: What draws on top stays on top in code
                Console.Clear();

                Player player = new Player("Player", 20, GameVars.playerSet);

                GameManager.SetAllEnemys();

                //set enemys for testing here :
                //GameManager.SwapEnemy();

                GameManager.Draw();

                player.DrawSprite(4, 13, 8, 8);
                //game loop
                AudioPlaybackEngine.MusicInstance.PlayLooping(Music.Wonky);

                GameVars.respawnWave = 3;
                do
                {
                    Canvas.DrawText("Current Level: "+GameVars.gameLevel.ToString()+"      ");
                    //Logic Stuff
                    player.UseSkills();

                    GameVars.respawnWave--;

                    LevelMenager.ChangeLevel();

                    //Game menager enemy usage
                    GameManager.CheckIfDead();
                    Canvas.DrawRect(42, 0, 6, 34);
                    Canvas.DrawRect(0, 13, 4, 8);
                    GameManager.UseEnemys(player);

                    GameManager.RespawnEnemys();

                    player.UpdateCoolDowns();

                    //draw
                    player.DrawHealth(4, 13);
                    player.DisplaySkills();
                    player.DisplayActionMode();

                    GameManager.Draw();
                    GameManager.DisplayActivity();

                    //Console.CursorVisible = false;
                    if (GameVars.respawnWave == 0)
                    {
                        GameVars.respawnWave = GameVars.maxRespawnWave;
                    }

                } while (player.hp > 0);

                AudioPlaybackEngine.MusicInstance.StopLooping();

                Menus.DeathScreen();

            } while (!Menus.endGame);

            AudioPlaybackEngine.Instance.Dispose();
            AudioPlaybackEngine.MusicInstance.Dispose();
        }
    }
}
