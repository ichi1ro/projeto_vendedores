using Microsoft.AspNetCore.Mvc;
using Projeto_Vendedores.Models;
using Projeto_Vendedores.Services;

namespace Projeto_Vendedores.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller obj)
        {
            _sellerService.Insert(obj);
            return RedirectToAction(nameof(Index));
        }
    }
}
