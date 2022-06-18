using System.Collections.Generic;
using UnityEngine;
using System;

namespace Modern
{
    [Serializable]
    public class LargeNumber
    {
        private const int MAX_SEGMENTS = 42;

        [Range(0, 999)] public List<int> number;

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

    }
}