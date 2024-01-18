namespace ASB_Notification
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            ASBConnectionString = new TextBox();
            BtnSave = new Button();
            btnTestConnetion = new Button();
            cbDeleteMessage = new CheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            tbTimerInterval = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // ASBConnectionString
            // 
            ASBConnectionString.Location = new Point(37, 83);
            ASBConnectionString.Multiline = true;
            ASBConnectionString.Name = "ASBConnectionString";
            ASBConnectionString.Size = new Size(1114, 176);
            ASBConnectionString.TabIndex = 0;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(48, 742);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(112, 34);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += button1_Click;
            // 
            // btnTestConnetion
            // 
            btnTestConnetion.Location = new Point(42, 288);
            btnTestConnetion.Name = "btnTestConnetion";
            btnTestConnetion.Size = new Size(221, 34);
            btnTestConnetion.TabIndex = 3;
            btnTestConnetion.Text = "Test Connection";
            btnTestConnetion.UseVisualStyleBackColor = true;
            // 
            // cbDeleteMessage
            // 
            cbDeleteMessage.AutoSize = true;
            cbDeleteMessage.Location = new Point(41, 396);
            cbDeleteMessage.Name = "cbDeleteMessage";
            cbDeleteMessage.Size = new Size(163, 29);
            cbDeleteMessage.TabIndex = 4;
            cbDeleteMessage.Text = "Delete Message";
            cbDeleteMessage.UseVisualStyleBackColor = true;
            cbDeleteMessage.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 60000;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 46);
            label1.Name = "label1";
            label1.Size = new Size(184, 25);
            label1.TabIndex = 5;
            label1.Text = "ASB Connectionstring";
            label1.Click += label1_Click;
            // 
            // tbTimerInterval
            // 
            tbTimerInterval.Location = new Point(44, 506);
            tbTimerInterval.Name = "tbTimerInterval";
            tbTimerInterval.Size = new Size(150, 31);
            tbTimerInterval.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 463);
            label2.Name = "label2";
            label2.Size = new Size(205, 25);
            label2.TabIndex = 7;
            label2.Text = "Timer interval in minutes";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1426, 909);
            Controls.Add(label2);
            Controls.Add(tbTimerInterval);
            Controls.Add(label1);
            Controls.Add(cbDeleteMessage);
            Controls.Add(btnTestConnetion);
            Controls.Add(BtnSave);
            Controls.Add(ASBConnectionString);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Paint += Form1_Paint;
            Resize += Form1_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private TextBox ASBConnectionString;
        private Button BtnSave;
        private Button btnTestConnetion;
        private CheckBox cbDeleteMessage;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private TextBox tbTimerInterval;
        private Label label2;
    }
}
