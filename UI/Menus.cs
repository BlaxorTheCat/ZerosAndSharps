using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace ZerosAndHashtags.UI
{
    internal class Menus
    {
        //MAXIMIZE WINDOW
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        private static string credit = "Programing, Music, SFX and Art By BlaxorTheCat \n" +
                                       "Music By Satos223 ";

        static public void MainMenu()
        {
            Console.Clear();
            //Music
            AudioPlaybackEngine.MusicInstance.PlayLooping(Music.MenuMain);
            //Screen
            Canvas.DrawImage(Resources.UI.logo, 32, 8, 0, 0);
            Console.WriteLine("\n");
            Console.WriteLine("-------------------------[1] TO START---------------------------\n");
            Console.WriteLine("--------------------[2] TO CHANGE SETTINGS----------------------\n");
            Console.WriteLine("------------------------[ESC] TO LEAVE--------------------------\n");
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        AudioPlaybackEngine.MusicInstance.StopLooping();
                        AudioPlaybackEngine.Instance.Dispose();
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.D1:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        AudioPlaybackEngine.MusicInstance.StopLooping();
                        return;
                    case ConsoleKey.D2:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        AudioPlaybackEngine.MusicInstance.StopLooping();
                        SettingsMenu();
                        return;
                }
            }
        }

        static public void SettingsMenu()
        {
            Console.Clear();

            AudioPlaybackEngine.MusicInstance.PlayLooping(Music.TuffChoice);

            Console.WriteLine($"[1] Enable Music?: ");
            Console.WriteLine($"[2] Enable SFX?: \n");
            Console.Write($"[3] Enable Action Numbers?: \n");
            Console.Write($"[4] Enable Action Text?: \n");
            Console.WriteLine("\n[ESC] TO GO BACK");
            Console.WriteLine($"\n{credit}");
            Canvas.DrawText(Options.enableMusic.ToString(), 10, 0);
            Canvas.DrawText(Options.enableSFX.ToString(), 9, 1);
            Canvas.DrawText(Options.dmgNumb.ToString(), 14, 3);
            Canvas.DrawText(Options.dmgText.ToString(), 13, 4);

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        AudioPlaybackEngine.MusicInstance.StopLooping();
                        using (StreamWriter writer = new StreamWriter(@"Settings.txt"))
                        {
                            writer.WriteLine(Options.enableMusic);
                            writer.WriteLine(Options.enableSFX);
                            writer.WriteLine(Options.dmgNumb);
                            writer.WriteLine(Options.dmgText);

                        }
                        MainMenu();
                        return;
                    case ConsoleKey.D1:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        Options.enableMusic = !Options.enableMusic; //added the " " cuz true is one less letter than false
                        Canvas.DrawText(Options.enableMusic.ToString() + " ", 10, 0);
                        AudioPlaybackEngine.MusicInstance.StopLooping();
                        AudioPlaybackEngine.MusicInstance.PlayLooping(Music.TuffChoice);
                        break;
                    case ConsoleKey.D2:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        Options.enableSFX = !Options.enableSFX;
                        Canvas.DrawText(Options.enableSFX.ToString() + " ", 9, 1);
                        break;
                    case ConsoleKey.D3:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        Options.dmgNumb = !Options.dmgNumb;
                        Canvas.DrawText(Options.dmgNumb.ToString() + " ", 14, 3);
                        break;
                    case ConsoleKey.D4:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        Options.dmgText = !Options.dmgText;
                        Canvas.DrawText(Options.dmgText.ToString() + " ", 13, 4);
                        break;
                }
            }
        }

        static string image = Resources.Sprites.Player.Warrior;
        static string colorMap = Resources.Colormaps.Player.Warrior;
        static public void SetPlayerSet(StartSet startSet)
        {
            Console.Clear();
            //Screen & logic
            GameVars.playerSet = startSet;
            Console.WriteLine("------------------------CHOOSE YOUR CLASS------------------------\n");

            Canvas.DrawImage(image, 8, 8, 12, 2, colorMap);
            Console.WriteLine($"\nChosen Class: ");
            Console.WriteLine($"\n---------------------PRESS ENTER TO CONTINUE---------------------");
            Canvas.DrawText(GameVars.playerSet.ToString(), 7, 10);

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D:

                        if (startSet + 1 > (StartSet)3)
                            startSet = 0;
                        else
                            ++startSet;

                        Canvas.DrawImage(image, 8, 8, 12, 2, null, ConsoleColor.Black);

                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);

                        SetPlayerIMG(startSet);

                        Canvas.DrawImage(image, 8, 8, 12, 2, colorMap);
                        Canvas.DrawText(startSet.ToString() + "     ", 7, 10);
                        GameVars.playerSet = startSet;
                        break;
                    case ConsoleKey.A:

                        if (startSet - 1 < 0)
                            startSet = (StartSet)3;
                        else
                            --startSet;

                        Canvas.DrawImage(image, 8, 8, 12, 2, null, ConsoleColor.Black);

                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);

                        SetPlayerIMG(startSet);

                        Canvas.DrawImage(image, 8, 8, 12, 2, colorMap);
                        Canvas.DrawText(startSet.ToString() + "     ", 7, 10);
                        GameVars.playerSet = startSet;
                        break;
                    case ConsoleKey.RightArrow:

                        if (startSet + 1 > (StartSet)3)
                            startSet = 0;
                        else
                            ++startSet;

                        Canvas.DrawImage(image, 8, 8, 12, 2, null, ConsoleColor.Black);

                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);

                        SetPlayerIMG(startSet);

                        Canvas.DrawImage(image, 8, 8, 12, 2, colorMap);
                        Canvas.DrawText(startSet.ToString() + "     ", 7, 10);
                        GameVars.playerSet = startSet;
                        break;
                    case ConsoleKey.LeftArrow:

                        if (startSet - 1 < 0)
                            startSet = (StartSet)3;
                        else
                            --startSet;

                        Canvas.DrawImage(image, 8, 8, 12, 2, null, ConsoleColor.Black);

                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);

                        SetPlayerIMG(startSet);

                        Canvas.DrawImage(image, 8, 8, 12, 2, colorMap);
                        Canvas.DrawText(startSet.ToString() + "     ", 7, 10);
                        GameVars.playerSet = startSet;
                        break;
                    case ConsoleKey.Enter:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        return;
                }
            }
        }
        
        static void SetPlayerIMG(StartSet startSet)
        {
            switch (startSet)
            {
                case StartSet.Warrior:
                    image = Resources.Sprites.Player.Warrior;
                    colorMap = Resources.Colormaps.Player.Warrior;
                    break;
                case StartSet.Barbarian:
                    image = Resources.Sprites.Player.Barbarian;
                    colorMap = Resources.Colormaps.Player.Barbarian;
                    break;
                case StartSet.Bard:
                    image = Resources.Sprites.Player.Bard;
                    colorMap = Resources.Colormaps.Player.Bard;
                    break;
                case StartSet.Sorcerer:
                    image = Resources.Sprites.Player.Sorcerer;
                    colorMap = Resources.Colormaps.Player.Sorcerer;
                    break;
            }
        }
        
        static public void Fullscreen()
        {
            //MAXIMIZE WINDOW
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3

            Console.WriteLine("For Best Experience Play in Fullscreen " +
                              "or Maximized Window");
            Console.CursorVisible = false;
            Thread.Sleep(2000);
        }

        static public bool endGame = false;
        static public void DeathScreen()
        {
            AudioPlaybackEngine.MusicInstance.PlayLooping(Music.GayOver);

            int x = 0;
            int y = 0;

            Console.Clear();

            Canvas.DrawText(" GA", x + 1, y + 3,ConsoleColor.DarkRed);
            Canvas.DrawText(" ME", x + 5, y + 3, ConsoleColor.DarkRed);

            Canvas.DrawText(" OV", x + 1, y + 4, ConsoleColor.DarkRed);
            Canvas.DrawText(" ER", x + 5, y + 4, ConsoleColor.DarkRed);

            Canvas.DrawImage(Resources.UI.skull, 8, 8, x, y, Resources.UI.skullCM);

            Canvas.DrawText($"Killed by: {GameVars.enemyTeritory[GameManager.choosenEnemy].name} [pos: {GameManager.choosenEnemy + 1}], used: {GameVars.enemyTeritory[GameManager.choosenEnemy].usedSkill.name} dealing {GameVars.enemyTeritory[GameManager.choosenEnemy].usedSkill.valueGiven} dmg", x, y + 9);

            Canvas.DrawText("[1] Try Again", x, y + 10);
            Canvas.DrawText("[2] Return to the Main Menu", x, y + 11);
            Canvas.DrawText("[ESC] Exit", x, y + 12);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        endGame = true;
                        return;
                    case ConsoleKey.D1:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        AudioPlaybackEngine.MusicInstance.StopLooping();
                        GameVars.mainmenu = false;
                        endGame = false;
                        return;
                    case ConsoleKey.D2:
                        AudioPlaybackEngine.Instance.PlaySound(SFX.select);
                        AudioPlaybackEngine.MusicInstance.StopLooping();
                        GameVars.mainmenu = true;
                        endGame = false;
                        return;
                }
            }
        }
    }
}
