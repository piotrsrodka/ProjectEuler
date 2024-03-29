﻿using System.Numerics;

namespace Common
{
    public static class Numbers
    {
        public static List<int> Divisors(int number)
        {
            List<int> properDivisors = new List<int>();

            for (int i = 1; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    properDivisors.Add(i);
                }
            }

            return properDivisors;
        }

        public static HashSet<int> ToDigitSet(int number)
        {
            var digits = new HashSet<int>();

            while (number > 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }

            return digits;
        }

        public static int[] ToDigits(int number)
        {
            var digits = new List<int>();

            while (number > 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }

            return digits.ToArray();
        }

        public static int[] ToDigits(BigInteger number)
        {
            var digits = new List<int>();

            while (number > 0)
            {
                digits.Add((int)(number % 10));
                number /= 10;
            }

            return digits.ToArray();
        }

        public static long DigitsSum(BigInteger number)
        {
            var digits = ToDigits(number);
            return digits.Sum();
        }

        public static int ToNumber(int[] digits)
        {
            int number = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                number += digits[i] * (int) Math.Pow(10, i);
            }

            return number;
        }

        public static int ToNumber(int[] digits, int left, int right)
        {
            int number = 0;

            for (int i = left; i < right; i++)
            {
                number += digits[i] * (int)Math.Pow(10, i - left);
            }

            return number;
        }

        public static int[] ToBinaryDigits(int number)
        {
            var digits = new List<int>();

            while (number > 0)
            {
                digits.Add(number % 2);
                number /= 2;
            }

            return digits.ToArray();
        }

        public static string Reverse(this string word)
        {
            var charArray = word.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool IsPalindromic(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[array.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
