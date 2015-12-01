using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaster
{
    static class Methods
    {
        /// <summary>
        /// Removes contiguous sequences of whitespaces of a string.
        /// </summary>
        /// <param name="s">The string to normalize.</param>
        public static string Norma(this string s)
        {
            int i, j, k;
            for (i = 0; i < s.Length && s[i] == ' '; ++i) ;
            for (j = s.Length - 1; j > i && s[j] == ' '; --j) ;
            StringBuilder sb = new StringBuilder();
            bool space = false;
            for (k = i; k <= j; ++k)
            {
                if (s[k] == ' ')
                {
                    if (!space)
                    {
                        sb.Append(s[k]);
                        space = true;
                    }
                }
                else
                {
                    sb.Append(s[k]);
                    space = false;
                }
            }
            return sb.ToString();
        }
    }
    static class Time
    {
        public const int MINS_PER_HOUR = 60,
            HOURS_PER_DAY = 24,
            DAYS_PER_WEEK = 7;
        public static int ToTime(this string s, bool military = true)
        {
            int hr, min;
            string[] sp;
            if (!military)
            {
                string suffix = s.Substring(s.Length - 2);
                sp = s.Substring(0, s.Length - 2).Split(':');
                hr = int.Parse(sp[0]);
                min = int.Parse(sp[1]);
                if (hr == 12) hr = 0;
                if (suffix == "PM")
                {
                    hr += 12;
                }

            }
            else
            {
                sp = s.Split(':');
                hr = int.Parse(sp[0]);
                min = int.Parse(sp[1]);
            }
            return hr * MINS_PER_HOUR + min;
        }
    }
}
