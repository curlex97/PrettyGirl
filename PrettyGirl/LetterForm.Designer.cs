namespace PrettyGirl
{
    partial class LetterForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.xTrackBar = new System.Windows.Forms.TrackBar();
            this.yTrackBar = new System.Windows.Forms.TrackBar();
            this.scaleWTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.scaleHTrackBar = new System.Windows.Forms.TrackBar();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.scaleWTextBox = new System.Windows.Forms.TextBox();
            this.scaleHTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleWTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleHTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // xTrackBar
            // 
            this.xTrackBar.Location = new System.Drawing.Point(153, 61);
            this.xTrackBar.Maximum = 70;
            this.xTrackBar.Minimum = -69;
            this.xTrackBar.Name = "xTrackBar";
            this.xTrackBar.Size = new System.Drawing.Size(260, 45);
            this.xTrackBar.TabIndex = 1;
            this.xTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.xTrackBar.ValueChanged += new System.EventHandler(this.xTrackBar_ValueChanged);
            // 
            // yTrackBar
            // 
            this.yTrackBar.Location = new System.Drawing.Point(153, 112);
            this.yTrackBar.Maximum = 70;
            this.yTrackBar.Minimum = -69;
            this.yTrackBar.Name = "yTrackBar";
            this.yTrackBar.Size = new System.Drawing.Size(260, 45);
            this.yTrackBar.TabIndex = 2;
            this.yTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.yTrackBar.ValueChanged += new System.EventHandler(this.yTrackBar_ValueChanged);
            // 
            // scaleWTrackBar
            // 
            this.scaleWTrackBar.Location = new System.Drawing.Point(153, 163);
            this.scaleWTrackBar.Maximum = 200;
            this.scaleWTrackBar.Name = "scaleWTrackBar";
            this.scaleWTrackBar.Size = new System.Drawing.Size(260, 45);
            this.scaleWTrackBar.TabIndex = 3;
            this.scaleWTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scaleWTrackBar.Value = 100;
            this.scaleWTrackBar.ValueChanged += new System.EventHandler(this.scaleWTrackBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Сдвиг по X-координате";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сдвиг по Y-координате";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Масштаб ширины";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Масштаб высоты";
            // 
            // scaleHTrackBar
            // 
            this.scaleHTrackBar.Location = new System.Drawing.Point(153, 214);
            this.scaleHTrackBar.Maximum = 200;
            this.scaleHTrackBar.Name = "scaleHTrackBar";
            this.scaleHTrackBar.Size = new System.Drawing.Size(260, 45);
            this.scaleHTrackBar.TabIndex = 7;
            this.scaleHTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scaleHTrackBar.Value = 100;
            this.scaleHTrackBar.ValueChanged += new System.EventHandler(this.scaleHTrackBar_ValueChanged);
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(419, 61);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(78, 20);
            this.xTextBox.TabIndex = 9;
            this.xTextBox.TextChanged += new System.EventHandler(this.xTextBox_TextChanged);
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(419, 112);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(78, 20);
            this.yTextBox.TabIndex = 10;
            this.yTextBox.TextChanged += new System.EventHandler(this.yTextBox_TextChanged);
            // 
            // scaleWTextBox
            // 
            this.scaleWTextBox.Location = new System.Drawing.Point(419, 163);
            this.scaleWTextBox.Name = "scaleWTextBox";
            this.scaleWTextBox.Size = new System.Drawing.Size(78, 20);
            this.scaleWTextBox.TabIndex = 11;
            this.scaleWTextBox.TextChanged += new System.EventHandler(this.scaleWTextBox_TextChanged);
            // 
            // scaleHTextBox
            // 
            this.scaleHTextBox.Location = new System.Drawing.Point(419, 214);
            this.scaleHTextBox.Name = "scaleHTextBox";
            this.scaleHTextBox.Size = new System.Drawing.Size(78, 20);
            this.scaleHTextBox.TabIndex = 12;
            this.scaleHTextBox.TextChanged += new System.EventHandler(this.scaleHTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 14;
            // 
            // LetterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 312);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.scaleHTextBox);
            this.Controls.Add(this.scaleWTextBox);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scaleHTrackBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scaleWTrackBar);
            this.Controls.Add(this.yTrackBar);
            this.Controls.Add(this.xTrackBar);
            this.Controls.Add(this.button1);
            this.Name = "LetterForm";
            this.Text = "LetterForm";
            ((System.ComponentModel.ISupportInitialize)(this.xTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleWTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleHTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar xTrackBar;
        private System.Windows.Forms.TrackBar yTrackBar;
        private System.Windows.Forms.TrackBar scaleWTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar scaleHTrackBar;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox scaleWTextBox;
        private System.Windows.Forms.TextBox scaleHTextBox;
        private System.Windows.Forms.Label label5;
    }
}