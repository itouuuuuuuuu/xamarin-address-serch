using System;
using Xamarin.Forms;

namespace Sample
{
    public partial class SamplePage : ContentPage
    {
        public SamplePage()
		{
			InitializeComponent();
			this.Title = "住所検索アプリ";
			getAddressSerchBtn.Clicked += getAddressSerchBtn_Clicked;

			this.BindingContext = new Address(); // Addressクラスのインスタンスをバインディング（初期表示）
		}

		private async void getAddressSerchBtn_Clicked(object sender, EventArgs e)
		{
            // 入力された値がnullでなく7文字だった場合
			if (!string.IsNullOrEmpty(AddressEntry.Text) && ((string)AddressEntry.Text).Length == 7)
			{
				Address Ad = await Core.getAddressSerchResult(AddressEntry.Text);

				if (Ad == null)
				{
                    await DisplayAlert("通知", "検索に失敗しました", "OK");
					return;
				}
				else
				{
					this.BindingContext = Ad;    // 正しい結果の場合は検索結果をバインディング
				}
			}
			else
			{
				await DisplayAlert("警告", "郵便番号は7桁で入力してください", "Ok");
			}
		}
    }
}
