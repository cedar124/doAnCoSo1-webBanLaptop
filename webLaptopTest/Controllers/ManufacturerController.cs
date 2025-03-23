using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using webLaptopTest.Data.Services;
using webLaptopTest.Data.Static;
using webLaptopTest.Models;

namespace webLaptopTest.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _service;

        public ManufacturerController(IManufacturerService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllManufacturer = await _service.GetAllAsync();
            return View(AllManufacturer);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")]Manufacturer manufacturer)
        {
            if (!ModelState.IsValid) return View(manufacturer);

            await _service.AddAsync(manufacturer);
            return RedirectToAction(nameof(Index));
        }

        //Edit
        public async Task<IActionResult> Edit(int Id)
        {
            var manufacturer = await _service.GetByIdAsync(Id);
            if (manufacturer == null) return View("NotFound");
            return View(manufacturer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, [Bind("Id, Name")] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid) return View(manufacturer);
            if(Id == manufacturer.Id)
            {
                await _service.UpdateAsync(Id, manufacturer);
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        //Delete
        public async Task<IActionResult> Delete(int Id)
        {
            var manufacturer = await _service.GetByIdAsync(Id);
            if (manufacturer == null) return View("NotFound");
            return View(manufacturer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var manufacturer = await _service.GetByIdAsync(Id);
            if (manufacturer == null) return View("NotFound");

            await _service.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
