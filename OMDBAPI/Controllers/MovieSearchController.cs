using Microsoft.AspNetCore.Mvc;
using OMDBAPI.Business.Interfaces;
using OMDBAPI.ViewModels;
using System.Threading.Tasks;

namespace OMDBAPI.Controllers
{
    public class MovieSearchController : Controller
    {
        private static IOmdbService _service;

        public MovieSearchController(IOmdbService service)
        {
            _service = service;
        }

        [Route("omdbapi/movie-search/{movName}")]
        public async Task<IActionResult> MoviePartialSearch(string movName)
        {
            var result = await _service.GetOmdbResponseAsync(movName);

            var view = new OMDBResponseView
            {
                OmdbResponse = result
            };

            return PartialView("~/Pages/_MoviePartial.cshtml", view);
        }
    }
}