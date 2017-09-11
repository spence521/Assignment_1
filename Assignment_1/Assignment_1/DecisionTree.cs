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
        public enum Features {FirstBigger, MiddleName, FirstStartEnd, FirstAlpha, FirstVowel, LastEven, None }

        public Features Feature { get; set; }
        public bool IsLeaf { get; set; }
        public DecisionTree LeftTree { get; set; } //no
        public DecisionTree RightTree { get; set; } //yes
        public char? Value { get; set; }
        public List<TrainingData> trainingData { get; private set; }
        public double Entropy { get; private set; }
        public InformationGain informationGain { get; private set; }
        public double Error { get; set; } // gets set in SetEntropy

        public DecisionTree(ref List<TrainingData> trainingdata)
        {
            informationGain = new InformationGain();
            IsLeaf = false;
            LeftTree = null;
            RightTree = null;
            Value = null;
            trainingData = trainingdata;
            SetEntropy();
            SetInformationGain();
            DetermineFeature();
            DetermineSubTrees();
        }

        public DecisionTree(bool isLeaf, ref List<TrainingData> trainingdata, char? value = null)
        {
            IsLeaf = isLeaf;
            LeftTree = null;
            RightTree = null;
            Value = value;
            if (!IsLeaf)
            {
                informationGain = new InformationGain();
                trainingData = trainingdata;
                SetEntropy();
                SetInformationGain();
                DetermineFeature();
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
            #endregion

            foreach (var item in trainingData)
            {
                if (item.FirstBigger)
                {
                    if (item.Label.Equals('+')) { F1_Yes_P++; }
                    else if (item.Label.Equals('-')) { F1_Yes_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F1_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F1_No_P++; }
                    else if (item.Label.Equals('-')) { F1_No_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F1_No++;
                }

                if (item.MiddleName)
                {
                    if (item.Label.Equals('+')) { F2_Yes_P++; }
                    else if (item.Label.Equals('-')) { F2_Yes_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F2_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F2_No_P++; }
                    else if (item.Label.Equals('-')) { F2_No_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F2_No++;
                }

                if (item.FirstStartEnd)
                {
                    if (item.Label.Equals('+')) { F3_Yes_P++; }
                    else if (item.Label.Equals('-')) { F3_Yes_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F3_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F3_No_P++; }
                    else if (item.Label.Equals('-')) { F3_No_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F3_No++;
                }

                if (item.FirstAlpha)
                {
                    if (item.Label.Equals('+')) { F4_Yes_P++; }
                    else if (item.Label.Equals('-')) { F4_Yes_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F4_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F4_No_P++; }
                    else if (item.Label.Equals('-')) { F4_No_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F4_No++;
                }

                if (item.FirstVowel)
                {
                    if (item.Label.Equals('+')) { F5_Yes_P++; }
                    else if (item.Label.Equals('-')) { F5_Yes_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F5_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F5_No_P++; }
                    else if (item.Label.Equals('-')) { F5_No_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F5_No++;
                }

                if (item.LastEven)
                {
                    if (item.Label.Equals('+')) { F6_Yes_P++; }
                    else if (item.Label.Equals('-')) { F6_Yes_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F6_Yes++;
                }
                else
                {
                    if (item.Label.Equals('+')) { F6_No_P++; }
                    else if (item.Label.Equals('-')) { F6_No_N++; }
                    else { Console.Error.WriteLine("You have corrupt data!"); }
                    F6_No++;
                }
            }

            informationGain.FirstBigger = CalculateInformationGain(F1_Yes, F1_No, F1_Yes_P, F1_Yes_N, F1_No_P, F1_No_N);
            informationGain.MiddleName = CalculateInformationGain(F2_Yes, F2_No, F2_Yes_P, F2_Yes_N, F2_No_P, F2_No_N);
            informationGain.FirstStartEnd = CalculateInformationGain(F3_Yes, F3_No, F3_Yes_P, F3_Yes_N, F3_No_P, F3_No_N);
            informationGain.FirstAlpha = CalculateInformationGain(F4_Yes, F4_No, F4_Yes_P, F4_Yes_N, F4_No_P, F4_No_N);
            informationGain.FirstVowel = CalculateInformationGain(F5_Yes, F5_No, F5_Yes_P, F5_Yes_N, F5_No_P, F5_No_N);
            informationGain.LastEven = CalculateInformationGain(F6_Yes, F6_No, F6_Yes_P, F6_Yes_N, F6_No_P, F6_No_N);
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
            else { Feature = Features.None; }
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
            else { LeftData = trainingData.Where(x => x.LastEven == false).ToList(); } //(Feature == Features.LastEven) 
            List<char> LeftLeafList = (from h in LeftData select h.Label).Distinct().ToList();
            bool IsLeftLeaf = (LeftLeafList.Count == 1);
            if (IsLeftLeaf)
            {
                LeftLeafValue = LeftData.Select(p => p.Label).First();
            }

            List<bool> FirstBigger_LeftLeafList = (from h in LeftData select h.FirstBigger).Distinct().ToList();
            List<bool> MiddleName_LeftLeafList = (from h in LeftData select h.MiddleName).Distinct().ToList();
            List<bool> FirstStartEnd_LeftLeafList = (from h in LeftData select h.FirstStartEnd).Distinct().ToList();
            List<bool> FirstAlpha_LeftLeafList = (from h in LeftData select h.FirstAlpha).Distinct().ToList();
            List<bool> FirstVowel_LeftLeafList = (from h in LeftData select h.FirstVowel).Distinct().ToList();
            List<bool> LastEven_LeftLeafList = (from h in LeftData select h.LastEven).Distinct().ToList();
            if(FirstBigger_LeftLeafList.Count == 1 && MiddleName_LeftLeafList.Count == 1 && FirstStartEnd_LeftLeafList.Count == 1 && FirstAlpha_LeftLeafList.Count == 1 &&
                FirstVowel_LeftLeafList.Count == 1 && LastEven_LeftLeafList.Count == 1)
            {
                IsLeftLeaf = true;
                var qaz = LeftData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(2).Select(p => p.Key).ToList();
                var maz = LeftData.GroupBy(m => m.Label).ToList();
                LeftLeafValue = LeftData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
            }


            char? RightLeafValue = null;
            List<TrainingData> RightData;
            if (Feature == Features.FirstBigger) { RightData = trainingData.Where(x => x.FirstBigger == true).ToList(); }
            else if (Feature == Features.MiddleName) { RightData = trainingData.Where(x => x.MiddleName == true).ToList(); }
            else if (Feature == Features.FirstStartEnd) { RightData = trainingData.Where(x => x.FirstStartEnd == true).ToList(); }
            else if (Feature == Features.FirstAlpha) { RightData = trainingData.Where(x => x.FirstAlpha == true).ToList(); }
            else if (Feature == Features.FirstVowel) { RightData = trainingData.Where(x => x.FirstVowel == true).ToList(); }
            else  { RightData = trainingData.Where(x => x.LastEven == true).ToList(); } //(Feature == Features.LastEven)
            List<char> RightLeafList = (from h in RightData select h.Label).Distinct().ToList();
            bool IsRightLeaf = (RightLeafList.Count == 1);
            if (IsRightLeaf)
            {
                RightLeafValue = RightData.Select(p => p.Label).First();
            }


            List<bool> FirstBigger_RightLeafList = (from h in RightData select h.FirstBigger).Distinct().ToList();
            List<bool> MiddleName_RightLeafList = (from h in RightData select h.MiddleName).Distinct().ToList();
            List<bool> FirstStartEnd_RightLeafList = (from h in RightData select h.FirstStartEnd).Distinct().ToList();
            List<bool> FirstAlpha_RightLeafList = (from h in RightData select h.FirstAlpha).Distinct().ToList();
            List<bool> FirstVowel_RightLeafList = (from h in RightData select h.FirstVowel).Distinct().ToList();
            List<bool> LastEven_RightLeafList = (from h in RightData select h.LastEven).Distinct().ToList();
            if (FirstBigger_RightLeafList.Count == 1 && MiddleName_RightLeafList.Count == 1 && FirstStartEnd_RightLeafList.Count == 1 && FirstAlpha_RightLeafList.Count == 1 &&
                FirstVowel_RightLeafList.Count == 1 && LastEven_RightLeafList.Count == 1)
            {
                IsRightLeaf = true;
                RightLeafValue = RightData.GroupBy(m => m.Label).OrderByDescending(r => r.Count()).Take(1).Select(p => p.Key).First();
            }


            if(LeftLeafValue.Equals(RightLeafValue) && (!(LeftLeafValue == null) || !(RightLeafValue == null)))
            {
                IsLeaf = true;
                LeftTree = null;
                RightTree = null;
                Value = LeftLeafValue;
                Feature = Features.None;
            }
            else
            {
                LeftTree = new DecisionTree(IsLeftLeaf, ref LeftData, LeftLeafValue);
                RightTree = new DecisionTree(IsRightLeaf, ref RightData, RightLeafValue);
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
    }
}
