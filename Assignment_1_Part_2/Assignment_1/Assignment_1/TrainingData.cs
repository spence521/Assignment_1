using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class TrainingData
    {
        public bool FirstBigger     { get; set; }
        public bool MiddleName      { get; set; }
        public bool FirstStartEnd   { get; set; } //first name starts and ends with the same letter
        public bool FirstAlpha      { get; set; } //First name is alphabettically before the last
        public bool FirstVowel       { get; set; } // second letter of first name is a vowel
        public bool LastEven        { get; set; }
        public char Label           { get; set; }
        //Additional Features
        public bool FirstPeriod     { get; set; } //first name has period
        public bool MiddlePeriod     { get; set; } //middle name has period
        public bool FirstHyphen     { get; set; } //first name has hyphen
        public bool LastHyphen      { get; set; } //last name has hyphen
        public bool FirstEven       { get; set; } //first name has even letters
        public bool MiddleEven      { get; set; }  //middle name has even letters
        public bool FirstBigger4     { get; set; } //first name is bigger than four letters
        public bool LastBigger4     { get; set; } //last name is bigger than four letters
        public bool LastStartEnd     { get; set; } //last name starts and ends with the same letter
        public bool MiddleStartEnd  { get; set; } //middle name starts and ends with the same letter
        public bool Last2ndVowel    { get; set; } // second letter of last name is a vowel
        public bool First3rdVowel   { get; set; } // third letter of first name is a vowel
        public bool Last3rdVowel    { get; set; } // third letter of last name is a vowel
        public bool ThreeSpaces     { get; set; } // the entire name has at least three spaces



        public TrainingData(bool firstNameBigger, bool hasMiddleName, bool firstStartEndSameLetter, bool firstAlphaBeforeLast, 
            bool firstNameSecondLetterVowel, bool lastNameEven, char label, bool firstPeriod, bool middlePeriod, 
            bool firstHyphen, bool lastHyphen, bool firstEven, bool middleEven, bool firstBigger4, bool lastBigger4, bool lastStartEnd, 
            bool middleStartEnd, bool last2ndVowel, bool first3rdVowel, bool last3rdVowel, bool threeSpaces)
        {
            FirstBigger = firstNameBigger;
            MiddleName = hasMiddleName;
            FirstStartEnd = firstStartEndSameLetter;
            FirstAlpha = firstAlphaBeforeLast;
            FirstVowel = firstNameSecondLetterVowel;
            LastEven = lastNameEven;
            Label = label;
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
        public override string ToString()
        {
            return
            (FirstBigger == true ? "T " : "F ") +
            (MiddleName == true ? "T " : "F ") +
            (FirstStartEnd == true ? "T " : "F ") +
            (FirstAlpha == true ? "T " : "F ") +
            (FirstVowel == true ? "T " : "F ") +
            (LastEven == true ? "T " : "F ") +
            (FirstPeriod == true ? "T " : "F ") +
            (MiddlePeriod == true ? "T " : "F ") +
            (FirstHyphen == true ? "T " : "F ") +
            (LastHyphen == true ? "T " : "F ") +
            (FirstEven == true ? "T " : "F ") +
            (MiddleEven == true ? "T " : "F ") +
            (FirstBigger4 == true ? "T " : "F ") +
            (LastBigger4 == true ? "T " : "F ") +
            (LastStartEnd == true ? "T " : "F ") +
            (MiddleStartEnd == true ? "T " : "F ") +
            (Last2ndVowel == true ? "T " : "F ") +
            (First3rdVowel == true ? "T " : "F ") +
            (Last3rdVowel == true ? "T " : "F ") +
            (ThreeSpaces == true ? "T " : "F ") +
            Label;
        }


    }
}
