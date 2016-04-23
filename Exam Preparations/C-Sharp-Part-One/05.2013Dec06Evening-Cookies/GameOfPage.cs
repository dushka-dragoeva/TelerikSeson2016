using System;

public class GameOfPage
{
    public const int CookieSize = 3;
    public const int CookieValue = 7;
    public const int TraySize = 16;

    public const string WhatQuestion = "what is";
    public const string BuyQuestion = "buy";
    public const string PaypalQuestion = "paypal";

    public const string CookieCrumb = "cookie crumb";
    public const string BrokenCookie = "broken cookie";
    public const string Cookie = "cookie";
    public const string Page = "page";
    public const string Smile = "smile";
    public const decimal CookiePrice = 1.79m;

    private static bool isCookie = false;
    private static bool isCookieCrumb = false;
    private static bool isBrokenCookie = false;
    // private static bool isItEmpty = false;

    private static int counter = 0;

    public static void Main()
    {
        int[] cookies = new int[16];

        for (int i = 0; i < 16; i++)
        {
            cookies[i] = Convert.ToInt32(Console.ReadLine(), 2);
        }

        string input = Console.ReadLine();

        while (true)
        {
            if (input == WhatQuestion)
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                int cookieCenter = GetBit(cookies[row], TraySize - 1 - col);
              
                if (cookieCenter == 0)
                {
                    Console.WriteLine(Smile);
                }
                else
                {
                    CheckForCookie(row, TraySize - 1 - col, cookies);
                    if (isCookie)
                    {
                        Console.WriteLine(Cookie);
                    }
                    else if (isBrokenCookie)
                    {
                        Console.WriteLine(BrokenCookie);
                    }
                    else if (isCookieCrumb)
                    {
                        Console.WriteLine(CookieCrumb);
                    }
                }
            }
            else if (input == BuyQuestion)
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                int cookieCenter = GetBit(cookies[row], TraySize - 1 - col);

                if (cookieCenter == 0)
                {
                    Console.WriteLine(Smile);
                }
                else
                {
                    CheckForCookie(row, TraySize - 1 - col, cookies);

                    if (isCookie)
                    {
                        counter++;
                        TakeCookie(row, TraySize - 1 - col, cookies);
                    }
                    else
                    {
                        Console.WriteLine(Page);
                    }
                }
            }
            else if (input == PaypalQuestion)
            {
                decimal totalPrice = counter * CookiePrice;
                Console.WriteLine(totalPrice);
                break;
            }

            input = Console.ReadLine();
        }
    }

    public static void TakeCookie(int row, int col, int[] arr)
    {
        arr[row - 1] = ResetBit(arr[row - 1], col - 1);
        arr[row - 1] = ResetBit(arr[row - 1], col);
        arr[row - 1] = ResetBit(arr[row - 1], col + 1);

        arr[row] = ResetBit(arr[row], col - 1);
        arr[row] = ResetBit(arr[row], col);
        arr[row] = ResetBit(arr[row], col + 1);

        arr[row + 1] = ResetBit(arr[row + 1], col + 1);
        arr[row + 1] = ResetBit(arr[row + 1], col + 1);
        arr[row + 1] = ResetBit(arr[row + 1], col + 1);
    }

    public static int ResetBit(int number, int position)
    {
        number = ~(1 << position) & number;
        return number;
    }

    public static void CheckForCookie(int row, int col, int[] arr)
    {
        int upperRow = row > 0 ? arr[row - 1] : 0;
        int middleRow = arr[row];
        int bottomRow = row < arr.Length - 1 ? arr[row + 1] : 0;

        isCookieCrumb = true;

        isBrokenCookie = (GetBit(upperRow, col - 1) != 0 || GetBit(upperRow, col) != 0 || GetBit(upperRow, col + 1) != 0 ||
            GetBit(middleRow, col - 1) != 0 || GetBit(middleRow, col + 1) != 0 ||
            GetBit(bottomRow, col - 1) != 0 || GetBit(bottomRow, col) != 0 || GetBit(bottomRow, col + 1) != 0);

        isCookie = (GetBit(upperRow, col - 1) != 0 && GetBit(upperRow, col) != 0 && GetBit(upperRow, col + 1) != 0 &&
                    GetBit(middleRow, col - 1) != 0 && GetBit(middleRow, col) != 0 && GetBit(middleRow, col + 1) != 0 &&
                    GetBit(bottomRow, col - 1) != 0 && GetBit(bottomRow, col) != 0 && GetBit(bottomRow, col + 1) != 0);
    }

    public static int GetBit(int number, int position)
    {
        int mask = 1;
        int numberAndMask = (mask << position) & number;
        int bit = numberAndMask >> position;
        return bit;
    }
}