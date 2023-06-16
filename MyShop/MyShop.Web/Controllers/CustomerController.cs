using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private IUnitOfWork _uow;

        public CustomerController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                var customers = _uow.CustomerRepository.All();
                return View(customers);
            }
            else
            {
                var customers = new[] { _uow.CustomerRepository.Get(id.Value) };
                return View(customers);
            }
        }
    }
}
