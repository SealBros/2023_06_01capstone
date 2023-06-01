﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EUV.Utility
{
    public class Sorter : System.Collections.IComparer
    {
        public int Column = 0;
        public SortOrder Order = SortOrder.Ascending;
        public int Compare(object x, object y)  // IComparer Member
        {
            if (!(x is ListViewItem))
                return 0;
            if (!(y is ListViewItem))
                return 0;

            ListViewItem l1 = (ListViewItem)x;
            ListViewItem l2 = (ListViewItem)y;

            if (l1.ListView.Columns[Column].Tag != null && l1.ListView.Columns[Column].Tag.ToString() == "Numeric")
            {
                string str1 = l1.SubItems[Column].Text;
                string str2 = l2.SubItems[Column].Text;

                if (str1 == "")
                {
                    str1 = "99999";
                }
                if (str2 == "")
                {
                    str2 = "99999";
                }

                float fl1 = float.Parse(str1);
                float fl2 = float.Parse(str2);

                if (Order == SortOrder.Ascending)
                {
                    return fl1.CompareTo(fl2);
                }
                else
                {
                    return fl2.CompareTo(fl1);
                }
            }
            else
            {
                string str1 = l1.SubItems[Column].Text;
                string str2 = l2.SubItems[Column].Text;

                if (Order == SortOrder.Ascending)
                {
                    return str1.CompareTo(str2);
                }
                else
                {
                    return str2.CompareTo(str1);
                }
            }
        }
    }
}
