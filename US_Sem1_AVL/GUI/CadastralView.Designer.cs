namespace US_Sem1_AVL.GUI
{
    partial class CadastralView
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
            this.inputName = new System.Windows.Forms.TextBox();
            this.inputID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnShowProperties = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inputPropCount = new System.Windows.Forms.TextBox();
            this.inputPListsCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inputName
            // 
            this.inputName.Location = new System.Drawing.Point(58, 39);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(227, 20);
            this.inputName.TabIndex = 8;
            // 
            // inputID
            // 
            this.inputID.Location = new System.Drawing.Point(58, 12);
            this.inputID.Name = "inputID";
            this.inputID.Size = new System.Drawing.Size(227, 20);
            this.inputID.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(129, 194);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(210, 194);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnShowProperties
            // 
            this.btnShowProperties.Location = new System.Drawing.Point(17, 136);
            this.btnShowProperties.Name = "btnShowProperties";
            this.btnShowProperties.Size = new System.Drawing.Size(115, 23);
            this.btnShowProperties.TabIndex = 14;
            this.btnShowProperties.Text = "Show Properties";
            this.btnShowProperties.UseVisualStyleBackColor = true;
            this.btnShowProperties.Click += new System.EventHandler(this.btnShowProperties_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Properties count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Property lists count";
            // 
            // inputPropCount
            // 
            this.inputPropCount.Enabled = false;
            this.inputPropCount.Location = new System.Drawing.Point(129, 69);
            this.inputPropCount.Name = "inputPropCount";
            this.inputPropCount.Size = new System.Drawing.Size(75, 20);
            this.inputPropCount.TabIndex = 17;
            // 
            // inputPListsCount
            // 
            this.inputPListsCount.Enabled = false;
            this.inputPListsCount.Location = new System.Drawing.Point(129, 94);
            this.inputPListsCount.Name = "inputPListsCount";
            this.inputPListsCount.Size = new System.Drawing.Size(75, 20);
            this.inputPListsCount.TabIndex = 18;
            // 
            // CadastralView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 223);
            this.Controls.Add(this.inputPListsCount);
            this.Controls.Add(this.inputPropCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShowProperties);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.inputID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CadastralView";
            this.Text = "CadastralView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.TextBox inputID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnShowProperties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputPropCount;
        private System.Windows.Forms.TextBox inputPListsCount;
    }
}