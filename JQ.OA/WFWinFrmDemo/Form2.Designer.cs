namespace WFWinFrmDemo
{
    partial class Form2
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
            this.startWorkFlow = new System.Windows.Forms.Button();
            this.txtBookMarkName = new System.Windows.Forms.TextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startWorkFlow
            // 
            this.startWorkFlow.Location = new System.Drawing.Point(12, 68);
            this.startWorkFlow.Name = "startWorkFlow";
            this.startWorkFlow.Size = new System.Drawing.Size(144, 23);
            this.startWorkFlow.TabIndex = 0;
            this.startWorkFlow.Text = "Start Workflow";
            this.startWorkFlow.UseVisualStyleBackColor = true;
            this.startWorkFlow.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBookMarkName
            // 
            this.txtBookMarkName.Location = new System.Drawing.Point(217, 71);
            this.txtBookMarkName.Name = "txtBookMarkName";
            this.txtBookMarkName.Size = new System.Drawing.Size(296, 20);
            this.txtBookMarkName.TabIndex = 1;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(12, 208);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(144, 23);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "WakeUp BookMark";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(217, 211);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(296, 20);
            this.txtValue.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(296, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "WakeUP From SQL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.txtBookMarkName);
            this.Controls.Add(this.startWorkFlow);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startWorkFlow;
        private System.Windows.Forms.TextBox txtBookMarkName;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}