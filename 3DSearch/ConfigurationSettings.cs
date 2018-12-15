using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _3DSearch
{
    class ConfigurationSettings
    {
        public static string BaseName = string.Empty;
        public static string ServName = string.Empty;
        public static string UserName = string.Empty;
        public static string Password = string.Empty;

        public static string LocalPath = string.Empty;
        public static string SQLConnection1 = string.Empty;


        public ConfigurationSettings()
        {
            NewMethod();
        }

        public static void NewMethod()
        {
            string configExe = Environment.CurrentDirectory + "\\3DSearch.dll.config";

            if (System.IO.File.Exists(configExe))
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = configExe;
                Configuration conf = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                SQLConnection1 = conf.AppSettings.Settings["SQLConnection1"]?.Value == null ? string.Empty : conf.AppSettings.Settings["SQLConnection1"]?.Value;


                LocalPath = conf.AppSettings.Settings["LocalPath"]?.Value == null ? string.Empty : conf.AppSettings.Settings["LocalPath"]?.Value;
                
            }
        }

        public void UpdateConfigurationString()
        {
            string s = @"Data Source = " + ConfigurationSettings.ServName + "; Initial Catalog = " + ConfigurationSettings.BaseName + "; User ID = " + ConfigurationSettings.UserName + "; Password = " + ConfigurationSettings.Password + "; TrustServerCertificate = True";

            string configExe = Environment.CurrentDirectory + "\\3DSearch.dll.config";
            try
            {


                if (System.IO.File.Exists(configExe))
                {
                    ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                    fileMap.ExeConfigFilename = configExe;
                    Configuration conf = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                    conf.AppSettings.Settings.Remove("SQLConnection1");
                    conf.AppSettings.Settings.Remove("SWPlusDBConnectionString");
                    conf.AppSettings.Settings.Remove("LocalPath");
                    conf.AppSettings.Settings.Remove("_3DSearch.Properties.Settings.SQLConnection1");
                    conf.AppSettings.Settings.Remove("_3DSearch.Properties.Settings.SWPlusDBConnectionString");

                    //_3DSearch.Properties.Settings.SQLConnection1
                    conf.AppSettings.Settings.Add("SQLConnection1", s);
                    conf.AppSettings.Settings.Add("SWPlusDBConnectionString", s);
                    conf.AppSettings.Settings.Add("LocalPath", ConfigurationSettings.LocalPath);

                    conf.AppSettings.Settings.Add("_3DSearch.Properties.Settings.SQLConnection1", s);
                    conf.AppSettings.Settings.Add("_3DSearch.Properties.Settings.SWPlusDBConnectionString", s);
                    conf.Save(ConfigurationSaveMode.Full);

                    NewMethod();

                }
            }
            catch (ConfigurationErrorsException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.BareMessage);
            }
        }


        public static void ReturnSettings(ref string baseName, ref string servName, ref string userName, ref string password, ref string localPath)
        {

            string conString = ConfigurationSettings.SQLConnection1;
            if (conString != null)
            {
                string[] parced = conString.Split(';');


                baseName = parced[0].Split('=')[1];
                servName = parced[1].Split('=')[1];
                userName = parced[2].Split('=')[1];
                password = parced[3].Split('=')[1];
                localPath = ConfigurationSettings.LocalPath;
            }
        }

        public static bool IsServerConnected()
        {
            using (var l_oConnection = new SqlConnection(ConfigurationSettings.SQLConnection1))
            {
                try
                {
                    l_oConnection.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return false;
                }
                finally
                {
                    l_oConnection.Dispose();
                }
            }
        }
    }
}