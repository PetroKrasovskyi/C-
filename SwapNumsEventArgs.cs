using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    public class SwapNumsEventArgs : EventArgs
    {
        //public byte Source {  get; private set; }  
        
        //public byte Destination { get; private set; }   

        public Position Source { get; private set; }

        public Position Destination { get; private set; }    

        //public SwapNumsEventArgs(byte source, byte destination)
        //{
        //    Source = source;
        //    Destination = destination;
        //}

        public SwapNumsEventArgs(Position sourcePos, Position destinationPos)
        { 
            Source = sourcePos;
            Destination = destinationPos;
        }

    }
}
