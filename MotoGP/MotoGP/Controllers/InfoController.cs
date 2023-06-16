using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP.Models;
using System.Xml.Linq;
using MotoGP.Data;
using MotoGP.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MotoGP.Controllers
{
    public class InfoController : Controller
    {
        private readonly GPContext _context;
        public InfoController(GPContext context)
        {
            _context = context;
        }


        public IActionResult ListRaces()
        {
            ViewData["Title"] = "Races";
            ViewData["BannerNr"] = 0;
            var races = _context.Races
                .OrderBy(r => r.Date)
                .ToList<Race>();
            return View(races);
        }

        public IActionResult BuildMap()
        {
            /*Race race1 = new Race();
            Race race2 = new Race();
            Race race3 = new Race();

            race1.RaceID = 1;
            race1.Name = "Assen";
            race1.X =517;
            race1.Y =19;

            race2.RaceID = 2;
            race2.Name = "Losail Circuit";
            race2.X =859;
            race2.Y = 249;

            race3.RaceID = 3;
            race3.Name = "Autódromo Termas de Río Hondo";
            race3.X =194;
            race3.Y =428;

            var races = new List<Race> { race1, race2, race3};

            ViewData["BannerNr"] = 3;
            ViewData["Races"] = races;
            ViewData["Title"] = "Races on map";*/
            var races = _context.Races.ToList<Race>();
            return View(races);
        }
        public IActionResult ShowRace(int id)
        {
            Race race = _context.Races
                .Where(r => r.RaceID == id)
                .FirstOrDefault();
            return View(race);
        }
        public IActionResult ListRiders()
        {
            var riders = _context.Riders.OrderBy(r => r.Number).ToList();
            return View(riders);
        }
        public IActionResult SelectRace(int raceID = 0)
        {
            var selectRaceViewModel = new SelectRaceViewModel();
            if (raceID != 0)
            {
                selectRaceViewModel.Race = _context.Races.SingleOrDefault(r => r.RaceID == raceID);
            }
            /*else
            {
                selectRaceViewModel.Races = new SelectList(
                    _context.Races
                    .OrderBy(m => m.Name)
                    , "RaceID", "Name");
            }*/

            var races = new SelectList(_context.Races.OrderBy(m => m.Name), "RaceID", "Name");
            selectRaceViewModel.Races = races;

            return View(selectRaceViewModel);
        }

        public IActionResult ListTeams()
        {
            var teams = _context.Teams.Include(t => t.Riders).ToList();
            return View(teams);
        }
        public IActionResult ListTeamsRiders(int id = 0)
        {
            var selectTeamViewModel = new SelectTeamViewModel();
            selectTeamViewModel.Teams= _context.Teams.ToList();
            
            if (id != 0)
            {
                selectTeamViewModel.Riders = _context.Riders.Where(r=>r.TeamID== id).ToList();
            }

            return View(selectTeamViewModel);
        }
    }
}
