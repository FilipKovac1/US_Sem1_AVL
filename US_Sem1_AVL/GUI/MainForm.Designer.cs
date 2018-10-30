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
            this.labelPersons = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.comboTypes = new System.Windows.Forms.ComboBox();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.comboPType = new System.Windows.Forms.ComboBox();
            this.dataGridPerson = new System.Windows.Forms.DataGridView();
            this.labelCACount = new System.Windows.Forms.Label();
            this.dataGridCA = new System.Windows.Forms.DataGridView();
            this.comboCAType = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCA)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPersons
            // 
            this.labelPersons.AutoSize = true;
            this.labelPersons.Location = new System.Drawing.Point(10, 41);
            this.labelPersons.Name = "labelPersons";
            this.labelPersons.Size = new System.Drawing.Size(85, 13);
            this.labelPersons.TabIndex = 0;
            this.labelPersons.Text = "Persons (Count):";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(401, 517);
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
            this.comboTypes.Location = new System.Drawing.Point(13, 519);
            this.comboTypes.Name = "comboTypes";
            this.comboTypes.Size = new System.Drawing.Size(121, 21);
            this.comboTypes.TabIndex = 2;
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(140, 519);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(146, 20);
            this.textSearch.TabIndex = 3;
            this.textSearch.Text = "Search";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(298, 517);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(97, 23);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(500, 517);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(101, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Delete";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // comboPType
            // 
            this.comboPType.FormattingEnabled = true;
            this.comboPType.Items.AddRange(new object[] {
            "PreOrder",
            "PostOrder",
            "InOrder"});
            this.comboPType.Location = new System.Drawing.Point(672, 38);
            this.comboPType.Name = "comboPType";
            this.comboPType.Size = new System.Drawing.Size(100, 21);
            this.comboPType.TabIndex = 8;
            this.comboPType.SelectedIndexChanged += new System.EventHandler(this.comboPType_SelectedIndexChanged);
            // 
            // dataGridPerson
            // 
            this.dataGridPerson.AllowUserToAddRows = false;
            this.dataGridPerson.AllowUserToDeleteRows = false;
            this.dataGridPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPerson.Location = new System.Drawing.Point(13, 66);
            this.dataGridPerson.Name = "dataGridPerson";
            this.dataGridPerson.Size = new System.Drawing.Size(759, 212);
            this.dataGridPerson.TabIndex = 9;
            this.dataGridPerson.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPerson_CellClick);
            // 
            // labelCACount
            // 
            this.labelCACount.AutoSize = true;
            this.labelCACount.Location = new System.Drawing.Point(10, 287);
            this.labelCACount.Name = "labelCACount";
            this.labelCACount.Size = new System.Drawing.Size(124, 13);
            this.labelCACount.TabIndex = 10;
            this.labelCACount.Text = "Cadastral Areas (Count) :";
            // 
            // dataGridCA
            // 
            this.dataGridCA.AllowUserToAddRows = false;
            this.dataGridCA.AllowUserToDeleteRows = false;
            this.dataGridCA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCA.Location = new System.Drawing.Point(12, 311);
            this.dataGridCA.Name = "dataGridCA";
            this.dataGridCA.Size = new System.Drawing.Size(759, 200);
            this.dataGridCA.TabIndex = 11;
            this.dataGridCA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCA_CellClick);
            // 
            // comboCAType
            // 
            this.comboCAType.FormattingEnabled = true;
            this.comboCAType.Items.AddRange(new object[] {
            "PreOrder",
            "PostOrder",
            "InOrder"});
            this.comboCAType.Location = new System.Drawing.Point(671, 284);
            this.comboCAType.Name = "comboCAType";
            this.comboCAType.Size = new System.Drawing.Size(100, 21);
            this.comboCAType.TabIndex = 12;
            this.comboCAType.SelectedIndexChanged += new System.EventHandler(this.comboCAType_SelectedIndexChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(671, 517);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test Structure";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(786, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readFileToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // readFileToolStripMenuItem
            // 
            this.readFileToolStripMenuItem.Name = "readFileToolStripMenuItem";
            this.readFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.readFileToolStripMenuItem.Text = "Read From";
            this.readFileToolStripMenuItem.Click += new System.EventHandler(this.readFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 551);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.comboCAType);
            this.Controls.Add(this.dataGridCA);
            this.Controls.Add(this.labelCACount);
            this.Controls.Add(this.dataGridPerson);
            this.Controls.Add(this.comboPType);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.comboTypes);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.labelPersons);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "US2_1_AVL";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCA)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPersons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox comboTypes;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox comboPType;
        private System.Windows.Forms.DataGridView dataGridPerson;
        private System.Windows.Forms.Label labelCACount;
        private System.Windows.Forms.DataGridView dataGridCA;
        private System.Windows.Forms.ComboBox comboCAType;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}

