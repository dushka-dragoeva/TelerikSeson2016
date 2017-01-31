namespace Source
{
    using System;
    using System.Collections.Generic;

    class Hash
    {
        private const ulong BASE1 = 31;
        private const ulong MOD1 = 1000000009;

        private const ulong BASE2 = 10037;
        private const ulong MOD2 = 1000000033;

        private ulong power1;
        private ulong[] power2;

        private int[] lastindex;
        private int[] distances;

        public ulong Hash1 { get; private set; }
        public ulong Hash2 { get; private set; }

        public Hash(string str, int n)
        {
            if (n > 0)
            {
                this.distances = new int[n];
            }
            this.lastindex = new int[26];
            for (int i = 0; i < lastindex.Length; i++)
            {
                lastindex[i] = -1;
            }

            this.Hash1 = 0;
            this.Hash2 = 0;

            this.power1 = 1;
            this.power2 = new ulong[str.Length + 1];
            power2[0] = 1;

            for (int i = 0; i < str.Length; i++)
            {
                this.Add(str[i], i);
                this.power1 = this.power1 * BASE1 % MOD1;
                this.power2[i + 1] = this.power2[i] * BASE2 % MOD2;
            }
        }

        public void Add(char c, int index)
        {
            this.Hash1 *= BASE1;
            this.Hash2 *= BASE2;

            if ('A' <= c && c <= 'Z')
            {
                this.Hash1 += (ulong)(c - 'A' + 1);
                this.Hash2 += MOD2 - 1; // upper case

            }
            else
            {
                this.Hash1 += MOD1 - 1; // lower case
                this.Hash2 += MOD2 - 2; // last of kind
                if (this.distances != null)
                {
                    this.distances[index] = (int)(MOD2 - 2);
                }
                if (lastindex[c - 'a'] >= 0)
                {
                    int distance = index - lastindex[c - 'a'];
                    if (this.distances != null)
                    {
                        this.distances[lastindex[c - 'a']] = distance;
                    }
                    this.Hash2 += (ulong)(distance + 2) * this.power2[distance];
                }

                lastindex[c - 'a'] = index;
            }

            this.Hash1 %= MOD1;
            this.Hash2 %= MOD2;
        }

        public void Remove(char c, int index)
        {
            if ('A' <= c && c <= 'Z')
            {
                this.Hash1 += MOD1 * MOD1 - (ulong)(c - 'A' + 1) * this.power1;
                this.Hash2 += MOD2 * MOD2 - (MOD2 - 1) * this.power2[this.power2.Length - 1];
            }
            else
            {
                this.Hash1 += MOD1 * MOD1 - (MOD1 - 1) * this.power1;
                this.Hash2 += MOD2 * MOD2 - (ulong)distances[index] * this.power2[this.power2.Length - 1];

                if (lastindex[c - 'a'] == index)
                {
                    lastindex[c - 'a'] = -1;
                }
            }

            this.Hash1 %= MOD1;
            this.Hash2 %= MOD2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            if (pattern.Length > text.Length)
            {
                Console.WriteLine(0);
                return;
            }

            Hash hpattern = new Hash(pattern, 0);
            Hash hwindow = new Hash(text.Substring(0, pattern.Length), text.Length);

            List<int> matches = new List<int>();

            if (hpattern.Hash1 == hwindow.Hash1
                && hpattern.Hash2 == hwindow.Hash2)
            {
                matches.Add(1);
            }

            for (int i = pattern.Length; i < text.Length; i++)
            {
                hwindow.Add(text[i], i);
                hwindow.Remove(text[i - pattern.Length], i - pattern.Length);

                if (hpattern.Hash1 == hwindow.Hash1
                    && hpattern.Hash2 == hwindow.Hash2)
                {
                    matches.Add(i - pattern.Length + 2);
                }
            }

            Console.WriteLine("{0}\n{1}", matches.Count, string.Join(" ", matches));
        }
    }
}
