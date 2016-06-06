using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static void Main(string[] args)
    {

        var abcdDim = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        var a = abcdDim[0];
        var b = abcdDim[1];
        var c = abcdDim[2];
        var d = abcdDim[3];

        var HPRoom = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        //  string[,,,] snakesInTheRoom = new string[a, b, c, d];

        var counter = 0;

        var basCaunt = int.Parse(Console.ReadLine());

        var snakes = new Dictionary<char, int[]>();

        for (int i = 0; i < basCaunt; i++)
        {
            var input = Console.ReadLine().Split(' ').ToArray();

            var key = input[0][0];
            snakes[key] = new int[4];
            for (int j = 0; j < 4; j++)
            {
                snakes[key][j] = int.Parse(input[j + 1]);
            }
        }

        bool isHarryInDied = false;
        bool isSnakeInRoom = false;

        var commands = new List<string[]>();

        var curCom = Console.ReadLine().Split(' ').ToArray();

        do
        {
            commands.Add(curCom);
            curCom = Console.ReadLine().Split(' ').ToArray();
        }
        while (curCom[0] != "END");

        for (int k = 0; k < commands.Count; k++)
        {
            var nextComand = commands[k];
            int dim = nextComand[1][0] - 'A';
            int delta = int.Parse(nextComand[2]);

            char key = nextComand[0][0];

            if (key != '@')
            {
                var currSnake = snakes[key];
                currSnake[dim] = currSnake[dim] + delta ;

                if (currSnake[dim] >= abcdDim[dim])
                {
                   currSnake[dim] = abcdDim[dim]-1;
                }
                else if (currSnake[dim] < 0)
                {
                    currSnake[dim] = 0;
                }

                //  check if HP is in that room
                if (currSnake[0] == HPRoom[0] &&
                 currSnake[1] == HPRoom[1] &&
                 currSnake[2] == HPRoom[2] &&
                 currSnake[3] == HPRoom[3])
                {
                    isHarryInDied = true;
                    Console.WriteLine("{0}: \"You thought you could escape, didn't you?\" - {1}", key, counter);
                    break;
                }
            }

            else
            {

                HPRoom[dim] = HPRoom[dim] + delta;

                if (HPRoom[dim] >= abcdDim[dim])
                {
                    HPRoom[dim] = abcdDim[dim]-1;
                }
                else if (HPRoom[dim] < 0)
                {
                    HPRoom[dim] = 0;
                }
                counter++;

                //// Check if there are snakes in that room 

                var aHarry = HPRoom[0];
                var bHarry = HPRoom[1];
                var cHarry = HPRoom[2];
                var dHarry = HPRoom[3];
                var currBas = string.Empty;

                foreach (var basilic in snakes)
                {

                    var aBasilic = basilic.Value[0];
                    var bBasilic = basilic.Value[1];
                    var cBasilic = basilic.Value[2];
                    var dBasilic = basilic.Value[3];

                    if (aHarry == aBasilic && bHarry == bBasilic && cHarry == cBasilic && dHarry == dBasilic)
                    {
                        currBas += basilic.Key;
                    }

                }

                if (currBas != string.Empty)
                {
                    isHarryInDied = true;
                    var winerBasilik = currBas.ToCharArray().OrderBy(x => x).First().ToString();
                    Console.WriteLine("{0}: \"Step {1} was the worst you ever made.\"", winerBasilik, counter);
                    Console.WriteLine("{0}: \"You will regret until the rest of your life... All 3 seconds of it!\"", winerBasilik);
                    break;

                }

            }
        }
        if (!isHarryInDied)
        {
            Console.WriteLine("@: \"I am the chosen one!\" - {0}", counter);
        }

        //  Console.WriteLine(string.Join(". ",commands));
    }
}

