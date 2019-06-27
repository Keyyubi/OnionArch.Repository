using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrazySale.Services;
using CrazySale.Models;

namespace CrazySale
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IChartService _chartService;

        public ProductController(IProductService productService, IUserService userService, IChartService chartService)
        {
            _productService = productService;
            _userService = userService;
            _chartService = chartService;
        }
        public async Task<IActionResult> Index(string msg = null, string scsMsg = null)
        {
            if(!_userService.IsAuthenticate())
                return RedirectToAction("Index", "Login", new { msg="Giriş yapmalısınız."});
            
            ViewData["ErrorMsg"] = msg;
            ViewData["SuccessInfo"] = scsMsg;
            
            var items = await _productService.GetAllProductsAsync();
            var model = new ProductViewModel() { Products = items };
            return View(model);
        }

        // Prevents the Cross-Site Request Forgery (CSRF)
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product newProduct)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var success = await _productService.AddProductAsync(newProduct);
            if (!success)
                return BadRequest("Ürün eklenemedi.");
            
            return RedirectToAction("Index");
        }

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
        }
    }
}