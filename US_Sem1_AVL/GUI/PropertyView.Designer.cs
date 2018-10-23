namespace US_Sem1_AVL.GUI
{
    partial class PropertyView
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
            this.btnClose = new System.Windows.Forms.Button();
            this.inputAddress = new System.Windows.Forms.TextBox();
            this.inputID = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inputDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridOccupants = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.inputList = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOccupants)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(127, 314);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // inputAddress
            // 
            this.inputAddress.Location = new System.Drawing.Point(82, 33);
            this.inputAddress.Name = "inputAddress";
            this.inputAddress.Size = new System.Drawing.Size(201, 20);
            this.inputAddress.TabIndex = 15;
            // 
            // inputID
            // 
            this.inputID.Location = new System.Drawing.Point(82, 6);
            this.inputID.Name = "inputID";
            this.inputID.Size = new System.Drawing.Size(201, 20);
            this.inputID.TabIndex = 14;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(208, 314);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ID";
            // 
            // inputDesc
            // 
            this.inputDesc.Location = new System.Drawing.Point(82, 59);
            this.inputDesc.Name = "inputDesc";
            this.inputDesc.Size = new System.Drawing.Size(201, 20);
            this.inputDesc.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Description";
            // 
            // dataGridOccupants
            // 
            this.dataGridOccupants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOccupants.Location = new System.Drawing.Point(12, 153);
            this.dataGridOccupants.Name = "dataGridOccupants";
            this.dataGridOccupants.Size = new System.Drawing.Size(271, 155);
            this.dataGridOccupants.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Occupants";
            // 
            // inputList
            // 
            this.inputList.Enabled = false;
            this.inputList.Location = new System.Drawing.Point(82, 97);
            this.inputList.Name = "inputList";
            this.inputList.Size = new System.Drawing.Size(201, 20);
            this.inputList.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "On List";
            // 
            // PropertyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 344);
            this.Controls.Add(this.inputList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridOccupants);
            this.Controls.Add(this.inputDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.inputAddress);
            this.Controls.Add(this.inputID);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PropertyView";
            this.Text = "Property";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOccupants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox inputAddress;
        private System.Windows.Forms.TextBox inputID;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridOccupants;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputList;
        private System.Windows.Forms.Label label5;
    }
}