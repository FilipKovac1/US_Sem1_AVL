using System;
using System.Windows.Forms;

namespace US_Sem1_AVL.GUI
{
    partial class PropertiesView
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
            this.propertyBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.propertyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.propertyBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridProperties = new System.Windows.Forms.DataGridView();
            this.propertyBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.propertyBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyBindingSource2
            // 
            this.propertyBindingSource2.DataSource = typeof(Model.Property);
            // 
            // propertyBindingSource
            // 
            this.propertyBindingSource.DataSource = typeof(Model.Property);
            // 
            // propertyBindingSource1
            // 
            this.propertyBindingSource1.DataSource = typeof(Model.Property);
            // 
            // dataGridProperties
            // 
            this.dataGridProperties.AllowUserToAddRows = false;
            this.dataGridProperties.AllowUserToDeleteRows = false;
            this.dataGridProperties.AllowUserToOrderColumns = true;
            this.dataGridProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProperties.Location = new System.Drawing.Point(12, 12);
            this.dataGridProperties.Name = "dataGridProperties";
            this.dataGridProperties.ReadOnly = true;
            this.dataGridProperties.Size = new System.Drawing.Size(802, 455);
            this.dataGridProperties.TabIndex = 0;
            this.dataGridProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProperties_RowClick);
            // 
            // propertyBindingSource3
            // 
            this.propertyBindingSource3.DataSource = typeof(Model.Property);
            // 
            // PropertiesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 479);
            this.Controls.Add(this.dataGridProperties);
            this.Name = "PropertiesView";
            this.Text = "Properties";
            ((System.ComponentModel.ISupportInitialize)(this.propertyBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyBindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource propertyBindingSource;
        private System.Windows.Forms.BindingSource propertyBindingSource1;
        private System.Windows.Forms.BindingSource propertyBindingSource2;
        private System.Windows.Forms.DataGridView dataGridProperties;
        private System.Windows.Forms.BindingSource propertyBindingSource3;
    }
}