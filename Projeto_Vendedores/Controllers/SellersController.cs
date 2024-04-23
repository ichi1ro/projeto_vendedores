using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Vendedores.Models;
using Projeto_Vendedores.Models.ViewModels;
using Projeto_Vendedores.Services;
using Projeto_Vendedores.Services.Exceptions;
using System.Diagnostics;

namespace Projeto_Vendedores.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel() { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SellerFormViewModel obj)
        {   
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                obj.Departments = departments;
                return View(obj);
            }
            _sellerService.Insert(obj.Seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var obj = _sellerService.FindById(id.Value);
            if (obj == null) return RedirectToAction(nameof(Error), new { message = "Id not found" });
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var obj = _sellerService.FindById(id.Value);
            if (obj == null) return RedirectToAction(nameof(Error), new { message = "Id not found" });
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var obj = _sellerService.FindById(id.Value);
            if (obj == null) return RedirectToAction(nameof(Error), new { message = "Id not found" });
            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SellerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            if (id != viewModel.Seller.Id) return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            try
            {
                _sellerService.Uptade(viewModel.Seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = message
            };
            return View(viewModel);
        }
    }
}
