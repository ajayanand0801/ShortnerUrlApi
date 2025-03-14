namespace ShortenUrlApi.Presentation.Models;

/// <summary>
/// Response model for URL shortening operation
/// </summary>
public class ShortenUrlResponse
{
    /// <summary>
    /// The original URL that was shortened
    /// </summary>
    public string OriginalUrl { get; set; } = string.Empty;

    /// <summary>
    /// The shortened version of the URL
    /// </summary>
    public string ShortUrl { get; set; } = string.Empty;
} 