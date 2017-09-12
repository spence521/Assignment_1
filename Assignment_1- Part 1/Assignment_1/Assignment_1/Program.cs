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
            Data data;

            #region Passing in parameters
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a file argument.");
                return;
            }
            StreamReader reader = File.OpenText(args[0]);
            if (args.Length > 1)
            {
                StreamReader reader2 = File.OpenText(args[1]);
                data = new Data(reader, reader2);
                Console.WriteLine("\t" + data.Error + "\n");
            }
            else
            {
                data = new Data(reader);
                //data.TraverseTree();
                Console.WriteLine("\nThe depth of your tree is: \n" + data.Depth + "\n");
            }
            #endregion

            #region Non-arguments
            //string startupPath = System.IO.Directory.GetCurrentDirectory();
            //StreamReader reader = File.OpenText(startupPath + @"\updated_train.txt");
            //StreamReader reader2 = File.OpenText(startupPath + @"\updated_train.txt");
            //data = new Data(reader, reader2);
            //Console.WriteLine(data.Error);
            //Console.ReadKey(false);
            #endregion
            //tree.PrintTrainingData();
            //tree.PrintData();
            //tree.display();
        }
        //static decimal helper(double P, double N)
        //{
        //    return decimal.Parse(((-P * Math.Log(P, 2)) - (N * Math.Log(N, 2))).ToString());
        //}
    }


}