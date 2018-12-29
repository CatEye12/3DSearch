namespace _3DSearch
{
    partial class LittlePane
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
            this.button1 = new System.Windows.Forms.Button();
            this.AddFileFromFolderButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ConfigurationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddFileFromFolderButton
            // 
            this.AddFileFromFolderButton.Enabled = false;
            this.AddFileFromFolderButton.Location = new System.Drawing.Point(20, 249);
            this.AddFileFromFolderButton.Name = "AddFileFromFolderButton";
            this.AddFileFromFolderButton.Size = new System.Drawing.Size(116, 28);
            this.AddFileFromFolderButton.TabIndex = 1;
            this.AddFileFromFolderButton.Text = "AddFileFromFolder";
            this.AddFileFromFolderButton.UseVisualStyleBackColor = true;
            this.AddFileFromFolderButton.Visible = false;
            this.AddFileFromFolderButton.Click += new System.EventHandler(this.AddFileFromFolderButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(20, 80);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(116, 28);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ConfigurationButton
            // 
            this.ConfigurationButton.Location = new System.Drawing.Point(20, 131);
            this.ConfigurationButton.Name = "ConfigurationButton";
            this.ConfigurationButton.Size = new System.Drawing.Size(116, 28);
            this.ConfigurationButton.TabIndex = 3;
            this.ConfigurationButton.Text = "Configuration";
            this.ConfigurationButton.UseVisualStyleBackColor = true;
            this.ConfigurationButton.Click += new System.EventHandler(this.ConfigurationButton_Click);
            // 
            // LittlePane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConfigurationButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.AddFileFromFolderButton);
            this.Controls.Add(this.button1);
            this.Name = "LittlePane";
            this.Size = new System.Drawing.Size(286, 436);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AddFileFromFolderButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ConfigurationButton;
    }
}
