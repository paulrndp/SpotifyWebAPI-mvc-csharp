using ConsumeSpotifyWebAPI.Models;


namespace ConsumeSpotifyWebAPI.Services
{
    public interface ISpotifyService
    {
        Task<IEnumerable<Release>> GetNewReleases(string countryCode, int limit, string accessToken);
    }
}