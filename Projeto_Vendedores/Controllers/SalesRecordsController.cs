using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Vendedores.Interfaces;
using Projeto_Vendedores.Migrations;
using Projeto_Vendedores.Models;
using Projeto_Vendedores.Models.Enums;
using Projeto_Vendedores.Models.ViewModels;
using Projeto_Vendedores.Services;
using Projeto_Vendedores.Services.Exceptions;
using System.Diagnostics;

namespace Projeto_Vendedores.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;
        private readonly SellerService _sellerService;

        public SalesRecordsController(SalesRecordService salesRecordService, SellerService sellerService)
        {
            _salesRecordService = salesRecordService;
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var sellers = await _sellerService.FindAllAsync();
            var viewModel = new SalesRecordFormViewModel() { Sellers = sellers };
            Dictionary<string, int> status = new Dictionary<string, int>()
            {
                {"Pending", 0 },
                {"Billed", 1 },
                {"Canceled", 2 }
            };
            ViewBag.Status = new SelectList(status, "Value", "Key");
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalesRecordFormViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                var sellers = await _sellerService.FindAllAsync();
                obj.Sellers = sellers;
                return View(obj);
            }
            await _salesRecordService.InsertAsync(obj.SalesRecord);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var obj = await _salesRecordService.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _salesRecordService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var obj = await _salesRecordService.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            var obj = await _salesRecordService.FindByIdAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            List<Seller> sellers = await _sellerService.FindAllAsync();
            SalesRecordFormViewModel viewModel = new SalesRecordFormViewModel
            {
                SalesRecord = obj,
                Sellers = sellers
            };
            Dictionary<string, int> status = new Dictionary<string, int>()
            {
                {"Pending", 0 },
                {"Billed", 1 },
                {"Canceled", 2 }
            };
            ViewBag.Status = new SelectList(status, "Value", "Key");
            ViewBag.Date = viewModel.SalesRecord.Date;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SalesRecordFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var sellers = await _sellerService.FindAllAsync();
                viewModel.Sellers = sellers;
                return View(viewModel);
            }

            if (id != viewModel.SalesRecord.Id)
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            try
            {
                await _salesRecordService.UptadeAsync(viewModel.SalesRecord);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }
        public IActionResult SimpleSearch()
        {
            return View();
        }
        public IActionResult GroupingSearch()
        {
            return View();
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
