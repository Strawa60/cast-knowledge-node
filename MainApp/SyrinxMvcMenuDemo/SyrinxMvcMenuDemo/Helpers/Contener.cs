using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SyrinxMvc.Helpers
{
    public class Contener
    {
        public static List<string> SeparateKeyWords(string keyWordsLine)
        {
            if (keyWordsLine != null)
            {
                List<string> tempolaryList = new List<string>();

                string[] temp = keyWordsLine.Split(';');

                for (int i = 0; i < temp.Length - 1; i++)
                {
                    if (temp[i][0] == ' ')
                    {
                        temp[i] = temp[i].Remove(0, 1);
                    }
                }


                foreach (string q in temp)
                {
                    if (q != "")
                    {
                        tempolaryList.Add(q);
                    }
                }

                return tempolaryList;
            }
            else
            {
                return null;
            }
        }

        //public static List<string> SeparateKeyWords(string keyWordsLine)
        //{
        //    List<string> tempolaryList = new List<string>();

        //    string[] temp = keyWordsLine.Split(';');

        //    for (int i = 0; i < temp.Length - 1; i++)
        //    {
        //        if (temp[i][0] == ' ')
        //        {
        //            temp[i] = temp[i].Remove(0, 1);
        //        }
        //    }


        //    foreach (string q in temp)
        //    {
        //        if (q != "")
        //        {
        //            tempolaryList.Add(q);
        //        }
        //    }

        //    return tempolaryList;
        //}
    
    }
}