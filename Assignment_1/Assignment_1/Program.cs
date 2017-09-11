using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Passing in parameters
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a file argument.");
                return;
            }
            StreamReader reader = File.OpenText(args[0]);
            #endregion

            #region Non-arguments
            //string startupPath = System.IO.Directory.GetCurrentDirectory();
            //StreamReader reader = File.OpenText(startupPath + @"\updated_train.txt");
            //Console.WriteLine(startupPath + @"\training.data");
            #endregion
            Data data = new Data(reader);
            //Console.WriteLine(data.Depth);
            data.TraverseTree();
            Console.WriteLine(data.Error);
            // helper(0.66257668711656437, 0.33742331288343558);
            //Console.WriteLine(tree.Entropy);
            //tree.PrintTrainingData();
            //tree.PrintData();
            //tree.display();
            // Console.ReadKey(false);
        }
        //static decimal helper(double P, double N)
        //{
        //    return decimal.Parse(((-P * Math.Log(P, 2)) - (N * Math.Log(N, 2))).ToString());
        //}
    }
}