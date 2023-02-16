namespace Tabu.ViewModels
{
    public class Utilities
    {
        public bool IsDual(uint integer)
        {
            if (integer % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
