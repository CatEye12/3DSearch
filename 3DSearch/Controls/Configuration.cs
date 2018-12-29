using System;
using System.Windows.Forms;

namespace _3DSearch
{
    public partial class ConfigurationControl : UserControl
    {
        string baseName = string.Empty, servName = string.Empty, userName = string.Empty, password = string.Empty, localPath = string.Empty;



        public ConfigurationControl()
        {
            InitializeComponent();
            ConfigurationSettings.NewMethod();
            ConfigurationSettings.ReturnSettings(ref baseName, ref servName, ref userName, ref password, ref localPath);
            FillFormWithDefault();
        }

        
        private void buttonCheckConnection_Click(object sender, EventArgs e)
        {
            if (ConfigurationSettings.IsServerConnected())
            {
                MessageBox.Show("Подключение прошло успешно.");
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к серверу!");
            }
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

                ConfigurationSettings.BaseName = textBoxBaseName.Text;
                ConfigurationSettings.ServName = textBoxServName.Text;
                ConfigurationSettings.UserName = textBoxUserName.Text;
                ConfigurationSettings.Password = textBoxPassword.Text;
                ConfigurationSettings.LocalPath = textBoxLocalPath.Text;
                newSettings.UpdateConfigurationString();
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
