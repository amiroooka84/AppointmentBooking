using MD.PersianDateTime.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public static class ConvertDate
    {
        public static DateTime ConvertShamsiToMiladi(string date)
        {
            PersianDateTime persianDateTime = PersianDateTime.Parse(date);
            return persianDateTime.ToDateTime();
        }

        public static string ConvertMiladiToShamsi(this DateTime? date, string format)
        {
            PersianDateTime persianDateTime = new PersianDateTime(date);
            return persianDateTime.ToString(format);
        }
    }
}
