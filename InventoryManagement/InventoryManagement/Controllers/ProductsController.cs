using InventoryManagement.Contracts;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _products;
        public ProductsController(IProducts products)
        {
            _products = products;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            var models = _products.GetAll();
            return View(models);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var result = _products.GetById(id);
            return View(result);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                var result = _products.Add(product);
                TempData["Message"] = $"Product {product.ProductName} added successfuly";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Product not added";
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _products.GetById(id);
            return View(result);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                var result = _products.Update(product);
                TempData["Message"] = $"Product {product.ProductName} updated successfuly";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Product not updated";
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeletePost(int ProductId)
        {
            return View();
        }
    }
}
