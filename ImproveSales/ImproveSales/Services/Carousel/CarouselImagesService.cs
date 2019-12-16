namespace ImproveSales.Services.Carousel
{
    using ImproveSales.Interfaces.Services.Carousel;
    using ImproveSales.Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;

    class CarouselImagesService : ICarouselImagesService
    {
        public CarouselImagesService()
        {
            using StreamReader reader = File.OpenText("wwwroot/images/index/carousel/JSON/CarouselData.json");
            CarouselImages = JsonSerializer.Deserialize<List<CarouselImage>>(reader.ReadToEnd());
        }

        public List<CarouselImage> CarouselImages { get; }
    }
}
