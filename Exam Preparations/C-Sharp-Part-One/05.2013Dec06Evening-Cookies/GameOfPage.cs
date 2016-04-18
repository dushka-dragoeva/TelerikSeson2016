using System;

public class GameOfPage
{
    public const int CookieSize = 3;
    public const int CookieNumber = 7;
    public const int TraySize = 16;

    public static bool isItCookie = false;
    public static bool isItCookieCrumb = false;
    public static bool isItBrokencookie = false;
    public static bool isItEmpty = false;

    public static void Main()
    {
        int[] cookies = new int[16];
        //  int currentRow = 0;


        for (int i = 0; i < 16; i++)
        {
            cookies[i] = Convert.ToInt32(Console.ReadLine(), 2);
        }

        for (int i = 0; i < 16; i++)
        {
            Console.WriteLine(GetBits(cookies[i], 1, CookieSize));
        }
    }

    public static void CheckForCookie(int row, int col, int[] arr)
    {
        int position = TraySize -1- col ;
        int cookieRow = GetBits(arr[row], position - 1, CookieSize);
        int upperRow = GetBits(arr[row - 1], position - 1, CookieSize);
        int bottenRow = GetBits(arr[row + 1], position - 1, CookieSize);

        if (GetBits(arr[row], position, 1) == 0)
        {
            isItEmpty = true;
        }
        else if (row == 0 || row == TraySize-1 )
        {

        }
        //if (isItCookie)
        //{
        //    answer = "cookie";
        //}
        //else if (isItCookieCrumb)
        //{
        //    answer = "cookie crumb";
        //}
        //else if (isItBrokencookie)
        //{
        //    answer = "broken cookie";
        //}





        // return answer;
    }

    public static int GetBits(int number, int position, int length)
    {
        var binaryNumber = new string('1', length);
        int mask = Convert.ToInt32(binaryNumber, 2);
        int numberAndMask = (mask << position) & number;
        int bitsNumber = numberAndMask >> position;
        return bitsNumber;
    }

}