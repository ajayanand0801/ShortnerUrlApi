using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ShortenUrlApi.Application.Interfaces;

namespace ShortenUrlApi.Infrastructure.Services;

/// <summary>
/// Implementation of URL shortening service that uses SHA256 hashing
/// </summary>
public class UrlShortenerService : IUrlShortenerService
{
    private readonly ConcurrentDictionary<string, string> _urlMappings = new();

    /// <summary>
    /// Generates a shortened URL by creating a hash of the original URL
    /// </summary>
    /// <param name="originalUrl">The original URL to be shortened</param>
    /// <returns>An 8-character Base64 encoded string derived from the SHA256 hash of the original URL</returns>
    public string GenerateShortUrl(string originalUrl)
    {
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(originalUrl));
        return Convert.ToBase64String(hash).Substring(0, 8).Replace("/", "_").Replace("+", "-");
    }

    public async Task<string> GenerateShortCodeAsync(string originalUrl)
    {
        if (string.IsNullOrWhiteSpace(originalUrl))
            throw new ArgumentException("URL cannot be empty", nameof(originalUrl));

        // Generate a unique short code using the first 8 characters of a SHA256 hash
        using var sha256 = SHA256.Create();
        var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(originalUrl + DateTime.UtcNow.Ticks));
        var shortCode = Convert.ToHexString(hashBytes).Substring(0, 8);

        // Store the mapping
        _urlMappings.TryAdd(shortCode, originalUrl);

        return await Task.FromResult(shortCode);
    }

    public async Task<string?> GetOriginalUrlAsync(string shortCode)
    {
        if (string.IsNullOrWhiteSpace(shortCode))
            throw new ArgumentException("Short code cannot be empty", nameof(shortCode));

        _urlMappings.TryGetValue(shortCode, out var originalUrl);
        return await Task.FromResult(originalUrl);
    }
} 