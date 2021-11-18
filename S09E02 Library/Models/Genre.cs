using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace S09E02_Library.Models
{
    public class Genre
    {
        [JsonPropertyName("id"),Key]
        public int GenreId { get; set; }
        [JsonPropertyName("name"), Required]
        public string GenreName { get; set; }
        
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}