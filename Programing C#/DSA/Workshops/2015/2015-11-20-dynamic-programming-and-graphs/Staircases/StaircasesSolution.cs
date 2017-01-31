namespace Staircases
{
	using System;

	class StartUp
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			
			long[,] dp = new long[512, 512];

			for(int i = 1; i <= n; i++)
				dp[i, i] = 1;

			for(int i = 1; i <= n; i++)
			{
				for(int j = 1; j < i; j++)
				{
					for(int k = 1; k < i - j; k++)
					{
						dp[i, i - j] += dp[j, k];
					}
				}
			}

			long answer = 0;
			for(int i = 0; i < n; i++)
			{
				answer += dp[n, i];
			}

			Console.WriteLine(answer);
		}
	}
}
