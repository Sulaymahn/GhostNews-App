using System;
using System.Collections.Generic;
using System.Text;

namespace GhostNews.Utilities
{
    public static class Mathx
    {
        public static double TranslateToNewRange(double OldMin, double OldMax, double NewMin, double NewMax, double OldValue)
        {
            if(OldValue > OldMax) return NewMax;
            if (OldValue < OldMin) return OldMin;

            var oldRange = OldMax - OldMin;
            var newRange = NewMax - NewMin;
            return ((OldValue - OldMin) * newRange / oldRange) + NewMin;
        }
    }
}
