namespace ImproveSales.Models
{
    using System.Text.Json.Serialization;

    public class CarouselImage
    {

        [JsonPropertyName("imageName")]
        public string ImageName { get; set; }
        [JsonPropertyName("Content")]
        public string Content { get; set; }
        [JsonPropertyName("PathToProduct ")]
        public string PathToProduct { get; set; }
    }
}
