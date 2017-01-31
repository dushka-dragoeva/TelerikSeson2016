namespace Friends
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public class Edge
	{
		public int To { get; set; }
		public int Length { get; set; }

		public Edge(int to, int length)
		{
			this.To = to;
			this.Length = length;
		}
	}

	public class StartUp
	{
		static List<Edge>[] edges;
		static int maxn;
		static int[] tree;
		static int[] mindist;

		static void Main()
		{
			int[] line = Console.ReadLine().Split(' ')
				.Select(int.Parse).ToArray();

			int n = line[0];
			int m = line[1];

			edges = new List<Edge>[n];
			for(int i = 0; i < edges.Length; i++)
			{
				edges[i] = new List<Edge>();
			}

			mindist = new int[n];

			line = Console.ReadLine().Split(' ')
				.Select(int.Parse).ToArray();

			int start = line[0] - 1;
			int end = line[1] - 1;

			line = Console.ReadLine().Split(' ')
				.Select(int.Parse).ToArray();

			int mid1 = line[0] - 1;
			int mid2 = line[1] - 1;

			for(int i = 0; i < m; i++)
			{
				line = Console.ReadLine().Split(' ')
					.Select(int.Parse).ToArray();

				edges[line[0] - 1].Add(new Edge(line[1] - 1, line[2]));
				edges[line[1] - 1].Add(new Edge(line[0] - 1, line[2]));
			}

			// Done reading input

			// Index tree setup

			maxn = 1;
			while(maxn < n)
			{
				maxn *= 2;
			}

			tree = new int[maxn * 2];
			for(int i = 0; i < tree.Length; i++)
			{
				tree[i] = -1;
			}

			// Dijkstras
			
			Dijkstra(mid1, mid2);
			int s1 = mindist[start];
			int e1 = mindist[end];
			int m12 = mindist[mid2];

			Dijkstra(mid2, mid1);
			int s2 = mindist[start];
			int e2 = mindist[end];
			//int m21 = mindist[mid1];
			
			Console.WriteLine(Math.Min(s1 + m12 + e2, s2 + m12 + e1));
		}

		static void Update(int index)
		{
			index += maxn;
			while(index > 1)
			{
				if(tree[index ^ 1] < 0)
				{
					tree[index / 2] = tree[index];
				}
				else if(tree[index] < 0)
				{
					tree[index / 2] = tree[index ^ 1];
				}
				else if(mindist[tree[index]] < mindist[tree[index ^ 1]])
				{
					tree[index / 2] = tree[index];
				}
				else
				{
					tree[index / 2] = tree[index ^ 1];
				}

				index /= 2;
			}
		}

		static void Push(int index, int dist)
		{
			mindist[index] = dist;
			tree[index + maxn] = index;
			Update(index);
		}

		static void Pop(int index)
		{
			tree[index + maxn] = -1;
			Update(index);
		}

		static void Dijkstra(int from, int exclude)
		{
			for(int i = 0; i < mindist.Length; i++)
			{
				mindist[i] = 1 << 30;
			}

			Push(from, 0);

			while(tree[1] >= 0)
			{
				from = tree[1];
				Pop(from);
				
				if(from == exclude)
				{
					continue;
				}

				foreach(var edge in edges[from])
				{
					int currdist = mindist[from] + edge.Length;
					if(mindist[edge.To] > currdist)
					{
						mindist[edge.To] = currdist;
						Push(edge.To, currdist);
					}
				}
			}
		}
	}
}
