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
			getAddressSerchBtn.Clicked += GetAddressSerchBtn_Clicked;

			this.BindingContext = new Address();
		}

		private async void GetAddressSerchBtn_Clicked(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(AddressEntry.Text) && ((string)AddressEntry.Text).Length == 7)
			{
				Address Ad = await Core.GetAddressSerchResult(AddressEntry.Text);

				if (Ad == null)
				{
                    await DisplayAlert("通知", "検索に失敗しました", "OK");
					return;
				}
				else
				{
					this.BindingContext = Ad;
				}
			}
			else
			{
				await DisplayAlert("警告", "郵便番号は7桁で入力してください", "Ok");
			}
		}
    }
}
