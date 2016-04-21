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

    private static bool isItCookie = false;
    private static bool isItCookieCrumb = false;
    private static bool isItBrokenCookie = false;
    private static bool isItEmpty = false;

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
                int cookieCenter = GetBits(cookies[row], TraySize - 1 - col, 1);
                Console.WriteLine("cookie" + cookieCenter);
                if (cookieCenter == 0)
                {
                    Console.WriteLine(Smile);
                }
                else 
                {
                    CheckForCookie(row, col, cookies);
                    AnswerWhatQuestion();
                }
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
    }

    public static void TakeCookie(int row, int col, int[] arr)
    {
        int position = TraySize - 1 - col;

        for (int i = row - 1; i <= +row + 1; i++)
        {
            arr[i] = ResetBits(arr[i], position - 1, CookieSize);
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

        int position = TraySize - col - 1;
        int length = 0;
        int startPosition = 0;

        if (col == TraySize-1)
        {
            startPosition = 0;
            length = CookieSize - 1;
        }

        startPosition = position - 1;
        length = CookieSize;

        int[] singleCookie = new int[CookieSize];

        //for (int i = 0; i < 3; i++)
        //{
        //    singleCookie[i] = GetBits(arr[row], position - 1, CookieSize);
        //}

        singleCookie[1] = GetBits(arr[row], startPosition - 1, length);

        if (row > 0)
        {
            singleCookie[0] = GetBits(arr[row - 1], startPosition - 1, length);
        }

        if (row < TraySize - 1)
        {
            singleCookie[2] = GetBits(arr[row + 1], startPosition - 1, length);
        }

        int onesCounter = CountOnes(singleCookie);

        if (onesCounter == CookieSize * CookieSize)
        {
            isItCookie = true;
            isItEmpty = false;
            isItBrokenCookie = false;
            isItCookieCrumb = false;
        }
        else if (onesCounter == 1)
        {
            isItCookieCrumb = true;
            isItCookie = false;
            isItEmpty = false;
            isItBrokenCookie = false;
        }
        else if (onesCounter == 0)
        {
            isItEmpty = true;
            isItCookie = false;
            isItBrokenCookie = false;
            isItCookieCrumb = false;
        }
        else
        {
            isItBrokenCookie = true;
            isItCookieCrumb = false;
            isItCookie = false;
            isItEmpty = false;
        }
    }

    private static int CountOnes(int[] singleCookie)
    {
        int onesCounter = 0;

        for (int i = 0; i < singleCookie.Length; i++)
        {
            for (int j = 0; j < CookieSize; j++)
            {
                if (singleCookie[i] > 0)
                {
                    int curretBit = GetBits(singleCookie[i], j, 1);
                    if (curretBit == 1)
                    {
                        onesCounter++;
                    }
                }
            }
        }

        return onesCounter;
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