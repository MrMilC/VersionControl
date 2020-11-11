namespace _08_RM_GB4PW8
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.btnSelectCar = new System.Windows.Forms.Button();
            this.btnSelectBall = new System.Windows.Forms.Button();
            this.lblNext = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Location = new System.Drawing.Point(12, 251);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(942, 118);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // btnSelectCar
            // 
            this.btnSelectCar.Location = new System.Drawing.Point(12, 12);
            this.btnSelectCar.Name = "btnSelectCar";
            this.btnSelectCar.Size = new System.Drawing.Size(75, 75);
            this.btnSelectCar.TabIndex = 1;
            this.btnSelectCar.Text = "CAR";
            this.btnSelectCar.UseVisualStyleBackColor = true;
            this.btnSelectCar.Click += new System.EventHandler(this.btnSelectCar_Click);
            // 
            // btnSelectBall
            // 
            this.btnSelectBall.Location = new System.Drawing.Point(106, 12);
            this.btnSelectBall.Name = "btnSelectBall";
            this.btnSelectBall.Size = new System.Drawing.Size(75, 75);
            this.btnSelectBall.TabIndex = 2;
            this.btnSelectBall.Text = "BALL";
            this.btnSelectBall.UseVisualStyleBackColor = true;
            this.btnSelectBall.Click += new System.EventHandler(this.btnSelectBall_Click);
            // 
            // lblNext
            // 
            this.lblNext.AutoSize = true;
            this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNext.Location = new System.Drawing.Point(416, 9);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(119, 20);
            this.lblNext.TabIndex = 3;
            this.lblNext.Text = "Coming next:";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Fuchsia;
            this.btnColor.Location = new System.Drawing.Point(106, 93);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 4;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 381);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.btnSelectBall);
            this.Controls.Add(this.btnSelectCar);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button btnSelectCar;
        private System.Windows.Forms.Button btnSelectBall;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Button btnColor;
    }
}

