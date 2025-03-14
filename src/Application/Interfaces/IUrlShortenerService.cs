using System.Threading.Tasks;

namespace ShortenUrlApi.Application.Interfaces;

/// <summary>
/// Defines the contract for URL shortening operations
/// </summary>
public interface IUrlShortenerService
{
    /// <summary>
    /// Generates a short code for the given URL
    /// </summary>
    /// <param name="originalUrl">The original URL to be shortened</param>
    /// <returns>The shortened URL code</returns>
    Task<string> GenerateShortCodeAsync(string originalUrl);

    /// <summary>
    /// Retrieves the original URL for a given short code
    /// </summary>
    /// <param name="shortCode">The short code to look up</param>
    /// <returns>The original URL if found, null otherwise</returns>
    Task<string?> GetOriginalUrlAsync(string shortCode);
} 