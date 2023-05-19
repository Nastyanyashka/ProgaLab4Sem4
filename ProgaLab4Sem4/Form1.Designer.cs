namespace ProgaLab4Sem4
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
            comboBox1 = new ComboBox();
            listBox1 = new ListBox();
            label2 = new Label();
            ipAddress_textBox = new TextBox();
            Connect = new Button();
            Disconnect = new Button();
            transefToServerButton = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            goBack_button = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(281, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 41);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(281, 319);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 376);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Ip адрес";
            // 
            // ipAddress_textBox
            // 
            ipAddress_textBox.Location = new Point(68, 373);
            ipAddress_textBox.Multiline = true;
            ipAddress_textBox.Name = "ipAddress_textBox";
            ipAddress_textBox.Size = new Size(122, 23);
            ipAddress_textBox.TabIndex = 6;
            // 
            // Connect
            // 
            Connect.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            Connect.Location = new Point(12, 405);
            Connect.Name = "Connect";
            Connect.Size = new Size(83, 23);
            Connect.TabIndex = 7;
            Connect.Text = "Соедениться";
            Connect.UseVisualStyleBackColor = true;
            Connect.Click += Connect_Click;
            // 
            // Disconnect
            // 
            Disconnect.Enabled = false;
            Disconnect.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            Disconnect.Location = new Point(101, 405);
            Disconnect.Name = "Disconnect";
            Disconnect.Size = new Size(89, 23);
            Disconnect.TabIndex = 8;
            Disconnect.Text = "Отключиться";
            Disconnect.UseVisualStyleBackColor = true;
            Disconnect.Click += Disconnect_Click;
            // 
            // transefToServerButton
            // 
            transefToServerButton.Enabled = false;
            transefToServerButton.Location = new Point(12, 434);
            transefToServerButton.Name = "transefToServerButton";
            transefToServerButton.Size = new Size(281, 23);
            transefToServerButton.TabIndex = 9;
            transefToServerButton.Text = "Передать серверу";
            transefToServerButton.UseVisualStyleBackColor = true;
            transefToServerButton.Click += transefToServerButton_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(315, 12);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(258, 348);
            textBox2.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(315, 376);
            label3.Name = "label3";
            label3.Size = new Size(162, 15);
            label3.TabIndex = 15;
            label3.Text = "Нет подключения к серверу";
            // 
            // goBack_button
            // 
            goBack_button.Location = new Point(196, 405);
            goBack_button.Name = "goBack_button";
            goBack_button.Size = new Size(97, 23);
            goBack_button.TabIndex = 16;
            goBack_button.Text = "Назад";
            goBack_button.UseVisualStyleBackColor = true;
            goBack_button.Click += goBack_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 474);
            Controls.Add(goBack_button);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(transefToServerButton);
            Controls.Add(Disconnect);
            Controls.Add(Connect);
            Controls.Add(ipAddress_textBox);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ListBox listBox1;
        private Label label2;
        private TextBox ipAddress_textBox;
        private Button Connect;
        private Button Disconnect;
        private Button transefToServerButton;
        private TextBox textBox2;
        private Label label3;
        private Button goBack_button;
    }
}