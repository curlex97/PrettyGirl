namespace PrettyGirl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлПочеркаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьФайлПочеркаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерХолстаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаШрифтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьКонфигурациюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предпросмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настроитьБуквуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.синтезаторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveотображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отобразитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.постройкаПочеркаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.построитьНовыйПочеркToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(352, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 475);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.редактированиеToolStripMenuItem,
            this.синтезаторToolStripMenuItem,
            this.постройкаПочеркаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.открытьФайлПочеркаToolStripMenuItem,
            this.сохранитьФайлПочеркаToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить...";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // открытьФайлПочеркаToolStripMenuItem
            // 
            this.открытьФайлПочеркаToolStripMenuItem.Name = "открытьФайлПочеркаToolStripMenuItem";
            this.открытьФайлПочеркаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.открытьФайлПочеркаToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.открытьФайлПочеркаToolStripMenuItem.Text = "Открыть файл почерка";
            this.открытьФайлПочеркаToolStripMenuItem.Click += new System.EventHandler(this.открытьФайлПочеркаToolStripMenuItem_Click);
            // 
            // сохранитьФайлПочеркаToolStripMenuItem
            // 
            this.сохранитьФайлПочеркаToolStripMenuItem.Name = "сохранитьФайлПочеркаToolStripMenuItem";
            this.сохранитьФайлПочеркаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.сохранитьФайлПочеркаToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.сохранитьФайлПочеркаToolStripMenuItem.Text = "Сохранить файл почерка";
            this.сохранитьФайлПочеркаToolStripMenuItem.Click += new System.EventHandler(this.сохранитьФайлПочеркаToolStripMenuItem_Click);
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размерХолстаToolStripMenuItem,
            this.настройкаШрифтаToolStripMenuItem,
            this.обновитьКонфигурациюToolStripMenuItem,
            this.предпросмотрToolStripMenuItem,
            this.настроитьБуквуToolStripMenuItem});
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.редактированиеToolStripMenuItem.Text = "Редактирование";
            // 
            // размерХолстаToolStripMenuItem
            // 
            this.размерХолстаToolStripMenuItem.Name = "размерХолстаToolStripMenuItem";
            this.размерХолстаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.размерХолстаToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.размерХолстаToolStripMenuItem.Text = "Размер холста...";
            this.размерХолстаToolStripMenuItem.Click += new System.EventHandler(this.размерХолстаToolStripMenuItem_Click);
            // 
            // настройкаШрифтаToolStripMenuItem
            // 
            this.настройкаШрифтаToolStripMenuItem.Name = "настройкаШрифтаToolStripMenuItem";
            this.настройкаШрифтаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.настройкаШрифтаToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.настройкаШрифтаToolStripMenuItem.Text = "Настройка почерка...";
            this.настройкаШрифтаToolStripMenuItem.Click += new System.EventHandler(this.настройкаШрифтаToolStripMenuItem_Click);
            // 
            // обновитьКонфигурациюToolStripMenuItem
            // 
            this.обновитьКонфигурациюToolStripMenuItem.Name = "обновитьКонфигурациюToolStripMenuItem";
            this.обновитьКонфигурациюToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.обновитьКонфигурациюToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.обновитьКонфигурациюToolStripMenuItem.Text = "Обновить конфигурацию";
            this.обновитьКонфигурациюToolStripMenuItem.Click += new System.EventHandler(this.обновитьКонфигурациюToolStripMenuItem_Click);
            // 
            // предпросмотрToolStripMenuItem
            // 
            this.предпросмотрToolStripMenuItem.Name = "предпросмотрToolStripMenuItem";
            this.предпросмотрToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.предпросмотрToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.предпросмотрToolStripMenuItem.Text = "Предпросмотр...";
            this.предпросмотрToolStripMenuItem.Click += new System.EventHandler(this.предпросмотрToolStripMenuItem_Click);
            // 
            // настроитьБуквуToolStripMenuItem
            // 
            this.настроитьБуквуToolStripMenuItem.Name = "настроитьБуквуToolStripMenuItem";
            this.настроитьБуквуToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.настроитьБуквуToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.настроитьБуквуToolStripMenuItem.Text = "Настроить букву";
            this.настроитьБуквуToolStripMenuItem.Click += new System.EventHandler(this.настроитьБуквуToolStripMenuItem_Click);
            // 
            // синтезаторToolStripMenuItem
            // 
            this.синтезаторToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liveотображениеToolStripMenuItem,
            this.отобразитьToolStripMenuItem});
            this.синтезаторToolStripMenuItem.Name = "синтезаторToolStripMenuItem";
            this.синтезаторToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.синтезаторToolStripMenuItem.Text = "Генератор";
            // 
            // liveотображениеToolStripMenuItem
            // 
            this.liveотображениеToolStripMenuItem.Name = "liveотображениеToolStripMenuItem";
            this.liveотображениеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.liveотображениеToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.liveотображениеToolStripMenuItem.Text = "Отображение почерка";
            this.liveотображениеToolStripMenuItem.Click += new System.EventHandler(this.liveотображениеToolStripMenuItem_Click);
            // 
            // отобразитьToolStripMenuItem
            // 
            this.отобразитьToolStripMenuItem.Name = "отобразитьToolStripMenuItem";
            this.отобразитьToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.отобразитьToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.отобразитьToolStripMenuItem.Text = "Отобразить";
            this.отобразитьToolStripMenuItem.Click += new System.EventHandler(this.отобразитьToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(334, 475);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 508);
            this.progressBar1.Minimum = 100;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(632, 19);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Value = 100;
            this.progressBar1.SizeChanged += new System.EventHandler(this.progressBar1_SizeChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(650, 511);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // постройкаПочеркаToolStripMenuItem
            // 
            this.постройкаПочеркаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.построитьНовыйПочеркToolStripMenuItem});
            this.постройкаПочеркаToolStripMenuItem.Name = "постройкаПочеркаToolStripMenuItem";
            this.постройкаПочеркаToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.постройкаПочеркаToolStripMenuItem.Text = "Постройка почерка";
            // 
            // построитьНовыйПочеркToolStripMenuItem
            // 
            this.построитьНовыйПочеркToolStripMenuItem.Name = "построитьНовыйПочеркToolStripMenuItem";
            this.построитьНовыйПочеркToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.I)));
            this.построитьНовыйПочеркToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.построитьНовыйПочеркToolStripMenuItem.Text = "Построить новый почерк...";
            this.построитьНовыйПочеркToolStripMenuItem.Click += new System.EventHandler(this.построитьНовыйПочеркToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 536);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Красивая девочка";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem синтезаторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liveотображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отобразитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерХолстаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкаШрифтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьКонфигурациюToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem предпросмотрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлПочеркаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьФайлПочеркаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настроитьБуквуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem постройкаПочеркаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem построитьНовыйПочеркToolStripMenuItem;
    }
}

