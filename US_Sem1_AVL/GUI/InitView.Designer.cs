namespace US_Sem1_AVL.GUI
{
    partial class InitView
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
            this.btnNot = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inputCad = new System.Windows.Forms.TextBox();
            this.inputPer = new System.Windows.Forms.TextBox();
            this.inputPLists = new System.Windows.Forms.TextBox();
            this.inputProps = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnNot
            // 
            this.btnNot.Location = new System.Drawing.Point(15, 112);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(108, 23);
            this.btnNot.TabIndex = 0;
            this.btnNot.Text = "Do Not Generate";
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.btnNot_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(136, 112);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Genrate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cadastral areas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Persons";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Property Lists";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Properties";
            // 
            // inputCad
            // 
            this.inputCad.Location = new System.Drawing.Point(136, 6);
            this.inputCad.Name = "inputCad";
            this.inputCad.Size = new System.Drawing.Size(100, 20);
            this.inputCad.TabIndex = 6;
            this.inputCad.Text = "1000";
            // 
            // inputPer
            // 
            this.inputPer.Location = new System.Drawing.Point(136, 31);
            this.inputPer.Name = "inputPer";
            this.inputPer.Size = new System.Drawing.Size(100, 20);
            this.inputPer.TabIndex = 7;
            this.inputPer.Text = "10000";
            // 
            // inputPLists
            // 
            this.inputPLists.Location = new System.Drawing.Point(136, 58);
            this.inputPLists.Name = "inputPLists";
            this.inputPLists.Size = new System.Drawing.Size(100, 20);
            this.inputPLists.TabIndex = 8;
            this.inputPLists.Text = "100";
            // 
            // inputProps
            // 
            this.inputProps.Location = new System.Drawing.Point(136, 86);
            this.inputProps.Name = "inputProps";
            this.inputProps.Size = new System.Drawing.Size(100, 20);
            this.inputProps.TabIndex = 9;
            this.inputProps.Text = "1000";
            // 
            // InitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 143);
            this.Controls.Add(this.inputProps);
            this.Controls.Add(this.inputPLists);
            this.Controls.Add(this.inputPer);
            this.Controls.Add(this.inputCad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnNot);
            this.Name = "InitView";
            this.Text = "SP Start";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputCad;
        private System.Windows.Forms.TextBox inputPer;
        private System.Windows.Forms.TextBox inputPLists;
        private System.Windows.Forms.TextBox inputProps;
    }
}