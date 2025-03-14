using System.ComponentModel.DataAnnotations;

namespace ShortenUrlApi.Presentation.Models
{
    public class GetUrlRequest
    {
        /// <summary>
        /// The short code to retrieve the original URL for
        /// </summary>
        [Required]
        public string ShortCode { get; set; } = string.Empty;
    }
} 