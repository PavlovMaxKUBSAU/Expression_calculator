
namespace Exp_Calculator
{
    partial class Form1
    {
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
            this.Calc_button = new System.Windows.Forms.Button();
            this.X_label = new System.Windows.Forms.Label();
            this.exp_label = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.reply_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Calc_button
            // 
            this.Calc_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Calc_button.Location = new System.Drawing.Point(230, 143);
            this.Calc_button.Name = "Calc_button";
            this.Calc_button.Size = new System.Drawing.Size(160, 32);
            this.Calc_button.TabIndex = 0;
            this.Calc_button.Text = "Вычислить";
            this.Calc_button.UseVisualStyleBackColor = true;
            this.Calc_button.Click += new System.EventHandler(this.Calc_button_Click);
            // 
            // X_label
            // 
            this.X_label.AutoSize = true;
            this.X_label.Font = new System.Drawing.Font("Footlight MT Light", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(209)));
            this.X_label.Location = new System.Drawing.Point(30, 49);
            this.X_label.Name = "X_label";
            this.X_label.Size = new System.Drawing.Size(58, 15);
            this.X_label.TabIndex = 1;
            this.X_label.Text = "Число X:";
            // 
            // exp_label
            // 
            this.exp_label.AutoSize = true;
            this.exp_label.Font = new System.Drawing.Font("Footlight MT Light", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(209)));
            this.exp_label.Location = new System.Drawing.Point(12, 100);
            this.exp_label.Name = "exp_label";
            this.exp_label.Size = new System.Drawing.Size(79, 15);
            this.exp_label.TabIndex = 2;
            this.exp_label.Text = "Выражение:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.richTextBox1.Location = new System.Drawing.Point(94, 47);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(160, 25);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.richTextBox2.Location = new System.Drawing.Point(94, 96);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(500, 25);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox3.Enabled = false;
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.richTextBox3.Location = new System.Drawing.Point(94, 208);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(160, 25);
            this.richTextBox3.TabIndex = 7;
            this.richTextBox3.Text = "";
            // 
            // reply_label
            // 
            this.reply_label.AutoSize = true;
            this.reply_label.Font = new System.Drawing.Font("Footlight MT Light", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(209)));
            this.reply_label.Location = new System.Drawing.Point(45, 211);
            this.reply_label.Name = "reply_label";
            this.reply_label.Size = new System.Drawing.Size(43, 15);
            this.reply_label.TabIndex = 6;
            this.reply_label.Text = "Ответ:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 268);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.reply_label);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.exp_label);
            this.Controls.Add(this.X_label);
            this.Controls.Add(this.Calc_button);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Калькулятор выражений";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Calc_button;
        private System.Windows.Forms.Label X_label;
        private System.Windows.Forms.Label exp_label;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label reply_label;
    }
}

