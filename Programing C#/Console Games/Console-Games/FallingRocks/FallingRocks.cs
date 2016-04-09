using System;
using System.Collections.Generic;
using System.Threading;

public class FallingRocks
{
    public const string RockType = "!@#$%^&*()+.;";
    public const int Hight = 25;
    public const int Width = 39;
    public const int SkyHight = 7;

    public struct Rock
    {
        public int x;
        public int y;
        public char symbol;
        public ConsoleColor color;
    }

    public struct Dwarf
    {
        public int x;
        public int y;
        public string face;
        public ConsoleColor color;
    }

    public static void PrintOnPosition(int x, int y, char symbol, ConsoleColor color = ConsoleColor.Red)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }

    public static void PrintStringOnPosition(int x, int y, string text, ConsoleColor color = ConsoleColor.Red)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(text);
    }

    public static void Main()
    {
        int playfieldHignt = Hight;
        int playgrowndWidth = Width;
        Console.BufferHeight = Console.WindowHeight = Hight;
        Console.BufferWidth = Console.WindowWidth = Width;
        Console.BackgroundColor = ConsoleColor.Gray;

        Dwarf gogo = new Dwarf();
        gogo.x = Console.WindowWidth / 2 - 2;
        gogo.y = Console.WindowHeight - 1;
        gogo.color = ConsoleColor.DarkMagenta;
        gogo.face = "(0)";

        Random randomGerator = new Random();

        List<Rock> rocks = new List<Rock>();

        int level = 1;
        int health = 100;
        int points = 0;
        int bonusHealth = 10;
        int nextLevelPoints = 1000;
        int bonusHealthPoints = 200;

        int rockDensity = Width / 2;
        int rockDensityLevelUp = (int)(1.1 * rockDensity);


        int middlewidth = Width / 2;

        while (true)
        {
            if (health == 0)
            {
                Console.WriteLine("Game Over");
                Console.ReadKey();
                break;
            }
            {
                Rock newRock = new Rock();
                ConsoleColor currentRockColor = (ConsoleColor)randomGerator.Next(Enum.GetNames(typeof(ConsoleColor)).Length);

                while (true)
                {
                    if (currentRockColor != Console.BackgroundColor)
                    {
                        newRock.color = currentRockColor;
                        break;
                    }
                    else
                    {
                        currentRockColor = (ConsoleColor)randomGerator.Next(Enum.GetNames(typeof(ConsoleColor)).Length);
                    }
                }
                newRock.y = SkyHight;
                newRock.x = randomGerator.Next(0, playgrowndWidth);
                newRock.symbol = RockType[randomGerator.Next(RockType.Length)];
                rocks.Add(newRock);
            }

            // Move dwarf(key pressed)
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                // Clear buffer if key is pressed more than one before redrawing
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (gogo.x - 1 > 0)
                    {
                        gogo.x = gogo.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (gogo.x + 1 < playgrowndWidth - gogo.face.Length)
                    {
                        gogo.x = gogo.x + 1;
                    }
                }
            }

            // Move FallingRocks   
            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldRock = rocks[i];
                if (rocks[i].y < playfieldHignt - 1)
                {
                    Rock newRock = new Rock();
                    newRock.x = oldRock.x;
                    newRock.y = oldRock.y + 1;
                    newRock.symbol = oldRock.symbol;
                    newRock.color = oldRock.color;
                    rocks.Remove(oldRock);
                    rocks.Add(newRock);
                }
                else
                {
                    rocks.Remove(oldRock);
                }
            }

            //Check for colision with rock

            foreach (var rock in rocks)
            {
                if (rock.y == playfieldHignt - 1)
                {
                    for (int i = 0; i < gogo.face.Length; i++)
                 
                    {
                        if (gogo.x+i == rock.x)
                        {
                            health -= 5;
                        }

                        else
                        {
                            points += 5;
                        }
                }
                }
            }



            // Clear Console
            Console.Clear();

            // ReDraw playfield
            PrintStringOnPosition(gogo.x, gogo.y, gogo.face, gogo.color);

            foreach (var rock in rocks)
            {
                PrintOnPosition(rock.x, rock.y, rock.symbol, rock.color);
            }

            // Drow info - Result
            var size = Console.CursorSize = 25;

            string title = "FOLLING ROCKS";
            string currentLevel = string.Format("LEVEL {0}", level);
            string currentHealth = string.Format("HEALTH {0}%", health);
            string currentPoints = string.Format("POINTS {0}", points);

            PrintStringOnPosition((Width - title.Length) / 2, 1, title, ConsoleColor.DarkMagenta);
            PrintStringOnPosition((Width - currentLevel.Length) / 2, 3, currentLevel, ConsoleColor.DarkMagenta);
            PrintStringOnPosition(5, 5, currentHealth);
            PrintStringOnPosition(Width - currentPoints.Length - 6, 5, currentPoints);
            PrintStringOnPosition(0, SkyHight, new string('`', Width), ConsoleColor.Blue);

            //  Slow down  program
            Thread.Sleep(150);

        }
    }
}

