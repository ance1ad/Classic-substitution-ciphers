namespace Cipher
{
    partial class Form1
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
            label2 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label8 = new Label();
            textBox3 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            warningLabel = new Label();
            label3 = new Label();
            textBox4 = new TextBox();
            button4 = new Button();
            button3 = new Button();
            textBox5 = new TextBox();
            label4 = new Label();
            label6 = new Label();
            pair = new TextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(385, 290);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(87, 9);
            label5.Name = "label5";
            label5.Size = new Size(105, 24);
            label5.TabIndex = 4;
            label5.Text = "ваш текст:";
            label5.Click += label5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 35);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(263, 393);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(589, 36);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(263, 392);
            textBox2.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(589, 10);
            label8.Name = "label8";
            label8.Size = new Size(276, 24);
            label8.TabIndex = 4;
            label8.Text = "кодирование/декодирование";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(368, 131);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(133, 23);
            textBox3.TabIndex = 6;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(318, 134);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 7;
            label1.Text = "Ключ";
            // 
            // button1
            // 
            button1.Location = new Point(318, 237);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(94, 22);
            button1.TabIndex = 8;
            button1.Text = "Кодировать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(444, 237);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(102, 22);
            button2.TabIndex = 8;
            button2.Text = "Декодировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(304, 45);
            radioButton1.Margin = new Padding(3, 2, 3, 2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(101, 19);
            radioButton1.TabIndex = 9;
            radioButton1.TabStop = true;
            radioButton1.Text = "Шифр Цезаря";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(304, 68);
            radioButton2.Margin = new Padding(3, 2, 3, 2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(171, 19);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "Мультпликативный шифр";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(304, 90);
            radioButton3.Margin = new Padding(3, 2, 3, 2);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(119, 19);
            radioButton3.TabIndex = 9;
            radioButton3.TabStop = true;
            radioButton3.Text = "Шифр Плейфера";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // warningLabel
            // 
            warningLabel.AutoSize = true;
            warningLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            warningLabel.Location = new Point(278, 210);
            warningLabel.Name = "warningLabel";
            warningLabel.Size = new Size(0, 15);
            warningLabel.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(919, 10);
            label3.Name = "label3";
            label3.Size = new Size(173, 24);
            label3.TabIndex = 4;
            label3.Text = "частотный анализ";
            label3.Click += label3_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(881, 36);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ScrollBars = ScrollBars.Vertical;
            textBox4.Size = new Size(240, 392);
            textBox4.TabIndex = 5;
            // 
            // button4
            // 
            button4.Location = new Point(589, 423);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(262, 33);
            button4.TabIndex = 8;
            button4.Text = "Загрузить в файл";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(11, 423);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(267, 33);
            button3.TabIndex = 10;
            button3.Text = "Загрузить из файла";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(339, 297);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(179, 32);
            textBox5.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(396, 314);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(318, 164);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 13;
            label6.Text = "Пара";
            // 
            // pair
            // 
            pair.Location = new Point(368, 164);
            pair.Margin = new Padding(3, 2, 3, 2);
            pair.Name = "pair";
            pair.Size = new Size(133, 23);
            pair.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(1208, 517);
            Controls.Add(pair);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(textBox5);
            Controls.Add(button3);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(warningLabel);
            Controls.Add(label2);
            HelpButton = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Шифрование";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label8;
        private TextBox textBox3;
        private Label label1;
        private Button button1;
        private Button button2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Label warningLabel;
        private Label label3;
        private TextBox textBox4;
        private Button button4;
        private Button button3;
        private TextBox textBox5;
        private Label label4;
        private Label label6;
        private TextBox pair;
    }
}