using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DSearch
{
    public partial class ConfigurationControl : UserControl
    {
        string baseName = string.Empty, servName = string.Empty, userName = string.Empty, password = string.Empty, localPath = string.Empty;






        public ConfigurationControl()
        {
            InitializeComponent();
            ConfigurationSettings.ReturnSettings(ref baseName, ref servName, ref userName, ref password, ref localPath);
            FillFormWithDefault();
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonSaveConfiguration_Click(object sender, EventArgs e)
        {
            if (CheckValues())
            {
                ConfigurationSettings newSettings = new ConfigurationSettings();

                newSettings.BaseName = textBoxBaseName.Text;
                newSettings.ServName = textBoxServName.Text;
                newSettings.UserName = textBoxUserName.Text;
                newSettings.Password = textBoxPassword.Text;
                newSettings.LocalPath = textBoxLocalPath.Text;
                newSettings.UpdateConfigurationString(newSettings);
            }
            else
            {
                MessageBox.Show("Поля заполнены не верно!\nНе удалось сохранить настройки.");
            }
        }

        private bool CheckValues()
        {
            if
            (
                 !string.IsNullOrWhiteSpace(textBoxBaseName.Text) &&
                 !string.IsNullOrWhiteSpace(textBoxServName.Text) &&
                 !string.IsNullOrWhiteSpace(textBoxUserName.Text) &&
                 !string.IsNullOrWhiteSpace(textBoxPassword.Text) &&

                 !string.IsNullOrWhiteSpace(textBoxLocalPath.Text)
            )
            { return true; }
            else return false;
        }


        private void FillFormWithDefault()
        {



            textBoxBaseName.Text = baseName;

            textBoxServName.Text = servName;

            textBoxUserName.Text = userName;
            textBoxPassword.Text = password;
            textBoxLocalPath.Text = localPath;
        }
    }
}
