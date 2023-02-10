using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabu.ViewModels
{
    public class Utilities
    {
        public bool IsDual(uint integer)
        {
            if(integer % 2 == 0)
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
