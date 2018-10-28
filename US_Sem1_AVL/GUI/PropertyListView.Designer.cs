using System;
using System.Windows.Forms;

namespace US_Sem1_AVL.GUI
{
    partial class PropertyListView
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
            this.btnShowProperties = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.Owners = new System.Windows.Forms.DataGridView();
            this.btnAddOwner = new System.Windows.Forms.Button();
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.btnFindProperty = new System.Windows.Forms.Button();
            this.btnDeleteProperty = new System.Windows.Forms.Button();
            this.btnRemoveOwner = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Owners)).BeginInit();
            this.SuspendLayout();
            // 
            // inputName
            // 
            this.inputName.Enabled = false;
            this.inputName.Location = new System.Drawing.Point(94, 33);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(227, 20);
            this.inputName.TabIndex = 8;
            // 
            // inputID
            // 
            this.inputID.Location = new System.Drawing.Point(94, 6);
            this.inputID.Name = "inputID";
            this.inputID.Size = new System.Drawing.Size(227, 20);
            this.inputID.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cadastral Area";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(168, 379);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShowProperties
            // 
            this.btnShowProperties.Location = new System.Drawing.Point(15, 277);
            this.btnShowProperties.Name = "btnShowProperties";
            this.btnShowProperties.Size = new System.Drawing.Size(103, 23);
            this.btnShowProperties.TabIndex = 12;
            this.btnShowProperties.Text = "Show Properties";
            this.btnShowProperties.UseVisualStyleBackColor = true;
            this.btnShowProperties.Click += new System.EventHandler(this.btnShowProperties_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(249, 379);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Owners
            // 
            this.Owners.AllowUserToAddRows = false;
            this.Owners.AllowUserToDeleteRows = false;
            this.Owners.AllowUserToOrderColumns = true;
            this.Owners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Owners.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Owners.Location = new System.Drawing.Point(15, 65);
            this.Owners.MultiSelect = false;
            this.Owners.Name = "Owners";
            this.Owners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Owners.Size = new System.Drawing.Size(306, 146);
            this.Owners.TabIndex = 14;
            this.Owners.TabStop = false;
            this.Owners.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Owners_CellClick);
            // 
            // btnAddOwner
            // 
            this.btnAddOwner.Location = new System.Drawing.Point(224, 217);
            this.btnAddOwner.Name = "btnAddOwner";
            this.btnAddOwner.Size = new System.Drawing.Size(97, 23);
            this.btnAddOwner.TabIndex = 15;
            this.btnAddOwner.Text = "Add Owner";
            this.btnAddOwner.UseVisualStyleBackColor = true;
            this.btnAddOwner.Click += new System.EventHandler(this.btnAddOwner_Click);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Location = new System.Drawing.Point(15, 217);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(103, 23);
            this.btnAddProperty.TabIndex = 16;
            this.btnAddProperty.Text = "Add Property";
            this.btnAddProperty.UseVisualStyleBackColor = true;
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // btnFindProperty
            // 
            this.btnFindProperty.Location = new System.Drawing.Point(15, 248);
            this.btnFindProperty.Name = "btnFindProperty";
            this.btnFindProperty.Size = new System.Drawing.Size(103, 23);
            this.btnFindProperty.TabIndex = 17;
            this.btnFindProperty.Text = "Find Property";
            this.btnFindProperty.UseVisualStyleBackColor = true;
            this.btnFindProperty.Click += new System.EventHandler(this.btnFindProperty_Click);
            // 
            // btnDeleteProperty
            // 
            this.btnDeleteProperty.Location = new System.Drawing.Point(15, 306);
            this.btnDeleteProperty.Name = "btnDeleteProperty";
            this.btnDeleteProperty.Size = new System.Drawing.Size(103, 23);
            this.btnDeleteProperty.TabIndex = 18;
            this.btnDeleteProperty.Text = "Delete Property";
            this.btnDeleteProperty.UseVisualStyleBackColor = true;
            this.btnDeleteProperty.Click += new System.EventHandler(this.btnDeleteProperty_Click);
            // 
            // btnRemoveOwner
            // 
            this.btnRemoveOwner.Location = new System.Drawing.Point(224, 248);
            this.btnRemoveOwner.Name = "btnRemoveOwner";
            this.btnRemoveOwner.Size = new System.Drawing.Size(97, 23);
            this.btnRemoveOwner.TabIndex = 19;
            this.btnRemoveOwner.Text = "Remove Owner";
            this.btnRemoveOwner.UseVisualStyleBackColor = true;
            this.btnRemoveOwner.Click += new System.EventHandler(this.btnRemoveOwner_Click);
            // 
            // PropertyListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 414);
            this.Controls.Add(this.btnRemoveOwner);
            this.Controls.Add(this.btnDeleteProperty);
            this.Controls.Add(this.btnFindProperty);
            this.Controls.Add(this.btnAddProperty);
            this.Controls.Add(this.btnAddOwner);
            this.Controls.Add(this.Owners);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShowProperties);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.inputID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PropertyListView";
            this.Text = "Property List";
            ((System.ComponentModel.ISupportInitialize)(this.Owners)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Owners_AddNew(object sender, DataGridViewRowEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.TextBox inputID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnShowProperties;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridView Owners;
        private System.Windows.Forms.Button btnAddOwner;
        private Button btnAddProperty;
        private Button btnFindProperty;
        private Button btnDeleteProperty;
        private Button btnRemoveOwner;
    }
}