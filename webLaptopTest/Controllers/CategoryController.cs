using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using webLaptopTest.Data.Services;
using webLaptopTest.Data.Static;
using webLaptopTest.Models;

namespace webLaptopTest.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllCategories = await _service.GetAllAsync();
            return View(AllCategories);
        }


        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")]Category category)
        {
            if (!ModelState.IsValid) return View(category);
            await _service.AddAsync(category);
            return RedirectToAction(nameof(Index));
        }

        //Edit
        public async Task<IActionResult> Edit(int Id)
        {
            var category = await _service.GetByIdAsync(Id);
            if (category == null) return View("NotFound");
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, [Bind("Id, Name")] Category category)
        {
            if (!ModelState.IsValid) return View(category);
            if (Id == category.Id)
            {
                await _service.UpdateAsync(Id, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //Delete
        public async Task<IActionResult> Delete(int Id)
        {
            var category = await _service.GetByIdAsync(Id);
            if (category == null) return View("NotFound");
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int Id)
        {
            var category = await _service.GetByIdAsync(Id);
            if (category == null) return View("NotFound");

            await _service.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
