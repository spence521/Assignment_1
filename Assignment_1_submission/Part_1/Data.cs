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
        public StreamReader reader { get; set; }
        public StreamReader reader_2 { get; set; }
        public List<Entry> data_1 { get; private set; }
        public List<TrainingData> trainingData { get; private set; }
        public List<Entry> data_2 { get; private set; }
        public List<TrainingData> testData { get; private set; }
        public DecisionTree Tree { get; set; }
        public int Depth { get; set; }
        public double Error { get; set; }

        public Data(StreamReader r, StreamReader r2 = null)
        {
            data_1 = new List<Entry>();
            trainingData = new List<TrainingData>();
            data_2 = new List<Entry>();
            testData = new List<TrainingData>();
            reader = r;
            reader_2 = r2;
            SetData();
            SetTrainingData();
            List<TrainingData> trainingDataHelper = trainingData;
            Tree = new DecisionTree(ref trainingDataHelper);
            Tree.CollapseTree();
            if (reader_2 != null)
            {
                List<TrainingData> testDataHelper = testData;
                Error = (Convert.ToDouble(Tree.DetermineError(ref testDataHelper)) / Convert.ToDouble(testData.Count)) * 100;
            }
            Depth = Tree.DetermineDepth(0);
            //Error = Tree.Error; 
        }
        public void SetData()
        {
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
                }
                data_1.Add(new Entry(Sign, First_Name, Middle_Name, Last_Name));
            }
            if (reader_2 != null)
            {
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
                    }
                    data_2.Add(new Entry(Sign, First_Name, Middle_Name, Last_Name));
                }
            }
        }
        public void PrintData()
        {
            foreach (var item in data_1)
            {
                Console.WriteLine(item.Sign + " " + item.First_Name + " " + item.Middle_Name + item.Last_Name);
            }
        }

        public void SetTrainingData()
        {
            foreach (var item in data_1)
            {
                trainingData.Add(new TrainingData(FirstNameBigger(item.First_Name, item.Last_Name),
                    MiddleName(item.Middle_Name),
                    FirstStartEndSameLetter(item.First_Name),
                    FirstAlphaBeforeLast(item.First_Name, item.Last_Name),
                    FirstNameSecondLetterVowel(item.First_Name),
                    LastNameEven(item.Last_Name),
                    item.Sign));
            }
            if (reader_2 != null)
            {
                foreach (var item in data_2)
                {
                    testData.Add(new TrainingData(FirstNameBigger(item.First_Name, item.Last_Name),
                        MiddleName(item.Middle_Name),
                        FirstStartEndSameLetter(item.First_Name),
                        FirstAlphaBeforeLast(item.First_Name, item.Last_Name),
                        FirstNameSecondLetterVowel(item.First_Name),
                        LastNameEven(item.Last_Name),
                        item.Sign));
                }
            }
        }
        public void PrintTrainingData()
        {
            int i = 1;
            foreach (var item in trainingData)
            {
                Console.WriteLine(i.ToString() + "\t" + item.FirstBigger.ToString() + "\t" + item.MiddleName.ToString() + "\t" + item.FirstStartEnd.ToString() + "\t" + 
                    item.FirstAlpha.ToString() + "\t" + item.FirstVowel.ToString() + "\t" + item.LastEven.ToString() + "\t" + item.Label.ToString());
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
        private bool FirstNameSecondLetterVowel(string first)
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
        private bool LastNameEven(string last)
        {
            if ((last.Length % 2) == 0) { return true; }
            else { return false; }
        }        
        public void TraverseTree()
        {
            Tree.TraverseTree();
        }
    }
}
