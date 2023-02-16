namespace Tabu.ViewModels
{
    public class TeamViewModel
    {
        public string TeamName { get; set; }
        public int TotalPoints { get; set; } = 0;
        public int CurrentPoints { get; set; } = 0;

        public List<String> log = new List<String>();
        public void CurrentReset()
        {
            CurrentPoints = 0;
            log.Clear();
        }
        public void FullReset()
        {
            CurrentPoints = 0;
            TotalPoints = 0;
            log.Clear();
        }
        public void ApplyRoundPoints()
        {
            TotalPoints = TotalPoints + CurrentPoints;

        }
    }
}
