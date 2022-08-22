using ConsumeSpotifyWebAPI.Models;

namespace ConsumeSpotifyWebAPI.Services
{
    public interface ISpotifyService
    {
        Task<IEnumerable<Release>> GetNewRelease(string countryCode, int limit, string accessToken);

    }
}
