using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static SizeM OrderSize(int p1, int p2, int p3)
        {
            SizeM point = new SizeM();
            int[] values = new int[3] { p1, p2, p3 };


            point.P1 = values.Max();
            point.P3 = values.Min();
            point.P2 = values.Where(x => x != point.P1 && x != point.P3).First();

            return point;
        }
    }

    public class SizeM
    {
        public int P1;
        public int P2;
        public int P3;
    }

    public class PointM
    {
        public double LowerBound;
        public double UpperBound;
    }
}
