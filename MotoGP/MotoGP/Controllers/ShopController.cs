using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;

namespace MotoGP.Controllers
{
    public class ShopController : Controller
    {
        private readonly GPContext _context;
        public ShopController(GPContext context)
        {
            _context = context;
        }
        public IActionResult OrderTicket()
        {
            ViewData["BannerNr"] = 3;
            ViewData["Title"] = "Order Tickets";

            var countries = new SelectList(_context.Countries.OrderBy(c => c.Name), "CountryID", "Name");
            ViewData["Countries"] = countries;

            var races = _context.Races.OrderBy(r => r.Name).ToList();
            ViewData["Races"] = races;
            return View();
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OrderTicket([Bind("Name,Email,Address,CountryID,RaceID,Number")] Ticket ticket)
        {
            ticket.OrderDate = DateTime.Now;
            //ticket.Number = 1;
            //ticket.CountryID = 1;
            //ticket.RaceID= 1;
            ticket.Paid = false;
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("ConfirmOrder", new { id = ticket.TicketID });

            }
            return View(ticket);
        }
        public IActionResult ConfirmOrder(int id)
        {
            Ticket ticket = _context.Tickets.Include(t => t.Race).SingleOrDefault(t => t.TicketID == id);
            return View(ticket);

        }
        //GET
        public IActionResult ListTickets(int raceID = 0)
        {
            var listTicketsViewModel = new ListTicketsViewModel();
            listTicketsViewModel.RacesList = new SelectList(_context.Races.OrderBy(r => r.Name), "RaceID", "Name");

            if (raceID != 0)
            {
                listTicketsViewModel.Tickets = _context.Tickets
                    .OrderByDescending(t => t.OrderDate)
                    .Include(t => t.Race)
                    .Where(t => t.RaceID == raceID)
                    .ToList();
            }
            else
            {
                listTicketsViewModel.Tickets = _context.Tickets
                    .OrderByDescending(t => t.OrderDate)
                    .Include(t => t.Race)
                    .ToList();
            }


            return View(listTicketsViewModel);
        }

        public IActionResult EditTicket(int id)
        {
            var ticket = _context.Tickets.Include(t => t.Country).Include(t => t.Race).SingleOrDefault(t => t.TicketID == id);
            return View(ticket);
        }
        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTicket(int id, [Bind("TicketID,Paid")] Ticket ticket)
        {

            
                try
                {
                    _context.Tickets.Attach(ticket);
                    _context.Entry(ticket).Property(t => t.Paid).IsModified = true;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException) { throw; }

                return RedirectToAction("ListTickets");
      
           
            
            
        }
        
    }

}
