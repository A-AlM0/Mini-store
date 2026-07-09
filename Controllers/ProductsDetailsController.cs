using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini_store.Data;
using mini_store.Models;

namespace mini_store.Controllers
{
    public class ProductsDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsDetailsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var productDetails = _context.ProductDetails.Include(pd => pd.Product).ToList();
            return View(productDetails);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var products = _context.Products.ToList();
            ViewBag.Products = products;
            return View();
        }



        [HttpPost]
        public IActionResult Create(ProductDetails productDetails)
        {
            if (ModelState.IsValid)
            {
                _context.ProductDetails.Add(productDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var products = _context.Products.ToList();
            ViewBag.Products = products;
            return View(productDetails);
        }

        public IActionResult Details(int id)
        {
            var productDetails = _context.ProductDetails.FirstOrDefault(pd => pd.Id == id);
            if (productDetails == null)
            {
                return NotFound();
            }
            return View(productDetails);
        }
    

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productDetails = _context.ProductDetails.FirstOrDefault(pd => pd.Id == id);
            if (productDetails == null)
            {
                return NotFound();
            }

            var products = _context.Products.ToList();
            ViewBag.Products = products;

            return View(productDetails);
        }

        [HttpPost]
        public IActionResult Edit(ProductDetails productDetails)
        {
            if (ModelState.IsValid)
            {
                _context.ProductDetails.Update(productDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var products = _context.Products.ToList();
            ViewBag.Products = products;
            return View(productDetails);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var productDetails = _context.ProductDetails
                                         .Include(pd => pd.Product)
                                         .FirstOrDefault(pd => pd.Id == id);
            if (productDetails == null)
            {
                return NotFound();
            }
            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var productDetails = _context.ProductDetails.FirstOrDefault(pd => pd.Id == id);
            if (productDetails == null)
            {
                return NotFound();
            }

            _context.ProductDetails.Remove(productDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}