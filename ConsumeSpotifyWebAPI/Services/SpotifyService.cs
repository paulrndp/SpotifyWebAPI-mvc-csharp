using ConsumeSpotifyWebAPI.Models;
using ConsumeSpotifyWebAPI.Services;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ConsumeSpotifyWebAPI.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _httpClient;

        public SpotifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Release>> GetNewRelease(string countryCode, int limit, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetAsync($"browse/new-release?country={countryCode}&limit={limit}");

            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetNewReleaseResult>(responseStream);

            return responseObject!.albums.items.Select(i => new Release
            {
                Name = i.name,
                Date = i.release_date,
                ImageUrl = i.images.FirstOrDefault()!.url,
                Link = i.external_urls.spotify,
                Artists = string.Join(",", i.artists.Select(i => i.name))
            });

        }
    }
}
