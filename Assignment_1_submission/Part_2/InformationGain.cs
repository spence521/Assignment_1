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

        public double FirstPeriod { get; set; } //first name has period
        public double MiddlePeriod { get; set; } //middle name has period
        public double FirstHyphen { get; set; } //first name has hyphen
        public double LastHyphen { get; set; } //last name has hyphen
        public double FirstEven { get; set; } //first name has even letters
        public double MiddleEven { get; set; }  //middle name has even letters
        public double FirstBigger4 { get; set; } //first name is bigger than four letters
        public double LastBigger4 { get; set; } //last name is bigger than four letters
        public double LastStartEnd { get; set; } //last name starts and ends with the same letter
        public double MiddleStartEnd { get; set; } //middle name starts and ends with the same letter
        public double Last2ndVowel { get; set; } // second letter of last name is a vowel
        public double First3rdVowel { get; set; } // third letter of first name is a vowel
        public double Last3rdVowel { get; set; } // third letter of last name is a vowel
        public double ThreeSpaces { get; set; } // the entire name has at least three spaces

        public InformationGain(double firstBigger, double midleName, double firstStartEnd, double firstAlpha, double firstVowel, double lastEven,
            double firstPeriod, double middlePeriod, double firstHyphen, double lastHyphen, double firstEven, double middleEven, double firstBigger4,
            double lastBigger4, double lastStartEnd, double middleStartEnd, double last2ndVowel, double first3rdVowel, double last3rdVowel, double threeSpaces)
        {
            FirstBigger = firstBigger;
            MiddleName = midleName;
            FirstStartEnd = firstStartEnd;
            FirstAlpha = firstAlpha;
            FirstVowel = firstVowel;
            LastEven = lastEven;
            FirstPeriod = firstPeriod;
            MiddlePeriod = middlePeriod;
            FirstHyphen = firstHyphen;
            LastHyphen = lastHyphen;
            FirstEven = firstEven;
            MiddleEven = middleEven;
            FirstBigger4 = firstBigger4;
            LastBigger4 = lastBigger4;
            LastStartEnd = lastStartEnd;
            MiddleStartEnd = middleStartEnd;
            Last2ndVowel = last2ndVowel;
            First3rdVowel = first3rdVowel;
            Last3rdVowel = last3rdVowel;
            ThreeSpaces = threeSpaces;
        }
        public InformationGain()
        {
            FirstBigger = 0;
            MiddleName = 0;
            FirstStartEnd = 0;
            FirstAlpha = 0;
            FirstVowel = 0;
            LastEven = 0;
            FirstPeriod    = 0;
            MiddlePeriod   = 0;
            FirstHyphen    = 0;
            LastHyphen     = 0;
            FirstEven      = 0;
            MiddleEven     = 0;
            FirstBigger4   = 0;
            LastBigger4    = 0;
            LastStartEnd   = 0;
            MiddleStartEnd = 0;
            Last2ndVowel   = 0;
            First3rdVowel  = 0;
            Last3rdVowel = 0;
            ThreeSpaces = 0;
        }
        public List<double> ToList()
        {
            return new List<double>
            {
                FirstBigger, MiddleName, FirstStartEnd, FirstAlpha, FirstVowel, LastEven,
                FirstPeriod, MiddlePeriod, FirstHyphen, LastHyphen,  FirstEven, MiddleEven, FirstBigger4, LastBigger4,
                LastStartEnd, MiddleStartEnd, Last2ndVowel, First3rdVowel, Last3rdVowel, ThreeSpaces
            };
        }

    }
}
