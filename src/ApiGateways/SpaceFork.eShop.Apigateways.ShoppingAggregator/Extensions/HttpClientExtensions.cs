using System.Text.Json;

namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something wrong when trying to call API : {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
