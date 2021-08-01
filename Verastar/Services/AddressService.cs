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
        Task<AddressResponse> GetAddressListAsync(string term);
        Task<FullAddressResponseDTO> GetAddressByIdAsync(string id);
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
            if (string.IsNullOrWhiteSpace(term))
                return new AddressResponse();

            string apiKey = "S2z8KArOKUOdlrzxC7VBgg32199";
            term = term.Trim();
            term = Uri.EscapeUriString(term);

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

        public async Task<FullAddressResponseDTO> GetAddressByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            string apiKey = "S2z8KArOKUOdlrzxC7VBgg32199";
            id = id.Trim();
            id = Uri.EscapeUriString(id);

            var uri = new Uri($"https://api.getAddress.io/get/{id}?api-key={apiKey}");

            try
            {
                HttpResponseMessage response = await Client.GetAsync(uri);

                string responseJson = await response.Content.ReadAsStringAsync();

                var addressResponse = JsonSerializer.Deserialize<FullAddressResponse>(responseJson);

                var fullAddress = new FullAddressResponseDTO();
                fullAddress.line1 = addressResponse.line_1;
                fullAddress.line2 = addressResponse.line_2;
                fullAddress.towncity = addressResponse.town_or_city;
                fullAddress.district = addressResponse.district;
                fullAddress.postcode = addressResponse.postcode;

                return fullAddress;
            }
            catch (Exception)
            {
            }
            return null;
        }

    }
}
