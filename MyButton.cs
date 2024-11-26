using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Fifteen
{
    public class MyButton : Button
    {
        private const int STEP = 10;
        private const int STEP_COUNT = (MainForm.BTN_WIDTH + MainForm.OFFSET) / STEP;
             
        public void ChangePos(Point newPos)
        {
            Direction newDir = GetDirection(newPos);

            ChangeCoords(newDir);
        }

        private void ChangeCoords(Direction dir)
        {
            switch (dir)
            {
                case Direction.None:
                    break;
                case Direction.North:
                    //'-'
                    ChangeTop(-STEP);
                    break;
                case Direction.South:
                    //'+'
                    ChangeTop(STEP);
                    break;
                case Direction.West:
                    //'-'
                    ChangeLeft(-STEP);
                    break;
                case Direction.East:
                    //'+'
                    ChangeLeft(STEP);
                    break;
                default:
                    break;
            }
        }

        private void ChangeTop(int delta)
        {
            for (int i = 0; i < STEP_COUNT; i++)
            {
                Top += delta;
                Parent.Refresh();
            }
        }

        private void ChangeLeft(int delta)
        {
            for (int i = 0; i < STEP_COUNT; i++)
            {
                Left += delta;
                Parent.Refresh();
            }
        }

        public Direction GetDirection(Point newPos)
        {
            Direction dir = Direction.None;

            if (Top == newPos.Y)
            {
                if (Left < newPos.X)
                {
                    dir = Direction.East;
                }
                else 
                {
                    dir = Direction.West;
                }
            }
            if (Left == newPos.X)
            {
                if (Top > newPos.Y)
                { 
                    dir = Direction.North; 
                }
                else
                {
                    dir = Direction.South;
                }
            }

            return dir;
        }
    }
}
