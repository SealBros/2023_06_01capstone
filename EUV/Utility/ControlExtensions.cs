using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EUV.Utility
{
    public static class ControlExtensions
    {
        public static string TrimUnPrintable(this string input)
        {
            return Regex.Replace(input, @"[^\u0020-\u007E]", String.Empty);
        }

        static readonly int[] Empty = new int[0];

        public static int LocateSingle(this byte[] self, byte[] candidate)
        {
            if (IsEmptyLocate(self, candidate))
                return -1;



            for (int i = 0; i < self.Length; i++)
            {
                if (!IsMatch(self, i, candidate))
                    continue;

                return i;
            }

            return -1;

        }

        static bool IsMatch(byte[] array, int position, byte[] candidate)
        {
            if (candidate.Length > (array.Length - position))
                return false;

            for (int i = 0; i < candidate.Length; i++)
                if (array[position + i] != candidate[i])
                    return false;

            return true;
        }

        static bool IsEmptyLocate(byte[] array, byte[] candidate)
        {
            return array == null
                || candidate == null
                || array.Length == 0
                || candidate.Length == 0
                || candidate.Length > array.Length;
        }

        public static T[] RemoveAt<T>(this T[] array, int startIndex, int length)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            if (length < 0)
            {
                startIndex += 1 + length;
                length = -length;
            }

            if (startIndex < 0)
                throw new ArgumentOutOfRangeException("startIndex");
            if (startIndex + length > array.Length)
                throw new ArgumentOutOfRangeException("length");

            T[] newArray = new T[array.Length - length];

            Array.Copy(array, 0, newArray, 0, startIndex);
            Array.Copy(array, startIndex + length, newArray, startIndex, array.Length - startIndex - length);

            return newArray;
        }

        public static void InvokeIfNeeded(this Control control, Action action)
        {
            if (control.IsDisposed)
                return;

            try
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(action);
                }
                else
                {
                    action();
                }
            }
            catch (ObjectDisposedException)
            {
            }
        }
    }
}
