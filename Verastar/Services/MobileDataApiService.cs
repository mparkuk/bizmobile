using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Verastar.Models;

namespace Verastar.Services
{
	public interface IMobileDataApiService
	{
		Task<List<MobileInfo>> GetMobileInfo();
	}
	public class MobileDataApiService : IMobileDataApiService
	{
        public HttpClient Client { get; }

		public MobileDataApiService(HttpClient client)
		{
			client.BaseAddress = new Uri("https://parseapi.back4app.com/classes/");
			client.DefaultRequestHeaders.Add("X-Parse-Master-Key", "uZ1r1iHnOQr5K4WggIibVczBZSPpWfYbSRpD6INw");
			client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "MEqvn3N742oOXsF33z6BFeezRkW8zXXh4nIwOQUT");

			Client = client;
		}

		public async Task<List<MobileInfo>> GetMobileInfo()
		{
			var filters = new { Brand = "Samsung" };
			string jsonString = JsonSerializer.Serialize(filters);
			string jsonEncoded = HttpUtility.UrlEncode(jsonString);

			var uri = new Uri("https://parseapi.back4app.com/classes/Dataset_Cell_Phones_Model_Brand?limit=10&where=" + jsonEncoded);
			
			List<MobileInfo> info = new List<MobileInfo>();

			try
            {
				HttpResponseMessage response = await Client.GetAsync(uri);

				string responseJson = await response.Content.ReadAsStringAsync();

				info = JsonSerializer.Deserialize<List<MobileInfo>>(responseJson);
			}
			catch (Exception)
			{
			}
			return info;
		}
	}
}
