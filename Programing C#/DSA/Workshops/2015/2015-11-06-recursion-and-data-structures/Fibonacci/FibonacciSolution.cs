namespace FibonacciFast
{
    using System;
  
	class Matrix
    {
        public long[,] Table { get; set; }

        const int MOD = 1000000007;

        public Matrix(long a, long b, long c, long d)
        {
            this.Table = new long[2, 2];

            this.Table[0, 0] = a;
            this.Table[0, 1] = b;
            this.Table[1, 0] = c;
            this.Table[1, 1] = d;
        }

        public Matrix(Matrix A, Matrix B)
        {
            this.Table = new long[2, 2];

            this.Table[0, 0] = A.Table[0, 0] * B.Table[0, 0]
                            + A.Table[0, 1] * B.Table[1, 0];
            this.Table[0, 1] = A.Table[0, 0] * B.Table[0, 1]
                            + A.Table[0, 1] * B.Table[1, 1];
            this.Table[1, 0] = A.Table[1, 0] * B.Table[0, 0]
                            + A.Table[1, 1] * B.Table[1, 0];
            this.Table[1, 1] = A.Table[1, 0] * B.Table[0, 1]
                            + A.Table[1, 1] * B.Table[1, 1];

            this.Table[0, 0] %= MOD;
            this.Table[0, 1] %= MOD;
            this.Table[1, 0] %= MOD;
            this.Table[1, 1] %= MOD;
        }
    }

    class Program
    {
        static Matrix PowMod(Matrix a, long p)
        {
            if (p == 1)
            {
                return a;
            }

            if (p % 2 == 1)
            {
                return new Matrix(PowMod(a, p - 1), a);
            }

            a = PowMod(a, p / 2);
            return new Matrix(a, a);
        }

        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            var a = new Matrix(1, 1, 1, 0);
            Console.WriteLine(PowMod(a, n).Table[0, 1]);
        }
    }
}
