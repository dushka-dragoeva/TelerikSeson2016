using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

public class FallingRocks
{
    public const string RockType = "!@#$%^&*()+.;";
    public const int Hight = 35;
    public const int Width = 39;
    public const int SkyHight = 7;
    private const int MaxPoints = 6000;
    private const int MaxHealth = 200;
    private const int Acceleration = 10;
    private const int LevelUpPoints = 1000;

    /// method, that print rock on specific position
    public static void PrintOnPosition(int x, int y, char symbol, ConsoleColor color = ConsoleColor.Red)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }

    /// method, that any string rock on specific position
    public static void PrintStringOnPosition(int x, int y, string text, ConsoleColor color = ConsoleColor.Red)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(text);
    }

    public struct Rock
    {
        public int X;
        public int Y;
        public char Symbol;
        public ConsoleColor Color;
    }

    public struct Dwarf
    {
        public int X;
        public int Y;
        public string Face;
        public ConsoleColor Color;
    }

    public static void Main()
    {
        using (SoundPlayer TextMusic = new SoundPlayer(@"../../Music/Tension-music-loop-114-bpm.wav"))
        {
            TextMusic.PlayLooping();
        }

        int playfieldHignt = Hight;
        int playgrowndWidth = Width;
        Console.BufferHeight = Console.WindowHeight = Hight;
        Console.BufferWidth = Console.WindowWidth = Width;
        Console.BackgroundColor = ConsoleColor.Yellow;

        Dwarf gogo = new Dwarf();
        gogo.X = (Console.WindowWidth / 2) - 2;
        gogo.Y = Console.WindowHeight - 1;
        gogo.Color = ConsoleColor.DarkMagenta;
        gogo.Face = "(0)";

        Random randomGerator = new Random();

        List<Rock> rocks = new List<Rock>();

        int level = 1;
        int health = 100;
        int points = 0;
        int bonusHealth = 10;
        int speedUp = 0;

        while (true)
        {
            {
                Rock newRock = new Rock();
                ConsoleColor currentRockColor =
                    (ConsoleColor)randomGerator.Next(Enum.GetNames(typeof(ConsoleColor)).Length);

                while (true)
                {
                    if (currentRockColor != Console.BackgroundColor)
                    {
                        newRock.Color = currentRockColor;
                        break;
                    }
                    else
                    {
                        currentRockColor = (ConsoleColor)randomGerator.Next(Enum.GetNames(typeof(ConsoleColor)).Length);
                    }
                }

                newRock.Y = SkyHight;
                newRock.X = randomGerator.Next(0, playgrowndWidth);
                newRock.Symbol = RockType[randomGerator.Next(RockType.Length)];
                rocks.Add(newRock);
            }

            /// Move dwarf(key pressed)
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                /// Clear buffer if key is pressed more than one before redrawing
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (gogo.X - 1 > 0)
                    {
                        gogo.X = gogo.X - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (gogo.X + 1 < playgrowndWidth - gogo.Face.Length)
                    {
                        gogo.X = gogo.X + 1;
                    }
                }
            }

            /// Move FallingRocks   
            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldRock = rocks[i];
                if (rocks[i].Y < playfieldHignt - 1)
                {
                    Rock newRock = new Rock();
                    newRock.X = oldRock.X;
                    newRock.Y = oldRock.Y + 1;
                    newRock.Symbol = oldRock.Symbol;
                    newRock.Color = oldRock.Color;
                    rocks.Remove(oldRock);
                    rocks.Add(newRock);
                }
                else
                {
                    rocks.Remove(oldRock);
                }
            }

            /// Check for colision with rock
            foreach (var rock in rocks)
            {
                if (rock.Y == playfieldHignt - 1)
                {
                    for (int i = 0; i < gogo.Face.Length; i++)
                    {
                        if (gogo.X + i == rock.X)
                        {
                            if (rock.Symbol == '@' && health <= MaxHealth - bonusHealth)
                            {
                                Console.Beep(1000, 150);

                                health += bonusHealth;
                            }
                            else
                            {
                                Console.Beep(2200, 100);
                                health -= 5;
                            }
                        }
                        else
                        {
                            points += 2;
                        }

                        if (points == LevelUpPoints * level)
                        {
                            level++;
                            speedUp += Acceleration;

                            if (health <= MaxHealth - 100)
                            {
                                health += 100;
                            }
                            else
                            {
                                health = MaxHealth;
                            }
                        }
                    }
                }
            }

            /// Clear Console
            Console.Clear();

            /// check if game is end
            if (health > 0 && points < MaxPoints)
            {
                /// REDrow info - Result
                string title = "FOLLING ROCKS";
                string currentLevel = string.Format("LEVEL {0}", level);
                string currentHealth = string.Format("HEALTH {0}%", health);
                string currentPoints = string.Format("POINTS {0}", points);

                PrintStringOnPosition((Width - title.Length) / 2, 1, title, ConsoleColor.DarkMagenta);
                PrintStringOnPosition((Width - currentLevel.Length) / 2, 3, currentLevel, ConsoleColor.DarkMagenta);
                PrintStringOnPosition(5, 5, currentHealth);
                PrintStringOnPosition(Width - currentPoints.Length - 6, 5, currentPoints);
                PrintStringOnPosition(0, SkyHight, new string('`', Width), ConsoleColor.Blue);

                /// ReDraw dwarf and rocks
                PrintStringOnPosition(gogo.X, gogo.Y, gogo.Face, gogo.Color);

                foreach (var rock in rocks)
                {
                    PrintOnPosition(rock.X, rock.Y, rock.Symbol, rock.Color);
                }

                /// Slow down  program
                Thread.Sleep(150 + speedUp);
            }
            else
            {
                /// Game is over
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                ConsoleColor color = ConsoleColor.DarkGreen;
                string gameOver = "END GAME";
                string youLosе = "You Lose";
                string youWon = "You Won";
                string newGame = "Pres ENTER for New Game";
                string endGame = "Press DEL for Exit";

                PrintStringOnPosition((Width - gameOver.Length) / 2, SkyHight - 5, gameOver, color);

                if (health == 0)
                {
                    PrintStringOnPosition((Width - youLosе.Length) / 2, SkyHight - 4, youLosе, color);
                }
                else
                {
                    PrintStringOnPosition((Width - youWon.Length) / 2, SkyHight - 4, youWon, color);
                }

                PrintStringOnPosition((Width - newGame.Length) / 2, SkyHight - 2, newGame, color);
                PrintStringOnPosition((Width - endGame.Length) / 2, SkyHight - 1, endGame, color);

                string key = Console.ReadKey().Key.ToString();

                if (key.ToUpper() == "ENTER")
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    health = 100;
                    points = 0;
                    speedUp = 0;
                    level = 1;
                    continue;
                }
                else if (key.ToUpper() == "DELETE")
                {
                    Environment.Exit(0);
                    Environment.Exit(0);
                }
            }
        }
    }
}