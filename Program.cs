using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter expression");
                string inputExpression = Console.ReadLine();

                if (inputExpression.Contains(" * "))
                {
                    int num1, num2, den1, den2;
                    ExtractFractionNumbers(inputExpression, " * ",out num1, out num2,out den1,out den2);

                    int TotalNum = num1 * num2;
                    int TotalDen = den1 * den2;
                    if (TotalDen > 1)
                    {
                        Console.WriteLine(ConvertToFraction(TotalNum, TotalDen));
                    }
                    else
                    {
                        Console.WriteLine(TotalNum);
                    }
                    Console.ReadLine();
                }
                else if (inputExpression.Contains(" / "))
                {
                    int num1, num2, den1, den2;
                    ExtractFractionNumbers(inputExpression, " / ", out num1, out num2, out den1, out den2);

                    int TotalNum = num1 * den2;
                    int TotalDen = den1 * num2;
                    if (TotalDen > 1)
                    {
                        Console.WriteLine(ConvertToFraction(TotalNum, TotalDen));
                    }
                    else
                    {
                        Console.WriteLine(TotalNum);
                    }
                    Console.ReadLine();
                }
                else if (inputExpression.Contains(" - "))
                {
                    int num1, num2, den1, den2;
                    ExtractFractionNumbers(inputExpression, " - ", out num1, out num2, out den1, out den2);

                    int TotalNum = (num1 * den2) - (num2 * den1);
                    int TotalDen = den1 * den2;

                    int commonFactor = GetCommonFactor(TotalNum, TotalDen);
                    TotalNum = TotalNum / commonFactor;
                    TotalDen = TotalDen / commonFactor;
                    if (TotalDen > 1)
                    {
                        Console.WriteLine(ConvertToFraction(TotalNum, TotalDen));
                    }
                    else
                    {
                        Console.WriteLine(TotalNum);
                    }
                    Console.ReadLine();
                }
                else if (inputExpression.Contains(" + "))
                {
                    int num1, num2, den1, den2;
                    ExtractFractionNumbers(inputExpression, " + ", out num1, out num2, out den1, out den2);

                    int TotalNum = (num1 * den2) + (num2 * den1);
                    int TotalDen = den1 * den2;
                    if (TotalDen > 1)
                    {
                        int commonFactor = GetCommonFactor(TotalNum, TotalDen);
                        TotalNum = TotalNum / commonFactor;
                        TotalDen = TotalDen / commonFactor;
                        Console.WriteLine(ConvertToFraction(TotalNum, TotalDen));
                    }
                    else
                    {
                        Console.WriteLine(TotalNum);
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Error: Invalid expresion");
                }
            }
            catch
            {
                Console.WriteLine("Error: Invalid expression");
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Extract two numbers into fractions from given arithmetic expresion
        /// </summary>
        /// <param name="inputExpression"></param>
        /// <param name="arthOperator"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="den1"></param>
        /// <param name="den2"></param>
        static void ExtractFractionNumbers(string inputExpression, string arthOperator, out int num1, out int num2,  out int den1,  out int den2){
            string[] inputData = ConvertToFractions(inputExpression.Split(new string[] { arthOperator }, StringSplitOptions.None));
            if (inputData[0].Split('/').Length == 2)
            {
                num1 = Convert.ToInt16(inputData[0].Split('/')[0]);
                den1 = Convert.ToInt16(inputData[0].Split('/')[1]);
            }
            else
            {
                num1 = Convert.ToInt16(inputData[0]);
                den1 = 1;
            }
            if (inputData[1].Split('/').Length == 2)
            {
                num2 = Convert.ToInt16(inputData[1].Split('/')[0]);
                den2 = Convert.ToInt16(inputData[1].Split('/')[1]);
            }
            else
            {
                num2 = Convert.ToInt16(inputData[1]);
                den2 = 1;
            }

        }
        /// <summary>
        /// Convert into fraction representaion from numerator and denominator 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="den"></param>
        /// <returns></returns>
        static string ConvertToFraction(int num, int den)
        {
            int number = num/den;
            return num % den > 0 ? number != 0 ? Convert.ToString(number + "_" + num % den + "/" + den) : Convert.ToString(num + "/" + den) : number != 0 ? Convert.ToString(number) : Convert.ToString(num + "/" + den);
        }
        /// <summary>
        /// Get the GCD (greatest common divisor)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int GetCommonFactor(int a, int b)
        {
            if (a == 0)
                return b;
            return GetCommonFactor(b % a, a);
        } 
        /// <summary>
        /// Convert mixed numbers into fractions
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        static string[] ConvertToFractions(string[] inputData)
        {
            try
            {
                List<string> inputValidData = new List<string>();
                foreach (string element in inputData)
                {
                    if (element.Contains('_'))
                    {
                        int fraNumber = Convert.ToInt16(element.Trim().Split('_')[0]);
                        int num = Convert.ToInt16(element.Trim().Split('_')[1].Split('/')[0]);
                        int denami = Convert.ToInt16(element.Trim().Split('_')[1].Split('/')[1]);
                        inputValidData.Add(Convert.ToString((fraNumber * denami) + num) + "/" + denami);
                    }
                    else
                    {
                        inputValidData.Add(element);
                    }
                }
                return inputValidData.ToArray();
            }
            catch
            {
                throw;
            }

        }
    }
}