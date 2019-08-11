using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexTest
{

    class Program
    {
        private static Regex reg_wait = new Regex("^@wait\\s+([\\d.]+)\\s*([\\d.]+)?", RegexOptions.IgnoreCase);

        static void Main(string[] args)
        {
            string str = "@wait 0.5";
            Match match = reg_wait.Match(str);

            //while (match.Success)
            //{
            //    Debug.WriteLine("{0}:{1}", match.Index, match.Value);
            //    match = match.NextMatch();
            //}

            Debug.WriteLine("{0} , {1} , {2} ", match.Groups[1].Value, match.Groups.Count, match.Groups[2].Length);

            NewMethod(match);

            NewMethod1(match);

            string str1 = "@wait 0.5 0.5";
            Match match1 = reg_wait.Match(str1);

            NewMethod(match1);

            NewMethod1(match1);
            //for (int i = 1; i <= 2; i++)
            //{
            //    Group g = match.Groups[i];
            //    Debug.WriteLine("Group" + i + "='" + g + "'");
            //    CaptureCollection cc = g.Captures;
            //    for (int j = 0; j < cc.Count; j++)
            //    {
            //        Capture c = cc[j];
            //        Debug.WriteLine("Capture" + j + "='" + c + "', Position=" + c.Index);
            //    }
            //}



            //test();
        }

        private static void NewMethod1(Match match)
        {
            if (match.Groups[2].Length > 0)
            {
                Debug.WriteLine("{0} , {1} , {2}", match.Groups[1].Value, match.Groups[2].Value, match.Groups.Count);
                Debug.WriteLine("{0}:{1}", float.Parse(match.Groups[1].Value), float.Parse(match.Groups[2].Value));
            }
        }

        private static void NewMethod(Match match)
        {
            Debug.WriteLine("Match: {0} , {1}" ,  match.Value , match.Length);
            int groupCtr = 0;
            foreach (Group group in match.Groups)
            {
                Debug.WriteLine("   Group {0}: {1} , {2} ", groupCtr, group.Value , group.Length) ;
                int captureCtr = 0;
                foreach (Capture capture in group.Captures)
                {
                    captureCtr++;
                    Debug.WriteLine("      Capture {0}: '{1}' , {2}", captureCtr, capture.Value , capture.Length);
                }
                groupCtr++;
            }
        }

        static void test()
        {
            string text = "One car red car blue car";
            string pat = @"(\w+)\s+(car)";

            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match m = r.Match(text);
            int matchCount = 0;
            while (m.Success)
            {
                Debug.WriteLine("Match" + (++matchCount));
                for (int i = 1; i <= 2; i++)
                {
                    Group g = m.Groups[i];
                    Debug.WriteLine("Group" + i + "='" + g + "'");
                    CaptureCollection cc = g.Captures;
                    for (int j = 0; j < cc.Count; j++)
                    {
                        Capture c = cc[j];
                        Debug.WriteLine("Capture" + j + "='" + c + "', Position=" + c.Index);
                    }
                }
                m = m.NextMatch();
            }
        }
    }
}
