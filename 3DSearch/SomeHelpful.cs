using SolidWorks.Interop.sldworks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace _3DSearch.Controls
{
    public class SomeHelpful
    {

        /// <summary>
        /// Определяет значения размера модели по убыванию
        /// </summary>
        /// <param name="p1">Наибольшее</param>
        /// <param name="p2">Среднее</param>
        /// <param name="p3">Наименьшее</param>
        /// <returns></returns>
        public static SizeM OrderSize(decimal p1, decimal p2, decimal p3)
        {
            SizeM point = new SizeM();
            decimal[] values = new decimal[3] { p1, p2, p3 };

            
            point.P1 = values.Max();
            point.P3 = values.Min();

            IEnumerable< decimal> middle = values.Where(x => x != point.P1 && x != point.P3).Select(x=>x);
            if (middle.Count() == 0)
            {
                #region Если два размерных габарита совпадают
                if (values[0] == values[1])
                {
                    point.P2 = values[0];
                    return point;
                }
                else if (values[1] == values[2])
                {
                    point.P2 = values[1];
                    return point;
                }
                else
                {
                    point.P2 = values[0];
                    return point;
                }
                #endregion
            }
            else
            {
                point.P2 = middle.First();
            }

            return point;
        }

        public static bool OpenLocal(string path)
        {

            SldWorks swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");

            if (File.Exists(path))
            {
                swApp.OpenDoc(path, 1);
                return true;
            }
            else
            {
                MessageBox.Show("Файл не был найден локально!");
                return false;
            }
        }

    }

    public class SizeM
    {
        public decimal P1;
        public decimal P2;
        public decimal P3;
    }

    public class PointM
    {
        public decimal LowerBound;
        public decimal UpperBound;
    }
}
