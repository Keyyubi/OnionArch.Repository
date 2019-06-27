using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrazySale.Models;
using CrazySale.Services;

namespace CrazySale.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IChartService _chartService;
        private readonly IUserService _userService;
        public HomeController(IProductService productService, IChartService chartService, IUserService userService)
        {
            _productService = productService;
            _chartService = chartService;
            _userService = userService;
        }


        public async Task<IActionResult> Index(string msg = null, string scsMsg = null)
        {
            if(!_userService.IsAuthenticate())
                return RedirectToAction("Index", "Login", new { msg="Giriş yapmalısınız."});
            
            ViewData["ErrorMsg"] = msg;
            ViewData["SuccessInfo"] = scsMsg;
            var items = await _productService.GetOnSaleProductsAsync();
            var model = new ProductViewModel() { Products = items };
            return View(model);
        }
        
        public async Task<IActionResult> AddProductToChart(int Amount, Guid pId)
        {
            if(Amount == 0)
                return RedirectToAction("Index");
            
            var result = await _chartService.AddProductToChartAsync(pId,Amount);
            if(result)
                return RedirectToAction("Index", new { scsMsg="Ürün başarılı bir şekilde sepete eklendi."});
            
            return RedirectToAction("Index", new { scsMsg="Ürün eklenirken bir hata oluştu."});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
