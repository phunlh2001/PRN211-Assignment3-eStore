using System;

namespace DataAccess.DaoAccess.Utils
{
    public static class BaseDate
    {
        public static DateTime GetCoupleNextDays()
        {
            var today = DateTime.Now;
            var nextTwoDays = today.AddDays(2);
            return nextTwoDays;
        }

        public static DateTime GetDateNow()
        {
            var now = DateTime.Now;
            return now;
        }

        public static DateTime GetSevenNextDays()
        {
            var today = DateTime.Now;
            var nextSevenDays = today.AddDays(7);
            return nextSevenDays;
        }
    }
}