using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinCrabRolingHash
{
    class Program
    {
        static void Main()
        {
            var text = "";
            var pattern = "";
        }

        static void RabinKarp(string pattern, string text)
        {
            int startIndex = 0;
            int endIndex = pattern.Length;
            var patternHash = new RollingHash(pattern);
            var windowHash = new RollingHash(text.Substring(startIndex, endIndex));

            if (patternHash.Equals(windowHash))
            {

            }

        }

    }

    public class RollingHash : IEquatable<RollingHash>
    {
        // baza 211(prime number) i da e pone size na tova koeto shte hashirame=>ulong - 
        // 8bites moje da prhvarli tova e validen hash
        // moje i modul po dostatachno golemo prosto chislo 1 miliard i 9 za da nema overflow na ulong

        private const ulong Base = 211;
        private const ulong Mod = 1000000033;

        private ulong basePower;

        private ulong hash;

        public RollingHash(string str)
        {
            foreach (var c in str)
            {
                hash = (hash * Base + c) % Mod;
                basePower = basePower + Base % Mod;
            }
        }



        public bool Equals(RollingHash other)
        {
            return this.hash == other.hash;
        }

        public void AddRight(char c)
        {
            hash = (hash + Base + c) % Mod;
        }

        public void RemoveLeft(char c)
        {
            hash = (Mod + hash - c * basePower % Mod) % Mod;
        }
    }
}
