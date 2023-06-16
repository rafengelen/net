using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Models;
using MyShop.Web.Models.ViewModels;
using Newtonsoft.Json;

namespace MyShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private IUnitOfWork _uow;

        public OrderController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Order> orders = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7159");
                HttpResponseMessage response = await client.GetAsync("api/Orders");
                if (response.IsSuccessStatusCode)
                {
                    var ordersResponse = response.Content.ReadAsStringAsync().Result;
                    //deserialize the response from webapi and storing into orders IEnumerable
                    orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(ordersResponse);
                }
                return View(orders);
            }
        }



        public IActionResult Create()
        {
            var viewModel = new ProductsAndCustomersVM
            {
                Products = _uow.ProductRepository.All(),
                Customers = _uow.CustomerRepository.All()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            var allCustomers = _uow.CustomerRepository.All();
            var checkCustomerAlreadyExists = allCustomers.SingleOrDefault(c => c.Name == model.Customer.Name);

            if (checkCustomerAlreadyExists != null)
            {
                checkCustomerAlreadyExists.ShippingAddress = model.Customer.ShippingAddress;
                checkCustomerAlreadyExists.PostalCode = model.Customer.PostalCode;
                checkCustomerAlreadyExists.City = model.Customer.City;
                checkCustomerAlreadyExists.Country = model.Customer.Country;

                _uow.CustomerRepository.Update(checkCustomerAlreadyExists);

                var order = new Order
                {
                    Orderlines = model.LineItems
                    .Select(line => new Orderline { ProductID = line.ProductID, Quantity = line.Quantity })
                    .ToList(),
                    OrderDate = DateTime.Now,
                    Customer = checkCustomerAlreadyExists
                };

                _uow.OrderRepository.Add(order);
                _uow.OrderRepository.SaveChanges();
            } else
            {
                var customer = new Customer
                {
                    Name = model.Customer.Name,
                    ShippingAddress = model.Customer.ShippingAddress,
                    City = model.Customer.City,
                    PostalCode = model.Customer.PostalCode,
                    Country = model.Customer.Country
                };

                var order = new Order
                {
                    Orderlines = model.LineItems
                    .Select(line => new Orderline { ProductID = line.ProductID, Quantity = line.Quantity })
                    .ToList(),
                    OrderDate = DateTime.Now,
                    Customer = customer
                };

                _uow.OrderRepository.Add(order);
                _uow.OrderRepository.SaveChanges();
            }

            return Ok("Order Created");
        }

    }
}
