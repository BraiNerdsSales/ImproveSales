namespace ImproveSales.Interfaces.Services.Carousel
{
    using ImproveSales.Models;
    using System.Collections.Generic;

    public interface ICarouselImagesService
    {
        List<CarouselImage> CarouselImages { get; }
    }
}
