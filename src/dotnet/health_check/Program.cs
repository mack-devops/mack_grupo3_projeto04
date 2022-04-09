using appcommonfunctions;
using appcommonfunctions.UI;

namespace health_check
{
	public class Program
	{
		const string ENDPOINT = "http://localhost:5147/health_check";
		const string ROCKET_CHAT_SERVER = "http://20.226.49.189";
		const string ROCKET_CHAT_SERVER_TOKEN = "/hooks/62505b2e646d99d65cc84ee3/YxqbXpfWRG4s55opz5EpGfLwtCdbA7odniM4N3RBCDJSSgAP";

		static void Main()
		{
			try
			{
				new Program().StartApp();
			}
			catch (Exception ex)
			{
				new LineColor().PrintResult(ex.Message, StatusScreen.Error);
				new Screen().RenderNextRound(300000);
			}
		}

		private void StartApp()
		{
			// Renderização do cabeçalho no console
			new Screen().RenderHeader("Health Check || Projeto 04 || Grupo 03");

            bool lastStatus = false;

            while (true)
			{
				lastStatus = new CallManager().Main(ENDPOINT, string.Concat(ROCKET_CHAT_SERVER, ROCKET_CHAT_SERVER_TOKEN), lastStatus);
				Thread.Sleep(3000);
			}
		}
	}
}
