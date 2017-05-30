using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sample
{
	/// <summary>
	/// WebAPIを実行してレスポンスを取得する
	/// </summary>
	public class HttpService
	{
		public static async Task<dynamic> getDataFromService(string queryString)
		{
			dynamic data = null;
			HttpClient client = new HttpClient();
			var response = await client.GetAsync(queryString);

			if ((response != null) && !((int)response.StatusCode >= 400))
			{
				string json = response.Content.ReadAsStringAsync().Result;
				data = JsonConvert.DeserializeObject(json);
			}

			return data;
		}

	}
}
