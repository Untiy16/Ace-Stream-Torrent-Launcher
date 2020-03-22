namespace Ace_Stream_File_Launcher
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dashedLabel1 = new Ace_Stream_File_Launcher.DashedLabel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(17, 27);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(249, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // dashedLabel1
            // 
            this.dashedLabel1.AllowDrop = true;
            this.dashedLabel1.AutoSize = true;
            this.dashedLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(220)))), ((int)(((byte)(225)))));
            this.dashedLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashedLabel1.Font = new System.Drawing.Font("Comic Sans MS", 25.875F);
            this.dashedLabel1.Image = ((System.Drawing.Image)(resources.GetObject("dashedLabel1.Image")));
            this.dashedLabel1.Location = new System.Drawing.Point(51, 9);
            this.dashedLabel1.Name = "dashedLabel1";
            this.dashedLabel1.Size = new System.Drawing.Size(322, 245);
            this.dashedLabel1.TabIndex = 2;
            this.dashedLabel1.Text = "          \r\n\r\n\r\n\r\n                              ";
            this.dashedLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dashedLabel1.Click += new System.EventHandler(this.dashedLabel1_Click);
            this.dashedLabel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.dashedLabel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 266);
            this.Controls.Add(this.dashedLabel1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(426, 305);
            this.Name = "Form1";
            this.Opacity = 0D;
            this.Text = "Ace Stream File Launcher";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private DashedLabel dashedLabel1;
    }
}

