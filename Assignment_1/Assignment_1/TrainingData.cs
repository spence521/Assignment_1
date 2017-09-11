using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class TrainingData
    {
        public bool FirstBigger { get; set; }
        public bool MiddleName { get; set; }
        public bool FirstStartEnd { get; set; } //first name starts and ends with the same letter
        public bool FirstAlpha { get; set; } //First name is alphabettically before the last
        public bool FirstVowel { get; set; }
        public bool LastEven { get; set; }
        public char Label { get; set; }

        public TrainingData(bool firstNameBigger, bool hasMiddleName, bool firstStartEndSameLetter, bool firstAlphaBeforeLast, bool firstNameSecondLetterVowel, bool lastNameEven, char label)
        {
            FirstBigger = firstNameBigger;
            MiddleName = hasMiddleName;
            FirstStartEnd = firstStartEndSameLetter;
            FirstAlpha = firstAlphaBeforeLast;
            FirstVowel = firstNameSecondLetterVowel;
            LastEven = lastNameEven;
            Label = label;
        }


    }
}
