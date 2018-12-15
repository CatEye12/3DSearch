using _3DSearch.Controls;
using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _3DSearch
{

    class SearchModel
    {

        #region Properties

        [DisplayName("ID")]
        public int ID { get; set; }


        [DisplayName("Ширина")]
        public int Size1 { get; set; }

        [DisplayName("Высота")]
        public int Size2{ get; set; }


        [DisplayName("Длина")]
        public int Size3 { get; set; }


        [DisplayName("Диаметр вала-1")]
        public int DimVal1 { get; set; }


        [DisplayName("Диаметр вала-2")]
        public int DimVal2 { get; set; }


        [DisplayName("Диаметр вала-3")]
        public int DimVal3 { get; set; }


        [DisplayName("Есть локально")]
        public bool Local { get; set; }


        [DisplayName("Открыть")]
        public DataGridViewButtonColumn button { get; set; }

        #endregion


        private DataGridViewButtonColumn buttonprototype;
        public SearchModel()
        {
            buttonprototype = new DataGridViewButtonColumn();
            buttonprototype.UseColumnTextForButtonValue = true;
            buttonprototype.Text = "Открыть";
        
        }

        private SQLRepositoryDataContext dataSearch;


        public List<SearchModel> SearchSimilar()
        {

            List<SearchModel> showable;

            using (dataSearch = new SQLRepositoryDataContext(Properties.Settings.Default.SQLConnection1))
            {
                showable = new List<SearchModel>();

                foreach (KindaRepository item in dataSearch.KindaRepositories)
                {

                    showable.Add(new SearchModel()
                    {
                        ID = item.Id,
                        Size1 = item.Size1,
                        Size2 = item.Size2,
                        Size3 = item.Size3,
                        DimVal1 = item.DimVal1,
                        DimVal2 = item.DimVal2,
                        DimVal3 = item.DimVal3,
                        Local = item.Path == string.Empty ? false : true,
                        button = buttonprototype
                    });
                }
            }

            return showable;
        }


        public List<SearchModel> SearchSimilar(double percents , int sizeX, int sizeY, int SizeZ)
        {
            SizeM _3DimensionSize = SomeHelpful.OrderSize(sizeX, sizeY, SizeZ);
            List<SearchModel> showableTable = new List<SearchModel>();


            double allowance = Allowance(_3DimensionSize.P2, _3DimensionSize.P1);
            PointM allowance1 = new PointM { LowerBound = allowance - percents, UpperBound = allowance + percents }; //10% допустимое отклонение
            allowance = Allowance(_3DimensionSize.P3, _3DimensionSize.P2);
            PointM allowance2 = new PointM { LowerBound = allowance - percents, UpperBound = allowance + percents }; //10% допустимое отклонение



            List<KindaRepository> firstSelect; //выборка по основным габаритным параметрам

            using (dataSearch = new SQLRepositoryDataContext(Properties.Settings.Default.SQLConnection1))
            {
                var table = dataSearch.KindaRepositories.ToList();

                try
                {
                    firstSelect = table.Where(
                    x =>
                    (Allowance(x.Size2, x.Size1) > allowance1.LowerBound && Allowance(x.Size2, x.Size1) < allowance1.UpperBound &&//поиск деталей соответствующим допустимому отклонению
                     Allowance(x.Size3, x.Size2) > allowance1.LowerBound && Allowance(x.Size3, x.Size2) < allowance1.UpperBound   

                  )).ToList();
                }
                catch (Exception fail)
                {
                    MessageBox.Show(fail.Message);
                    throw fail;
                }
            }

            //чтоб пользователю не отображались не нужные данные из БД, приводим выборку к другому тиму
            foreach (KindaRepository item in firstSelect)
            {

                showableTable.Add(new SearchModel()
                {
                    Size1 = item.Size1,
                    Size2 = item.Size2,
                    Size3 = item.Size3,
                    DimVal1 = item.DimVal1,
                    DimVal2 = item.DimVal2,
                    DimVal3 = item.DimVal3,
                    Local = item.Path == string.Empty ? false : true,
                    button = buttonprototype
                });
            }

            return showableTable;
        }

        private static double Allowance(int p1, int p2)
        {
            double div = p1 / (double)p2;
            double rounded = Math.Round(div, 3);

            MessageBox.Show(div.ToString() + "   " + rounded.ToString());


            return rounded;
        }

        public void OpenModelFromDB(byte[] bytes, string newName)
        {


            File.WriteAllBytes(Properties.Settings.Default.LocalPath + @"\" + newName + ".SLDPRT", bytes);


            //using (Stream file = File.OpenWrite(Properties.Settings.Default.LocalPath + @"\" + newName + ".SLDPRT"))
            //{
            //    file.Write(bytes, 0, bytes.Length);
            //}
        }


        private byte[] GetBytesFromDB(int ID)
        {
            byte[] bytes = new byte[] { };

            
            using (dataSearch = new SQLRepositoryDataContext(Properties.Settings.Default.SQLConnection1))
            {
                
               var b = dataSearch.KindaRepositories.Where(x => x.Id == ID).Select(x=>x.Model).First();
               bytes = b.ToArray();
            }
            return bytes;
        }


        public string GetPathFromDB(int ID)
        {
            string path = string.Empty;



            using (dataSearch = new SQLRepositoryDataContext(Properties.Settings.Default.SQLConnection1))
            {

                path = dataSearch.KindaRepositories.Where(x => x.Id == ID).Select(x => x.Path).First();
            }
            return path;
        }
        public bool OpenLocal(string path)
        {

            SldWorks swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");

            if (File.Exists(path))
            {
                swApp.OpenDoc(path, 1);
                return true;
            }
            else
            {
                MessageBox.Show("Failed OpenLocal()");
                return false;
            }
        }


        public void GoToGetBytes(int ID)
        {


            Byte[] modelPart = GetBytesFromDB(ID);
            if (modelPart.Count() > 0)
            {

                OpenModelFromDB(modelPart, "temp");
            }
        }
    }
}