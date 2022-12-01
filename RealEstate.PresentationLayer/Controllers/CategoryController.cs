using Microsoft.AspNetCore.Mvc;
using RealEstate.BusinessLayer.Abstract;

namespace RealEstate.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryservice;

        public CategoryController(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }

        public IActionResult Index()
        {
            var values=_categoryservice.TGetList();
            return View(values);
        }
    }
}
