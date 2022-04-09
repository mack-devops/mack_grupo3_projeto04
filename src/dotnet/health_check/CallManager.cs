using appcommonfunctions;
using appcommonfunctions.UI;
using System.Net;

namespace health_check
{
    public class CallManager
    {
        public bool Main(string endpoint, string rocketChatServer, bool lastStatus)
        {
            bool statusEndpoint = false;

            try
            {
                statusEndpoint = CheckEndpoint(endpoint);
            }
            catch (Exception ex)
            {
                new LineColor().PrintResult($"API OFFLINE --> {ex.Message}", StatusScreen.Error);

                if (statusEndpoint != lastStatus)
                    SendLogRocketChat(endpoint, "OFFLINE", rocketChatServer, ex.Message);

                return false;
            }

            if (statusEndpoint != lastStatus)
            {
                if (statusEndpoint)
                {
                    SendLogRocketChat(endpoint, "ONLINE", rocketChatServer);
                    return true;
                }
                else
                {
                    SendLogRocketChat(endpoint, "ERROR", rocketChatServer);
                    return false;
                }
            }

            return lastStatus;
        }

        private bool CheckEndpoint(string endpoint)
        {
            new LineColor().Bold($"--> {DateTime.Now} || Checking <--");
            new LineColor().PrintResult($"--> {DateTime.Now} || {endpoint}", StatusScreen.Loading);
            var respApi = new HttpResponseMessage();

            respApi = new HttpRequester().Get(endpoint);

            if (respApi.StatusCode == HttpStatusCode.OK)
            {
                new LineColor().PrintResult($"API ONLINE", StatusScreen.Success);
                return true;
            }
            else
            {
                new LineColor().PrintResult($"API ERROR --> Code Status = {respApi.StatusCode}", StatusScreen.Error);
                return false;
            }
        }

        private bool SendLogRocketChat(string endpoint, string statusEndpoint, string rocketchatServer, string excepionMessage = null)
        {
            new LineColor().Bold($"--> {DateTime.Now} || Sending Log <--");
            new LineColor().PrintResult($"--> {DateTime.Now} || Sending Log -> {rocketchatServer}", StatusScreen.Loading);

            string jsonMsg = $"[API] {endpoint} --> {statusEndpoint} || {excepionMessage} {DateTime.Now}";
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
