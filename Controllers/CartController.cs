using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using mini_store.Data;
using mini_store.ViewModels;
using System.Linq;

namespace mini_store.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // 1. دالة الـ Index أصبحت تقرأ الـ Id المخزن في السيرفر تلقائياً
        public IActionResult Index()
        {
            var count = HttpContext.Session.GetInt32("counter") ?? 0;

            // جلب رقم المنتج الذي تم حفظه أثناء الإضافة
            var savedProductId = HttpContext.Session.GetInt32("cart_product_id") ?? 0;

            // البحث عن المنتج باستخدام الرقم المحفوظ
            var product = _context.Products.FirstOrDefault(p => p.Id == savedProductId);

            var viewModel = new CartItemViewModel
            {
                ProductId = product?.Id ?? 0,
                ProductName = product?.Name ?? "منتج غير معروف",
                Price = product?.Price ?? 0,
                Quantity = count
            };

            return View(viewModel);
        }

        // 2. دالة الإضافة تقوم بحفظ الـ Id داخل الـ Session
        public IActionResult AddToCart(int id)
        {
            var count = HttpContext.Session.GetInt32("counter") ?? 0;
            count++;

            // حفظ العداد وحفظ معرف المنتج في الجلسة (Session)
            HttpContext.Session.SetInt32("counter", count);
            HttpContext.Session.SetInt32("cart_product_id", id);

            TempData["SuccessMessage"] = "تمت إضافة المنتج إلى السلة بنجاح!";

            return RedirectToAction("Details", "Home", new { id = id });
        }
    }
}