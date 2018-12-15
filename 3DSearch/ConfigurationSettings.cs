using _3DSearch.Properties;
using System;
using System.Configuration;

namespace _3DSearch
{
    class ConfigurationSettings
    {
        public string BaseName;
        public string ServName;
        public string UserName;
        public string Password;
        public string LocalPath;

        

        public void UpdateConfigurationString(ConfigurationSettings newC)
        {
            Configuration config;

            string s = @"Data Source = " + newC.ServName + "; Initial Catalog = " + newC.BaseName + "; User ID = " + newC.UserName + "; Password = " + newC.Password + "; TrustServerCertificate = True";
           
            string exeConfigPath = this.GetType().Assembly.Location;

            try
            {
                config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
                config.AppSettings.Settings.Add("SQLConnection1", s);
                config.AppSettings.Settings.Add("LocalPath", newC.LocalPath);
                config.Save(ConfigurationSaveMode.Minimal);


                Settings.Default.PropertyValues["SQLConnection1"].PropertyValue = s;
                Settings.Default.PropertyValues["LocalPath"].PropertyValue = newC.LocalPath;
                Settings.Default.Save();
                System.Windows.Forms.MessageBox.Show(s);
            }
            catch (ConfigurationErrorsException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.BareMessage);
            }
        }


        public static void ReturnSettings(ref string baseName, ref string servName, ref string userName, ref string password, ref string localPath)
        {

            string conString = Settings.Default.SQLConnection1;
            string[] parced = conString.Split(';');


            baseName = parced[0].Split('=')[1];
            servName = parced[1].Split('=')[1];
            userName = parced[2].Split('=')[1];
            password = parced[3].Split('=')[1];
            localPath = Settings.Default.LocalPath;
        }
    }
}