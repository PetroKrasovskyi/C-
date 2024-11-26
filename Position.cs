using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    public struct Position
    {
        private int _x;
        private int _y;

        #region CTOR

        public Position(int column, int row)
        {
            _x = column;
            _y = row;
        }

        #endregion

        #region PROPS

        public int X 
        {   
            get 
            { 
                return _x; 
            } 
            set 
            { 
                _x = value; 
            } 
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public Position North
        {
            get
            { 
                return new Position(_x, _y - 1);    
            }
        }

        public Position South
        {
            get
            {
                return new Position(_x, _y + 1);
            }
        }

        public Position West
        {
            get
            {
                return new Position(_x - 1, _y);
            }
        }

        public Position East
        {
            get
            {
                return new Position(_x + 1, _y);
            }
        }

        #endregion

        #region OPERATOR OVERLOADING

        public static bool operator == (Position pos1, Position pos2)
        {
            return pos1.X == pos2.X && pos1.Y == pos2.Y;
        }

        public static bool operator != (Position pos1, Position pos2)
        {
            return pos1.X != pos2.X || pos1.Y != pos2.Y;
        }

        #endregion
    }
}
