using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    public static class AI
    {
        public static Random Randomizer { get; } = new Random();

        public static byte GetNum(int size)
        {
            int result = Randomizer.Next(1, (size * size));

            return (byte)result;
        }

        public static Direction GetDirection()
        { 
            Direction dir = new Direction();

            int result = Randomizer.Next((int)(Direction.North), (int)(Direction.East));

            switch ((Direction)result)
            {
                case Direction.None:
                    break;
                case Direction.North:
                    dir = Direction.North;
                    break;
                case Direction.South:
                    dir = Direction.South;
                    break;
                case Direction.West:
                    dir = Direction.West;
                    break;
                case Direction.East:
                    dir = Direction.East;
                    break;
                default:
                    break;
            }

            return dir;
        }
    }
}
