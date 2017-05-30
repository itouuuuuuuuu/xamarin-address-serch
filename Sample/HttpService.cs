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
            dynamic data = null;                                // returnする変数
			HttpClient client = new HttpClient();               // HttpClient型の変数
			var response = await client.GetAsync(queryString);  // 非同期でhttpリクエストしレスポンスを取得

            // nullでなく400文字以上でない場合
			if ((response != null) && !((int)response.StatusCode >= 400))
			{
				string json = response.Content.ReadAsStringAsync().Result; // レスポンスを取得
				data = JsonConvert.DeserializeObject(json);                // json形式に変換
			}

			return data;
		}

	}
}
