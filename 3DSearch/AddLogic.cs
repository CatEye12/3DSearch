using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;

namespace _3DSearch
{
    class AddLogic
    {

        SldWorks swApp;
        ModelDoc2 modelDoc;
        SQLRepositoryDataContext dataContest;



        public void InsertNewValue(KindaRepository newObject)
        {
            try
            {
                swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
                modelDoc = swApp?.ActiveDoc;
                if (modelDoc != null)
                {
                    using (dataContest = new SQLRepositoryDataContext(Properties.Settings.Default.SQLConnection1))
                    {

                        if (!dataContest.KindaRepositories.Any(x => x.Size1.Equals(newObject.Size1) && x.Size2.Equals(newObject.Size2) && x.Size3.Equals(newObject.Size3)
                        && x.DimVal1.Equals(newObject.DimVal1) && x.DimVal2.Equals(newObject.DimVal2) && x.DimVal3.Equals(newObject.DimVal3)))
                        {
                            dataContest.KindaRepositories.InsertOnSubmit(newObject);

                            dataContest.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                            dataContest.Refresh(System.Data.Linq.RefreshMode.KeepChanges);
                            System.Windows.Forms.MessageBox.Show("Сохранено");
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Такая деталь уже есть в базе данных!");
                        }
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Нету открытых документов. Откройте документ для сохранения.");
                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw ex;
            }
        }


        public bool SaveLocal(string name)
        {
            int errors = 0, warnings = 0;

            swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            modelDoc = swApp?.ActiveDoc;


            if (swApp != null)
            {

                if (modelDoc != null)
                {
                    Directory.CreateDirectory(Properties.Settings.Default.LocalPath);

                    bool saved =  modelDoc.Extension.SaveAs(Path.Combine(Properties.Settings.Default.LocalPath, name + ".SLDPRT"), 0, 0, null, ref errors, ref warnings);
                    if (errors != 0 || warnings != 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Не удалось сохранить деталь" + (swFileSaveError_e)errors + "   " + (swFileSaveWarning_e)warnings);
                    }

                    return saved;
                }
                else
                {
                    swApp.SendMsgToUser("Нету открытых документов!");
                    return false;
                }
            }
            return false;
        }


        public string GetPath()
        {
            swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            modelDoc = swApp?.ActiveDoc;


            if (swApp != null)
            {

                if (modelDoc != null)
                {
                    return modelDoc.GetPathName();
                }
                else
                {
                    swApp.SendMsgToUser("Нету открытых документов!");
                    return string.Empty;
                }
            }
            return string.Empty;
        }


        //не работает при открытом документе
        public byte[] ModelBytes(string path)
        {
            byte[] modelBytes = new byte[] { };


            if (path != string.Empty)
            {
                modelDoc = swApp?.ActiveDoc;
                swApp.CloseDoc(path);
                
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, System.IO.FileShare.ReadWrite))
                {

                    using (var reader = new BinaryReader(stream))
                    {


                        modelBytes = reader.ReadBytes((int)stream.Length);
                    }
                }
                swApp.OpenDoc(path, 1);
            }
            return modelBytes;
        }
    }
}
