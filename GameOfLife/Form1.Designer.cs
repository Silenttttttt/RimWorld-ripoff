namespace rimworldripoff
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SizeNud = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.randomizerButton = new System.Windows.Forms.Button();
            this.RunCheckbox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GridCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DelayNud = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.DensityNud = new System.Windows.Forms.NumericUpDown();
            this.resetbutton = new System.Windows.Forms.Button();
            this.RowButton = new System.Windows.Forms.Button();
            this.SpaceshipButton = new System.Windows.Forms.Button();
            this.GunButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.SizeNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DensityNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // SizeNud
            // 
            this.SizeNud.Location = new System.Drawing.Point(117, 8);
            this.SizeNud.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SizeNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SizeNud.Name = "SizeNud";
            this.SizeNud.Size = new System.Drawing.Size(62, 23);
            this.SizeNud.TabIndex = 1;
            this.SizeNud.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.SizeNud.ValueChanged += new System.EventHandler(this.SizeNud_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Square size (px):";
            // 
            // randomizerButton
            // 
            this.randomizerButton.Location = new System.Drawing.Point(18, 46);
            this.randomizerButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.randomizerButton.Name = "randomizerButton";
            this.randomizerButton.Size = new System.Drawing.Size(96, 27);
            this.randomizerButton.TabIndex = 5;
            this.randomizerButton.Text = "Randomizer";
            this.randomizerButton.UseVisualStyleBackColor = true;
            this.randomizerButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // RunCheckbox
            // 
            this.RunCheckbox.AutoSize = true;
            this.RunCheckbox.Checked = true;
            this.RunCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RunCheckbox.Location = new System.Drawing.Point(568, 12);
            this.RunCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RunCheckbox.Name = "RunCheckbox";
            this.RunCheckbox.Size = new System.Drawing.Size(47, 19);
            this.RunCheckbox.TabIndex = 6;
            this.RunCheckbox.Text = "Run";
            this.RunCheckbox.UseVisualStyleBackColor = true;
            this.RunCheckbox.CheckedChanged += new System.EventHandler(this.RunCheckbox_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.TimerTick);
            // 
            // GridCheckbox
            // 
            this.GridCheckbox.AutoSize = true;
            this.GridCheckbox.Checked = true;
            this.GridCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GridCheckbox.Location = new System.Drawing.Point(509, 10);
            this.GridCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GridCheckbox.Name = "GridCheckbox";
            this.GridCheckbox.Size = new System.Drawing.Size(48, 19);
            this.GridCheckbox.TabIndex = 7;
            this.GridCheckbox.Text = "Grid";
            this.GridCheckbox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Delay (ms):";
            // 
            // DelayNud
            // 
            this.DelayNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DelayNud.Location = new System.Drawing.Point(858, 89);
            this.DelayNud.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DelayNud.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DelayNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DelayNud.Name = "DelayNud";
            this.DelayNud.Size = new System.Drawing.Size(62, 23);
            this.DelayNud.TabIndex = 9;
            this.DelayNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DelayNud.ValueChanged += new System.EventHandler(this.DelayNud_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Density (%):";
            // 
            // DensityNud
            // 
            this.DensityNud.Location = new System.Drawing.Point(416, 8);
            this.DensityNud.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DensityNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DensityNud.Name = "DensityNud";
            this.DensityNud.Size = new System.Drawing.Size(62, 23);
            this.DensityNud.TabIndex = 11;
            this.DensityNud.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.DensityNud.ValueChanged += new System.EventHandler(this.DensityNud_ValueChanged);
            // 
            // resetbutton
            // 
            this.resetbutton.Location = new System.Drawing.Point(18, 80);
            this.resetbutton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(96, 27);
            this.resetbutton.TabIndex = 12;
            this.resetbutton.Text = "Reset";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.GliderButton_Click);
            // 
            // RowButton
            // 
            this.RowButton.Location = new System.Drawing.Point(785, 5);
            this.RowButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RowButton.Name = "RowButton";
            this.RowButton.Size = new System.Drawing.Size(65, 27);
            this.RowButton.TabIndex = 12;
            this.RowButton.Text = "Row";
            this.RowButton.UseVisualStyleBackColor = true;
            this.RowButton.Click += new System.EventHandler(this.RowButton_Click);
            // 
            // SpaceshipButton
            // 
            this.SpaceshipButton.Location = new System.Drawing.Point(701, 5);
            this.SpaceshipButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SpaceshipButton.Name = "SpaceshipButton";
            this.SpaceshipButton.Size = new System.Drawing.Size(77, 27);
            this.SpaceshipButton.TabIndex = 13;
            this.SpaceshipButton.Text = "Spaceship";
            this.SpaceshipButton.UseVisualStyleBackColor = true;
            this.SpaceshipButton.Click += new System.EventHandler(this.SpaceshipButton_Click);
            // 
            // GunButton
            // 
            this.GunButton.Location = new System.Drawing.Point(858, 5);
            this.GunButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GunButton.Name = "GunButton";
            this.GunButton.Size = new System.Drawing.Size(86, 27);
            this.GunButton.TabIndex = 14;
            this.GunButton.Text = "Glider Gun";
            this.GunButton.UseVisualStyleBackColor = true;
            this.GunButton.Click += new System.EventHandler(this.GunButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(714, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(681, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(681, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "0";
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(807, 54);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(168, 52);
            this.trackBar1.TabIndex = 19;
            this.trackBar1.TickFrequency = 2;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(685, 108);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "0";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Items.Add("None");
            this.domainUpDown1.Items.Add("Char");
            this.domainUpDown1.Items.Add("Wall");
            this.domainUpDown1.Items.Add("SandBag");
            this.domainUpDown1.Location = new System.Drawing.Point(316, 80);
            this.domainUpDown1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(140, 23);
            this.domainUpDown1.TabIndex = 22;
            this.domainUpDown1.Text = "domainUpDown1";
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1001, 7);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(229, 122);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(43, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 500);
            this.panel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1575, 786);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GunButton);
            this.Controls.Add(this.SpaceshipButton);
            this.Controls.Add(this.RowButton);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.DensityNud);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DelayNud);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GridCheckbox);
            this.Controls.Add(this.RunCheckbox);
            this.Controls.Add(this.randomizerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SizeNud);
            this.Controls.Add(this.trackBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RimWorld ripoff C#";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SizeNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DensityNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown SizeNud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button randomizerButton;
        private System.Windows.Forms.CheckBox RunCheckbox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox GridCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown DelayNud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown DensityNud;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.Button RowButton;
        private System.Windows.Forms.Button SpaceshipButton;
        private System.Windows.Forms.Button GunButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

