using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Verastar.Models.AddressAggregate;

namespace Verastar.Services
{
    public interface IAddressService
    {
        Task<AddressResponse> GetAddressListAsync(string postcode);
    }

    public class AddressService : IAddressService
    {
        public HttpClient Client { get; }

        public AddressService(HttpClient client)
        {
            Client = client;
        }

        public async Task<AddressResponse> GetAddressListAsync(string term)
        {
            string apiKey = "PCW45-12345-12345-1234X";
            term = term.Trim();
            term = HttpUtility.UrlEncode(term);

            var uri = new Uri($"https://api.getAddress.io/autocomplete/{term}?api-key={apiKey}");

            try
            {
                HttpResponseMessage response = await Client.GetAsync(uri);

                string responseJson = await response.Content.ReadAsStringAsync();

                var info = JsonSerializer.Deserialize<AddressResponse>(responseJson);
                return info;
            }
            catch (Exception)
            {
            }
            return null;
        }

    }
}
