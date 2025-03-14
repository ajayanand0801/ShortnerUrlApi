using Microsoft.AspNetCore.Mvc;
using ShortenUrlApi.Application.Interfaces;
using ShortenUrlApi.Presentation.Models;
using System.Threading.Tasks;

namespace ShortenUrlApi.Presentation.Controllers;

/// <summary>
/// Controller for URL shortening operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ShortenUrlController : ControllerBase
{
    private readonly IUrlShortenerService _urlShortenerService;

    /// <summary>
    /// Initializes a new instance of the ShortenUrlController
    /// </summary>
    /// <param name="urlShortenerService">The URL shortener service</param>
    public ShortenUrlController(IUrlShortenerService urlShortenerService)
    {
        _urlShortenerService = urlShortenerService ?? throw new ArgumentNullException(nameof(urlShortenerService));
    }

    /// <summary>
    /// Creates a shortened version of the provided URL
    /// </summary>
    /// <param name="request">Request containing the original URL to shorten</param>
    /// <returns>Response containing both the original and shortened URLs</returns>
    /// <response code="200">Returns the shortened URL</response>
    /// <response code="400">If the URL is invalid or empty</response>
    [HttpPost]
    [ProducesResponseType(typeof(ShortenUrlResponse), 200)]
    [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
    public async Task<IActionResult> ShortenUrl([FromBody] ShortenUrlRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var shortCode = await _urlShortenerService.GenerateShortCodeAsync(request.OriginalUrl);
        
        var response = new ShortenUrlResponse
        {
            OriginalUrl = request.OriginalUrl,
            ShortUrl = $"{Request.Scheme}://{Request.Host}/api/ShortenUrl/{shortCode}"
        };

        return Ok(response);
    }

    /// <summary>
    /// Retrieves the original URL for a given short code
    /// </summary>
    /// <param name="shortCode">The short code to look up</param>
    /// <returns>The original URL if found</returns>
    /// <response code="200">Returns the original URL</response>
    /// <response code="404">If the short code is not found</response>
    [HttpGet("{shortCode}")]
    [ProducesResponseType(typeof(string), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetOriginalUrl([FromRoute] string shortCode)
    {
        var originalUrl = await _urlShortenerService.GetOriginalUrlAsync(shortCode);
        
        if (originalUrl == null)
            return NotFound();

        return Ok(originalUrl);
    }
} 