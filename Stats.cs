using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    public class Stats
    {
        int _swaps = 0;

        private BL _bl;

        public Stats(BL bl)
        {
            _bl = bl;
            _bl.NumsSwapped += SwappedNumsHandler;
        }

        public int Swaps
        {
            get
            {
                return _swaps;   
            }
        }

        public string SwapsStr
        {
            get
            {
                return _swaps.ToString();
            }
        }

        public void SwappedNumsHandler(object sender, SwapNumsEventArgs args)
        { 
            _swaps++;   
        }
    }
}
