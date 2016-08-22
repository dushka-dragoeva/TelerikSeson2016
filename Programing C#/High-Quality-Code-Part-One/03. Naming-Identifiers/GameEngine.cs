namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class GameEngine
    {
        private const string GameRules = @"
                    >>> Mine Sweeper - Console Edition <<<
                Try open all fields without stepping on a mine.
                            Commands:
                    'top' -       displays the Highscore
                    'restart' -   initiates a new game
                    'exit' -      terminates the game.";

        private const string EnterMove = "Please, enter row and coloumn: ";
        private const string GameOver = "Game Over!";
        private const string WrongCommand = "Wrong Command";
        private const string YouLost = "You lost with {0} points. ";
        private const string EnterYourNickName = "Please enter your nickname";
        private const string HighScores = " Top Players:";
        private const string NoHighScores = "There aren't high scores yet.\n";
        private const string MadeInBulgaria = "Made in Bulgaria!\n";
        private const string Bye = "Bye,bye!";

        private const int MinCommandLength = 3;
        private const int MaxPossibleMoves = 35;
        private const int GameFieldsRows = 5;
        private const int GameFieldsCols = 10;
        private const int MaxHighScoreLength = 6;

        private const char MineFieldSymbol = '*';
        private const char WithoutMineFieldSymbol = '-';
        private const char UnopenedFieldSymbol = '?';

        private static readonly string YouWon = $"Bravo! You succeed to open all {MaxPossibleMoves} fields";

        public static void Run()
        {
            string command = string.Empty;
            char[,] gameField = GenerateGameField();
            char[,] mines = GenerateMines();
            int pointsCounter = 0;
            bool isMineExploded = false;
            List<ScoreInfo> hignScoreInfo = new List<ScoreInfo>(MaxHighScoreLength);
            int row = 0;
            int col = 0;
            bool isNewGame = true;
            bool isGameOver = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine(GameRules);
                    PrintGameField(gameField);
                    isNewGame = false;
                }

                Console.Write(EnterMove);

                command = Console.ReadLine().Trim();

                if (command.Length >= MinCommandLength)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= gameField.GetLength(0) && col <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowHighScoreList(hignScoreInfo);
                        break;
                    case "restart":
                        gameField = GenerateGameField();
                        mines = GenerateMines();
                        PrintGameField(gameField);
                        isMineExploded = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine(Bye);
                        break;
                    case "turn":
                        if (mines[row, col] != MineFieldSymbol)
                        {
                            if (mines[row, col] == WithoutMineFieldSymbol)
                            {
                                ShowFieldValue(gameField, mines, row, col);
                                pointsCounter++;
                            }

                            if (MaxPossibleMoves == pointsCounter)
                            {
                                isGameOver = true;
                            }
                            else
                            {
                                PrintGameField(gameField);
                            }
                        }
                        else
                        {
                            isMineExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine(WrongCommand);
                        break;
                }

                if (isMineExploded)
                {
                    PrintGameField(mines);
                    Console.Write(string.Format(YouLost, pointsCounter));
                    Console.WriteLine(EnterYourNickName);

                    string nickname = Console.ReadLine();
                    ScoreInfo currentPlayer = new ScoreInfo(nickname, pointsCounter);

                    if (hignScoreInfo.Count < MaxHighScoreLength - 1)
                    {
                        hignScoreInfo.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < hignScoreInfo.Count; i++)
                        {
                            if (hignScoreInfo[i].Points < currentPlayer.Points)
                            {
                                hignScoreInfo.Insert(i, currentPlayer);
                                hignScoreInfo.RemoveAt(hignScoreInfo.Count - 1);
                                break;
                            }
                        }
                    }

                    hignScoreInfo.Sort((ScoreInfo firstPlayerInfo, ScoreInfo nextPlayerInfo) =>
                    nextPlayerInfo.Name.CompareTo(firstPlayerInfo.Name));
                    hignScoreInfo.Sort((ScoreInfo firstPlayerInfo, ScoreInfo nextPlayerInfo) =>
                    nextPlayerInfo.Points.CompareTo(firstPlayerInfo.Points));
                    ShowHighScoreList(hignScoreInfo);

                    gameField = GenerateGameField();
                    mines = GenerateMines();
                    pointsCounter = 0;
                    isMineExploded = false;
                    isNewGame = true;
                }

                if (isGameOver)
                {
                    Console.WriteLine(YouWon);
                    PrintGameField(mines);
                    Console.WriteLine(EnterYourNickName);
                    string nickname = Console.ReadLine();
                    ScoreInfo currentPlayerInfo = new ScoreInfo(nickname, pointsCounter);
                    hignScoreInfo.Add(currentPlayerInfo);
                    ShowHighScoreList(hignScoreInfo);
                    gameField = GenerateGameField();
                    mines = GenerateMines();
                    pointsCounter = 0;
                    isGameOver = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine(MadeInBulgaria);
            Console.Read();
        }

        private static void ShowHighScoreList(List<ScoreInfo> highScoreInfo)
        {
            Console.WriteLine(HighScores);

            if (highScoreInfo.Count > 0)
            {
                for (int i = 0; i < highScoreInfo.Count; i++)
                {
                    Console.WriteLine($"{i}. {highScoreInfo[i].Name} --> {highScoreInfo[i].Points}");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(NoHighScores);
            }
        }

        private static void ShowFieldValue(char[,] gameField, char[,] mines, int row, int col)
        {
            char minesCount = CountMines(mines, row, col);
            mines[row, col] = minesCount;
            gameField[row, col] = minesCount;
        }

        private static void PrintGameField(char[,] gameField)
        {
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", gameField[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GenerateGameField()
        {
            char[,] board = new char[GameFieldsRows, GameFieldsCols];

            for (int i = 0; i < GameFieldsRows; i++)
            {
                for (int j = 0; j < GameFieldsCols; j++)
                {
                    board[i, j] = UnopenedFieldSymbol;
                }
            }

            return board;
        }

        private static char[,] GenerateMines()
        {
            char[,] gameField = new char[GameFieldsRows, GameFieldsCols];

            for (int i = 0; i < GameFieldsRows; i++)
            {
                for (int j = 0; j < GameFieldsCols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!mines.Contains(randomNumber))
                {
                    mines.Add(randomNumber);
                }
            }

            foreach (int mine in mines)
            {
                int col = mine / GameFieldsCols;
                int row = mine % GameFieldsCols;
                if (row == 0 && mine != 0)
                {
                    col--;
                    row = GameFieldsCols;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = MineFieldSymbol;
            }

            return gameField;
        }

        private static void GetNeighbourMinesCount(char[,] gameField)
        {
            int cols = gameField.GetLength(0);
            int rows = gameField.GetLength(1);

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (gameField[i, j] != MineFieldSymbol)
                    {
                        char minesAroundCoveredCell = CountMines(gameField, i, j);
                        gameField[i, j] = minesAroundCoveredCell;
                    }
                }
            }
        }

        private static char CountMines(char[,] gameField, int row, int col)
        {
            int minesNumber = 0;
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameField[row - 1, col] == MineFieldSymbol)
                {
                    minesNumber++;
                }
            }

            if (row + 1 < rows)
            {
                if (gameField[row + 1, col] == MineFieldSymbol)
                {
                    minesNumber++;
                }
            }

            if (col - 1 >= 0)
            {
                if (gameField[row, col - 1] == MineFieldSymbol)
                {
                    minesNumber++;
                }
            }

            if (col + 1 < cols)
            {
                if (gameField[row, col + 1] == MineFieldSymbol)
                {
                    minesNumber++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (gameField[row - 1, col - 1] == MineFieldSymbol)
                {
                    minesNumber++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (gameField[row - 1, col + 1] == MineFieldSymbol)
                {
                    minesNumber++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (gameField[row + 1, col - 1] == MineFieldSymbol)
                {
                    minesNumber++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (gameField[row + 1, col + 1] == MineFieldSymbol)
                {
                    minesNumber++;
                }
            }

            return char.Parse(minesNumber.ToString());
        }
    }
}