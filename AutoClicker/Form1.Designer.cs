namespace Autoclicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            txtDelay = new TextBox();
            label2 = new Label();
            cmbClickType = new ComboBox();
            label3 = new Label();
            chkSpinning = new CheckBox();
            label4 = new Label();
            txtHotkey = new TextBox();
            label5 = new Label();
            btnStartStop = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(11, 25);
            label1.Name = "label1";
            label1.Size = new Size(107, 28);
            label1.TabIndex = 0;
            label1.Text = "Click Delay";
            // 
            // txtDelay
            // 
            txtDelay.Location = new Point(15, 59);
            txtDelay.Name = "txtDelay";
            txtDelay.Size = new Size(208, 27);
            txtDelay.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(11, 93);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 2;
            label2.Text = "Click Type";
            // 
            // cmbClickType
            // 
            cmbClickType.FormattingEnabled = true;
            cmbClickType.Location = new Point(15, 127);
            cmbClickType.Name = "cmbClickType";
            cmbClickType.Size = new Size(208, 28);
            cmbClickType.TabIndex = 3;
            cmbClickType.SelectedIndexChanged += cmbClickType_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(247, 25);
            label3.Name = "label3";
            label3.Size = new Size(90, 28);
            label3.TabIndex = 4;
            label3.Text = "Spinning";
            // 
            // chkSpinning
            // 
            chkSpinning.AutoSize = true;
            chkSpinning.Font = new Font("Segoe UI", 10F);
            chkSpinning.Location = new Point(252, 64);
            chkSpinning.Name = "chkSpinning";
            chkSpinning.Size = new Size(18, 17);
            chkSpinning.TabIndex = 5;
            chkSpinning.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(247, 93);
            label4.Name = "label4";
            label4.Size = new Size(75, 28);
            label4.TabIndex = 7;
            label4.Text = "Hotkey";
            // 
            // txtHotkey
            // 
            txtHotkey.Location = new Point(252, 128);
            txtHotkey.Name = "txtHotkey";
            txtHotkey.Size = new Size(208, 27);
            txtHotkey.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI", 7F);
            label5.Location = new Point(377, 110);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 9;
            label5.Text = "(F8 by default)";
            // 
            // btnStartStop
            // 
            btnStartStop.Font = new Font("Segoe UI", 10F);
            btnStartStop.Location = new Point(423, 268);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(10, 10);
            btnStartStop.TabIndex = 6;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 190);
            Controls.Add(label5);
            Controls.Add(txtHotkey);
            Controls.Add(label4);
            Controls.Add(btnStartStop);
            Controls.Add(chkSpinning);
            Controls.Add(label3);
            Controls.Add(cmbClickType);
            Controls.Add(label2);
            Controls.Add(txtDelay);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "AutoClicker v1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDelay;
        private Label label2;
        private ComboBox cmbClickType;
        private Label label3;
        private CheckBox chkSpinning;
        private Label label4;
        private TextBox txtHotkey;
        private Label label5;
        private Button btnStartStop;
    }
}
