namespace appcommonfunctions.UI
{
	public class LineColor
	{
		public void Red(string outputMsg)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(outputMsg);
			Console.ResetColor();
		}

		public void Green(string outputMsg)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(outputMsg);
			Console.ResetColor();
		}

		public void Yellow(string outputMsg)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(outputMsg);
			Console.ResetColor();
		}

		public void White(string outputMsg)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(outputMsg);
			Console.ResetColor();
		}

		public void Cyan(string outputMsg)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write(outputMsg);
			Console.ResetColor();
		}

		public void Magenta(string outputMsg)
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write(outputMsg);
			Console.ResetColor();
		}

		public void Bold(string outputMsg)
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n {outputMsg}");
			Console.ResetColor();
		}

		public void PrintResult(string msg, StatusScreen status)
		{
			switch (status)
			{
				case StatusScreen.Success:
					new LineColor().Green(" [Success    ] - " + DateTime.Now.ToString() + " - ");
					new LineColor().White(msg + "\n");
					break;

				case StatusScreen.Warning:
					new LineColor().Yellow(" [Warning    ] - " + DateTime.Now.ToString() + " - ");
					new LineColor().White(msg + "\n");
					break;

				case StatusScreen.Error:
					new LineColor().Red(" [Error      ] - " + DateTime.Now.ToString() + " - ");
					new LineColor().White(msg + "\n");
					break;

				case StatusScreen.Loading:
					new LineColor().Cyan(" [In Progress] - " + DateTime.Now.ToString() + " - ");
					new LineColor().White(msg + "\n");
					break;
			}
		}
	}
}
