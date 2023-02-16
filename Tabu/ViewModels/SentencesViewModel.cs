namespace Tabu.ViewModels
{
    public class SentenceDataModel
    {
        public string GuessWord { get; set; }
        public string TabuWord1 { get; set; }
        public string TabuWord2 { get; set; }
        public string TabuWord3 { get; set; }
        public string TabuWord4 { get; set; }
        public string TabuWord5 { get; set; }
        public bool IsUsed { get; set; }

        public void Reset()
        {
            IsUsed = false;
        }
    }
}
