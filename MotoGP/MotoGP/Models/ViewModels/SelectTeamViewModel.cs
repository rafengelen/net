namespace MotoGP.Models.ViewModels
{
    public class SelectTeamViewModel
    {
        public List<Team> Teams { get; set; }
        public List<Rider>? Riders { get; set; }
        public int teamID;
    }
}
