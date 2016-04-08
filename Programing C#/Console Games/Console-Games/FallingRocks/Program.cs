using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    public const string RockType = "!@#$%^&*()+.;";
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
        public int y; // TODO = bottom of the field 38
        public string face;
        public ConsoleColor color;
    }

    public static void PrintOnPosition(int x, int y, char symbol, ConsoleColor color = ConsoleColor.Red)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }

    public static void PrintStringOnPosition(int x, int y, string symbol, ConsoleColor color = ConsoleColor.Red)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }

    public static void Main()
    {
        int playfieldHignt = 40;
        int playgrowndWidth = 49;
        Console.BufferHeight = Console.WindowHeight = 40;
        Console.BufferWidth = Console.WindowWidth = 49;
        Console.BackgroundColor = ConsoleColor.Yellow;

        Dwarf gogo = new Dwarf();
        gogo.x = Console.WindowWidth / 2 - 2;
        gogo.y = Console.WindowHeight - 1;
        gogo.color = ConsoleColor.DarkMagenta;
        gogo.face = "(0)";

        Random randomGerator = new Random();

        List<Rock> rocks = new List<Rock>();


        // ^, @, *, &, +, %, $, #, !, ., ;,

        // ! @ # $ % ^ & * ( )  + . ;


        while (true)
        {
            {
                Rock newRock = new Rock();
                newRock.color = ConsoleColor.Black;
                newRock.y = 0;
                newRock.x = randomGerator.Next(0, playgrowndWidth);
                newRock.symbol = RockType[randomGerator.Next(RockType.Length)];
                rocks.Add(newRock);
            }
            // Move our car / dwarf(key pressed)
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

            // Move Cars/ FallingRocks   


            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldRock = rocks[i];
                if (rocks[i].y < playfieldHignt-1)
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

            //Check for colision with car / dwarf

            // Clear Console
            Console.Clear();

            // ReDraw playfield
            PrintStringOnPosition(gogo.x, gogo.y, gogo.face, gogo.color);
            foreach (var rock in rocks)
            {
                PrintOnPosition(rock.x, rock.y, rock.symbol, rock.color);
            }
            // Drow info - Result

            //  Slow down  program
            Thread.Sleep(150);

        }
    }
}

