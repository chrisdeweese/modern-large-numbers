using System.Collections.Generic;
using UnityEngine;
using System;

namespace ModernProgramming
{
    [Serializable]
    public class LargeNumber
    {
        private const int MAX_SEGMENTS = 42;

        [Range(0, 999)] public List<int> number;

        /// <summary>
        /// Names for all large numbers.
        /// </summary>
        public enum Suffixes
        {
            None,                   // 10^0
            Thousand,               // 10^3
            Million,                // 10^6
            Billion,                // 10^9
            Trillion,               // 10^12
            Quadrillion,            // 10^15
            Qintillion,             // 10^18
            Sextillion,             // 10^21
            Septillion,             // 10^24
            Octillion,              // 10^27
            Nonillion,              // 10^30
            Decillion,              // 10^33
            Undecillion,            // 10^36
            Duodecillion,           // 10^39
            Tredecillion,           // 10^42
            Quattuordecillion,      // 10^45
            Quindecillion,          // 10^48
            Sexdecillion,           // 10^51
            Septendecillion,        // 10^54
            Octodecillion,          // 10^57
            Novemdecillion,         // 10^60
            Vigintillion,           // 10^63
            Unvigintillion,         // 10^66
            Duovigintillion,        // 10^69
            Trevigintillion,        // 10^72
            Quattuorvigintillion,   // 10^75
            Quinvigintillion,       // 10^78
            Sexvigintillion,        // 10^81
            Septenvigintillion,     // 10^84
            Octovigintillion,       // 10^87
            Novemvigintillion,      // 10^90
            Trigintillion,          // 10^93
            Untrigintillion,        // 10^96
            Duotrigintillion,       // 10^99
            Trestrigintillion,      // 10^102
            Quattuortrigintillion,  // 10^105
            Quinquatrigintillion,   // 10^108
            Sestrigintillion,       // 10^111
            Septentrigintillion,    // 10^114
            Octotrigintillion,      // 10^117
            Noventrigintillion,     // 10^120
            Quadragintillion        // 10^123
        };

        /// <summary>
        /// Creates a new large number with default value of zero.
        /// </summary>
        public LargeNumber()
        {
            number = new List<int> {000};
        }

        /// <summary>
        /// Creates a new large number clamped between 0 and 999.
        /// </summary>
        public LargeNumber(int newNumber)
        {
            number = new List<int> {Mathf.Clamp(newNumber, 0, 999)};
        }

        /// <summary>
        /// Creates a new large number with up to forty-two 3 digit segments (10^123)
        /// </summary>
        /// <param name="newNumber">First segment</param>
        /// <param name="newSegments">Number of following segments</param>
        public LargeNumber(int newNumber, int newSegments)
        {
            if (newSegments > MAX_SEGMENTS)
            {
                newSegments = MAX_SEGMENTS;
            }

            number = new List<int>();
            number.Add(Mathf.Clamp(newNumber, 0, 999));
        }
        
        /// <summary>
        /// Removes leading zeroes from large number.
        /// </summary>
        public void RemoveLeadingZeros()
        {
            for (int i = number.Count - 1; i > 0; i--)
            {
                if (number[i] == 0)
                {
                    number.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Add one to the large number.
        /// </summary>
        public void AddOne()
        {
            number[0] += 1;
            if (number[0] > 999)
            {
                number[0] = 0;
                AddOne(1);
            }
        }

        /// <summary>
        /// Subtract one from the large number.
        /// </summary>
        public void SubtractOne()
        {
            number[0] -= 1;
            if (number[0] < 0)
            {
                if (number.Count > 1)
                    SubtractOne(1);
                else
                {
                    number[0] = 0;
                }
            }
            RemoveLeadingZeros();
        }
        
        /// <summary>
        /// Adds a large number to this large number.
        /// </summary>
        /// <param name="numberToAdd">Number to add.</param>
        public void AddLargeNumber(LargeNumber numberToAdd)
        {
            int difference = number.Count - numberToAdd.number.Count;

            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                    numberToAdd.number.Add(000);
            }
            else if (difference < 0)
            {
                for (int i = 0; i > difference; i--)
                    number.Add(000);
            }
            for (int i = 0; i < number.Count; i++)
            {
                difference = number.Count - numberToAdd.number.Count;
                if (difference > 0)
                {
                    for (int o = 0; o < difference; o++)
                        numberToAdd.number.Add(000);
                }
                else if (difference < 0)
                {
                    for (int o = 0; o > difference; o--)
                        number.Add(000);
                }

                int carry = 0;
                int total = number[i] + numberToAdd.number[i] + carry;
                if (total > 999)
                {
                    //carry
                    carry = (int)total / 1000;
                    //remainder
                    int newNumber = total - (carry * 1000);

                    number[i] = newNumber;
                    if (i == number.Count - 1)
                    {
                        number.Add(carry);
                        carry = 0;
                    }
                    else
                    {
                        AddLargeNumber(i + 1, carry);
                    }
                }
                else
                {
                    number[i] = total;
                }
            }
            //number = result;
            RemoveLeadingZeros();
            numberToAdd.RemoveLeadingZeros();

            if (number.Count > MAX_SEGMENTS)
            {
                for (int n = 0; n < number.Count; n++)
                {
                    number[n] = 999;
                }
                number.RemoveRange(MAX_SEGMENTS, number.Count - MAX_SEGMENTS);
            }
        }

        /// <summary>
        /// Subtracts a large number from this large number.
        /// </summary>
        /// <param name="numberToSubtract"></param>
        public void SubLargeNumber(LargeNumber numberToSubtract)
        {
            LargeNumber temp = new LargeNumber();
            temp.Assign(numberToSubtract);
            if (Equals(temp) <= 0)
            {
                number.Clear();
                number.Add(000);
            }
            else
            {
                //get string of largeNumber parameter
                string amountString = temp.LargeNumberToString();
                //compare length of numbers
                int digitDifference = LargeNumberToString().Length - amountString.Length;
                //make numbers the same digits
                for (int i = 0; i < digitDifference; i++)
                {
                    amountString = "0" + amountString;
                }
                //Debug.Log("amountString: " + amountString);
                //create 9's compliment of p_amountString
                string number9sCompliment = "";
                //for (int i = amountString.Length-1; i > 0; i--)
                for (int i = 0; i < amountString.Length; i++)
                {
                    if (amountString[i].Equals('0'))
                    {
                        number9sCompliment += "9";
                    }
                    if (amountString[i].Equals('1'))
                    {
                        number9sCompliment += "8";
                    }
                    if (amountString[i].Equals('2'))
                    {
                        number9sCompliment += "7";
                    }
                    if (amountString[i].Equals('3'))
                    {
                        number9sCompliment += "6";
                    }
                    if (amountString[i].Equals('4'))
                    {
                        number9sCompliment += "5";
                    }
                    if (amountString[i].Equals('5'))
                    {
                        number9sCompliment += "4";
                    }
                    if (amountString[i].Equals('6'))
                    {
                        number9sCompliment += "3";
                    }
                    if (amountString[i].Equals('7'))
                    {
                        number9sCompliment += "2";
                    }
                    if (amountString[i].Equals('8'))
                    {
                        number9sCompliment += "1";
                    }
                    if (amountString[i].Equals('9'))
                    {
                        number9sCompliment += "0";
                    }
                }
                //SUB
                temp.Assign(temp.StringToLargeNumber(number9sCompliment));
                int digits = LargeNumberToString().Length;
                AddLargeNumber(temp);
                //check to see if there is a carry
                if (digits < LargeNumberToString().Length)
                {
                    int addCarry = number[number.Count - 1];
                    int subCarry = 1;

                    if (addCarry > 9)
                    {
                        subCarry = 10;
                        addCarry /= 10;
                    }
                    if (addCarry > 9)
                    {
                        subCarry = 100;
                        addCarry /= 10;
                    }
                    subCarry *= addCarry;

                    number[number.Count - 1] -= subCarry;
                    if (number[number.Count - 1] < 1)
                        number[number.Count - 1] = 0;
                    temp = new LargeNumber(addCarry);
                    AddLargeNumber(temp);
                }

                RemoveLeadingZeros();
            }
        }

        /// <summary>
        /// Check if large number is equal to this large number.
        /// </summary>
        /// <param name="numberToCompare"></param>
        public int Equals(LargeNumber numberToCompare)
        {
            int match = 0;
            if (number.Count == numberToCompare.number.Count)
            {
                for (int i = number.Count - 1; i >= 0; i--)
                {
                    if (number[i] != numberToCompare.number[i])
                    {
                        if (number[i] > numberToCompare.number[i])
                            match = 1;
                        else
                            match = -1;
                        break;
                    }
                }
            }
            else
            {
                if (number.Count > numberToCompare.number.Count)
                    match = 1;
                else
                    match = -1;
            }

            return match;
        }

        //TODO: ASSIGNMENT
        public void Assign(LargeNumber p_num)
        {
            number.Clear();
            foreach (int i in p_num.number)
            {
                number.Add(i);
            }
        }
        
        public string LargeNumberToShortString()
        {
            if (number.Count == 0)
                return "0";
            string result = "" + number[number.Count - 1];
            if (number.Count > 1)
            {
                result += "." + string.Format("{0:000}", number[number.Count - 2]);
                result += " " + (Suffixes)(number.Count - 1);
            }

            return result;
        }

        public string LargeNumberToString()
        {
            string result = "";
            for (int i = number.Count - 1; i >= 0; i--)
            {
                if (number[i] < 100)
                    result += "0";
                if (number[i] < 10)
                    result += "0";
                result += number[i];
            }

            result = result.TrimStart('0');

            return result;
        }

        public LargeNumber StringToLargeNumber(string p_str)
        {
            LargeNumber result = new LargeNumber();

            while (p_str.Length % 3 != 0)
            {
                p_str = "0" + p_str;
            }

            //for substring second parameter is length
            for (int i = 0; i < p_str.Length; i += 3)
            {
                result.number.Add(int.Parse(p_str.Substring(i, 3)));
            }

            result.number.Reverse();

            for (int i = result.number.Count - 1; i > 0; i--)
            {
                if (result.number[i] == 0)
                {
                    result.number.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }

            return result;
        }
        
        public void ClampList()
    {
        if (number.Count > MAX_SEGMENTS)
            number.RemoveRange(MAX_SEGMENTS, number.Count - MAX_SEGMENTS);
    }

        #region ## Private Methods ##

        private void AddOne(int segmentCount)
        {
            if (number.Count == segmentCount)
            {
                if (number.Count < MAX_SEGMENTS)
                {
                    number.Add(1);
                }
            }
            else
            {
                number[segmentCount]++;
                if (number[segmentCount] > 999)
                {
                    number[segmentCount] = 0;
                    AddOne(segmentCount + 1);
                }
            }
        }
        
        private void SubtractOne(int p_count)
        {
            bool flag = true;
            for (int i = p_count; i < number.Count; i++)
            {
                if (number[i] != 0)
                {
                    number[i]--;
                    for (int o = i - 1; o >= 0; o--)
                    {
                        number[o] = 999;
                    }
                    flag = false;
                    break;
                }
                if (flag)
                {
                    number[i - 1] = 0;
                }
            }
        }
        
        private void AddLargeNumber(int count, int carry)
        {
            int total = number[count] + carry;
            if (total > 999)
            {
                //carry
                carry = (int)total / 1000;
                //remander
                int remander = total - (carry * 1000);

                number[count] = remander;
                if (count == number.Count - 1)
                {
                    number.Add(carry);
                    carry = 0;
                }
                else
                {
                    AddLargeNumber(count + 1, carry);
                }
            }
            else
            {
                number[count] = total;
            }
        }

        #endregion
    }
}