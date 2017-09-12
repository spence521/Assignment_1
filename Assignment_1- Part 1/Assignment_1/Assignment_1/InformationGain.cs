using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class InformationGain
    {
        public double FirstBigger { get; set; }
        public double MiddleName { get; set; }
        public double FirstStartEnd { get; set; }
        public double FirstAlpha { get; set; }
        public double FirstVowel { get; set; }
        public double LastEven { get; set; }

        public InformationGain(double firstBigger, double midleName, double firstStartEnd, double firstAlpha, double firstVowel, double lastEven)
        {
            FirstBigger = firstBigger;
            MiddleName = midleName;
            FirstStartEnd = firstStartEnd;
            FirstAlpha = firstAlpha;
            FirstVowel = firstVowel;
            LastEven = lastEven;
        }
        public InformationGain()
        {
            FirstBigger = 0;
            MiddleName = 0;
            FirstStartEnd = 0;
            FirstAlpha = 0;
            FirstVowel = 0;
            LastEven = 0;
        }
        public List<double> ToList()
        {
            return new List<double> { FirstBigger, MiddleName, FirstStartEnd, FirstAlpha, FirstVowel, LastEven};
        }

    }
}
