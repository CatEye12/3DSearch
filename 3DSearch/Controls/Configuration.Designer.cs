namespace _3DSearch
{
    partial class ConfigurationControl
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
            this.lblBaseName = new System.Windows.Forms.Label();
            this.lblServName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.textBoxBaseName = new System.Windows.Forms.TextBox();
            this.textBoxServName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.buttonSaveConfiguration = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLocalPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // menuBack
            // 
            this.menuBack.Location = new System.Drawing.Point(0, 3);
            this.menuBack.Name = "menuBack";
            this.menuBack.Size = new System.Drawing.Size(106, 33);
            this.menuBack.TabIndex = 1;
            this.menuBack.Text = "<-Главное меню";
            this.menuBack.UseVisualStyleBackColor = true;
            this.menuBack.Click += new System.EventHandler(this.menuBack_Click);
            // 
            // lblBaseName
            // 
            this.lblBaseName.AutoSize = true;
            this.lblBaseName.Location = new System.Drawing.Point(21, 62);
            this.lblBaseName.Name = "lblBaseName";
            this.lblBaseName.Size = new System.Drawing.Size(66, 13);
            this.lblBaseName.TabIndex = 2;
            this.lblBaseName.Text = "База даных";
            // 
            // lblServName
            // 
            this.lblServName.AutoSize = true;
            this.lblServName.Location = new System.Drawing.Point(21, 93);
            this.lblServName.Name = "lblServName";
            this.lblServName.Size = new System.Drawing.Size(74, 13);
            this.lblServName.TabIndex = 2;
            this.lblServName.Text = "Имя сервера";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(21, 123);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(103, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Имя пользователя";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(21, 151);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(45, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Пароль";
            // 
            // textBoxBaseName
            // 
            this.textBoxBaseName.Location = new System.Drawing.Point(126, 55);
            this.textBoxBaseName.Name = "textBoxBaseName";
            this.textBoxBaseName.Size = new System.Drawing.Size(105, 20);
            this.textBoxBaseName.TabIndex = 3;
            // 
            // textBoxServName
            // 
            this.textBoxServName.Location = new System.Drawing.Point(126, 86);
            this.textBoxServName.Name = "textBoxServName";
            this.textBoxServName.Size = new System.Drawing.Size(105, 20);
            this.textBoxServName.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(126, 142);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(105, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(126, 116);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(105, 20);
            this.textBoxUserName.TabIndex = 3;
            // 
            // buttonSaveConfiguration
            // 
            this.buttonSaveConfiguration.Location = new System.Drawing.Point(138, 203);
            this.buttonSaveConfiguration.Name = "buttonSaveConfiguration";
            this.buttonSaveConfiguration.Size = new System.Drawing.Size(76, 29);
            this.buttonSaveConfiguration.TabIndex = 4;
            this.buttonSaveConfiguration.Text = "Сохранить";
            this.buttonSaveConfiguration.UseVisualStyleBackColor = true;
            this.buttonSaveConfiguration.Click += new System.EventHandler(this.buttonSaveConfiguration_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Локальный путь";
            // 
            // textBoxLocalPath
            // 
            this.textBoxLocalPath.Location = new System.Drawing.Point(126, 168);
            this.textBoxLocalPath.Name = "textBoxLocalPath";
            this.textBoxLocalPath.Size = new System.Drawing.Size(105, 20);
            this.textBoxLocalPath.TabIndex = 3;
            // 
            // ConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSaveConfiguration);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxLocalPath);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxServName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBaseName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblServName);
            this.Controls.Add(this.lblBaseName);
            this.Controls.Add(this.menuBack);
            this.Name = "ConfigurationControl";
            this.Size = new System.Drawing.Size(270, 800);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button menuBack;
        private System.Windows.Forms.Label lblBaseName;
        private System.Windows.Forms.Label lblServName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox textBoxBaseName;
        private System.Windows.Forms.TextBox textBoxServName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Button buttonSaveConfiguration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLocalPath;
    }
}
