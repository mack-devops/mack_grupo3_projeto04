using appcommonfunctions;
using appcommonfunctions.UI;
using health_check;

namespace project04
{
	public class Program
	{
		const string ENDPOINT = "https://www.google.com/";
		const string ROCKET_CHAT_SERVER = "http://20.226.49.189";
		const string ROCKET_CHAT_SERVER_TOKEN = "/hooks/624f79a0646d995c60c84c9e/gofKei4Niz83346NFHarwRvQLKxq35ZF5HbpJcJQKpdxfCnQ";

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

			while (true)
			{
				new CallManager().Main(ENDPOINT, string.Concat(ROCKET_CHAT_SERVER, ROCKET_CHAT_SERVER_TOKEN));
				Thread.Sleep(5000);
			}
		}
	}
}
