using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstate.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        IProductsService _productsService;
        private readonly ICategoryService _categoryservice;

        public ProductController(IProductsService productsService, ICategoryService categoryservice)
        {
            _productsService = productsService;
            _categoryservice = categoryservice;
        }

        public IActionResult Index()
        {
            var values=_productsService.TGetProductByCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in _categoryservice.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _productsService.TInsert(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var values=_productsService.TGetByID(id);
            _productsService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> values1 = (from x in _categoryservice.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values1;
            return View();
            var values = _productsService.TGetByID(id);
            return View(values);
        }
    }
}
