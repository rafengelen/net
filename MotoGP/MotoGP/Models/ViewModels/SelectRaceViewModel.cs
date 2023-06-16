using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModels
{
    public class SelectRaceViewModel
    {
        public int raceID;
        public Race Race { get; set; }
        public SelectList Races { get; set; }

    }
}
