using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using webLaptopTest.Data.Services;
using webLaptopTest.Data.Static;
using webLaptopTest.Models;

namespace webLaptopTest.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ItemController : Controller
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllItem = await _service.GetAllAsync(n => n.Manufacturer, n => n.Category);
            return View(AllItem);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var AllItem = await _service.GetAllAsync(n => n.Category, n => n.Manufacturer);
            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allItem.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                //var filteredResultNewer = AllItem.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                //var filteredResultNewerer = AllItem.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                var filteredResultNewererer = AllItem.Where(n => n.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)|| n.Description.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filteredResultNewererer);
            }
            return View("Index", AllItem);
        }

        //Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int Id)
        {
            var ItemDetail = await _service.GetItemByIdAsync(Id);
            return View(ItemDetail);
        }

        //Create
        public async Task<IActionResult> Create()
        {
            var ItemDropdownsData = await _service.GetNewItemDropdownsValues();
            ViewBag.Category = new SelectList(ItemDropdownsData.Category, "Id", "Name");
            ViewBag.Manufacturer = new SelectList(ItemDropdownsData.Manufacturer, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewItemVM Item)
        {
            if (!ModelState.IsValid)
            {
                var ItemDropdownsData = await _service.GetNewItemDropdownsValues();
                ViewBag.Category = new SelectList(ItemDropdownsData.Category, "Id", "Name");
                ViewBag.Manufacturer = new SelectList(ItemDropdownsData.Manufacturer, "Id", "Name");
                return View(Item);
            }
            await _service.AddNewItemAsync(Item);
            return RedirectToAction(nameof(Index));
        }


        //Edit
        public async Task<IActionResult> Edit(int Id)
        {
            var item = await _service.GetItemByIdAsync(Id);
            if (item == null) return View("NotFound");

            var response = new NewItemVM()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Stock = item.Stock,
                imgUrl = item.imgUrl,
                imgUrl2 = item.imgUrl2,
                CategoryId = item.CategoryId,
                ManufacturerId = item.ManufacturerId,
            };

            var ItemDropdownsData = await _service.GetNewItemDropdownsValues();
            ViewBag.Category = new SelectList(ItemDropdownsData.Category, "Id", "Name");
            ViewBag.Manufacturer = new SelectList(ItemDropdownsData.Manufacturer, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, NewItemVM Item)
        {
            if (Id != Item.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var ItemDropdownsData = await _service.GetNewItemDropdownsValues();
                ViewBag.Category = new SelectList(ItemDropdownsData.Category, "Id", "Name");
                ViewBag.Manufacturer = new SelectList(ItemDropdownsData.Manufacturer, "Id", "Name");
                return View(Item);
            }
            await _service.UpdateItemAsync(Item);
            return RedirectToAction(nameof(Index));
        }

        //Delete
        public async Task<IActionResult> Delete(int Id)
        {
            var item = await _service.GetByIdAsync(Id);
            if (item == null) return View("NotFound");
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var item = await _service.GetByIdAsync(Id);
            if (item == null) return View("NotFound");

            await _service.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}