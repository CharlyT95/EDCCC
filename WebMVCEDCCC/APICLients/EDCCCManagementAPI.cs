using System.Text;
using System.Text.Json;

namespace WebMVCEDCCC.APICLients
{
    public class EDCCCManagementAPI
    {
        private readonly HttpClient _httpClient;
        private readonly string _api;

        public EDCCCManagementAPI(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _api = configuration["ApiSettings:ApiPrefix"];
        }

        public async Task<string> GetCCards()
        {
            var response = await _httpClient.GetAsync(_api + "CCard");
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetBills(int CCardId)
        {
            var response = await _httpClient.GetAsync(_api + "Bill/GetBillsListByCCard?CCardId=" + CCardId);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<HttpResponseMessage> SaveNewBill(object parameter)
        {
            var content = new StringContent(JsonSerializer.Serialize(parameter), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_api + "Bill", content);
            return response;
        }



    }
}
