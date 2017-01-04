using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pattern
{
	public static class Svg
	{
		private static void WriteToStream(StreamWriter outFile, string directions, int width)
		{
			int x = 0;
			int y = 0;
			int maxX = 0;
			int maxY = 0;

			var points = new List<Tuple<int, int>>();
			points.Add(new Tuple<int, int>(x, y));

			foreach(char c in directions)
			{
				switch(c)
				{
					case 'u':
						y += width;
						break;
					case 'd':
						y -= width;
						break;
					case 'l':
						x -= width;
						break;
					case 'r':
						x += width;
						break;
					default:
						throw new ArgumentException("Directions string contains invalid characters");
				}

				if(maxX < x)
				{
					maxX = x;
				}
				if(maxY < y)
				{
					maxY = y;
				}
				points.Add(new Tuple<int, int>(x, y));
			}

			outFile.WriteLine(@"<svg xmlns=""http://www.w3.org/2000/svg"" version=""1.1"" width=""{0}"" height=""{1}"">
<polyline points=""{2}"" stroke=""black"" stroke-width=""2"" fill=""none"" />
</svg>",
				maxX + width * 2, maxY + width * 2,
				string.Join(" ", points.Select(point => (width + point.Item1) + "," + (width + maxY - point.Item2))));
		}

		public static void WriteToFile(string filename, string directions, int width = 32)
		{
			var outFile = new StreamWriter (filename);
			WriteToStream (outFile, directions, width);
			outFile.Close ();
		}
	}
}
