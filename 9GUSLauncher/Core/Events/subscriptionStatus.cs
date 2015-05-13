using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _9GUSLauncher.Core.Events
{
    public class subscriptionStatus
    {
        public static bool getOnlieDate(eventVar _event)
        {
            bool check = false;

            String eventDate = _event.eventDate.ToShortDateString();
            
            String nowDate = DateTime.Now.ToShortDateString();
            
            DateTime _eventDate = new DateTime();
            _eventDate = DateTime.Parse(eventDate);
            
            DateTime _nowDate = new DateTime();
            _nowDate = DateTime.Parse(nowDate);
            
            TimeSpan difference = _eventDate - _nowDate;
            double days = difference.TotalDays;

            
            if (days > 0)
            {
                check = true;
               
            }
            else if(days == 0)
            {
                /*DateTime dt = DateTime.Parse("1/1/1111 21:00:00");
                DateTime _dt = new DateTime();
                _dt = DateTime.Parse(dt.ToString("H:mm"));
                String nowTime = DateTime.Now.ToShortTimeString();
                DateTime _nowTime = new DateTime();
                _nowDate = DateTime.Parse(nowTime.ToString());

                TimeSpan timeDiff = _dt - _nowDate;

                double hours = timeDiff.TotalHours;

                if(hours > 0)
                {
                    check = true;
                }
                else if(hours == 0 || hours < 0)
                {
                    check = false;
                }*/
                check = false;
            }
            else if(days < 0)
            {
                check = false;
            }

            return check;
        }

    }
}
