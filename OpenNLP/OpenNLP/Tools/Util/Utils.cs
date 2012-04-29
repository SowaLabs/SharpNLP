/*==========================================================================;
 *
 *  This file is part of SharpNLP (http://sharpnlp.codeplex.com/)
 *
 *  File:    Utils.cs
 *  Desc:    Common utilities
 *  Created: Apr-2012
 *
 *  Author:  Miha Grcar
 *
 ***************************************************************************/

//using System;
using System.Globalization;

namespace OpenNLP.Tools.Util
{
    public static class Utils
    {
        private static HashSet<char> mAposLikeChars
            = new HashSet<char>(new char[] { (char)0x60, (char)0xB4, (char)0x2018, (char)0x2019, (char)0x201B, (char)0x2039, (char)0x203A });

        public static string MapUnicodeChars(string txt)
        {
            //Console.WriteLine("MapUnicodeChars was called.");
            char[] buffer = new char[txt.Length];
            for (int i = 0; i < txt.Length; i++)
            {
                char ch = txt[i];
                UnicodeCategory unicodeCategory = char.GetUnicodeCategory(ch);
                if (unicodeCategory == UnicodeCategory.CurrencySymbol) { ch = '$'; }
                else if (unicodeCategory == UnicodeCategory.DashPunctuation) { ch = '-'; }
                else if (mAposLikeChars.Contains(ch)) { ch = '\''; }
                else if (unicodeCategory == UnicodeCategory.InitialQuotePunctuation
                    || unicodeCategory == UnicodeCategory.FinalQuotePunctuation) { ch = '"'; }
                buffer[i] = ch;
            }
            return new string(buffer);
        }
    }
}