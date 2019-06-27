using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sale.Data.Model;
using Sale.Service;
using Sale.WebApp.Models;

namespace CrazySale.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _CartService;
        private readonly IUserService _userService;
        public CartController(IProductService productService, ICartService CartService, IUserService userService)
        {
            _productService = productService;
            _CartService = CartService;
            _userService = userService;
        }
        public async Task<IActionResult> Index(string msg = null, string scsMsg = null)
        {
            //if(!_userService.IsAuthenticate())
            //    return RedirectToAction("Index", "Login", new { msg="Giriş yapmalısınız."});

            //ViewData["ErrorMsg"] = msg;
            //ViewData["SuccessInfo"] = scsMsg;
            //var model = await _CartService.GetCartProductsAsync();

            //if(model == null || model.Products.Count == 0)
            //    return RedirectToAction("Index", "Home", new { msg="Sepetinizde hiç ürün yok."});

            return View();//model);
        }
        
        public async Task<IActionResult> DeleteFromCart(Guid pId)
        {
            //var result = await _CartService.DeleteProductFromCart(pId);

            //if(!result)
            //    return RedirectToAction("Index", new { msg="Bir hata oluştu."});
            //else
            //    return RedirectToAction("Index", new { msg="Ürün sepetten çıkarıldı."});

            return View();
        }

        public async Task<IActionResult> CompleteSale(decimal Total)
        {
            //var result = await _CartService.CompleteShopping(Total);
            //if(result)
            //    return RedirectToAction("Index", "Home", new { scsMsg="Alışverişiniz tamamlandı."});
            //else
            //    return RedirectToAction("Index", new { Msg="Alışveriş tamamlanamadı."});            

            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
