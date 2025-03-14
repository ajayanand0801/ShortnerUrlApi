using System;

namespace ShortenUrlApi.Domain.Entities;

/// <summary>
/// Represents a shortened URL entity in the system
/// </summary>
public class ShortUrl
{
    /// <summary>
    /// Gets or sets the unique identifier for the shortened URL
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the original URL that was shortened
    /// </summary>
    public required string OriginalUrl { get; set; }

    /// <summary>
    /// Gets or sets the generated short code for the URL
    /// </summary>
    public required string ShortCode { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the URL was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
} 