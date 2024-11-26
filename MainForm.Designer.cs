namespace Fifteen
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrp1 = new StatusStrip();
            lblSwapsNum = new Label();
            SuspendLayout();
            // 
            // statusStrp1
            // 
            statusStrp1.ImageScalingSize = new Size(24, 24);
            statusStrp1.Location = new Point(0, 557);
            statusStrp1.Name = "statusStrp1";
            statusStrp1.Size = new Size(381, 22);
            statusStrp1.TabIndex = 0;
            statusStrp1.Text = "Stats";
            // 
            // lblSwapsNum
            // 
            lblSwapsNum.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lblSwapsNum.AutoSize = true;
            lblSwapsNum.BackColor = SystemColors.Control;
            lblSwapsNum.FlatStyle = FlatStyle.Popup;
            lblSwapsNum.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSwapsNum.Location = new Point(133, 529);
            lblSwapsNum.Name = "lblSwapsNum";
            lblSwapsNum.Size = new Size(120, 23);
            lblSwapsNum.TabIndex = 1;
            lblSwapsNum.Text = "Swaps:    ";
            lblSwapsNum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 579);
            Controls.Add(lblSwapsNum);
            Controls.Add(statusStrp1);
            Name = "MainForm";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "MainForm";
            Load += frmMain_Load;
            Click += btnShuffleBtn_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrp1;
        private Label lblSwapsNum;
    }
}
