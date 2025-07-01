using Microsoft.AspNetCore.Mvc;
using OrderDeliveryApp.Core.Interfaces;
using OrderDeliveryApp.Core.Models;

namespace OrderDeliveryApp.Controllers;

public class OrdersController : Controller
{
	private readonly IOrderService _orderService;

	public OrdersController(IOrderService orderService)
	{
		_orderService = orderService;
	}

	// GET: Orders
	public async Task<IActionResult> Index()
	{
		var orders = await _orderService.GetAllOrdersAsync();
		return View(orders);
	}

	// GET: Orders/Details
	public async Task<IActionResult> Details(Guid id)
	{
		var order = await _orderService.GetOrderByIdAsync(id);
		if (order == null)
		{
			return NotFound();
		}
		return View(order);
	}

	// GET: Orders/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: Orders/Create
	[HttpPost]
	public async Task<IActionResult> Create([Bind("SenderCity,SenderAddress,ReceiverCity,ReceiverAddress,Weight,PickupDate")] Order order)
	{
		if (ModelState.IsValid)
		{
			await _orderService.CreateOrderAsync(order);
			return RedirectToAction(nameof(Details), new { id = order.Id });
		}

		var errors = ModelState.Values.SelectMany(v => v.Errors);
		return View(order);
	}
}
