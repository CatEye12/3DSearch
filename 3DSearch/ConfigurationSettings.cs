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

                SQLConnection1 = conf.ConnectionStrings.ConnectionStrings["_3DSearch.Properties.Settings.SQLConnection1"] == null ? string.Empty : conf.ConnectionStrings.ConnectionStrings["_3DSearch.Properties.Settings.SQLConnection1"].ToString();

                ClientSettingsSection localPathSect = (ClientSettingsSection)conf.SectionGroups["applicationSettings"].Sections["_3DSearch.Properties.Settings"];
                LocalPath = localPathSect.Settings.Get("LocalPath").Value.ValueXml.InnerText;
            }
        }

        public void UpdateConfigurationString()
        {
            string s = @"Data Source =" + ConfigurationSettings.ServName + "; Initial Catalog =" + ConfigurationSettings.BaseName + "; User ID =" + ConfigurationSettings.UserName + "; Password =" + ConfigurationSettings.Password + "; TrustServerCertificate = True";

            string configExe = Environment.CurrentDirectory + "\\3DSearch.dll.config";
            try
            {

                if (System.IO.File.Exists(configExe))
                {
                    ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                    fileMap.ExeConfigFilename = configExe;
                    Configuration conf = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);


                    conf.ConnectionStrings.ConnectionStrings["_3DSearch.Properties.Settings.SQLConnection1"].ConnectionString = s;
                    ClientSettingsSection localPathSect = (ClientSettingsSection)conf.SectionGroups["applicationSettings"].Sections["_3DSearch.Properties.Settings"];
                    localPathSect.Settings.Get("LocalPath").Value.ValueXml.InnerText = ConfigurationSettings.LocalPath;

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
                    if (baseName.Contains(" ")) { baseName.Replace(' ', (char)0); }

                servName = parced[1].Split('=')[1];
                    if (servName.Contains(" ")) { servName.Replace(' ', (char)0); }


                userName = parced[2].Split('=')[1];
                    if (userName.Contains(" ")) { userName.Replace(' ', (char)0); }

                password = parced[3].Split('=')[1];
                    if (password.Contains(" ")) { password.Replace(' ', (char)0); }

                localPath = ConfigurationSettings.LocalPath;
                    if (localPath.Contains(" ")) { localPath.Replace(' ', (char)0); }
            }
        }

        public static bool IsServerConnected()
        {
            using (var l_oConnection = new SqlConnection(ConfigurationSettings.SQLConnection1))
            {
                if (l_oConnection != null)
                {
                    try
                    {
                        l_oConnection.Open();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        return false;
                    }
                    finally
                    {
                        l_oConnection.Dispose();
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Не удалось получить доступ к базе данных. Проверте строку подключения и сетевые настройки");
                    return false;
                }
            }
        }
    }
}