using System.ComponentModel.DataAnnotations;

namespace ShortenUrlApi.Presentation.Models;

/// <summary>
/// Request model for URL shortening
/// </summary>
public class ShortenUrlRequest
{
    /// <summary>
    /// The original URL to be shortened
    /// </summary>
    [Required]
    [Url]
    public string OriginalUrl { get; set; } = string.Empty;
} 