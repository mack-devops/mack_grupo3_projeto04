using System.Net;
using System.Text;

namespace health_check
{
	public class HttpRequester
	{
		public HttpResponseMessage Get(string _urlApi)
		{
			using (var client = new HttpClient())
			{
				return client.GetAsync(_urlApi).Result;
			}
		}

		public HttpResponseMessage Post(string _urlApi, string _payload)
		{
			var content = new StringContent(_payload, Encoding.UTF8, "application/json");
			using (var client = new HttpClient())
			{
				return client.PostAsync(_urlApi, content).Result;
			}
		}
	}
}