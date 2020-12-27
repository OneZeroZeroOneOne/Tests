using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Utilities
{
    public static class TimeAdder
    {
        public static DateTime AddTimeSegment(DateTime currentTime, string timeSegment, int amount)
        {
            switch (timeSegment)
            {
                case "Day":
                    currentTime = currentTime.AddDays(amount);
                    break;
                case "Month":
                    currentTime = currentTime.AddMonths(amount);
                    break;
            }
            return currentTime;
        }
    }
}
