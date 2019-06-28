using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sale.Data.Model;
using Sale.Service;
using Sale.WebApp.Models;

namespace Sale.WebApp
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly ICartService _cartService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, IUserService userService, ICartService cartService, ICategoryService categoryService)
        {
            _productService = productService;
            _userService = userService;
            _cartService = cartService;
            _categoryService = categoryService;
        }
        public IActionResult Index(string msg = null, string scsMsg = null)
        {
            //if(!_userService.CurrentUser().IsAuthenticate)
            //    return RedirectToAction("Index", "Login", new { msg="Giriş yapmalısınız."});

            // Creates some categories for testing if there are no categories those defined earlier.
            if (_categoryService.GetAll().Count() == 0)
            {
                List<Category> initCats = new List<Category>();
                initCats.Add(new Category { Name = "Kategori 1" });
                initCats.Add(new Category { Name = "Kategori 2" });
                initCats.Add(new Category { Name = "Kategori 3" });
                _categoryService.AddRange(initCats);
                int result = _categoryService.SaveChanges();
            }

            ViewData["ErrorMsg"] = msg;
            ViewData["SuccessInfo"] = scsMsg;

            var products = _productService.GetAll();
            var categories = _categoryService.GetAll();
            var model = new ProductViewModel() { Products = products, Categories = categories };
            return View(model);
        }

        // Prevents the Cross-Site Request Forgery (CSRF)
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(AddProductPartial newProduct)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _productService.Add(newProduct.product);
            if (_productService.SaveChanges() == 0)
                return RedirectToAction("Index", new { msg = "Ürün eklenemedi" });

            return RedirectToAction("Index", new { scsMsg = "Ürün başarıyla eklendi" });
        }

        /*
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(Product p)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var success = await _productService.UpdateProduct(p);

            if (!success)
                return BadRequest("Ürün silinemedi.");
            
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(Guid pId)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var success = await _productService.DeleteProductAsync(pId);

            if (!success)
                return BadRequest("Ürün silinemedi.");
            
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> RouteUpdateProduct(Guid pId)
        {
            var model = await _productService.GetProduct(pId);
            return View("UpdateProduct",model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductToChart(int Amount, Guid pId)
        {
            if(Amount == 0)
                return RedirectToAction("Index");
            
            var result = await _chartService.AddProductToChartAsync(pId,Amount);
            if(result)
                return RedirectToAction("Index", new { scsMsg="Ürün başarılı bir şekilde sepete eklendi."});
            
            return RedirectToAction("Index", new { scsMsg="Ürün eklenirken bir hata oluştu."});
        }*/
    }
}