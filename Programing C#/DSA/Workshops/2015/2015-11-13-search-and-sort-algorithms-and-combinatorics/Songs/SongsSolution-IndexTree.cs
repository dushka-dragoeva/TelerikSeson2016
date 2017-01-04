namespace Songs
{
    using System;
    using System.Linq;

    class Program
	{
		public static void Update(int[] tree, int index, int val)
		{
			while (index > 0)
			{
				tree[index] += val;
				index &= index - 1;
			}

			tree[0] += val;
		}

		public static int Query(int[] tree, int index)
		{
			int n = tree.Length;

			int val = 0;
			while (index < n)
			{
				val += tree[index];
				index += index & -index;
				if (index == 0)
				{
					break;
				}
			}

			return val;
		}

		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			var array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			var array2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			var rename = new int[n + 1];

			for (int i = 0; i < n; i++)
			{
				rename[array1[i]] = i;
			}

			for (int i = 0; i < n; i++)
			{
				array2[i] = rename[array2[i]];
			}

			var tree = new int[n];

			for(int i = 0; i < n; i++)
			{
				Update(tree, i, 1);
				array1[array2[i]] = i;
			}

			long inversions = 0;

			for(int i = n - 1; i >= 0; i--)
			{
				Update(tree, array1[i], -1);
				inversions += Query(tree, array1[i]);
			}

			Console.WriteLine(inversions);
		}
	}
}
