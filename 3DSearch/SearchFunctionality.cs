﻿using _3DSearch.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _3DSearch
{

    class SearchModel
    {

        #region Properties

        [DisplayName("ID")]
        public int ID { get; set; }


        [DisplayName("Ширина")]
        public decimal Size1 { get; set; }

        [DisplayName("Высота")]
        public decimal Size2 { get; set; }


        [DisplayName("Длина")]
        public decimal Size3 { get; set; }


        [DisplayName("Диаметр вала-1")]
        public decimal DimVal1 { get; set; }


        [DisplayName("Диаметр вала-2")]
        public decimal DimVal2 { get; set; }


        [DisplayName("Диаметр вала-3")]
        public decimal DimVal3 { get; set; }


        [DisplayName("Есть локально")]
        public bool Local { get; set; }
        #endregion

        
        public SearchModel()
        {
            
        }

        private SQLRepositoryDataContext dataSearch;


        public List<SearchModel> SearchSimilar()
        {
            List<KindaRepository> select = new List<KindaRepository>();


            using (dataSearch = new SQLRepositoryDataContext(ConfigurationSettings.SQLConnection1))
            {
                select = dataSearch.KindaRepositories.ToList();
            }

            return ConvertToVisible(select);
        }


        public List<SearchModel> SearchSimilar(int percents , SearchModel whatToSearch)
        {
            List<KindaRepository> firstSelect = new List<KindaRepository>(); //выборка по основным габаритным параметрам

            firstSelect = DBSelectByMainFeatures(percents, whatToSearch);

            if (whatToSearch.DimVal1 != 0 || whatToSearch.DimVal2 != 0 || whatToSearch.DimVal3 !=0)
            {
                firstSelect = DBSelectBySubFeatures(percents, whatToSearch, firstSelect);//значение переменной перезапишется
            }            
            
            return ConvertToVisible(firstSelect);
        }

        /// <summary>
        /// Приводим выборку к другому тиму, чтоб пользователю не отображались не нужные данные из БД
        /// </summary>
        /// <param name="firstSelect"></param>
        /// <returns></returns>
        public List<SearchModel> ConvertToVisible(List<KindaRepository> firstSelect)
        {
            bool withFirstDim = false, withSecondDim = false, withThirdDim = false;
            List<SearchModel> showableTable = new List<SearchModel>();

            withFirstDim = firstSelect.Any(x => x.DimVal1 > 0);
            if (withFirstDim)
                withSecondDim = firstSelect.Any(x => x.DimVal2 > 0);
            if (withSecondDim)
                withThirdDim = firstSelect.Any(x => x.DimVal3 > 0);

            if (withThirdDim)
            {
                foreach (KindaRepository item in firstSelect)
                {

                    showableTable.Add(new SearchModel()
                    {
                        ID = item.Id,
                        Size1 = item.Size1,
                        Size2 = item.Size2,
                        Size3 = item.Size3,
                        DimVal1 = item.DimVal1,
                        DimVal2 = item.DimVal2,
                        DimVal3 = item.DimVal3,
                        Local = item.Path == string.Empty ? false : true
                    });
                }
            }
            else if (withSecondDim)
            {
                foreach (KindaRepository item in firstSelect)
                {

                    showableTable.Add(new SearchModel()
                    {
                        ID = item.Id,
                        Size1 = item.Size1,
                        Size2 = item.Size2,
                        Size3 = item.Size3,
                        DimVal1 = item.DimVal1,
                        DimVal2 = item.DimVal2,
                        Local = item.Path == string.Empty ? false : true
                    });
                }
            }
            else if (withFirstDim)
            {
                foreach (KindaRepository item in firstSelect)
                {

                    showableTable.Add(new SearchModel()
                    {
                        ID = item.Id,
                        Size1 = item.Size1,
                        Size2 = item.Size2,
                        Size3 = item.Size3,
                        DimVal1 = item.DimVal1,
                        Local = item.Path == string.Empty ? false : true
                    });
                }
            }
            else
            {
                foreach (KindaRepository item in firstSelect)
                {

                    showableTable.Add(new SearchModel()
                    {
                        ID = item.Id,
                        Size1 = item.Size1,
                        Size2 = item.Size2,
                        Size3 = item.Size3,
                        Local = item.Path == string.Empty ? false : true
                    });
                }
            }



            return showableTable;
        }

        private List<KindaRepository> DBSelectByMainFeatures(int percents, SearchModel whatToSearch)
        {
            List<KindaRepository> firstSelect = new List<KindaRepository>();
            SizeM _3DimensionSize = SomeHelpful.OrderSize(whatToSearch.Size1, whatToSearch.Size2, whatToSearch.Size3);


            decimal allowance = Allowance(_3DimensionSize.P2, _3DimensionSize.P1);
            decimal percentsCalculated = Percents(percents);


            PointM allowance1 = new PointM { LowerBound = allowance - percentsCalculated, UpperBound = allowance + percentsCalculated }; //10% допустимое отклонение
            allowance = Allowance(_3DimensionSize.P3, _3DimensionSize.P2);
            PointM allowance2 = new PointM { LowerBound = allowance - percentsCalculated, UpperBound = allowance + percentsCalculated }; //10% допустимое отклонение




            using (dataSearch = new SQLRepositoryDataContext(ConfigurationSettings.SQLConnection1))
            {
                if (dataSearch != null)
                {
                    var table = dataSearch.KindaRepositories.ToList();

                    try
                    {
                        firstSelect = table.Where(
                        x =>
                        (Allowance(x.Size2, x.Size1) >= allowance1.LowerBound && Allowance(x.Size2, x.Size1) <= allowance1.UpperBound &&//поиск деталей соответствующим допустимому отклонению
                         Allowance(x.Size3, x.Size2) >= allowance2.LowerBound && Allowance(x.Size3, x.Size2) <= allowance2.UpperBound

                      )).ToList();
                    }
                    catch (Exception fail)
                    {
                        MessageBox.Show(fail.Message);
                        throw fail;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Не удалось установить подключение к базе даных. Проверте строку подключения и настройки сети!");
                }
            }

            return firstSelect;
        }

        /// <summary>
        /// Поиск по дополнительным параметрам, проводиться не на таблице из БД, а на списке обьектов выбранных по основным габаритам
        /// </summary>
        /// <param name="percents"></param>
        /// <param name="whatToSearch"></param>
        /// <param name="tableAlreadySelectedOnce"></param>
        /// <returns></returns>
        private List<KindaRepository> DBSelectBySubFeatures(int percents, SearchModel whatToSearch, List<KindaRepository> tableAlreadySelectedOnce)
        {
            List<KindaRepository> secondSelect = new List<KindaRepository>();

            SizeM _3DimensionSize = SomeHelpful.OrderSize(whatToSearch.Size1, whatToSearch.Size2, whatToSearch.Size3);


            decimal allowance;
            decimal percentsCalculated = Percents(percents);
            SizeM _3DiamVals = SomeHelpful.OrderSize(whatToSearch.DimVal1, whatToSearch.DimVal2, whatToSearch.DimVal3);


            if (_3DiamVals.P3 == 0 && _3DiamVals.P2 == 0 && _3DiamVals.P1 != 0)// задан один диаметр вала
            {
                allowance = Allowance(_3DiamVals.P1, _3DimensionSize.P1);
                PointM allowance1 = new PointM { LowerBound = allowance - percentsCalculated, UpperBound = allowance + percentsCalculated };

                secondSelect = tableAlreadySelectedOnce.Where(
                                    x =>x.DimVal1 > 0 &&
                                (Allowance(x.DimVal1, x.Size1) >= allowance1.LowerBound && Allowance(x.DimVal1, x.Size1) <= allowance1.UpperBound)).ToList();
            }
            else if (_3DiamVals.P3 == 0 && _3DiamVals.P2 != 0 && _3DiamVals.P1 != 0)// задано два диаметра вала
            {
                allowance = Allowance(_3DiamVals.P1, _3DimensionSize.P1);
                PointM allowance1 = new PointM { LowerBound = allowance - percentsCalculated, UpperBound = allowance + percentsCalculated };
                allowance = Allowance(_3DiamVals.P2, _3DimensionSize.P2);
                PointM allowance2 = new PointM { LowerBound = allowance - percentsCalculated, UpperBound = allowance + percentsCalculated };


                secondSelect = tableAlreadySelectedOnce.Where(
                                    x =>
                                (x.DimVal1 > 0 && x.DimVal2 > 0 &&
                                    Allowance(x.DimVal1, x.Size1) >= allowance1.LowerBound && Allowance(x.DimVal1, x.Size1) <= allowance1.UpperBound &&
                                    Allowance(x.DimVal2, x.Size2)>= allowance2.LowerBound && Allowance(x.DimVal2, x.Size2) <= allowance2.UpperBound
                                
                                    )).ToList();
            }
            else if (_3DiamVals.P3 != 0 && _3DiamVals.P2 != 0 && _3DiamVals.P1 != 0) //заданы три параметра по поиску для диаметра вала
            {

                allowance = Allowance(_3DiamVals.P1, _3DimensionSize.P1);
                PointM allowance1 = new PointM { LowerBound = allowance - percentsCalculated, UpperBound = allowance + percentsCalculated };
                allowance = Allowance(_3DiamVals.P2, _3DimensionSize.P2);
                PointM allowance2 = new PointM { LowerBound = allowance - percentsCalculated, UpperBound = allowance + percentsCalculated };
                allowance = Allowance(_3DiamVals.P3, _3DimensionSize.P3);
                PointM allowance3 = new PointM { LowerBound = allowance - percentsCalculated, UpperBound = allowance + percentsCalculated };


                secondSelect = tableAlreadySelectedOnce.Where(
                                    x =>
                                (x.DimVal1 > 0 && x.DimVal2 > 0 && x.DimVal3 > 0 &&
                                    Allowance(x.DimVal1, x.Size1) >= allowance1.LowerBound && Allowance(x.DimVal1, x.Size1) <= allowance1.UpperBound &&
                                    Allowance(x.DimVal2, x.Size2) >= allowance2.LowerBound && Allowance(x.DimVal2, x.Size2) <= allowance2.UpperBound &&
                                    Allowance(x.DimVal3, x.Size3) >= allowance3.LowerBound && Allowance(x.DimVal3, x.Size3) <= allowance3.UpperBound

                                    )).ToList();
            }

            return secondSelect;
        }

        private static decimal Percents(int p)
        {
            return (100 - p)/100m;
        }
        private static decimal Allowance(decimal p1, decimal p2)
        {
            return Math.Round((p1 / p2), 3);
        }

        public void OpenModelFromDB(byte[] bytes, string newName)
        {

            try
            {
                File.WriteAllBytes(ConfigurationSettings.LocalPath + @"\" + newName + ".SLDPRT", bytes);
                Process.Start(ConfigurationSettings.LocalPath + @"\" + newName + ".SLDPRT");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }


        private byte[] GetBytesFromDB(int ID)
        {
            byte[] bytes = new byte[] { };

            
            using (dataSearch = new SQLRepositoryDataContext(ConfigurationSettings.SQLConnection1))
            {
                if (dataSearch != null)
                {
                    var b = dataSearch.KindaRepositories.Where(x => x.Id == ID).Select(x => x.Model).First();

                    bytes = b.ToArray();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Не удалось установить подключение к базе даных. Проверте строку подключения и настройки сети!");
                }
            }
            return bytes;
        }


        public string GetPathFromDB(int  ID)
        {
            string path = string.Empty;


            using (dataSearch = new SQLRepositoryDataContext(ConfigurationSettings.SQLConnection1))
            {
                if (dataSearch != null)
                {
                    path = dataSearch.KindaRepositories.Where(x => x.Id == ID).Select(x => x.Path).First();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Не удалось установить подключение к базе даных. Проверте строку подключения и настройки сети!");
                }
            }
            return path;
        }


        public void GoToGetBytes(int ID)
        {


            byte[] modelPart = GetBytesFromDB(ID);
            if (modelPart.Count() > 0)
            {

                OpenModelFromDB(modelPart, "temp");
            }
        }




        public void GetPartFromDB(SearchModel wasSelected)
        {
            
            string localPath;


            if (wasSelected.Local)
            {

                localPath = GetPathFromDB(wasSelected.ID);

                if (!SomeHelpful.OpenLocal(localPath))
                {
                    GoToGetBytes(wasSelected.ID);
                }
            }
            else
            {
                GoToGetBytes(wasSelected.ID);
            }
            
        }
    }
}