using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sale.Data.Model;
using Sale.Service;
using Sale.WebApp.Models;

namespace Sale.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ICartProductService _cartProductService;
        private readonly IUserService _userService;
        private readonly ISaleService _saleService;
        public CartController(IProductService productService, ICartService cartService, IUserService userService, ICartProductService cartProductService, ISaleService saleService)
        {
            _productService = productService;
            _cartService = cartService;
            _userService = userService;
            _cartProductService = cartProductService;
            _saleService = saleService;
            
        }
        public IActionResult Index(string msg = null, string scsMsg = null)
        {
            if (UserService.CurrentUser == null || !UserService.CurrentUser.IsAuthenticate)
                return RedirectToAction("Index", "Login", new { msg = "Giriş yapmalısınız." });

            ViewData["ErrorMsg"] = msg;
            ViewData["SuccessInfo"] = scsMsg;
            var model = _cartProductService.GetCartProducts(_cartService.GetUserCart().Id);

            CartViewModel cvm = new CartViewModel();

            if(model == null || model.LongCount<CartProduct>() == 0)
                return RedirectToAction("Index", "Home", new { msg="Sepetinizde hiç ürün yok."});
            else
            {
                cvm.ProductAmountsOnCart = new List<int>();
                cvm.Products = new List<Product>();
                cvm.TotalPrice = 0;

                foreach (var item in model)
                {
                    Product p = _productService.Get(x => x.Id == item.ProductId);
                    cvm.TotalPrice += p.Price * item.OnCartAmount;
                    cvm.ProductAmountsOnCart.Add(item.OnCartAmount);
                    cvm.Products.Add(p);
                }
            }
            
            return View(cvm);
        }
        
        public IActionResult DeleteFromCart(long pId)
        {
            _cartProductService.Delete(pId);

            if (_cartService.SaveChanges() == 0)
                return RedirectToAction("Index", new { msg = "Bir hata oluştu." });
            else
                return RedirectToAction("Index", new { msg = "Ürün sepetten çıkarıldı." });
        }

        public IActionResult CompleteSale(decimal Total)
        {
            _saleService.CompleteShopping(Total);
            if (_saleService.SaveChanges() != 0)
                return RedirectToAction("Index", "Home", new { scsMsg = "Alışverişiniz tamamlandı." });
            else
                return RedirectToAction("Index", new { Msg = "Alışveriş tamamlanamadı." });
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
