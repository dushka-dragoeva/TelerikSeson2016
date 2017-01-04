namespace RepeatingPattern
{
	using System;

	class StartUp
	{
		static void Main()
		{
			string text = Console.ReadLine();

			int[] fl = new int[text.Length + 1];
			fl[0] = -1;
			fl[1] = 0;

			int j;
			for(int i = 1; i < text.Length; i++)
			{
				j = fl[i];
				while(j >= 0 && text[i] != text[j])
				{
					j = fl[j];
				}

				fl[i + 1] = j + 1;
			}

			j = 0;
			for(int i = 1; ; i++)
			{
				if(i == text.Length)
				{
					i = 0;
				}

				while(j >= 0 && text[i] != text[j])
				{
					j = fl[j];
				}

				j++;

				if(j == text.Length)
				{
					j = i + 1;
					break;
				}
			}

			Console.WriteLine(text.Substring(0, j));
		}
	}
}
