using Microsoft.AspNetCore.Mvc;
using OrderPlanner.Models;
using OrderPlanner.Services;
using System.Diagnostics;

namespace OrderPlanner.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ILogger<OrderController> logger,
            IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ordersList = await _orderRepository.GetOrdersAsync();
            if (ordersList == null)
            {
                return View(new List<Order>());
            }

            return View(ordersList);
        }
        public async Task<IActionResult> ReadOrder(Guid id)
        {
            var order = await _orderRepository.GetOrderAsync(id);
            if (order == null)
            {
                _logger.LogError($"Order with id {id} wasn't found.");

                return NotFound();
            }

            return View(order);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            _orderRepository.AddOrder(order);
            await _orderRepository.SaveChangesAsync();
            _logger.LogInformation($"Order with id {order.Id} was created.");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var order = await _orderRepository.GetOrderAsync(id);

            if (order == null)
            {
                _logger.LogError($"Order with id {id} coud not be deleted.");

                return NotFound();
            }

            _orderRepository.DeleteOrder(order);
            await _orderRepository.SaveChangesAsync();
            _logger.LogInformation($"Order with id {id} was deleted.");

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
