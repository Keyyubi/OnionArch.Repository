using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sale.WebApp.Models;
using Sale.Service;
using Sale.Data.Model;

namespace CrazySale.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly ICartProductService _cartProductService;

        public HomeController(IProductService productService, ICartService cartService, IUserService userService, ICartProductService cartProductService)
        {
            _productService = productService;
            _cartService = cartService;
            _userService = userService;
            _cartProductService = cartProductService;
        }


        public IActionResult Index(string msg = null, string scsMsg = null)
        {
            if (_userService.CurrentUser() != null && !_userService.CurrentUser().IsAuthenticate)
                return RedirectToAction("Index", "Login", new { msg = "Giriş yapmalısınız." });

            ViewData["ErrorMsg"] = msg;
            ViewData["SuccessInfo"] = scsMsg;
            var items = _productService.GetOnSaleProducts();
            var model = new ProductViewModel() { Products = items };
            return View(model);
        }
        
        public IActionResult AddProductToChart(int Amount, long pId)
        {
            if(Amount == 0)
                return RedirectToAction("Index");

            CartProduct crp = new CartProduct();
            crp.CartId = _cartService.GetUserCart().Id;
            crp.ProductId = pId;
            crp.OnCartAmount = Amount;

            try
            {
                _cartProductService.Add(crp);
                return RedirectToAction("Index", new { scsMsg = "Ürün başarılı bir şekilde sepete eklendi." });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { scsMsg = "Ürün eklenirken bir hata oluştu." });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
