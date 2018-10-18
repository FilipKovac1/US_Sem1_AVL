namespace US_Sem1_AVL
{
    partial class MainForm
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
            this.labelAllInfo = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.comboTypes = new System.Windows.Forms.ComboBox();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.comboTrees = new System.Windows.Forms.ComboBox();
            this.comboTreePrint = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelAllInfo
            // 
            this.labelAllInfo.AutoSize = true;
            this.labelAllInfo.Location = new System.Drawing.Point(13, 13);
            this.labelAllInfo.Name = "labelAllInfo";
            this.labelAllInfo.Size = new System.Drawing.Size(246, 13);
            this.labelAllInfo.TabIndex = 0;
            this.labelAllInfo.Text = "Info o programe Persons (654) Cadastral areas (10)";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(488, 415);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // comboTypes
            // 
            this.comboTypes.FormattingEnabled = true;
            this.comboTypes.Items.AddRange(new object[] {
            "Person",
            "Cadastral Area",
            "Property List",
            "Property"});
            this.comboTypes.Location = new System.Drawing.Point(12, 417);
            this.comboTypes.Name = "comboTypes";
            this.comboTypes.Size = new System.Drawing.Size(121, 21);
            this.comboTypes.TabIndex = 2;
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(139, 417);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(100, 20);
            this.textSearch.TabIndex = 3;
            this.textSearch.Text = "Search";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(385, 415);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(97, 23);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Results";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(587, 415);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(101, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // comboTrees
            // 
            this.comboTrees.FormattingEnabled = true;
            this.comboTrees.Items.AddRange(new object[] {
            "Person",
            "Cadastral Area (By ID)",
            "Cadastral Area (By Name)",
            "Property List",
            "Property"});
            this.comboTrees.Location = new System.Drawing.Point(12, 372);
            this.comboTrees.Name = "comboTrees";
            this.comboTrees.Size = new System.Drawing.Size(121, 21);
            this.comboTrees.TabIndex = 7;
            // 
            // comboTreePrint
            // 
            this.comboTreePrint.FormattingEnabled = true;
            this.comboTreePrint.Items.AddRange(new object[] {
            "PreOrder",
            "PostOrder",
            "InOrder"});
            this.comboTreePrint.Location = new System.Drawing.Point(139, 372);
            this.comboTreePrint.Name = "comboTreePrint";
            this.comboTreePrint.Size = new System.Drawing.Size(100, 21);
            this.comboTreePrint.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboTreePrint);
            this.Controls.Add(this.comboTrees);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.comboTypes);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelAllInfo);
            this.Name = "MainForm";
            this.Text = "US2_1_AVL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAllInfo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox comboTypes;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox comboTrees;
        private System.Windows.Forms.ComboBox comboTreePrint;
    }
}

