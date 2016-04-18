using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._2013Dec06Evening_Cookies
{
    class GameOfPage_Strings
    {
        public const int CookieSize = 3;

        public static bool isItCookie = false;
        public static bool isItCookieCrumb = false;
        public static bool isItBrokencookie = false;
        public static bool isItEmpty = false;

        public static void PlayTheGame()
        {
            string[] cookies = new string[16];
            //  int currentRow = 0;


            for (int i = 0; i < 16; i++)
            {
                cookies[i] = Console.ReadLine();
            }

        }

        public static void CheckForCookie(int row, int col, string[] arr)
        {

            string center = arr[row].Substring(col, 1);

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

        public static uint GetBits(uint number, int position)
        {

            uint mask = uint.Parse(Convert.ToString(CookieSize, 2));
            uint numberAndMask = mask << position & number;
            uint bit = numberAndMask >> position;
            return bit;
        }
    }
}
