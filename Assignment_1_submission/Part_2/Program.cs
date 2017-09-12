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
            StreamReader reader;
            StreamReader reader2;
            StreamReader reader3;
            StreamReader reader4;
            int depth;
            #region Passing in parameters
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a file argument.");
                return;
            }
            else if (args.Length == 2)
            {
                reader = File.OpenText(args[0]);
                reader2 = File.OpenText(args[1]);
                data = new Data(reader, reader2, int.MaxValue);
                Console.WriteLine("\t" + data.Error + "\n");
            }
            else if(args.Length == 3)
            {
                reader = File.OpenText(args[0]);
                reader2 = File.OpenText(args[1]);
                depth = Convert.ToInt32(args[2]);
                data = new Data(reader, reader2, depth);
                Console.WriteLine("\t" + Math.Round(100 - data.Error, 3) + "% Accuracy");
            }
            else if (args.Length > 3) //at least four arguments
            {
                reader = File.OpenText(args[0]);
                reader2 = File.OpenText(args[1]);
                reader3 = File.OpenText(args[2]);
                reader4 = File.OpenText(args[3]);
                if (args.Length == 4)
                {
                    data = new Data(reader, reader2, reader3, reader4, int.MaxValue);
                    Console.WriteLine(data.Error);
                }
                else
                {
                    depth = Convert.ToInt32(args[4]);
                    data = new Data(reader, reader2, reader3, reader4, depth);
                    Console.WriteLine("\t" + Math.Round(100 - data.Error, 3) + "% Accuracy\n"
                        + "Standard Deviation:\t" + Math.Round(data.StandardDeviation, 4));
                }
                //data.PrintData2();
            }

            #endregion

            #region Non-arguments
            //string startupPath = System.IO.Directory.GetCurrentDirectory();
            //StreamReader reader = File.OpenText(startupPath + @"\updated_training00.txt");
            //StreamReader reader2 = File.OpenText(startupPath + @"\updated_training01.txt");
            //StreamReader reader3 = File.OpenText(startupPath + @"\updated_training02.txt");
            //StreamReader reader4 = File.OpenText(startupPath + @"\updated_training03.txt");
            //StreamReader reader = File.OpenText(startupPath + @"\updated_train.txt");
            //StreamReader reader2 = File.OpenText(startupPath + @"\updated_test.txt");
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