using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using webLaptopTest.Data;
using webLaptopTest.Data.Cart;
using webLaptopTest.Data.Services;
using webLaptopTest.Data.Static;
using webLaptopTest.Data.ViewModels;

namespace webLaptopTest.Controllers
{
    [Authorize] 
    public class OrdersController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        private readonly ApplicationDbContext _context;
        public OrdersController(IItemService itemService, ShoppingCart shoppingCart, IOrdersService ordersService, ApplicationDbContext context)
        {
            _itemService = itemService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string UserRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(UserId, UserRole);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        public async Task<IActionResult> AddItemToShoppingCart(int Id)
        {
            var item = await _itemService.GetItemByIdAsync(Id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string UserEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await _ordersService.StoreOrderAsync(items, UserId, UserEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
        public async Task<IActionResult> EditStatus(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            var EditStatusVM = new EditOrderStatusVM
            {
                Id = order.Id,
                Status = order.Status,
                AvailableStatuses = OrderStatus.AllStatuses
            };
            return View(EditStatusVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStatus(EditOrderStatusVM model)
        {
            if (!ModelState.IsValid || !OrderStatus.AllStatuses.Contains(model.Status))
            {
                model.AvailableStatuses = OrderStatus.AllStatuses;
                return View(model);
            }
            var order = await _context.Orders.FindAsync(model.Id);
            if (order == null)
                return NotFound();
            order.Status = model.Status;
            _context.Update(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
