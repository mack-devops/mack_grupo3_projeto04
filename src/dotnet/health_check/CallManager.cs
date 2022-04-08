using appcommonfunctions;
using appcommonfunctions.UI;
using System.Net;

namespace health_check
{
	public class CallManager
	{
		public void Main(string endpoint, string rocketChatServer)
		{
			bool statusEndpoint = CheckEndpoint(endpoint);

			if (statusEndpoint)
				SendLogRocketChat(endpoint, "ONLINE", rocketChatServer);
			else
				SendLogRocketChat(endpoint, "OFFLINE", rocketChatServer);

		}

		private bool CheckEndpoint(string endpoint)
		{
			new LineColor().Bold($"--> {DateTime.Now} || Checking <--");
			new LineColor().PrintResult($"--> {DateTime.Now} || {endpoint}", StatusScreen.Loading);

			var respApi = new HttpRequester().Get(endpoint);
			if (respApi.StatusCode == HttpStatusCode.OK)
			{
				new LineColor().PrintResult($"API ONLINE", StatusScreen.Success);
				return true;
			}
			else
			{
				new LineColor().PrintResult($"API OFFLINE --> Code Status = {respApi.StatusCode}", StatusScreen.Error);
				return false;
			}
		}

		private bool SendLogRocketChat(string endpoint, string statusEndpoint, string rocketchatServer)
		{
			new LineColor().Bold($"--> {DateTime.Now} || Sending Log <--");
			new LineColor().PrintResult($"--> {DateTime.Now} || Sending Log -> {rocketchatServer}", StatusScreen.Loading);

			string jsonMsg = $"[API] {endpoint} --> {statusEndpoint} || {DateTime.Now}";
			string payload = "{\"text\": \"" + jsonMsg + "\"}";

			var respRocketchatServer = new HttpRequester().Post(rocketchatServer, payload);

			if (respRocketchatServer.StatusCode == HttpStatusCode.OK)
			{
				new LineColor().PrintResult($"LOG enviado com sucesso!", StatusScreen.Success);
				return true;
			}
			else
			{
				new LineColor().PrintResult($"Erro ao enviar o LOG! -> Status code server = {respRocketchatServer.StatusCode}", StatusScreen.Error);
				return false;
			}
		}
	}
}
