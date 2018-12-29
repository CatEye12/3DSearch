namespace _3DSearch
{
    partial class Search
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuBack = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxMainParams = new System.Windows.Forms.CheckBox();
            this.textBoxD3 = new System.Windows.Forms.TextBox();
            this.textBoxD2 = new System.Windows.Forms.TextBox();
            this.textBoxD1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPercents = new System.Windows.Forms.ComboBox();
            this.checkBoxSearchAll = new System.Windows.Forms.CheckBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewSearchResult = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // menuBack
            // 
            this.menuBack.Location = new System.Drawing.Point(3, 3);
            this.menuBack.Name = "menuBack";
            this.menuBack.Size = new System.Drawing.Size(103, 33);
            this.menuBack.TabIndex = 1;
            this.menuBack.Text = "<-Главное меню";
            this.menuBack.UseVisualStyleBackColor = true;
            this.menuBack.Click += new System.EventHandler(this.menuBack_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(8, 446);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(103, 33);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Искать";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxMainParams);
            this.groupBox1.Controls.Add(this.textBoxD3);
            this.groupBox1.Controls.Add(this.textBoxD2);
            this.groupBox1.Controls.Add(this.textBoxD1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxPercents);
            this.groupBox1.Controls.Add(this.checkBoxSearchAll);
            this.groupBox1.Controls.Add(this.textBoxHeight);
            this.groupBox1.Controls.Add(this.textBoxWidth);
            this.groupBox1.Controls.Add(this.textBoxLength);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 369);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры поиска:";
            // 
            // checkBoxMainParams
            // 
            this.checkBoxMainParams.AutoSize = true;
            this.checkBoxMainParams.Location = new System.Drawing.Point(22, 183);
            this.checkBoxMainParams.Name = "checkBoxMainParams";
            this.checkBoxMainParams.Size = new System.Drawing.Size(153, 21);
            this.checkBoxMainParams.TabIndex = 15;
            this.checkBoxMainParams.Text = "Только по основным";
            this.checkBoxMainParams.UseVisualStyleBackColor = true;
            this.checkBoxMainParams.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBoxD3
            // 
            this.textBoxD3.Location = new System.Drawing.Point(133, 296);
            this.textBoxD3.Name = "textBoxD3";
            this.textBoxD3.Size = new System.Drawing.Size(63, 25);
            this.textBoxD3.TabIndex = 14;
            // 
            // textBoxD2
            // 
            this.textBoxD2.Location = new System.Drawing.Point(133, 260);
            this.textBoxD2.Name = "textBoxD2";
            this.textBoxD2.Size = new System.Drawing.Size(63, 25);
            this.textBoxD2.TabIndex = 13;
            // 
            // textBoxD1
            // 
            this.textBoxD1.Location = new System.Drawing.Point(133, 224);
            this.textBoxD1.Name = "textBoxD1";
            this.textBoxD1.Size = new System.Drawing.Size(63, 25);
            this.textBoxD1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Диам. вала 3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Диам. вала 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Диам. вала 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "%";
            // 
            // comboBoxPercents
            // 
            this.comboBoxPercents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPercents.FormattingEnabled = true;
            this.comboBoxPercents.Location = new System.Drawing.Point(154, 154);
            this.comboBoxPercents.Name = "comboBoxPercents";
            this.comboBoxPercents.Size = new System.Drawing.Size(42, 25);
            this.comboBoxPercents.TabIndex = 7;
            // 
            // checkBoxSearchAll
            // 
            this.checkBoxSearchAll.AutoSize = true;
            this.checkBoxSearchAll.Location = new System.Drawing.Point(22, 154);
            this.checkBoxSearchAll.Name = "checkBoxSearchAll";
            this.checkBoxSearchAll.Size = new System.Drawing.Size(126, 21);
            this.checkBoxSearchAll.TabIndex = 6;
            this.checkBoxSearchAll.Text = "Без параметров";
            this.checkBoxSearchAll.UseVisualStyleBackColor = true;
            this.checkBoxSearchAll.CheckedChanged += new System.EventHandler(this.checkBoxSearchAll_CheckedChanged);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(96, 102);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(100, 25);
            this.textBoxHeight.TabIndex = 5;
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(96, 66);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(100, 25);
            this.textBoxWidth.TabIndex = 4;
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(96, 30);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(100, 25);
            this.textBoxLength.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Высота";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ширина";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Длина";
            // 
            // dataGridViewSearchResult
            // 
            this.dataGridViewSearchResult.AllowUserToAddRows = false;
            this.dataGridViewSearchResult.AllowUserToDeleteRows = false;
            this.dataGridViewSearchResult.AllowUserToResizeRows = false;
            this.dataGridViewSearchResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewSearchResult.Location = new System.Drawing.Point(3, 500);
            this.dataGridViewSearchResult.Name = "dataGridViewSearchResult";
            this.dataGridViewSearchResult.Size = new System.Drawing.Size(254, 288);
            this.dataGridViewSearchResult.TabIndex = 4;
            this.dataGridViewSearchResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchResult_CellClick_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Открыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewSearchResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.menuBack);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(1405, 800);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button menuBack;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewSearchResult;
        private System.Windows.Forms.CheckBox checkBoxSearchAll;
        private System.Windows.Forms.ComboBox comboBoxPercents;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxMainParams;
        private System.Windows.Forms.TextBox textBoxD3;
        private System.Windows.Forms.TextBox textBoxD2;
        private System.Windows.Forms.TextBox textBoxD1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}
