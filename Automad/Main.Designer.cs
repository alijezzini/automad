namespace Automad
{
    partial class Main
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.runButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Larkch = new System.Windows.Forms.CheckBox();
            this.Transferch = new System.Windows.Forms.CheckBox();
            this.Googlech = new System.Windows.Forms.CheckBox();
            this.Naverch = new System.Windows.Forms.CheckBox();
            this.Microsoftch = new System.Windows.Forms.CheckBox();
            this.Instagramch = new System.Windows.Forms.CheckBox();
            this.pausebtn = new System.Windows.Forms.Button();
            this.stopbtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pathlabel = new System.Windows.Forms.Label();
            this.importlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ImportButton = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.numberbox = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.logout = new System.Windows.Forms.Button();
            this.succounter = new System.Windows.Forms.Label();
            this.statuslabel = new System.Windows.Forms.Label();
            this.teststart = new System.Windows.Forms.Label();
            this.testfinish = new System.Windows.Forms.Label();
            this.percentage = new System.Windows.Forms.Label();
            this.replay = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Automad.Properties.Resources.back;
            this.pictureBox1.Location = new System.Drawing.Point(412, 158);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(291, 288);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.Location = new System.Drawing.Point(425, 38);
            this.runButton.Margin = new System.Windows.Forms.Padding(4);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(183, 54);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "Run Test";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.run_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Larkch);
            this.groupBox1.Controls.Add(this.Transferch);
            this.groupBox1.Controls.Add(this.Googlech);
            this.groupBox1.Controls.Add(this.Naverch);
            this.groupBox1.Controls.Add(this.Microsoftch);
            this.groupBox1.Controls.Add(this.Instagramch);
            this.groupBox1.Location = new System.Drawing.Point(40, 193);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(321, 133);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Applications";
            // 
            // Larkch
            // 
            this.Larkch.AutoSize = true;
            this.Larkch.Location = new System.Drawing.Point(188, 89);
            this.Larkch.Margin = new System.Windows.Forms.Padding(4);
            this.Larkch.Name = "Larkch";
            this.Larkch.Size = new System.Drawing.Size(58, 21);
            this.Larkch.TabIndex = 13;
            this.Larkch.Text = "Lark";
            this.Larkch.UseVisualStyleBackColor = true;
            this.Larkch.CheckedChanged += new System.EventHandler(this.Ch_OnChange);
            // 
            // Transferch
            // 
            this.Transferch.AutoSize = true;
            this.Transferch.Location = new System.Drawing.Point(188, 60);
            this.Transferch.Margin = new System.Windows.Forms.Padding(4);
            this.Transferch.Name = "Transferch";
            this.Transferch.Size = new System.Drawing.Size(103, 21);
            this.Transferch.TabIndex = 12;
            this.Transferch.Text = "TransferGo";
            this.Transferch.UseVisualStyleBackColor = true;
            this.Transferch.CheckedChanged += new System.EventHandler(this.Ch_OnChange);
            // 
            // Googlech
            // 
            this.Googlech.AutoSize = true;
            this.Googlech.Location = new System.Drawing.Point(13, 89);
            this.Googlech.Margin = new System.Windows.Forms.Padding(4);
            this.Googlech.Name = "Googlech";
            this.Googlech.Size = new System.Drawing.Size(76, 21);
            this.Googlech.TabIndex = 11;
            this.Googlech.Text = "Google";
            this.Googlech.UseVisualStyleBackColor = true;
            this.Googlech.CheckedChanged += new System.EventHandler(this.Ch_OnChange);
            // 
            // Naverch
            // 
            this.Naverch.AutoSize = true;
            this.Naverch.Location = new System.Drawing.Point(188, 32);
            this.Naverch.Margin = new System.Windows.Forms.Padding(4);
            this.Naverch.Name = "Naverch";
            this.Naverch.Size = new System.Drawing.Size(68, 21);
            this.Naverch.TabIndex = 10;
            this.Naverch.Text = "Naver";
            this.Naverch.UseVisualStyleBackColor = true;
            this.Naverch.CheckedChanged += new System.EventHandler(this.Ch_OnChange);
            // 
            // Microsoftch
            // 
            this.Microsoftch.AutoSize = true;
            this.Microsoftch.Location = new System.Drawing.Point(13, 60);
            this.Microsoftch.Margin = new System.Windows.Forms.Padding(4);
            this.Microsoftch.Name = "Microsoftch";
            this.Microsoftch.Size = new System.Drawing.Size(87, 21);
            this.Microsoftch.TabIndex = 9;
            this.Microsoftch.Text = "Microsoft";
            this.Microsoftch.UseVisualStyleBackColor = true;
            this.Microsoftch.CheckedChanged += new System.EventHandler(this.Ch_OnChange);
            // 
            // Instagramch
            // 
            this.Instagramch.AutoSize = true;
            this.Instagramch.Location = new System.Drawing.Point(13, 32);
            this.Instagramch.Margin = new System.Windows.Forms.Padding(4);
            this.Instagramch.Name = "Instagramch";
            this.Instagramch.Size = new System.Drawing.Size(92, 21);
            this.Instagramch.TabIndex = 8;
            this.Instagramch.Text = "Instagram";
            this.Instagramch.UseVisualStyleBackColor = true;
            this.Instagramch.CheckedChanged += new System.EventHandler(this.Ch_OnChange);
            // 
            // pausebtn
            // 
            this.pausebtn.Enabled = false;
            this.pausebtn.Location = new System.Drawing.Point(425, 96);
            this.pausebtn.Margin = new System.Windows.Forms.Padding(4);
            this.pausebtn.Name = "pausebtn";
            this.pausebtn.Size = new System.Drawing.Size(91, 54);
            this.pausebtn.TabIndex = 8;
            this.pausebtn.Text = "Pause";
            this.pausebtn.UseVisualStyleBackColor = true;
            this.pausebtn.Click += new System.EventHandler(this.Pause_Click);
            // 
            // stopbtn
            // 
            this.stopbtn.Enabled = false;
            this.stopbtn.Location = new System.Drawing.Point(517, 96);
            this.stopbtn.Margin = new System.Windows.Forms.Padding(4);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(91, 54);
            this.stopbtn.TabIndex = 9;
            this.stopbtn.Text = "Stop";
            this.stopbtn.UseVisualStyleBackColor = true;
            this.stopbtn.Click += new System.EventHandler(this.stopbtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pathlabel);
            this.groupBox2.Controls.Add(this.importlabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ImportButton);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.numberbox);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(40, 27);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(321, 159);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destination";
            // 
            // pathlabel
            // 
            this.pathlabel.AutoSize = true;
            this.pathlabel.Location = new System.Drawing.Point(156, 91);
            this.pathlabel.Name = "pathlabel";
            this.pathlabel.Size = new System.Drawing.Size(0, 17);
            this.pathlabel.TabIndex = 17;
            // 
            // importlabel
            // 
            this.importlabel.AutoSize = true;
            this.importlabel.Location = new System.Drawing.Point(156, 123);
            this.importlabel.Name = "importlabel";
            this.importlabel.Size = new System.Drawing.Size(0, 17);
            this.importlabel.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Phone Number";
            // 
            // ImportButton
            // 
            this.ImportButton.Enabled = false;
            this.ImportButton.Location = new System.Drawing.Point(40, 91);
            this.ImportButton.Margin = new System.Windows.Forms.Padding(4);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(105, 49);
            this.ImportButton.TabIndex = 9;
            this.ImportButton.Text = "Import Sheet";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 108);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(17, 16);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // numberbox
            // 
            this.numberbox.Location = new System.Drawing.Point(40, 50);
            this.numberbox.Margin = new System.Windows.Forms.Padding(4);
            this.numberbox.Name = "numberbox";
            this.numberbox.Size = new System.Drawing.Size(223, 22);
            this.numberbox.TabIndex = 7;
            this.numberbox.TextChanged += new System.EventHandler(this.numberbox_TextChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 54);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(17, 16);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(517, 350);
            this.logout.Margin = new System.Windows.Forms.Padding(4);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(91, 30);
            this.logout.TabIndex = 11;
            this.logout.Text = "Log Out";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_button);
            // 
            // succounter
            // 
            this.succounter.AutoSize = true;
            this.succounter.Location = new System.Drawing.Point(565, 193);
            this.succounter.Name = "succounter";
            this.succounter.Size = new System.Drawing.Size(78, 17);
            this.succounter.TabIndex = 12;
            this.succounter.Text = "succounter";
            this.succounter.Click += new System.EventHandler(this.succounter_Click);
            // 
            // statuslabel
            // 
            this.statuslabel.AutoSize = true;
            this.statuslabel.Location = new System.Drawing.Point(424, 225);
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(76, 17);
            this.statuslabel.TabIndex = 13;
            this.statuslabel.Text = "statuslabel";
            // 
            // teststart
            // 
            this.teststart.AutoSize = true;
            this.teststart.Location = new System.Drawing.Point(37, 340);
            this.teststart.Name = "teststart";
            this.teststart.Size = new System.Drawing.Size(0, 17);
            this.teststart.TabIndex = 14;
            // 
            // testfinish
            // 
            this.testfinish.AutoSize = true;
            this.testfinish.Location = new System.Drawing.Point(37, 363);
            this.testfinish.Name = "testfinish";
            this.testfinish.Size = new System.Drawing.Size(0, 17);
            this.testfinish.TabIndex = 15;
            // 
            // percentage
            // 
            this.percentage.AutoSize = true;
            this.percentage.Location = new System.Drawing.Point(528, 225);
            this.percentage.Name = "percentage";
            this.percentage.Size = new System.Drawing.Size(0, 17);
            this.percentage.TabIndex = 16;
            // 
            // replay
            // 
            this.replay.AutoSize = true;
            this.replay.Location = new System.Drawing.Point(427, 158);
            this.replay.Name = "replay";
            this.replay.Size = new System.Drawing.Size(107, 21);
            this.replay.TabIndex = 17;
            this.replay.Text = "Auto Replay";
            this.replay.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Successful Attempts: ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 394);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.replay);
            this.Controls.Add(this.percentage);
            this.Controls.Add(this.testfinish);
            this.Controls.Add(this.teststart);
            this.Controls.Add(this.statuslabel);
            this.Controls.Add(this.succounter);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.stopbtn);
            this.Controls.Add(this.pausebtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AUTOMAD";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Larkch;
        private System.Windows.Forms.CheckBox Transferch;
        private System.Windows.Forms.CheckBox Googlech;
        private System.Windows.Forms.CheckBox Naverch;
        private System.Windows.Forms.CheckBox Microsoftch;
        private System.Windows.Forms.CheckBox Instagramch;
        private System.Windows.Forms.Button pausebtn;
        private System.Windows.Forms.Button stopbtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox numberbox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Label pathlabel;
        private System.Windows.Forms.Label importlabel;
        private System.Windows.Forms.Label succounter;
        private System.Windows.Forms.Label statuslabel;
        private System.Windows.Forms.Label teststart;
        private System.Windows.Forms.Label testfinish;
        private System.Windows.Forms.Label percentage;
        private System.Windows.Forms.CheckBox replay;
        private System.Windows.Forms.Label label2;
    }
}