using System.Threading.Tasks;

namespace Sample
{
	public class Core
	{
		public static async Task<dynamic> GetAddressSerchResult(string address)
		{
			string pzNumber = address.Substring(0, 3); // 入力された郵便番号の上３桁を取得
			string taNumber = address.Substring(3);    // 入力された郵便番号の４桁目以降を取得する
			string queryString = "http://api.thni.net/jzip/X0401/JSON/" + pzNumber + "/" + taNumber + ".js"; // リクエストを作成
			dynamic results = await HttpService.getDataFromService(queryString).ConfigureAwait(false);

			if ((results != null) && (!string.IsNullOrEmpty((string)results["state"])))
			{
				Address Ad = new Address();                 // Addressクラスのインスタンスを作成
				Ad.state = (string)results["state"];        // インスタンスの各変数を設定
				Ad.stateName = (string)results["stateName"];
				Ad.city = (string)results["city"];
				Ad.street = (string)results["street"];
				return Ad;
			}
			else
			{
				return null;
			}

		}
	}
}