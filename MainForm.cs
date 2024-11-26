namespace Fifteen
{
    public partial class MainForm : Form
    {
        public const int BTN_WIDTH = 97;
        public const int OFFSET = 3;

        private BL _bl;
        private Stats _stats;
        private MyButton[,] _gameField;
        private int _fieldSize;

        public MainForm(BL bl, Stats stats)
        {
            InitializeComponent();
            _bl = bl;
            _stats = stats;
            _fieldSize = _bl.Size;
            _gameField = new MyButton[_fieldSize, _fieldSize];
            //_bl.NumsSwapped += SwappedNumsHandler;
            _bl.NumsSwapped += SwappedButtonsHandler;
        }

        public int FieldSize
        { 
            get 
            { 
                return _fieldSize; 
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetFrmSize();

            CreateGameBtn();

            CreateShuffleBtn();
        }

        private void SetFrmSize()
        {
            int frmDefaultSize = _fieldSize * BTN_WIDTH + (_fieldSize + 1) * OFFSET;
            int frmBufferHeight = BTN_WIDTH / 2 + 60;
            int frmWidth = frmDefaultSize;
            int frmHeight = frmDefaultSize + frmBufferHeight;

            ClientSize = new Size(frmWidth, frmHeight);
        }

        private void CreateGameBtn()
        {
            int btnWidth = BTN_WIDTH;
            int btnHeight = btnWidth;
            int offset = OFFSET;

            for (int x = 0; x < _bl.Size; x++)
            {
                for (int y = 0; y < _bl.Size; y++)
                {
                    int coordX = offset + x * offset + x * btnWidth;
                    int coordY = offset + y * offset + y * btnHeight;

                    MyButton btnGameBtn = new MyButton();

                    btnGameBtn.Name = "btnGameBtn";
                    btnGameBtn.Size = new System.Drawing.Size(btnWidth, btnHeight);
                    btnGameBtn.Location = new System.Drawing.Point(coordX, coordY);
                    btnGameBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                    btnGameBtn.Text = _bl[y, x];
                    btnGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

                    if (_bl[y, x] == "0")
                    {
                        btnGameBtn.Visible = false;
                    }

                    btnGameBtn.ForeColor = System.Drawing.Color.Black;
                    btnGameBtn.TabIndex = 0;
                    btnGameBtn.UseVisualStyleBackColor = true;

                    this.Controls.Add(btnGameBtn);

                    _gameField[y, x] = btnGameBtn;

                    btnGameBtn.Click += new System.EventHandler(btnGameBtn_Click);
                }
            }
        }

        private void CreateShuffleBtn()
        {
            int btnWidth = BTN_WIDTH * _fieldSize + OFFSET * (_fieldSize - 1);
            int btnHeight = BTN_WIDTH / 2;
            int offset = OFFSET;
            int coordX = offset;
            int coordY = (_fieldSize + 1) * offset + _fieldSize * BTN_WIDTH;

            MyButton btnShuffleBtn = new MyButton();

            btnShuffleBtn.Name = "btnShuffleBtn";
            btnShuffleBtn.Size = new System.Drawing.Size(btnWidth, btnHeight);
            btnShuffleBtn.Location = new System.Drawing.Point(coordX, coordY);
            btnShuffleBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            btnShuffleBtn.Text = "SHUFFLE";
            btnShuffleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnShuffleBtn.ForeColor = System.Drawing.Color.Black;
            btnShuffleBtn.TabIndex = 0;
            btnShuffleBtn.UseVisualStyleBackColor = true;
            this.Controls.Add(btnShuffleBtn);

            btnShuffleBtn.Click += new System.EventHandler(btnShuffleBtn_Click);

            lblSwapsNum.Location = new System.Drawing.Point(coordX, coordY + btnHeight + OFFSET);    
        }

        private void btnGameBtn_Click(object sender, EventArgs e)
        {
            byte clickedNum = byte.MaxValue;

            if (sender is Button)
            {
                Button btn = (Button)sender;

                if (byte.TryParse((btn.Text), out clickedNum))
                {
                    _bl.Swap(clickedNum);
                }
            }
        }

        private void btnShuffleBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;

                if (btn.Text == "SHUFFLE")
                {
                    _bl.Shuffle(); ;
                }
            }
        }

        public void SwappedNumsHandler(object sender, SwapNumsEventArgs args)
        {
            _gameField[args.Source.Y, args.Source.X].Text
                    = _bl[args.Source.Y, args.Source.X];

            _gameField[args.Destination.Y, args.Destination.X].Text
                    = _bl[args.Destination.Y, args.Destination.X];

            this.Refresh();
            System.Threading.Thread.Sleep(500);
        }

        public void SwappedButtonsHandler(object sender, SwapNumsEventArgs args)
        {
            Position clicked = args.Source;
            Position empty = args.Destination;

            MyButton tempBtn = _gameField[clicked.Y, clicked.X];

            Point clickedPoint = _gameField[clicked.Y, clicked.X].Location;
            Point emptyPoint = _gameField[empty.Y, empty.X].Location;

            //EXCHANGE BUTTONS IN ARRAY
            _gameField[clicked.Y, clicked.X] = _gameField[empty.Y, empty.X];
            _gameField[empty.Y, empty.X] = tempBtn;

            //EXCHANGE BUTTONS' LOCATION
            _gameField[clicked.Y, clicked.X].Location = clickedPoint;

            _gameField[empty.Y, empty.X].ChangePos(emptyPoint);

            //SHOW SWAP COUNT
            lblSwapsNum.Text = string.Format("Swaps: {0}", _stats.SwapsStr);

            //CHECK WIN-COMBINATION
            //if (_bl.IsWin())
            //{
            //    MessageBox.Show("YOU WIN");
            //    this.Close();
            //}

            if (_bl.IsWinCombination())
            {
                MessageBox.Show("YOU WIN");
                this.Close();
            }
        }
    }
}
