namespace ImproveSales.Pages
{
    using ImproveSales.Interfaces.Services.Carousel;
    using ImproveSales.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;

    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        #region Declaration
        private readonly ILogger<IndexModel> _logger;
        private readonly ICarouselImagesService _carouselService;
        #endregion // Declaration

        #region Initialization
        public IndexModel(ILogger<IndexModel> logger,
                          ICarouselImagesService carouselService)
        {
            _logger = logger;
            _carouselService = carouselService;
        }
        #endregion // Initialization

        #region Properties


        public List<CarouselImage> CarouselImages
        {
            get => _carouselService.CarouselImages;
        }

        #endregion // Properties

        #region OnGet()
        public void OnGet()
        {
            LogOppenedPage();
        }

        #endregion // OnGet()

        #region Private Methods

        private void LogOppenedPage()
        {
            if (User?.Identity?.IsAuthenticated == true)
                _logger.LogInformation($"User: {User.Identity.Name} opened home page.");
            else
                _logger.LogInformation("Not logged user opened home page");
        }

        #endregion //Private Methods
    }
}
