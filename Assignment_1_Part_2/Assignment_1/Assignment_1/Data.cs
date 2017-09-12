using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using static System.Math;

namespace Assignment_1
{
    public class Data
    {
        //public StreamReader reader { get; set; }
       // public StreamReader reader_2 { get; set; }
        public List<Entry> data_1 { get; private set; }
        public List<TrainingData> trainingData { get; private set; }
        public List<Entry> data_2 { get; private set; }
        public List<TrainingData> testData { get; private set; }
        public DecisionTree Tree { get; set; }
        public DecisionTree Tree2 { get; set; }
        public DecisionTree Tree3 { get; set; }
        public DecisionTree Tree4 { get; set; }
        public int Depth { get; set; }
        public double Error { get; set; }

        public Data(StreamReader r, StreamReader r2, int depth)
        {
            data_1 = new List<Entry>();
            trainingData = new List<TrainingData>();
            data_2 = new List<Entry>();
            testData = new List<TrainingData>();
            SetData(r, r2);
            SetTrainingData(r2);
            List<TrainingData> trainingDataHelper = trainingData;
            Tree = new DecisionTree(ref trainingDataHelper, depth);
            Tree.CollapseTree();
            if (r2 != null)
            {
                List<TrainingData> testDataHelper = testData;
                Error = (Convert.ToDouble(Tree.DetermineError(ref testDataHelper)) / Convert.ToDouble(testData.Count)) * 100;
            }
            Depth = Tree.DetermineDepth(0);
        }
        public Data(StreamReader r1, StreamReader r2, StreamReader r3, StreamReader r4, int depth)
        {
            double temp_error1;
            double temp_error2;
            double temp_error3; 
            double temp_error4;
            
            #region First Fold
            data_1 = new List<Entry>();
            trainingData = new List<TrainingData>();
            data_2 = new List<Entry>();
            testData = new List<TrainingData>();
            
            SetData(r1, r4);
            SetData(r2);
            SetData(r3);
            SetTrainingData(r4);

            List<TrainingData> trainingDataHelper = trainingData;
            Tree = new DecisionTree(ref trainingDataHelper, depth);
            Tree.CollapseTree();
            List<TrainingData> testDataHelper = testData;
            temp_error1 = (Convert.ToDouble(Tree.DetermineError(ref testDataHelper)) / Convert.ToDouble(testData.Count)) * 100;
            #endregion
            
            #region Second Fold
            data_1 = new List<Entry>();
            trainingData = new List<TrainingData>();
            data_2 = new List<Entry>();
            testData = new List<TrainingData>();
            
            SetData(r1, r3);
            SetData(r2);
            SetData(r4);
            SetTrainingData(r3);

            trainingDataHelper = trainingData;
            Tree2 = new DecisionTree(ref trainingDataHelper, depth);
            Tree2.CollapseTree();
            testDataHelper = testData;
            temp_error2 = (Convert.ToDouble(Tree2.DetermineError(ref testDataHelper)) / Convert.ToDouble(testData.Count)) * 100;
            #endregion

            #region Third Fold
            data_1 = new List<Entry>();
            trainingData = new List<TrainingData>();
            data_2 = new List<Entry>();
            testData = new List<TrainingData>();
            
            SetData(r1, r2);
            SetData(r3);
            SetData(r4);
            SetTrainingData(r2);

            trainingDataHelper = trainingData;
            Tree3 = new DecisionTree(ref trainingDataHelper, depth);
            Tree3.CollapseTree();
            testDataHelper = testData;
            temp_error3 = (Convert.ToDouble(Tree3.DetermineError(ref testDataHelper)) / Convert.ToDouble(testData.Count)) * 100;
            #endregion

            #region Fourth Fold
            data_1 = new List<Entry>();
            trainingData = new List<TrainingData>();
            data_2 = new List<Entry>();
            testData = new List<TrainingData>();
            
            SetData(r2, r1);
            SetData(r3);
            SetData(r4);
            SetTrainingData(r1);

            trainingDataHelper = trainingData;
            Tree4 = new DecisionTree(ref trainingDataHelper, depth);
            Tree4.CollapseTree();
            testDataHelper = testData;
            temp_error4 = (Convert.ToDouble(Tree4.DetermineError(ref testDataHelper)) / Convert.ToDouble(testData.Count)) * 100;
            #endregion

            //Console.WriteLine(temp_error1);
            //Console.WriteLine(temp_error2);
            //Console.WriteLine(temp_error3);
            //Console.WriteLine(temp_error4);
            Error = (temp_error1 + temp_error2 + temp_error3 + temp_error4) / 4;
        }
        public void SetData(StreamReader reader, StreamReader reader_2 = null)
        {
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                char Sign;
                string First_Name;
                string Middle_Name = "";
                string Last_Name;
                string[] splitstring = line.Split();
                Sign = splitstring.First().First();
                First_Name = splitstring[1];
                Last_Name = splitstring.Last();
                if (splitstring.Length >  3) //then there is a middle name
                {
                    int p = splitstring.Length - 3;
                    for (int i = 2; i < p+2; i++)
                    {
                        Middle_Name += splitstring[i] + " ";
                    }
                    Middle_Name = Middle_Name.Substring(0, Middle_Name.Length - 1);
                }
                data_1.Add(new Entry(Sign, First_Name, Middle_Name, Last_Name));
            }
            if (reader_2 != null)
            {
                reader_2.DiscardBufferedData();
                reader_2.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                string line2;
                while ((line2 = reader_2.ReadLine()) != null)
                {
                    char Sign;
                    string First_Name;
                    string Middle_Name = "";
                    string Last_Name;
                    string[] splitstring = line2.Split();
                    Sign = splitstring.First().First();
                    First_Name = splitstring[1];
                    Last_Name = splitstring.Last();
                    if (splitstring.Length > 3) //then there is a middle name
                    {
                        int p = splitstring.Length - 3;
                        for (int i = 2; i < p + 2; i++)
                        {
                            Middle_Name += splitstring[i] + " ";
                        }
                        Middle_Name = Middle_Name.Substring(0, Middle_Name.Length - 1);
                    }
                    data_2.Add(new Entry(Sign, First_Name, Middle_Name, Last_Name));
                }
            }
        }
        public void PrintData1()
        {
            int i = 1;
            foreach (var item in data_1)
            {
                Console.WriteLine(i + "\t" + item.Sign + " " + item.First_Name + " " + item.Middle_Name + " " + item.Last_Name);
                i++;
            }
        }
        public void PrintData2()
        {
            int i = 1;
            foreach (var item in data_2)
            {
                Console.WriteLine(i + "\t" + item.Sign + " " + item.First_Name + " " + item.Middle_Name + item.Last_Name);
                i++;
            }
        }

        public void SetTrainingData(StreamReader reader_2 = null)
        {
            foreach (var item in data_1)
            {
                trainingData.Add(new TrainingData(FirstNameBigger(item.First_Name, item.Last_Name),
                    MiddleName(item.Middle_Name),
                    FirstStartEndSameLetter(item.First_Name),
                    FirstAlphaBeforeLast(item.First_Name, item.Last_Name),
                    SecondLetterVowel(item.First_Name),
                    NameEven(item.Last_Name),
                    item.Sign, 
                    ContainsPeriod(item.First_Name),
                    ContainsPeriod(item.Middle_Name),
                    ContainsHyphen(item.First_Name),
                    ContainsHyphen(item.Last_Name),
                    NameEven(item.First_Name),
                    MiddleEven(item.Middle_Name),
                    LengthGT4(item.First_Name),
                    LengthGT4(item.Last_Name),
                    FirstStartEndSameLetter(item.Last_Name),
                    MiddleStartEndSameLetter(item.Middle_Name),
                    SecondLetterVowel(item.Last_Name),
                    ThirdLetterVowel(item.First_Name),
                    ThirdLetterVowel(item.Last_Name),
                    ThreeSpaces(item.First_Name + " " + item.Middle_Name + " " + item.Last_Name)
                    ));
            }
            if (reader_2 != null)
            {
                foreach (var item in data_2)
                {
                    testData.Add(new TrainingData(FirstNameBigger(item.First_Name, item.Last_Name),
                    MiddleName(item.Middle_Name),
                    FirstStartEndSameLetter(item.First_Name),
                    FirstAlphaBeforeLast(item.First_Name, item.Last_Name),
                    SecondLetterVowel(item.First_Name),
                    NameEven(item.Last_Name),
                    item.Sign,
                    ContainsPeriod(item.First_Name),
                    ContainsPeriod(item.Middle_Name),
                    ContainsHyphen(item.First_Name),
                    ContainsHyphen(item.Last_Name),
                    NameEven(item.First_Name),
                    MiddleEven(item.Middle_Name),
                    LengthGT4(item.First_Name),
                    LengthGT4(item.Last_Name),
                    FirstStartEndSameLetter(item.Last_Name),
                    MiddleStartEndSameLetter(item.Middle_Name),
                    SecondLetterVowel(item.Last_Name),
                    ThirdLetterVowel(item.First_Name),
                    ThirdLetterVowel(item.Last_Name),
                    ThreeSpaces(item.First_Name + " " + item.Middle_Name + " " + item.Last_Name)
                    ));
                }
            }
        }
        public void PrintTrainingData()
        {
            int i = 1;
            foreach (var item in trainingData)
            {
                Console.WriteLine(i.ToString() + "\t" + item.ToString());
                i++;
            }
        }
        

        private bool FirstNameBigger(string first, string last)
        {
            if (first.Length > last.Length) { return true; }
            else { return false; }
        }
        private bool MiddleName(string middle)
        {
            if (middle.Length > 0) { return true; }
            else { return false; }
        }
        private bool FirstStartEndSameLetter(string first)
        {
            if (first.ToUpper().First() == first.ToUpper().Last()) { return true; }
            else { return false; }
        }
        private bool FirstAlphaBeforeLast(string first, string last)
        {
            if (string.Compare(first, last) < 0) { return true; }
            else { return false; }
        }
        private bool SecondLetterVowel(string first)
        {
            if (first.Length > 1)
            {
                char p = (first.ToUpper())[1];
                if (p.Equals('A') || p.Equals('E') || p.Equals('I') || p.Equals('O') || p.Equals('U')) { return true; }
                else { return false; }
            }
            else
            {
                return false;                 
            }
        }
        private bool ThirdLetterVowel(string name)
        {
            if (name.Length > 2)
            {
                char p = (name.ToUpper())[2];
                if (p.Equals('A') || p.Equals('E') || p.Equals('I') || p.Equals('O') || p.Equals('U')) { return true; }
                else { return false; }
            }
            else
            {
                return false;
            }
        }
        private bool NameEven(string name)
        {
            if ((name.Length % 2) == 0) { return true; }
            else { return false; }
        }
        private bool MiddleEven(string name)
        {
            if (MiddleName(name) && (name.Length % 2) == 0) { return true; }
            else { return false; }
        }
        private bool ContainsPeriod(string name)
        {
            if (name.Contains(".")) { return true; }
            else { return false; }
        }
        private bool ContainsHyphen(string name)
        {
            if (name.Contains("-")) { return true; }
            else { return false; }
        }
        private bool LengthGT4(string name)
        {
            if(name.Length > 4) { return true; }
            else { return false; }
        }
        private bool MiddleStartEndSameLetter(string middle)
        {
            if (MiddleName(middle) && middle.ToUpper().First() == middle.ToUpper().Last()) { return true; }
            else { return false; }
        }
        private bool ThreeSpaces(string name)
        {
            string[] splitstring = name.Split();
            if(splitstring.Length > 3) { return true; }
            else { return false; }
        }

        public void TraverseTree()
        {
            Tree.TraverseTree();
        }
    }
}
