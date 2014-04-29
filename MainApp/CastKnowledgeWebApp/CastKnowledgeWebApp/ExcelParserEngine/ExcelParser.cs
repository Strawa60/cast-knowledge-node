using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using CastKnowledgeWebApp.Domain;

namespace CastKnowledgeWebApp.ExcelParserEngine
{
    public class ExcelParser
    {
        private static string Excel_PATH = @"D:/Dostawcy materiały ogniotrwałe"; // tempolary excel readpath

        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;
        private static int lastRow = 0;

        private static List<Dostawca> contractorList = new List<Dostawca>();

        private static void InitializeExcel()
        {
            try
            {
                MyApp = new Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(Excel_PATH);
                MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explict cast is not required here
                lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            }
            catch (System.IO.IOException)
            {
                // this file can't be read, do nothing... just skip the file
            }
        }

        public static List<Dostawca> ParseContractorData()
        {
            InitializeExcel();
            contractorList.Clear();

            switch (MySheet.Name)
            {
                case "Materiały Ogniotrwałe":
                    {
                        contractorList = ReadContractorData_MaterialyOgniotrwale();
                        break;
                    }
                default:
                    {
                        break;
                    }

            }

            return contractorList;

        }

        private static List<Dostawca> ReadContractorData_MaterialyOgniotrwale()
        {
            List<Dostawca> MO_ContractorList = new List<Dostawca>();
            for (int index = 2; index <= lastRow; index++)
            {
                System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "L" + index.ToString()).Cells.Value;

                List<string> MO_KeyWords = SeparateKeyWords(MyValues.GetValue(1, 12).ToString());
                Dostawca ContracorData = new Dostawca();
                ContracorData.Typ_firmy = new Typ_firmy { nazwa = "Materiały Ogniotrwałe" };
                //ContracorData.Typ_firmy.nazwa = "Materiały Ogniotrwałe";

                MO_ContractorList.Add(ValidateData(MyValues, ContracorData));
            }

            MyApp.Quit();
            return MO_ContractorList;
        }

        private static Dostawca ValidateData(System.Array MyValues, Dostawca ValidateContracorData)
        {
            if (MyValues.GetValue(1, 1) != null)
                ValidateContracorData.nazwa = MyValues.GetValue(1, 1).ToString();
            if (MyValues.GetValue(1, 2) != null)
                ValidateContracorData.miejscowosc = MyValues.GetValue(1, 2).ToString();
            if (MyValues.GetValue(1, 3) != null)
                ValidateContracorData.kod_pocztowy = MyValues.GetValue(1, 3).ToString();
            if (MyValues.GetValue(1, 4) != null)
                ValidateContracorData.ulica = MyValues.GetValue(1, 4).ToString();
            if (MyValues.GetValue(1, 5) != null)
                ValidateContracorData.wojewodztwo = MyValues.GetValue(1, 5).ToString();
            if (MyValues.GetValue(1, 6) != null)
                ValidateContracorData.telefon = MyValues.GetValue(1, 6).ToString();
            if (MyValues.GetValue(1, 7) != null)
                ValidateContracorData.fax = MyValues.GetValue(1, 7).ToString();
            if (MyValues.GetValue(1, 8) != null)
                ValidateContracorData.www = MyValues.GetValue(1, 8).ToString();
            if (MyValues.GetValue(1, 9) != null)
                ValidateContracorData.e_mail = MyValues.GetValue(1, 9).ToString();
            if (MyValues.GetValue(1, 10) != null)
                ValidateContracorData.prezes = MyValues.GetValue(1, 10).ToString();
            if (MyValues.GetValue(1, 11) != null)
                ValidateContracorData.Zasoby.Add(new Zasoby { nazwa_zasobu = MyValues.GetValue(1, 11).ToString() });

            return ValidateContracorData;
        }

        private static List<string> SeparateKeyWords(string KeyWordsLine)
        {
            List<string> tempolaryList = new List<string>();

            string[] temp = KeyWordsLine.Split(';');

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
    }
}