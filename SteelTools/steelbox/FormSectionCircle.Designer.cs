namespace steelbox
{
    partial class FormSectionCircle
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSectionCircle = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCircleArea = new System.Windows.Forms.Label();
            this.labelCInertiaX = new System.Windows.Forms.Label();
            this.labelCix = new System.Windows.Forms.Label();
            this.buttonSCO = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "外径D";
            // 
            // textBoxCD
            // 
            this.textBoxCD.Location = new System.Drawing.Point(301, 45);
            this.textBoxCD.Name = "textBoxCD";
            this.textBoxCD.Size = new System.Drawing.Size(100, 21);
            this.textBoxCD.TabIndex = 1;
            this.textBoxCD.Text = "300";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "壁厚t";
            // 
            // textBoxCt
            // 
            this.textBoxCt.Location = new System.Drawing.Point(301, 82);
            this.textBoxCt.Name = "textBoxCt";
            this.textBoxCt.Size = new System.Drawing.Size(100, 21);
            this.textBoxCt.TabIndex = 1;
            this.textBoxCt.Text = "12";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::steelbox.Properties.Resources.Drawing1_Model2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(24, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 205);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSectionCircle
            // 
            this.buttonSectionCircle.Location = new System.Drawing.Point(24, 269);
            this.buttonSectionCircle.Name = "buttonSectionCircle";
            this.buttonSectionCircle.Size = new System.Drawing.Size(101, 23);
            this.buttonSectionCircle.TabIndex = 3;
            this.buttonSectionCircle.Text = "计算截面特性";
            this.buttonSectionCircle.UseVisualStyleBackColor = true;
            this.buttonSectionCircle.Click += new System.EventHandler(this.buttonSectionCircle_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "ix";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(242, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "Area";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ix";
            // 
            // labelCircleArea
            // 
            this.labelCircleArea.AutoSize = true;
            this.labelCircleArea.Location = new System.Drawing.Point(299, 140);
            this.labelCircleArea.Name = "labelCircleArea";
            this.labelCircleArea.Size = new System.Drawing.Size(23, 12);
            this.labelCircleArea.TabIndex = 9;
            this.labelCircleArea.Text = "num";
            // 
            // labelCInertiaX
            // 
            this.labelCInertiaX.AutoSize = true;
            this.labelCInertiaX.Location = new System.Drawing.Point(299, 165);
            this.labelCInertiaX.Name = "labelCInertiaX";
            this.labelCInertiaX.Size = new System.Drawing.Size(23, 12);
            this.labelCInertiaX.TabIndex = 9;
            this.labelCInertiaX.Text = "num";
            // 
            // labelCix
            // 
            this.labelCix.AutoSize = true;
            this.labelCix.Location = new System.Drawing.Point(299, 189);
            this.labelCix.Name = "labelCix";
            this.labelCix.Size = new System.Drawing.Size(23, 12);
            this.labelCix.TabIndex = 9;
            this.labelCix.Text = "num";
            // 
            // buttonSCO
            // 
            this.buttonSCO.Location = new System.Drawing.Point(131, 269);
            this.buttonSCO.Name = "buttonSCO";
            this.buttonSCO.Size = new System.Drawing.Size(75, 23);
            this.buttonSCO.TabIndex = 10;
            this.buttonSCO.Text = "退出并代入";
            this.buttonSCO.UseVisualStyleBackColor = true;
            this.buttonSCO.Click += new System.EventHandler(this.buttonSCO_Click);
            // 
            // FormSectionCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 335);
            this.Controls.Add(this.buttonSCO);
            this.Controls.Add(this.labelCix);
            this.Controls.Add(this.labelCInertiaX);
            this.Controls.Add(this.labelCircleArea);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSectionCircle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxCt);
            this.Controls.Add(this.textBoxCD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormSectionCircle";
            this.Text = "FormSectionCircle";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCD;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCt;
        private System.Windows.Forms.Button buttonSectionCircle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCircleArea;
        private System.Windows.Forms.Label labelCInertiaX;
        private System.Windows.Forms.Label labelCix;
        private System.Windows.Forms.Button buttonSCO;
    }
}