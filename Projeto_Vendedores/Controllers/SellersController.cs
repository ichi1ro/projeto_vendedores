using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Vendedores.Migrations;
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

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel() { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SellerFormViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                obj.Departments = departments;
                return View(obj);
            }
            await _sellerService.InsertAsync(obj.Seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null) 
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Details(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null) 
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null) 
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel 
            { 
                Seller = obj, 
                Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id, SellerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                viewModel.Departments = departments;
                return View(viewModel);
            }

            if (id != viewModel.Seller.Id) 
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            try
            {
                await _sellerService.UptadeAsync(viewModel.Seller);
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
