using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_calculator
{
   public class CalculatorOperation
    {
        #region CalculatorOperationMethod
        public static string Sum(string input1, string input2)
        {
            if (input1.Length > input2.Length)
            {
                string swapt = input1;
                input1 = input2;
                input2 = swapt;

            }

            //Take an empty string for Calculation of Two Sum

            string result = string.Empty;
            int number1 = input1.Length;
            int number2 = input2.Length;

            //Take one IntegerFor Carry
            int carry = 0;
            int diff = number2 - number1;

            //Lets calculate from end to begining

            for (int i = number1 - 1; i >= 0; i--)
            {
                int sum = ((int)(input1[i] - '0') + (int)(input2[i + diff] - '0') + carry);
                result += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            // LEts add reminder

            for (int i = number2 - number1 - 1; i >= 0; i--)
            {
                int sum = ((int)(input2[i] - '0') + carry);
                result += (char)(sum % 10 + '0');
                carry = sum / 10;
            }
            if (carry > 0)
            {
                result += (char)(carry + '0');
            }
            char[] ch2 = result.ToCharArray();
            Array.Reverse(ch2);
            return new string(ch2);

        }
        public static string Sub(string input1, string input2)
        {
            string result = string.Empty;
            if (FindSmallerInput(input1, input2))
            {

                string swap = input1;
                input1 = input2;
                input2 = swap;
            }
            int inp1Length = input1.Length;
            int inp2Lenght = input2.Length;

            int diff = inp1Length - inp2Lenght;
            int carry = 0;
            for (int i = inp2Lenght - 1; i >= 0; i--)
            {
                int sub = (((int)input1[i + diff] - (int)'0') - ((int)input2[i] - (int)'0') - carry);
                if (sub < 0)
                {
                    sub = sub + 10;
                    carry = 1;

                }
                else
                    carry = 0;
                result += sub.ToString();

            }
            for (int i = inp1Length - inp2Lenght - 1; i >= 0; i--)
            {
                if (input1[i] == '0' && carry > 0)
                {
                    result += '9';
                    continue;
                }
                int sub = (((int)input1[i] - (int)'0') - carry);
                if (i < 0 || sub > 0)
                {
                    result += sub.ToString();
                    carry = 1;

                }
                else
                    carry = 0;

            }
            char[] resultoutput = result.ToCharArray();
            Array.Reverse(resultoutput);
            return new string(resultoutput);

        }
        public static bool FindSmallerInput(string val1, string val2)
        {
            int number1 = val1.Length;
            int number2 = val2.Length;
            bool res = false;
            if (number1 < number2) return true;
            if (number1 > number2) return false;

            for (int ni = 0; ni < number1; ni++)
            {
                if (val1[ni] < val2[ni]) return true;
                if (val1[ni] > val2[ni]) return false;
            }
            return false;

        }
        public static string Mult(string input1, string input2)
        {
            int len1 = input1.Length;
            int len2 = input2.Length;
            if (len1.ToString()=="0" && len2.ToString()=="0")
                return "0";
            int[] result = new int[len1 + len2];
            int i_n1 = 0;
            int i_n2 = 0;
            int i = 0;
            for (i = len1 - 1; i >= 0; i--)
            {
                int carry = 0;
                int n1 = input1[i] - '0';
                i_n2 = 0;

                for (int j = len2 - 1; j >= 0; j--)
                {
                    int n2 = input2[j] - '0';
                    int sum = n1 * n2 + result[i_n1 + i_n2] + carry;
                    carry = sum / 10;
                    result[i_n1 + i_n2] = sum % 10;
                    i_n2++;
                }
                if (carry > 0)
                    result[i_n1 + i_n2] += carry;

                i_n1++;
            }
            i = result.Length - 1;
            while (i >= 0 && result[i] == 0)
                i--;
            if (i == -1)
                return "0";
            string s = string.Empty;
            while (i >= 0)
            {
                s += (result[i--]);

            }
            return s;

        }
        public static string Div(string input1, string input2)
        {
            string res = string.Empty;
            int index = 0;
            double temp = 0;
            temp = (int)(input1[index] - '0');
            while (temp < double.Parse(input2))
            {
                temp = temp * 10 + (int)(input1[index + 1] - '0');
                index++;
            }
            ++index;
            while (input1.Length > index)
            {
                res += (char)(temp / (double.Parse(input2)) + '0');
                temp = (temp % (double.Parse(input2))) * 10 + (int)(input1[index] - '0');
                index++;
            }
            res += (char)(temp / double.Parse(input2) + '0');
            if (res.Length == 0)
                return "0";
            return res;
        }
        #endregion
    }
}
