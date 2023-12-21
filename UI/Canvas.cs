using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZerosAndHashtags.UI
{
    /*  
           0
        ██ 1
        ▓▓ 2
        ▒▒ 3
        ░░ 4
    */
    internal class Canvas
    {
        public static void DrawImage(string image, int imageWidth, int imageHeight, int x = 0, int y = 0, string colorMap = null, ConsoleColor color = ConsoleColor.White)
        {
            int z = 0;

            if (x < 0)
                x = 0;

            if (y < 0)
                y = 0;

            bool useColorMap = String.IsNullOrEmpty(colorMap)?false:true;
            if (useColorMap)
            {
                for (int i = 0; i < imageHeight; i++)// y
                {
                    if (i > 0)
                        z += imageWidth;

                    int cY = y + i;

                    for (int j = 0; j < imageWidth; j++)// x
                    {
                        int cP = j + z; //current Pixel
                        int cX = (x + j) * 2;
                        /* 
                            Pixel is devided to 2 positions

                            x1  x2
                              ██

                            x1 = x * 2
                            x2 = (x * 2) + 1 || x1 + 1
                         */
                        char c = image[cP];

                        Console.SetCursorPosition(cX, cY);

                        char pxColor = colorMap[cP];

                        switch (pxColor)
                        {
                            case '3':
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case '6':
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case '4':
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case '8':
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case '5':
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case '7':
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case '2':
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            case '1':
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case '0':
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                            case 'A':
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case 'B':
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 'D':
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 'C':
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 'E':
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 'F':
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;
                            case '9':
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                break;
                            default:
                                break;
                        }

                        switch (c)
                        {
                            case '0':
                                Console.Write("");
                                break;
                            case '1':
                                Console.Write("██");
                                break;
                            case '2':
                                Console.Write("▓▓");
                                break;
                            case '3':
                                Console.Write("▒▒");
                                break;
                            case '4':
                                Console.Write("░░");
                                break;
                            default:
                                break;
                        }
                        Console.ResetColor();
                    }
                }
            }else
            {
                for (int i = 0; i < imageHeight; i++)// y
                {
                    if (i > 0)
                        z += imageWidth;

                    int cY = y + i;

                    for (int j = 0; j < imageWidth; j++)// x
                    {
                        int cP = j + z; //current Pixel
                        int cX = (x + j) * 2;
                        /* 
                            Pixel is devided to 2 positions

                            x1  x2
                              ██

                            x1 = x * 2
                            x2 = (x * 2) + 1 || x1 + 1
                         */
                        char c = image[cP];

                        Console.SetCursorPosition(cX, cY);
                        Console.ForegroundColor = color;
                        switch (c)
                        {
                            case '0':
                                Console.Write("");
                                break;
                            case '1':
                                Console.Write("██");
                                break;
                            case '2':
                                Console.Write("▓▓");
                                break;
                            case '3':
                                Console.Write("▒▒");
                                break;
                            case '4':
                                Console.Write("░░");
                                break;
                            default:
                                break;
                        }
                        Console.ResetColor();
                    }
                }
            }
            Console.ResetColor();
        }

        public static void DrawPixel(int x = 0, int y = 0, ConsoleColor color = ConsoleColor.White, int opacity = 1)
        {
            Console.SetCursorPosition(x*2, y);
            Console.ForegroundColor = color;
            switch(opacity)
            {
                case 1:
                    Console.Write("██");
                    break;
                case 2:
                    Console.Write("▓▓");
                    break;
                case 3:
                    Console.Write("▒▒");
                    break;
                case 4:
                    Console.Write("░░");
                    break;
            }
            Console.ResetColor();
        }

        public static void DrawText(string varible, int x = 0, int y = 0, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x * 2, y);
            Console.ForegroundColor = color;
            Console.Write(varible);

            Console.ResetColor();
        }

        public static void DrawRect(int x, int y, int width = 8, int height = 8, ConsoleColor color = ConsoleColor.Black, bool outline = false)
        {
            Console.ForegroundColor = color;
            if(outline)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.SetCursorPosition((x + j) * 2, y + i);
                        if (i == 0 || i + 1 == width || j == 0 || j + 1 == width)
                            Console.Write("██");
                    }
                }
            }
            else
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.SetCursorPosition((x + j) * 2, y + i);
                        Console.Write("██");
                    }
                }
            }
            Console.ResetColor();
        }
    }
}
