using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    public class BL
    {
        private byte[,] _numbers;
        private byte[,] _sortedNumbers;
        private int _size;
        private Position _empty;
        private SwapProcessDelegate _numsSwapped;


        public BL(int n)
        {
            _empty = new Position();

            _size = n;

            _numbers = new byte[_size, _size];

            InitRandomArray();

            _sortedNumbers = new byte[_size, _size];
                       
            InitSortedArray();

            //FillSortedArray();
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public Position Empty
        {
            get
            {
                return _empty;
            }
        }

        private void InitRandomArray()
        {
            byte current;

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    do
                    {
                        if (i == _size - 1 && j == _size - 1)
                        {
                            current = 0;
                            break;
                        }

                        //current = GetNum();
                        current = AI.GetNum(_size);
                    }
                    while (Exists(current));

                    _numbers[i, j] = current;

                    if (current == 0)
                    {
                        _empty.X = j;
                        _empty.Y = i;
                    }
                }
            }
        }

        private void InitSortedArray()
        {
            byte current = 1;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (y == _size - 1 && x == _size - 1)
                    {
                        _sortedNumbers[y, x] = 0;

                        _empty.X = x;
                        _empty.Y = y;
                    }
                    else
                    {
                        _sortedNumbers[y, x] = current;
                        current++;
                    }
                }
            }
        }

        private void FillSortedArray()
        {
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    _numbers[y, x] = _sortedNumbers[y, x];
                }
            }
        }

        public string this[int row, int column]
        {
            get
            {
                return _numbers[row, column].ToString();
            }
        }

        private byte GetNum()
        {
            Random random = new Random();

            int result = random.Next(1, (_size * _size));

            return (byte)result;
        }

        private bool Exists(byte current)
        {
            bool exists = false;

            foreach (byte b in _numbers)
            {
                if (b == current)
                {
                    exists = true;
                    break;
                }
            }
        
            //for (int i = 0; i < _size; i++)
            //{
            //    for (int j = 0; j < _size; j++)
            //    {
            //        if (_numbers[i, j] == current)
            //        {
            //            exists = true;
            //            break;
            //        }
            //    }
            //}

            return exists;
        }

        public void Swap(Position clickedBtnPos)
        {
            if (CanMove(clickedBtnPos))
            {
                SwapNums(clickedBtnPos);
            }
        }

        public void Swap(byte clickedNum)
        {
            Position clickedPos = GetPosition(clickedNum);

            if (CanMove(clickedPos))
            {
                SwapNums(clickedPos);
            }
        }

        private void SwapNums(Position clickedPos)
        {
            byte temp = _numbers[clickedPos.Y, clickedPos.X];

            _numbers[clickedPos.Y, clickedPos.X] = _numbers[_empty.Y, _empty.X];

            _numbers[_empty.Y, _empty.X] = temp;
                        
            SwapPos(clickedPos);
        }

        private void SwapPos(Position clickedPos)
        {
            if (_numsSwapped != null)
            {
                _numsSwapped(this, new SwapNumsEventArgs(clickedPos, _empty));
            }

            Position tempPos = clickedPos;

            clickedPos = _empty;

            _empty = tempPos;

            //if (_numsSwapped != null)
            //{
            //    _numsSwapped(this, new SwapNumsEventArgs(clickedPos, _empty));
            //}
        }

        private Position GetPosition(byte clickedNum)
        {
            Position pos = new Position();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_numbers[i, j] == clickedNum)
                    {
                        pos.X = j;
                        pos.Y = i;

                        break;
                    }
                }
            }

            return pos;
        }

        private bool CanMove(Position pos)
        {
            return ((pos.North == _empty)
                   || (pos.South == _empty)
                   || (pos.West == _empty)
                   || (pos.East == _empty));
        }

        public void Shuffle()
        {
            Direction dir;

            Position destPos = new Position();

            int count = 1;

            do
            {
                dir = AI.GetDirection();

                switch (dir)
                {
                    case Direction.North:
                        destPos = _empty.North;
                        break;
                    case Direction.South:
                        destPos = _empty.South;
                        break;
                    case Direction.West:
                        destPos = _empty.West;
                        break;
                    case Direction.East:
                        destPos = _empty.East;
                        break;
                    default:
                        break;
                }

                if (InRange(destPos))
                {
                    SwapNums(destPos);
                }

                count++;
            }
            while (count <= 10);
        }

        private bool InRange(Position pos)
        {
            int maxX = _size;
            int maxY = _size;   

            return ((pos.X >= 0 && pos.X < maxX) && (pos.Y >= 0 && pos.Y < maxY));
        }

        public bool IsWin()
        {
            int maxPos = _size - 1;
            byte prev = 0;

            if (_numbers[maxPos, maxPos] == 0)
            {
                do
                {
                    for (int y = 0; y < _size; y++)
                    {
                        for (int x = 0; x < _size; x++)
                        {
                            byte current = _numbers[y, x];

                            if (prev == (_size * _size) - 1 && current == 0)
                            {
                                break;
                            }
                            else
                            {
                                if (current > prev)
                                {
                                    prev = current;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }

                    return true;
                }
                while (_numbers[maxPos, maxPos - 1] == ((_size * _size) - 1));
            }

            return false;
        }

        public bool IsWinCombination()
        {
            int maxPos = _size - 1;

            if (_numbers[maxPos, maxPos] == 0)
            {
                for (int y = 0; y < _size; y++)
                {
                    for (int x = 0; x < _size; x++)
                    {
                        if (_numbers[y, x] == _sortedNumbers[y, x])
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                return true;    
            }

            return false;
        }

        public event SwapProcessDelegate NumsSwapped
        {
            add 
            {
                _numsSwapped += value;
            }
            remove
            {
                _numsSwapped -= value;
            }
        }  
    }
}
