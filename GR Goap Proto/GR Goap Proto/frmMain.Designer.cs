namespace GR_Goap_Proto
{
    partial class frmMain
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
            btnRun = new Button();
            grpOutput = new GroupBox();
            lblOutput = new Label();
            lstChar = new ListBox();
            lstGoals = new ListBox();
            label1 = new Label();
            hScrollBar1 = new HScrollBar();
            lstPlanner = new ListBox();
            grpOutput.SuspendLayout();
            SuspendLayout();
            // 
            // btnRun
            // 
            btnRun.Location = new Point(501, 72);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(94, 29);
            btnRun.TabIndex = 0;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // grpOutput
            // 
            grpOutput.Controls.Add(lblOutput);
            grpOutput.Location = new Point(538, 145);
            grpOutput.Name = "grpOutput";
            grpOutput.Size = new Size(448, 459);
            grpOutput.TabIndex = 2;
            grpOutput.TabStop = false;
            grpOutput.Text = "Output";
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new Point(17, 30);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(50, 20);
            lblOutput.TabIndex = 0;
            lblOutput.Text = "label1";
            // 
            // lstChar
            // 
            lstChar.FormattingEnabled = true;
            lstChar.Location = new Point(34, 58);
            lstChar.Name = "lstChar";
            lstChar.Size = new Size(209, 84);
            lstChar.TabIndex = 3;
            // 
            // lstGoals
            // 
            lstGoals.FormattingEnabled = true;
            lstGoals.Location = new Point(274, 58);
            lstGoals.Name = "lstGoals";
            lstGoals.Size = new Size(164, 84);
            lstGoals.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 35);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 5;
            label1.Text = "Characters";
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(67, 253);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(357, 26);
            hScrollBar1.TabIndex = 6;
            // 
            // lstPlanner
            // 
            lstPlanner.FormattingEnabled = true;
            lstPlanner.Location = new Point(698, 64);
            lstPlanner.Name = "lstPlanner";
            lstPlanner.Size = new Size(133, 64);
            lstPlanner.TabIndex = 7;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 657);
            Controls.Add(lstPlanner);
            Controls.Add(hScrollBar1);
            Controls.Add(label1);
            Controls.Add(lstGoals);
            Controls.Add(lstChar);
            Controls.Add(grpOutput);
            Controls.Add(btnRun);
            Name = "frmMain";
            Text = "Form1";
            grpOutput.ResumeLayout(false);
            grpOutput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRun;
        private GroupBox grpOutput;
        private Label lblOutput;
        private ListBox lstChar;
        private ListBox lstGoals;
        private Label label1;
        private HScrollBar hScrollBar1;
        private ListBox lstPlanner;
    }
}
