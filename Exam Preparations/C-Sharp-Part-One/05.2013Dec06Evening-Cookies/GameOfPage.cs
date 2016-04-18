using System;

public class GameOfPage
{
    public const int CookieSize = 3;
    public const int CookieNumber = 7;
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

    public static bool isItCookie = false;
    public static bool isItCookieCrumb = false;
    public static bool isItBrokenCookie = false;
    public static bool isItEmpty = false;

    public static int counter = 0;

    public static void Main()
    {
        int[] cookies = new int[16];

        for (int i = 0; i < 16; i++)
        {
            cookies[i] = Convert.ToInt32(Console.ReadLine(), 2);
        }

        for (int i = 0; i < 16; i++)
        {
            Console.WriteLine(cookies[i]);
        }
        string input = Console.ReadLine();

        while (true)
        {
            if (input == WhatQuestion)
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                CheckForCookie(row, col, cookies);
                AnswerWhatQuestion();
            }
            else if (input == BuyQuestion)
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                CheckForCookie(row, col, cookies);
                AnswerBuyQuestion();
                if (isItCookie)
                {
                    TakeCookie(row, col, cookies);
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
        for (int i = 0; i < 16; i++)
        {
            Console.WriteLine(cookies[i]);
        }

    }
    public static void TakeCookie(int row, int col, int[] arr)
    {
        int position = TraySize - 1 - col;

        for (int i = row - 1; i <= +row + 1; i++)
        {
            arr[i] = ResetBits(arr[row], position - 1, CookieSize);
        }
    }

    public static int ResetBits(int number, int position, int length)
    {
        var binaryNumber = new string('1', length);
        int mask = Convert.ToInt32(binaryNumber, 2);
        int numberAndMask = ~(mask << position) & number;
        int bitsNumber = numberAndMask;
        return bitsNumber;
    }

    public static void AnswerBuyQuestion()
    {
        if (isItCookie)
        {
            counter++;
        }
        else if (isItCookieCrumb || isItBrokenCookie)
        {
            Console.WriteLine(Page);
        }
        else if (isItEmpty)
        {
            Console.WriteLine(Smile);
        }
    }

    public static void AnswerWhatQuestion()
    {
        if (isItCookie)
        {
            Console.WriteLine(Cookie);
        }
        else if (isItCookieCrumb)
        {
            Console.WriteLine(CookieCrumb);
        }
        else if (isItBrokenCookie)
        {
            Console.WriteLine(BrokenCookie);
        }
        else
        {
            Console.WriteLine(Smile);
        }
    }

    public static void CheckForCookie(int row, int col, int[] arr)
    {
        int position = TraySize - 1 - col;

        int cookieRowValue = GetBits(arr[row], position - 1, CookieSize);
        int upperRowValue = 0;
        int bottomRowValue = 0;

        if (row > 0)
        {
            upperRowValue = GetBits(arr[row - 1], position - 1, CookieSize);
        }

        if (row < TraySize - 1)
        {
            bottomRowValue = GetBits(arr[row + 1], position - 1, CookieSize);
        }

        if (cookieRowValue == 0 && upperRowValue == 0 && bottomRowValue == 0)
        {
            isItEmpty = true;
            isItCookie = false;
            isItBrokenCookie = false;
            isItCookieCrumb = false;
        }
        else if (cookieRowValue == CookieNumber && upperRowValue == CookieNumber && bottomRowValue == CookieNumber)
        {
            isItCookie = true;
            isItEmpty = false;
            isItBrokenCookie = false;
            isItCookieCrumb = false;

        }
        else if ((cookieRowValue + upperRowValue + bottomRowValue) == 1)
        {
            isItCookieCrumb = true;
            isItCookie = false;
            isItEmpty = false;
            isItBrokenCookie = false;
        }
        else
        {
            isItBrokenCookie = true;
            isItCookieCrumb = false;
            isItCookie = false;
            isItEmpty = false;
        }
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