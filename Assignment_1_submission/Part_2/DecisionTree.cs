using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class DecisionTree
    {
        /// <summary>
        /// Enums
        /// </summary>        
        public enum Features
        {
            FirstBigger, MiddleName, FirstStartEnd, FirstAlpha, FirstVowel, LastEven,
            FirstPeriod, MiddlePeriod, FirstHyphen, LastHyphen, FirstEven, MiddleEven, FirstBigger4,
            LastBigger4, LastStartEnd, MiddleStartEnd, Last2ndVowel, First3rdVowel, Last3rdVowel, ThreeSpaces, None
        }
        public Features Feature { get; set; }
        public bool IsLeaf { get; set; }
        public DecisionTree LeftTree { get; set; } //no
        public DecisionTree RightTree { get; set; } //yes
        public char? Value { get; set; }
        public List<TrainingData> trainingData { get; private set; }
        public double Entropy { get; private set; }
        public InformationGain informationGain { get; private set; }
        public double Error { get; set; } // gets set in SetEntropy
        public int DepthRemaining { get; set; }
        public List<Features> FeaturesTaken { get; set; }

        public DecisionTree(ref List<TrainingData> trainingdata, int depth = int.MaxValue)
        {
            informationGain = new InformationGain();
            FeaturesTaken = new List<Features>();
            IsLeaf = false;
            LeftTree = null;
            RightTree = null;
            Value = null;
            DepthRemaining = depth;
            trainingData = trainingdata;
            SetEntropy();
            SetInformationGain();
            DetermineFeature();
            FeaturesTaken.Add(Features.None);
            FeaturesTaken.Add(Feature);
            DetermineSubTrees();
        }

        public DecisionTree(bool isLeaf, ref List<TrainingData> trainingdata, char? value, int depthRemaining, ref List<Features> featuresTaken)
        {
            IsLeaf = isLeaf;
            LeftTree = null;
            RightTree = null;
            DepthRemaining = depthRemaining;
            Value = value;
            if (!IsLeaf)
            {
                FeaturesTaken = new List<Features>();
                informationGain = new InformationGain();
                trainingData = trainingdata;
                SetEntropy();
                SetInformationGain();
                FeaturesTaken = featuresTaken;
                DetermineFeature();
                FeaturesTaken.Add(Feature);
                DetermineSubTrees();
            }
            //else
            //{
            //    Console.WriteLine("You are at a Leaf" + value);
            //}
        }
        private void SetEntropy()
        {
            int positive_labels = 0;
            int negative_labels = 0;
            double P;
            double N;
            foreach (var item in trainingData)
            {
                if (item.Label.Equals('+')) { positive_labels++; }
                else { negative_labels++; }
            }
            P = Convert.ToDouble(positive_labels) / trainingData.Count;
            N = Convert.ToDouble(negative_labels) / trainingData.Count;
            Entropy = (-P * Math.Log(P, 2)) - (N * Math.Log(N, 2));
            Error = 1 - (Convert.ToDouble(positive_labels > negative_labels ? positive_labels : negative_labels) / Convert.ToDouble(trainingData.Count));

            if (double.IsInfinity(Entropy) || double.IsNaN(Entropy) || double.IsNegativeInfinity(Entropy) || double.IsPositiveInfinity(Entropy))
            {
                Console.WriteLine("You have a NaN, or infinity value");
            }
        }
        private void SetInformationGain()
        {
            #region Features Yes/No Values
            //Feature 1 values
            double F1_Yes_P = 0;
            double F1_Yes_N = 0;
            double F1_No_P = 0;
            double F1_No_N = 0;
            double F1_Yes = 0;
            double F1_No = 0;
            //Feature 2 values
            double F2_Yes_P = 0;
            double F2_Yes_N = 0;
            double F2_No_P = 0;
            double F2_No_N = 0;
            double F2_Yes = 0;
            double F2_No = 0;
            //Feature 3 values
            double F3_Yes_P = 0;
            double F3_Yes_N = 0;
            double F3_No_P = 0;
            double F3_No_N = 0;
            double F3_Yes = 0;
            double F3_No = 0;
            //Feature 4 values
            double F4_Yes_P = 0;
            double F4_Yes_N = 0;
            double F4_No_P = 0;
            double F4_No_N = 0;
            double F4_Yes = 0;
            double F4_No = 0;
            //Feature 5 values
            double F5_Yes_P = 0;
            double F5_Yes_N = 0;
            double F5_No_P = 0;
            double F5_No_N = 0;
            double F5_Yes = 0;
            double F5_No = 0;
            //Feature 6 values
            double F6_Yes_P = 0;
            double F6_Yes_N = 0;
            double F6_No_P = 0;
            double F6_No_N = 0;
            double F6_Yes = 0;
            double F6_No = 0;
            //Feature 7 values
            double F7_Yes_P = 0;
            double F7_Yes_N = 0;
            double F7_No_P = 0;
            double F7_No_N = 0;
            double F7_Yes = 0;
            double F7_No = 0;
            //Feature 8 values
            double F8_Yes_P = 0;
            double F8_Yes_N = 0;
            double F8_No_P = 0;
            double F8_No_N = 0;
            double F8_Yes = 0;
            double F8_No = 0;
            //Feature 9 values
            double F9_Yes_P = 0;
            double F9_Yes_N = 0;
            double F9_No_P = 0;
            double F9_No_N = 0;
            double F9_Yes = 0;
            double F9_No = 0;
            //Feature 10 values
            double F10_Yes_P = 0;
            double F10_Yes_N = 0;
            double F10_No_P = 0;
            double F10_No_N = 0;
            double F10_Yes = 0;
            double F10_No = 0;
            //Feature 11 values
            double F11_Yes_P = 0;
            double F11_Yes_N = 0;
            double F11_No_P = 0;
            double F11_No_N = 0;
            double F11_Yes = 0;
            double F11_No = 0;
            //Feature 12 values
            double F12_Yes_P = 0;
            double F12_Yes_N = 0;
            double F12_No_P = 0;
            double F12_No_N = 0;
            double F12_Yes = 0;
            double F12_No = 0;
            //Feature 13 values
            double F13_Yes_P = 0;
            double F13_Yes_N = 0;
            double F13_No_P = 0;
            double F13_No_N = 0;
            double F13_Yes = 0;
            double F13_No = 0;
            //Feature 14 values
            double F14_Yes_P = 0;
            double F14_Yes_N = 0;
            double F14_No_P = 0;
            double F14_No_N = 0;
            double F14_Yes = 0;
            double F14_No = 0;
            //Feature 15 values
            double F15_Yes_P = 0;
            double F15_Yes_N = 0;
            double F15_No_P = 0;
            double F15_No_N = 0;
            double F15_Yes = 0;
            double F15_No = 0;
            //Feature 16 values
            double F16_Yes_P = 0;
            double F16_Yes_N = 0;
            double F16_No_P = 0;
            double F16_No_N = 0;
            double F16_Yes = 0;
            double F16_No = 0;
            //Feature 17 values
            double F17_Yes_P = 0;
            double F17_Yes_N = 0;
            double F17_No_P = 0;
            double F17_No_N = 0;
            double F17_Yes = 0;
            double F17_No = 0;
            //Feature 18 values
            double F18_Yes_P = 0;
            double F18_Yes_N = 0;
            double F18_No_P = 0;
            double F18_No_N = 0;
            double F18_Yes = 0;
            double F18_No = 0;
            //Feature 19 values
            double F19_Yes_P = 0;
            double F19_Yes_N = 0;
            double F19_No_P = 0;
            double F19_No_N = 0;
            double F19_Yes = 0;
            double F19_No = 0;
            //Feature 20 values
            double F20_Yes_P = 0;
            double F20_Yes_N = 0;
            double F20_No_P = 0;
            double F20_No_N = 0;
            double F20_Yes = 0;
            double F20_No = 0;
            #endregion

            #region Calculating Yes/No Values
            foreach (var item in trainingData)
            {
                //Feature 1 counts
                if (item.FirstBigger)
                {
                    if (item.Label.Equals('+')) { F1_Yes_P++; }
                    else if (item.Label.Equals('-')) { F1_Yes_N++; }
                    F1_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F1_No_P++; }
                    else if (item.Label.Equals('-')) { F1_No_N++; }
                    F1_No++;
                }

                //Feature 2 counts
                if (item.MiddleName)
                {
                    if (item.Label.Equals('+')) { F2_Yes_P++; }
                    else if (item.Label.Equals('-')) { F2_Yes_N++; }
                    F2_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F2_No_P++; }
                    else if (item.Label.Equals('-')) { F2_No_N++; }
                    F2_No++;
                }

                //Feature 3 counts
                if (item.FirstStartEnd)
                {
                    if (item.Label.Equals('+')) { F3_Yes_P++; }
                    else if (item.Label.Equals('-')) { F3_Yes_N++; }
                    F3_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F3_No_P++; }
                    else if (item.Label.Equals('-')) { F3_No_N++; }
                    F3_No++;
                }

                //Feature 4 counts
                if (item.FirstAlpha)
                {
                    if (item.Label.Equals('+')) { F4_Yes_P++; }
                    else if (item.Label.Equals('-')) { F4_Yes_N++; }
                    F4_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F4_No_P++; }
                    else if (item.Label.Equals('-')) { F4_No_N++; }
                    F4_No++;
                }

                //Feature 5 counts
                if (item.FirstVowel)
                {
                    if (item.Label.Equals('+')) { F5_Yes_P++; }
                    else if (item.Label.Equals('-')) { F5_Yes_N++; }
                    F5_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F5_No_P++; }
                    else if (item.Label.Equals('-')) { F5_No_N++; }
                    F5_No++;
                }

                //Feature 6 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F6_Yes_P++; }
                    else if (item.Label.Equals('-')) { F6_Yes_N++; }
                    F6_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F6_No_P++; }
                    else if (item.Label.Equals('-')) { F6_No_N++; }
                    F6_No++;
                }
                //Feature 7 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F7_Yes_P++; }
                    else if (item.Label.Equals('-')) { F7_Yes_N++; }
                    F7_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F7_No_P++; }
                    else if (item.Label.Equals('-')) { F7_No_N++; }
                    F7_No++;
                }
                //Feature 8 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F8_Yes_P++; }
                    else if (item.Label.Equals('-')) { F8_Yes_N++; }
                    F8_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F8_No_P++; }
                    else if (item.Label.Equals('-')) { F8_No_N++; }
                    F8_No++;
                }
                //Feature 9 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F9_Yes_P++; }
                    else if (item.Label.Equals('-')) { F9_Yes_N++; }
                    F9_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F9_No_P++; }
                    else if (item.Label.Equals('-')) { F9_No_N++; }
                    F9_No++;
                }
                //Feature 10 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F10_Yes_P++; }
                    else if (item.Label.Equals('-')) { F10_Yes_N++; }
                    F10_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F10_No_P++; }
                    else if (item.Label.Equals('-')) { F10_No_N++; }
                    F10_No++;
                }
                //Feature 11 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F11_Yes_P++; }
                    else if (item.Label.Equals('-')) { F11_Yes_N++; }
                    F11_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F11_No_P++; }
                    else if (item.Label.Equals('-')) { F11_No_N++; }
                    F11_No++;
                }
                //Feature 12 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F12_Yes_P++; }
                    else if (item.Label.Equals('-')) { F12_Yes_N++; }
                    F12_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F12_No_P++; }
                    else if (item.Label.Equals('-')) { F12_No_N++; }
                    F12_No++;
                }
                //Feature 13 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F13_Yes_P++; }
                    else if (item.Label.Equals('-')) { F13_Yes_N++; }
                    F13_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F13_No_P++; }
                    else if (item.Label.Equals('-')) { F13_No_N++; }
                    F13_No++;
                }
                //Feature 14 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F14_Yes_P++; }
                    else if (item.Label.Equals('-')) { F14_Yes_N++; }
                    F14_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F14_No_P++; }
                    else if (item.Label.Equals('-')) { F14_No_N++; }
                    F14_No++;
                }
                //Feature 15 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F15_Yes_P++; }
                    else if (item.Label.Equals('-')) { F15_Yes_N++; }
                    F15_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F15_No_P++; }
                    else if (item.Label.Equals('-')) { F15_No_N++; }
                    F15_No++;
                }
                //Feature 16 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F16_Yes_P++; }
                    else if (item.Label.Equals('-')) { F16_Yes_N++; }
                    F16_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F16_No_P++; }
                    else if (item.Label.Equals('-')) { F16_No_N++; }
                    F16_No++;
                }
                //Feature 17 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F17_Yes_P++; }
                    else if (item.Label.Equals('-')) { F17_Yes_N++; }
                    F17_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F17_No_P++; }
                    else if (item.Label.Equals('-')) { F17_No_N++; }
                    F17_No++;
                }
                //Feature 18 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F18_Yes_P++; }
                    else if (item.Label.Equals('-')) { F18_Yes_N++; }
                    F18_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F18_No_P++; }
                    else if (item.Label.Equals('-')) { F18_No_N++; }
                    F18_No++;
                }
                //Feature 19 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F19_Yes_P++; }
                    else if (item.Label.Equals('-')) { F19_Yes_N++; }
                    F19_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F19_No_P++; }
                    else if (item.Label.Equals('-')) { F19_No_N++; }
                    F19_No++;
                }
                //Feature 20 counts
                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F20_Yes_P++; }
                    else if (item.Label.Equals('-')) { F20_Yes_N++; }
                    F20_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F20_No_P++; }
                    else if (item.Label.Equals('-')) { F20_No_N++; }
                    F20_No++;
                }
            }
            #endregion

            informationGain.FirstBigger = CalculateInformationGain(F1_Yes, F1_No, F1_Yes_P, F1_Yes_N, F1_No_P, F1_No_N);
            informationGain.MiddleName = CalculateInformationGain(F2_Yes, F2_No, F2_Yes_P, F2_Yes_N, F2_No_P, F2_No_N);
            informationGain.FirstStartEnd = CalculateInformationGain(F3_Yes, F3_No, F3_Yes_P, F3_Yes_N, F3_No_P, F3_No_N);
            informationGain.FirstAlpha = CalculateInformationGain(F4_Yes, F4_No, F4_Yes_P, F4_Yes_N, F4_No_P, F4_No_N);
            informationGain.FirstVowel = CalculateInformationGain(F5_Yes, F5_No, F5_Yes_P, F5_Yes_N, F5_No_P, F5_No_N);
            informationGain.LastEven = CalculateInformationGain(F6_Yes, F6_No, F6_Yes_P, F6_Yes_N, F6_No_P, F6_No_N);

            informationGain.FirstPeriod = CalculateInformationGain(F7_Yes, F7_No, F7_Yes_P, F7_Yes_N, F7_No_P, F7_No_N);
            informationGain.MiddlePeriod = CalculateInformationGain(F8_Yes, F8_No, F8_Yes_P, F8_Yes_N, F8_No_P, F8_No_N);
            informationGain.FirstHyphen = CalculateInformationGain(F9_Yes, F9_No, F9_Yes_P, F9_Yes_N, F9_No_P, F9_No_N);
            informationGain.LastHyphen = CalculateInformationGain(F10_Yes, F10_No, F10_Yes_P, F10_Yes_N, F10_No_P, F10_No_N);
            informationGain.FirstEven = CalculateInformationGain(F11_Yes, F11_No, F11_Yes_P, F11_Yes_N, F11_No_P, F11_No_N);
            informationGain.MiddleEven = CalculateInformationGain(F12_Yes, F12_No, F12_Yes_P, F12_Yes_N, F12_No_P, F12_No_N);
            informationGain.FirstBigger4 = CalculateInformationGain(F13_Yes, F13_No, F13_Yes_P, F13_Yes_N, F13_No_P, F13_No_N);
            informationGain.LastBigger4 = CalculateInformationGain(F14_Yes, F14_No, F14_Yes_P, F14_Yes_N, F14_No_P, F14_No_N);
            informationGain.LastStartEnd = CalculateInformationGain(F15_Yes, F15_No, F15_Yes_P, F15_Yes_N, F15_No_P, F15_No_N);
            informationGain.MiddleStartEnd = CalculateInformationGain(F16_Yes, F16_No, F16_Yes_P, F16_Yes_N, F16_No_P, F16_No_N);
            informationGain.Last2ndVowel = CalculateInformationGain(F17_Yes, F17_No, F17_Yes_P, F17_Yes_N, F17_No_P, F17_No_N);
            informationGain.First3rdVowel = CalculateInformationGain(F18_Yes, F18_No, F18_Yes_P, F18_Yes_N, F18_No_P, F18_No_N);
            informationGain.Last3rdVowel = CalculateInformationGain(F19_Yes, F19_No, F19_Yes_P, F19_Yes_N, F19_No_P, F19_No_N);
            informationGain.ThreeSpaces = CalculateInformationGain(F20_Yes, F20_No, F20_Yes_P, F20_Yes_N, F20_No_P, F20_No_N);
        }
        private double CalculateInformationGain(double Yes, double No, double Yes_P, double Yes_N, double No_P, double No_N)
        {
            //if (Yes == 0) { Yes = 1; }
            //if (No == 0) { No = 1; }

            double Yes_Positive = Yes_P / (Yes == 0 ? 1 : Yes );
            double Yes_Negative = Yes_N / (Yes == 0 ? 1 : Yes);
            double No_Positive = No_P / (No == 0 ? 1 : No);
            double No_Negative = No_N / (No == 0 ? 1 : No);

            double H_Yes_Positive = Yes_P / (Yes == 0 ? 1 : Yes);
            double H_Yes_Negative = Yes_N / (Yes == 0 ? 1 : Yes);
            double H_No_Positive = No_P / (No == 0 ? 1 : No);
            double H_No_Negative = No_N / (No == 0 ? 1 : No);

            if (Yes_Positive == 0){ H_Yes_Positive = 2; }
            if (Yes_Negative == 0) { H_Yes_Negative = 2; }
            if (No_Positive == 0) { H_No_Positive = 2; }
            if (No_Negative == 0) { H_No_Negative = 2; }

            double Yes_Result = ((-Yes_Positive) * Math.Log(H_Yes_Positive, 2)) - (Yes_Negative * Math.Log(H_Yes_Negative, 2));
            double No_Result = (((-No_Positive) * Math.Log(H_No_Positive, 2)) - ((No_Negative) * Math.Log(H_No_Negative, 2)));

            double Feature_Result = ((Yes / Convert.ToDouble(trainingData.Count)) * Yes_Result) + ((No / Convert.ToDouble(trainingData.Count)) * No_Result);
            if(double.IsInfinity(Feature_Result) || double.IsNaN(Feature_Result) || double.IsNegativeInfinity(Feature_Result) || double.IsPositiveInfinity(Feature_Result))
            {
                Console.WriteLine("You have a NaN, or infinity value");
            }
            return Entropy - Feature_Result;           
        }
        private void DetermineFeature()
        {   
            List<double> list = informationGain.ToList();
            if (list.Max() == list[0]) { Feature = Features.FirstBigger; }
            else if (list.Max() == list[1]) { Feature = Features.MiddleName; }
            else if (list.Max() == list[2]) { Feature = Features.FirstStartEnd; }
            else if (list.Max() == list[3]) { Feature = Features.FirstAlpha; }
            else if (list.Max() == list[4]) { Feature = Features.FirstVowel; }
            else if (list.Max() == list[5]) { Feature = Features.LastEven; }

            else if (list.Max() == list[6]) { Feature = Features.FirstPeriod; }
            else if (list.Max() == list[7]) { Feature = Features.MiddlePeriod; }
            else if (list.Max() == list[8]) { Feature = Features.FirstHyphen; }
            else if (list.Max() == list[9]) { Feature = Features.LastHyphen; }
            else if (list.Max() == list[10]) { Feature = Features.FirstEven; }
            else if (list.Max() == list[11]) { Feature = Features.MiddleEven; }
            else if (list.Max() == list[12]) { Feature = Features.FirstBigger4; }
            else if (list.Max() == list[13]) { Feature = Features.LastBigger4; }
            else if (list.Max() == list[14]) { Feature = Features.LastStartEnd; }
            else if (list.Max() == list[15]) { Feature = Features.MiddleStartEnd; }
            else if (list.Max() == list[16]) { Feature = Features.Last2ndVowel; }
            else if (list.Max() == list[17]) { Feature = Features.First3rdVowel; }
            else if (list.Max() == list[18]) { Feature = Features.Last3rdVowel; }
            else if (list.Max() == list[19]) { Feature = Features.ThreeSpaces; }
            else { Feature = Features.None; }

            if(list.All(x => x == 0))
            {
                if (!FeaturesTaken.Contains(Features.FirstBigger)) { Feature = Features.FirstBigger; }
                else if (!FeaturesTaken.Contains(Features.MiddleName)) { Feature = Features.MiddleName; }
                else if (!FeaturesTaken.Contains(Features.FirstStartEnd)) { Feature = Features.FirstStartEnd; }
                else if (!FeaturesTaken.Contains(Features.FirstAlpha)) { Feature = Features.FirstAlpha; }
                else if (!FeaturesTaken.Contains(Features.FirstVowel)) { Feature = Features.FirstVowel; }
                else if (!FeaturesTaken.Contains(Features.LastEven)) { Feature = Features.LastEven; }
                else if (!FeaturesTaken.Contains(Features.FirstPeriod)) { Feature = Features.FirstPeriod; }
                else if (!FeaturesTaken.Contains(Features.MiddlePeriod)) { Feature = Features.MiddlePeriod; }
                else if (!FeaturesTaken.Contains(Features.FirstHyphen)) { Feature = Features.FirstHyphen; }
                else if (!FeaturesTaken.Contains(Features.LastHyphen)) { Feature = Features.LastHyphen; }
                else if (!FeaturesTaken.Contains(Features.FirstEven)) { Feature = Features.FirstEven; }
                else if (!FeaturesTaken.Contains(Features.MiddleEven)) { Feature = Features.MiddleEven; }
                else if (!FeaturesTaken.Contains(Features.FirstBigger4)) { Feature = Features.FirstBigger4; }
                else if (!FeaturesTaken.Contains(Features.LastBigger4)) { Feature = Features.LastBigger4; }
                else if (!FeaturesTaken.Contains(Features.LastStartEnd)) { Feature = Features.LastStartEnd; }
                else if (!FeaturesTaken.Contains(Features.MiddleStartEnd)) { Feature = Features.MiddleStartEnd; }
                else if (!FeaturesTaken.Contains(Features.Last2ndVowel)) { Feature = Features.Last2ndVowel; }
                else if (!FeaturesTaken.Contains(Features.First3rdVowel)) { Feature = Features.First3rdVowel; }
                else if (!FeaturesTaken.Contains(Features.Last3rdVowel)) { Feature = Features.Last3rdVowel; }
                else if (!FeaturesTaken.Contains(Features.ThreeSpaces)) { Feature = Features.ThreeSpaces; }
                else { Feature = Features.None; }
            }
        }
        private void DetermineSubTrees()
        {
            char? LeftLeafValue = null;
            List<TrainingData> LeftData;
            if (Feature == Features.FirstBigger) { LeftData = trainingData.Where(x => x.FirstBigger == false).ToList(); }
            else if (Feature == Features.MiddleName) { LeftData = trainingData.Where(x => x.MiddleName == false).ToList(); }
            else if (Feature == Features.FirstStartEnd) { LeftData = trainingData.Where(x => x.FirstStartEnd == false).ToList(); }
            else if (Feature == Features.FirstAlpha) { LeftData = trainingData.Where(x => x.FirstAlpha == false).ToList(); }
            else if (Feature == Features.FirstVowel) { LeftData = trainingData.Where(x => x.FirstVowel == false).ToList(); }
            else if (Feature == Features.LastEven) { LeftData = trainingData.Where(x => x.LastEven == false).ToList(); }


            else if (Feature == Features.FirstPeriod) { LeftData = trainingData.Where(x => x.FirstPeriod == false).ToList(); }
            else if (Feature == Features.MiddlePeriod) { LeftData = trainingData.Where(x => x.MiddlePeriod == false).ToList(); }
            else if (Feature == Features.FirstHyphen) { LeftData = trainingData.Where(x => x.FirstHyphen == false).ToList(); }
            else if (Feature == Features.LastHyphen) { LeftData = trainingData.Where(x => x.LastHyphen == false).ToList(); }
            else if (Feature == Features.FirstEven) { LeftData = trainingData.Where(x => x.FirstEven == false).ToList(); }
            else if (Feature == Features.MiddleEven) { LeftData = trainingData.Where(x => x.MiddleEven == false).ToList(); }
            else if (Feature == Features.FirstBigger4) { LeftData = trainingData.Where(x => x.FirstBigger4 == false).ToList(); }
            else if (Feature == Features.LastBigger4) { LeftData = trainingData.Where(x => x.LastBigger4 == false).ToList(); }
            else if (Feature == Features.LastStartEnd) { LeftData = trainingData.Where(x => x.LastStartEnd == false).ToList(); }
            else if (Feature == Features.MiddleStartEnd) { LeftData = trainingData.Where(x => x.MiddleStartEnd == false).ToList(); }
            else if (Feature == Features.Last2ndVowel) { LeftData = trainingData.Where(x => x.Last2ndVowel == false).ToList(); }
            else if (Feature == Features.First3rdVowel) { LeftData = trainingData.Where(x => x.First3rdVowel == false).ToList(); }
            else if (Feature == Features.Last3rdVowel) { LeftData = trainingData.Where(x => x.Last3rdVowel == false).ToList(); }
            else { LeftData = trainingData.Where(x => x.ThreeSpaces == false).ToList(); } //ThreeSpaces
            List<char> LeftLeafList = (from h in LeftData select h.Label).Distinct().ToList();
            bool IsLeftLeaf = (LeftLeafList.Count == 1);
            if (IsLeftLeaf)
            {
                LeftLeafValue = LeftData.Select(p => p.Label).First();
            }
            else if(LeftData.Count < 2)
            {
                if (LeftData.Count == 0)
                {
                    LeftLeafValue = '-';
                    IsLeftLeaf = true;
                }
                else
                {
                    IsLeftLeaf = true;
                    LeftLeafValue = LeftData.Select(p => p.Label).First();
                }
            }

            List<bool> FirstBigger_LeftLeafList = (from h in LeftData select h.FirstBigger).Distinct().ToList();
            List<bool> MiddleName_LeftLeafList = (from h in LeftData select h.MiddleName).Distinct().ToList();
            List<bool> FirstStartEnd_LeftLeafList = (from h in LeftData select h.FirstStartEnd).Distinct().ToList();
            List<bool> FirstAlpha_LeftLeafList = (from h in LeftData select h.FirstAlpha).Distinct().ToList();
            List<bool> FirstVowel_LeftLeafList = (from h in LeftData select h.FirstVowel).Distinct().ToList();
            List<bool> LastEven_LeftLeafList = (from h in LeftData select h.LastEven).Distinct().ToList();

            List<bool> FirstPeriod_LeftLeafList = (from h in LeftData select h.FirstPeriod).Distinct().ToList();
            List<bool> MiddlePeriod_LeftLeafList = (from h in LeftData select h.MiddlePeriod).Distinct().ToList();
            List<bool> FirstHyphen_LeftLeafList = (from h in LeftData select h.FirstHyphen).Distinct().ToList();
            List<bool> LastHyphen_LeftLeafList = (from h in LeftData select h.LastHyphen).Distinct().ToList();
            List<bool> FirstEven_LeftLeafList = (from h in LeftData select h.FirstEven).Distinct().ToList();
            List<bool> MiddleEven_LeftLeafList = (from h in LeftData select h.MiddleEven).Distinct().ToList();
            List<bool> FirstBigger4_LeftLeafList = (from h in LeftData select h.FirstBigger4).Distinct().ToList();
            List<bool> LastBigger4_LeftLeafList = (from h in LeftData select h.LastBigger4).Distinct().ToList();
            List<bool> LastStartEnd_LeftLeafList = (from h in LeftData select h.LastStartEnd).Distinct().ToList();
            List<bool> MiddleStartEnd_LeftLeafList = (from h in LeftData select h.MiddleStartEnd).Distinct().ToList();
            List<bool> Last2ndVowel_LeftLeafList = (from h in LeftData select h.Last2ndVowel).Distinct().ToList();
            List<bool> First3rdVowel_LeftLeafList = (from h in LeftData select h.First3rdVowel).Distinct().ToList();
            List<bool> Last3rdVowel_LeftLeafList = (from h in LeftData select h.Last3rdVowel).Distinct().ToList();
            List<bool> ThreeSpaces_LeftLeafList = (from h in LeftData select h.ThreeSpaces).Distinct().ToList();

            if (FirstBigger_LeftLeafList.Count == 1 && MiddleName_LeftLeafList.Count == 1 && FirstStartEnd_LeftLeafList.Count == 1 && FirstAlpha_LeftLeafList.Count == 1 &&
                FirstVowel_LeftLeafList.Count == 1 && LastEven_LeftLeafList.Count == 1 && FirstPeriod_LeftLeafList.Count == 1 && MiddlePeriod_LeftLeafList.Count == 1 &&
                FirstHyphen_LeftLeafList.Count == 1 && LastHyphen_LeftLeafList.Count == 1 && FirstEven_LeftLeafList.Count == 1 && MiddleEven_LeftLeafList.Count == 1 && 
                FirstBigger4_LeftLeafList.Count == 1 && LastBigger4_LeftLeafList.Count == 1 && LastStartEnd_LeftLeafList.Count == 1 && MiddleStartEnd_LeftLeafList.Count == 1 && 
                Last2ndVowel_LeftLeafList.Count == 1 && First3rdVowel_LeftLeafList.Count == 1 && Last3rdVowel_LeftLeafList.Count == 1 && ThreeSpaces_LeftLeafList.Count == 1)
            {
                IsLeftLeaf = true;
                LeftLeafValue = LeftData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
            }


            char? RightLeafValue = null;
            List<TrainingData> RightData;
            if (Feature == Features.FirstBigger) { RightData = trainingData.Where(x => x.FirstBigger == true).ToList(); }
            else if (Feature == Features.MiddleName) { RightData = trainingData.Where(x => x.MiddleName == true).ToList(); }
            else if (Feature == Features.FirstStartEnd) { RightData = trainingData.Where(x => x.FirstStartEnd == true).ToList(); }
            else if (Feature == Features.FirstAlpha) { RightData = trainingData.Where(x => x.FirstAlpha == true).ToList(); }
            else if (Feature == Features.FirstVowel) { RightData = trainingData.Where(x => x.FirstVowel == true).ToList(); }
            else if (Feature == Features.LastEven) { RightData = trainingData.Where(x => x.LastEven == true).ToList(); }      

            else if (Feature == Features.FirstPeriod) { RightData = trainingData.Where(x => x.FirstPeriod == true).ToList(); }
            else if (Feature == Features.MiddlePeriod) { RightData = trainingData.Where(x => x.MiddlePeriod == true).ToList(); }
            else if (Feature == Features.FirstHyphen) { RightData = trainingData.Where(x => x.FirstHyphen == true).ToList(); }
            else if (Feature == Features.LastHyphen) { RightData = trainingData.Where(x => x.LastHyphen == true).ToList(); }
            else if (Feature == Features.FirstEven) { RightData = trainingData.Where(x => x.FirstEven == true).ToList(); }
            else if (Feature == Features.MiddleEven) { RightData = trainingData.Where(x => x.MiddleEven == true).ToList(); }
            else if (Feature == Features.FirstBigger4) { RightData = trainingData.Where(x => x.FirstBigger4 == true).ToList(); }
            else if (Feature == Features.LastBigger4) { RightData = trainingData.Where(x => x.LastBigger4 == true).ToList(); }
            else if (Feature == Features.LastStartEnd) { RightData = trainingData.Where(x => x.LastStartEnd == true).ToList(); }
            else if (Feature == Features.MiddleStartEnd) { RightData = trainingData.Where(x => x.MiddleStartEnd == true).ToList(); }
            else if (Feature == Features.Last2ndVowel) { RightData = trainingData.Where(x => x.Last2ndVowel == true).ToList(); }
            else if (Feature == Features.First3rdVowel) { RightData = trainingData.Where(x => x.First3rdVowel == true).ToList(); }
            else if (Feature == Features.Last3rdVowel) { RightData = trainingData.Where(x => x.Last3rdVowel == true).ToList(); }
            else { RightData = trainingData.Where(x => x.ThreeSpaces == true).ToList(); } //ThreeSpaces




            List<char> RightLeafList = (from h in RightData select h.Label).Distinct().ToList();
            bool IsRightLeaf = (RightLeafList.Count == 1);
            if (IsRightLeaf)
            {
                RightLeafValue = RightData.Select(p => p.Label).First();
            }
            else if (RightData.Count < 2)
            {
                IsRightLeaf = true;
                if (RightData.Count == 0)
                {
                    RightLeafValue = '+';
                    IsRightLeaf = true;
                }
                else
                {
                    IsRightLeaf = true;
                    RightLeafValue = RightData.Select(p => p.Label).First();
                }
            }


            List<bool> FirstBigger_RightLeafList = (from h in RightData select h.FirstBigger).Distinct().ToList();
            List<bool> MiddleName_RightLeafList = (from h in RightData select h.MiddleName).Distinct().ToList();
            List<bool> FirstStartEnd_RightLeafList = (from h in RightData select h.FirstStartEnd).Distinct().ToList();
            List<bool> FirstAlpha_RightLeafList = (from h in RightData select h.FirstAlpha).Distinct().ToList();
            List<bool> FirstVowel_RightLeafList = (from h in RightData select h.FirstVowel).Distinct().ToList();
            List<bool> LastEven_RightLeafList = (from h in RightData select h.LastEven).Distinct().ToList();

            List<bool> FirstPeriod_RightLeafList = (from h in RightData select h.FirstPeriod).Distinct().ToList();
            List<bool> MiddlePeriod_RightLeafList = (from h in RightData select h.MiddlePeriod).Distinct().ToList();
            List<bool> FirstHyphen_RightLeafList = (from h in RightData select h.FirstHyphen).Distinct().ToList();
            List<bool> LastHyphen_RightLeafList = (from h in RightData select h.LastHyphen).Distinct().ToList();
            List<bool> FirstEven_RightLeafList = (from h in RightData select h.FirstEven).Distinct().ToList();
            List<bool> MiddleEven_RightLeafList = (from h in RightData select h.MiddleEven).Distinct().ToList();
            List<bool> FirstBigger4_RightLeafList = (from h in RightData select h.FirstBigger4).Distinct().ToList();
            List<bool> LastBigger4_RightLeafList = (from h in RightData select h.LastBigger4).Distinct().ToList();
            List<bool> LastStartEnd_RightLeafList = (from h in RightData select h.LastStartEnd).Distinct().ToList();
            List<bool> MiddleStartEnd_RightLeafList = (from h in RightData select h.MiddleStartEnd).Distinct().ToList();
            List<bool> Last2ndVowel_RightLeafList = (from h in RightData select h.Last2ndVowel).Distinct().ToList();
            List<bool> First3rdVowel_RightLeafList = (from h in RightData select h.First3rdVowel).Distinct().ToList();
            List<bool> Last3rdVowel_RightLeafList = (from h in RightData select h.Last3rdVowel).Distinct().ToList();
            List<bool> ThreeSpaces_RightLeafList = (from h in RightData select h.ThreeSpaces).Distinct().ToList();

            if (FirstBigger_RightLeafList.Count == 1 && MiddleName_RightLeafList.Count == 1 && FirstStartEnd_RightLeafList.Count == 1 && FirstAlpha_RightLeafList.Count == 1 &&
                FirstVowel_RightLeafList.Count == 1 && LastEven_RightLeafList.Count == 1 && FirstPeriod_RightLeafList.Count == 1 && MiddlePeriod_RightLeafList.Count == 1 &&
                FirstHyphen_RightLeafList.Count == 1 && LastHyphen_RightLeafList.Count == 1 && FirstEven_RightLeafList.Count == 1 && MiddleEven_RightLeafList.Count == 1 &&
                FirstBigger4_RightLeafList.Count == 1 && LastBigger4_RightLeafList.Count == 1 && LastStartEnd_RightLeafList.Count == 1 && MiddleStartEnd_RightLeafList.Count == 1 &&
                Last2ndVowel_RightLeafList.Count == 1 && First3rdVowel_RightLeafList.Count == 1 && Last3rdVowel_RightLeafList.Count == 1 && ThreeSpaces_RightLeafList.Count == 1)
            {
                IsRightLeaf = true;
                RightLeafValue = RightData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
            }
            if(FeaturesTaken.Count > 19)
            {
                IsLeaf = true;
                LeftTree = null;
                RightTree = null;
                Value = trainingData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
                Feature = Features.None;
                return;
            }
            

            if (LeftLeafValue.Equals(RightLeafValue) && (!(LeftLeafValue == null) || !(RightLeafValue == null)))
            {
                IsLeaf = true;
                LeftTree = null;
                RightTree = null;
                Value = LeftLeafValue;
                Feature = Features.None;
            }
            else
            {
                List<Features> featuresTakenHelper = FeaturesTaken;
                if (DepthRemaining > 1)
                {
                    LeftTree = new DecisionTree(IsLeftLeaf, ref LeftData, LeftLeafValue, DepthRemaining - 1, ref featuresTakenHelper);
                    RightTree = new DecisionTree(IsRightLeaf, ref RightData, RightLeafValue, DepthRemaining - 1, ref featuresTakenHelper);
                }
                else
                {
                    if(IsLeftLeaf && IsRightLeaf)
                    {
                        LeftTree = new DecisionTree(IsLeftLeaf, ref LeftData, LeftLeafValue, DepthRemaining - 1, ref featuresTakenHelper);
                        RightTree = new DecisionTree(IsRightLeaf, ref RightData, RightLeafValue, DepthRemaining - 1, ref featuresTakenHelper);
                    }
                    else if(IsLeftLeaf)
                    {
                        RightLeafValue = RightData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
                        LeftTree = new DecisionTree(IsLeftLeaf, ref LeftData, LeftLeafValue, DepthRemaining - 1, ref featuresTakenHelper);
                        RightTree = new DecisionTree(true, ref RightData, RightLeafValue, DepthRemaining - 1, ref featuresTakenHelper);
                    }
                    else if(IsRightLeaf)
                    {
                        LeftLeafValue = LeftData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
                        LeftTree = new DecisionTree(true, ref LeftData, LeftLeafValue, DepthRemaining - 1, ref featuresTakenHelper);
                        RightTree = new DecisionTree(IsRightLeaf, ref RightData, RightLeafValue, DepthRemaining - 1, ref featuresTakenHelper);
                    }
                    else
                    {
                        if (LeftData.Count == 0 && RightData.Count == 0)
                        {
                            LeftLeafValue = '-';
                            RightLeafValue = '+';
                        }
                        else if (LeftData.Count == 0)
                        {
                            LeftLeafValue = RightData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
                        }
                        else if (RightData.Count == 0)
                        {
                            RightLeafValue = LeftData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
                        }
                        else
                        {
                            LeftLeafValue = LeftData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
                            RightLeafValue = RightData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
                        }
                        LeftTree = new DecisionTree(true, ref LeftData, LeftLeafValue, DepthRemaining - 1, ref featuresTakenHelper);
                        RightTree = new DecisionTree(true, ref RightData, RightLeafValue, DepthRemaining - 1, ref featuresTakenHelper);
                    }
                }
            }
        }
        public void PrintInformationGain()
        {
            Console.WriteLine("Is their first name longer than their last name?");
            Console.WriteLine(informationGain.FirstBigger.ToString());

            Console.WriteLine("Do they have a middle name?");
            Console.WriteLine(informationGain.MiddleName.ToString());

            Console.WriteLine("Does their first name start and end with the same letter?");
            Console.WriteLine(informationGain.FirstStartEnd.ToString());

            Console.WriteLine("Does their first name come alphabetically before their last name?");
            Console.WriteLine(informationGain.FirstAlpha.ToString());

            Console.WriteLine("Is the second letter of their first name a vowel (a,e,i,o,u)?");
            Console.WriteLine(informationGain.FirstVowel.ToString());

            Console.WriteLine("Is the number of letters in their last name even?");
            Console.WriteLine(informationGain.LastEven.ToString());
        }
        public int DetermineDepth(int count)
        {
            if(IsLeaf)
            {
                return count++;
            }
            else
            {
                int r = LeftTree.DetermineDepth(count + 1);
                int p = RightTree.DetermineDepth(count + 1);
                return Math.Max(r, p);
            }
        }
        public void CollapseTree()
        {
            if (!IsLeaf)
            {
                if (LeftTree.IsLeaf && RightTree.IsLeaf)
                {
                    if (LeftTree.Value.Equals(RightTree.Value))
                    {
                        IsLeaf = true;
                        Value = LeftTree.Value;
                        LeftTree = null;
                        RightTree = null;
                        Feature = Features.None;
                    }
                }
                else
                {
                    LeftTree.CollapseTree();
                    RightTree.CollapseTree();
                    if (LeftTree.IsLeaf && RightTree.IsLeaf)
                    {
                        if (LeftTree.Value.Equals(RightTree.Value))
                        {
                            IsLeaf = true;
                            Value = LeftTree.Value;
                            LeftTree = null;
                            RightTree = null;
                            Feature = Features.None;
                        }
                    }
                }
            }
        }
        public void TraverseTree()
        {
            if(IsLeaf)
            {
                Console.WriteLine(Value);
            }
            else
            {
                Console.WriteLine(Feature);
                LeftTree.TraverseTree();
                RightTree.TraverseTree();
            }
        }
        public int DetermineError(ref List<TrainingData> TestData)
        {
            int errors = 0;
            foreach (var item in TestData)
            { //for each item, i want to traverse down the tree
                errors += DetermineSubError(item);
            }
            return errors;
        }
        private int DetermineSubError(TrainingData item)
        {
            if (IsLeaf)
            {
                if (item.Label != Value) { return 1; }
                else { return 0; }
            }
            else
            {
                if (Feature == Features.FirstBigger)
                {
                    if (item.FirstBigger) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.MiddleName)
                {
                    if (item.MiddleName) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.FirstStartEnd)
                {
                    if (item.FirstStartEnd) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.FirstAlpha)
                {
                    if (item.FirstAlpha) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                } 
                else if (Feature == Features.FirstVowel)
                {
                    if (item.FirstVowel) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if(Feature == Features.LastEven) 
                {
                    if (item.LastEven) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }                                
                else if (Feature == Features.FirstPeriod)
                {
                    if (item.FirstPeriod) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.MiddlePeriod)
                {
                    if (item.MiddlePeriod) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.FirstHyphen)
                {
                    if (item.FirstHyphen) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.LastHyphen)
                {
                    if (item.LastHyphen) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.FirstEven)
                {
                    if (item.FirstEven) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.MiddleEven)
                {
                    if (item.MiddleEven) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.FirstBigger4)
                {
                    if (item.FirstBigger4) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.LastBigger4)
                {
                    if (item.LastBigger4) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.LastStartEnd)
                {
                    if (item.LastStartEnd) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.MiddleStartEnd)
                {
                    if (item.MiddleStartEnd) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.Last2ndVowel)
                {
                    if (item.Last2ndVowel) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.First3rdVowel)
                {
                    if (item.First3rdVowel) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else if (Feature == Features.Last3rdVowel)
                {
                    if (item.Last3rdVowel) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
                else //(Feature == Features.ThreeSpaces)
                {
                    if (item.ThreeSpaces) { return RightTree.DetermineSubError(item); }
                    else { return LeftTree.DetermineSubError(item); }
                }
            }
        }

    }
}
