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
        private readonly ICartProductService _cartProductService;

        public ProductController(IProductService productService, IUserService userService, ICartService cartService, ICategoryService categoryService, ICartProductService cartProductService)
        {
            _productService = productService;
            _userService = userService;
            _cartService = cartService;
            _categoryService = categoryService;
            _cartProductService = cartProductService;
        }
        public IActionResult Index(string msg = null, string scsMsg = null)
        {
            if (UserService.CurrentUser == null || !UserService.CurrentUser.IsAuthenticate)
                return RedirectToAction("Index", "Login", new { msg = "Giriş yapmalısınız." });

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

            ViewBag.Categories = _categoryService.GetAll();

            var model = new ProductViewModel() { Products = products};
            return View(model);
        }

        // Prevents the Cross-Site Request Forgery (CSRF)
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product newProduct)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _productService.Add(newProduct);
            if (_productService.SaveChanges() == 0)
                return RedirectToAction("Index", new { msg = "Ürün eklenemedi" });

            return RedirectToAction("Index", new { scsMsg = "Ürün başarıyla eklendi" });
        }

        
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(Product p)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _productService.Update(p);

            if (_productService.SaveChanges() == 0)
                return BadRequest("Ürün silinemedi.");
            
            return RedirectToAction("Index");
        }
        
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(long pId)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _productService.Delete(pId);

            if (_productService.SaveChanges() == 0)
                return BadRequest("Ürün silinemedi.");
            
            return RedirectToAction("Index");
        }
        
        public IActionResult RouteUpdateProduct(long pId)
        {
            var model = _productService.GetById(pId);
            ViewBag.Categories = _categoryService.GetAll();
            return View("UpdateProduct",model);
        }

        [ValidateAntiForgeryToken]
        public IActionResult AddProductToChart(int Amount, long pId)
        {
            if(Amount == 0)
                return RedirectToAction("Index");
            
            _cartProductService.Add(new CartProduct { CartId=_cartService.GetUserCart().Id, ProductId = pId, OnCartAmount = Amount });

            if(_cartProductService.SaveChanges() != 0)
                return RedirectToAction("Index", new { scsMsg="Ürün başarılı bir şekilde sepete eklendi."});
            
            return RedirectToAction("Index", new { scsMsg="Ürün eklenirken bir hata oluştu."});
        }
    }
}