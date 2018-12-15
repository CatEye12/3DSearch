namespace _3DSearch
{
    partial class AddFromFolders
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
            this.SuspendLayout();
            // 
            // menuBack
            // 
            this.menuBack.Location = new System.Drawing.Point(3, 3);
            this.menuBack.Name = "menuBack";
            this.menuBack.Size = new System.Drawing.Size(75, 33);
            this.menuBack.TabIndex = 1;
            this.menuBack.Text = "<-MainMenu";
            this.menuBack.UseVisualStyleBackColor = true;
            this.menuBack.Click += new System.EventHandler(this.menuBack_Click);
            // 
            // AddFromFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuBack);
            this.Name = "AddFromFolders";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button menuBack;
    }
}
