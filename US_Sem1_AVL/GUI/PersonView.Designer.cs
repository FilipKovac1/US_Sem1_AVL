namespace US_Sem1_AVL.GUI
{
    partial class PersonView
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.inputID = new System.Windows.Forms.TextBox();
            this.inputName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputBirthday = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.inputAddress = new System.Windows.Forms.TextBox();
            this.btnShowProperties = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnChangeAddress = new System.Windows.Forms.Button();
            this.btnChangeProperty = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(218, 329);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // inputID
            // 
            this.inputID.Location = new System.Drawing.Point(66, 21);
            this.inputID.Name = "inputID";
            this.inputID.Size = new System.Drawing.Size(227, 20);
            this.inputID.TabIndex = 3;
            // 
            // inputName
            // 
            this.inputName.Location = new System.Drawing.Point(66, 48);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(227, 20);
            this.inputName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Birthday";
            // 
            // inputBirthday
            // 
            this.inputBirthday.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.inputBirthday.Location = new System.Drawing.Point(66, 75);
            this.inputBirthday.MaxSelectionCount = 1;
            this.inputBirthday.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.inputBirthday.Name = "inputBirthday";
            this.inputBirthday.ShowTodayCircle = false;
            this.inputBirthday.TabIndex = 6;
            this.inputBirthday.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Address";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // inputAddress
            // 
            this.inputAddress.Enabled = false;
            this.inputAddress.Location = new System.Drawing.Point(67, 245);
            this.inputAddress.Name = "inputAddress";
            this.inputAddress.ReadOnly = true;
            this.inputAddress.Size = new System.Drawing.Size(227, 20);
            this.inputAddress.TabIndex = 8;
            this.inputAddress.TabStop = false;
            // 
            // btnShowProperties
            // 
            this.btnShowProperties.Location = new System.Drawing.Point(25, 300);
            this.btnShowProperties.Name = "btnShowProperties";
            this.btnShowProperties.Size = new System.Drawing.Size(115, 23);
            this.btnShowProperties.TabIndex = 9;
            this.btnShowProperties.Text = "Show Properties";
            this.btnShowProperties.UseVisualStyleBackColor = true;
            this.btnShowProperties.Click += new System.EventHandler(this.btnShowProperties_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(137, 329);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnChangeAddress
            // 
            this.btnChangeAddress.Location = new System.Drawing.Point(25, 271);
            this.btnChangeAddress.Name = "btnChangeAddress";
            this.btnChangeAddress.Size = new System.Drawing.Size(115, 23);
            this.btnChangeAddress.TabIndex = 11;
            this.btnChangeAddress.Text = "Change Address";
            this.btnChangeAddress.UseVisualStyleBackColor = true;
            this.btnChangeAddress.Click += new System.EventHandler(this.btnChangeAddress_Click);
            // 
            // btnChangeProperty
            // 
            this.btnChangeProperty.Location = new System.Drawing.Point(179, 271);
            this.btnChangeProperty.Name = "btnChangeProperty";
            this.btnChangeProperty.Size = new System.Drawing.Size(115, 52);
            this.btnChangeProperty.TabIndex = 12;
            this.btnChangeProperty.Text = "Change Property Owner";
            this.btnChangeProperty.UseVisualStyleBackColor = true;
            this.btnChangeProperty.Click += new System.EventHandler(this.btnChangeProperty_Click);
            // 
            // PersonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 361);
            this.Controls.Add(this.btnChangeProperty);
            this.Controls.Add(this.btnChangeAddress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShowProperties);
            this.Controls.Add(this.inputAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inputBirthday);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.inputID);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PersonView";
            this.Text = "Person";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox inputID;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar inputBirthday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputAddress;
        private System.Windows.Forms.Button btnShowProperties;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnChangeAddress;
        private System.Windows.Forms.Button btnChangeProperty;
    }
}