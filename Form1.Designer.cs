namespace SoulMemory_Calc
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.chkRing = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(19, 71);
            this.lbl1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(77, 37);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Min:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(19, 137);
            this.lbl2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(85, 37);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Max:";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(313, 60);
            this.txtInput.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(308, 44);
            this.txtInput.TabIndex = 4;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            // 
            // chkRing
            // 
            this.chkRing.AutoSize = true;
            this.chkRing.Location = new System.Drawing.Point(29, 128);
            this.chkRing.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.chkRing.Name = "chkRing";
            this.chkRing.Size = new System.Drawing.Size(342, 41);
            this.chkRing.TabIndex = 5;
            this.chkRing.Text = "Name-Engraved Ring";
            this.chkRing.UseVisualStyleBackColor = true;
            this.chkRing.CheckedChanged += new System.EventHandler(this.chkRing_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Controls.Add(this.chkRing);
            this.groupBox1.Location = new System.Drawing.Point(38, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.groupBox1.Size = new System.Drawing.Size(658, 219);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your Character";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "SoulMemory";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMax);
            this.groupBox2.Controls.Add(this.lblMin);
            this.groupBox2.Controls.Add(this.lbl1);
            this.groupBox2.Controls.Add(this.lbl2);
            this.groupBox2.Location = new System.Drawing.Point(38, 270);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.groupBox2.Size = new System.Drawing.Size(658, 213);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Matches with";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(38, 492);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(160, 37);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Chaoticoz";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblMin
            // 
            this.lblMin.Location = new System.Drawing.Point(289, 71);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(351, 37);
            this.lblMin.TabIndex = 4;
            this.lblMin.Text = "0";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMax
            // 
            this.lblMax.Location = new System.Drawing.Point(289, 137);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(351, 37);
            this.lblMax.TabIndex = 5;
            this.lblMax.Text = "0";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 558);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "Form1";
            this.Text = "DS2 Soulmemory Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.CheckBox chkRing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
    }
}

