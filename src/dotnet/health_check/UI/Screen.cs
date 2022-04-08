namespace appcommonfunctions.UI
{
	/// <summary>
	/// Metodos de renderização de menu
	/// </summary>
	public class Screen
	{
		/// <summary>
		/// Metodo de renderização do cabeçalho com versão
		/// </summary>
		public void RenderHeader(string ServiceName)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
			Console.WriteLine($"▒▒ -->\t {ServiceName}");
			Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
			Console.ResetColor();
			new LineColor().Yellow("\n\n\tStarting Process...");
			new LineColor().White($"\t {DateTime.Now} \n\n");
			Console.ResetColor();
		}

		/// <summary>
		/// Metodo de renderização do rodapé
		/// </summary>
		public void RenderNextRound(int timeSleep)
		{
			new LineColor().Magenta("\n\n=============================================================\n\n");
			new LineColor().Yellow($"\t\tNext Round: {DateTime.Now.AddMilliseconds(timeSleep)}");
			new LineColor().Magenta("\n\n=============================================================");
			Thread.Sleep(timeSleep);
			Console.ResetColor();
			Console.Clear();
		}
	}
}
