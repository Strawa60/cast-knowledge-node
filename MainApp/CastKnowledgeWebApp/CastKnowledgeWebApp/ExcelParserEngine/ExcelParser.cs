using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Domain.MultiTableDependency;

namespace CastKnowledgeWebApp.ExcelParserEngine
{
    public static class ExcelParser
    {
        private static string excel_PATH = @"D:/Dostawcy materiały ogniotrwałe"; // tempolary excel readpath

        private static Excel.Application myApp = null;
        private static Excel.Workbook myBook = null;
        private static Excel.Worksheet mySheet = null;
        private static int lastRow = 0;

        private static List<PairDataTemplate<Dostawca, List<string>>> contractorList = new List<PairDataTemplate<Dostawca, List<string>>>();


        private static void InitializeExcel()
        {
            try
            {
                myApp = new Excel.Application();
                myApp.Visible = false;
                myBook = myApp.Workbooks.Open(excel_PATH);
                mySheet = (Excel.Worksheet)myBook.Sheets[1]; // Explict cast is not required here
                lastRow = mySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;

            }
            catch (System.IO.IOException)
            {
                // this file can't be read, do nothing... just skip the file
                myBook.Close();
                myApp.Quit();
            }
        }

        private static void CloseExcel()
        {

            myBook.Close(false);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(mySheet);
            mySheet = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(myBook);
            myBook = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(myApp);
            myApp = null;
        }

        private static List<string> SeparateKeyWords(string keyWordsLine)
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

        public static List<PairDataTemplate<Dostawca, List<string>>> ParseContractorData()
        {
            try
            {
                InitializeExcel();
                contractorList.Clear();

                switch (mySheet.Name)
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
            }
            finally
            {

                CloseExcel();
            }
            return contractorList;

        }

        private static List<PairDataTemplate<Dostawca, List<string>>> ReadContractorData_MaterialyOgniotrwale()
        {
            //posiada dostawce i liste slow kluczowych
            List<PairDataTemplate<Dostawca, List<string>>> moContractorList = new List<PairDataTemplate<Dostawca, List<string>>>();

            for (int index = 2; index <= lastRow; index++)
            {
                System.Array myValues = (System.Array)mySheet.get_Range("A" + index.ToString(), "L" + index.ToString()).Cells.Value;

                List<string> moKeyWords = SeparateKeyWords(myValues.GetValue(1, 12).ToString());

                Dostawca ContracorData = new Dostawca();
                ContracorData.typ_firmy = "Materiały Ogniotrwałe";
                moContractorList.Add(new PairDataTemplate<Dostawca, List<string>>(ValidateContractorData(myValues, ContracorData), moKeyWords));

            }
            return moContractorList;
        }

        private static Dostawca ValidateContractorData(System.Array myValues, Dostawca validateContracorData)
        {
            if (myValues.GetValue(1, 1) != null)
                validateContracorData.nazwa = myValues.GetValue(1, 1).ToString();
            if (myValues.GetValue(1, 2) != null)
                validateContracorData.miejscowosc = myValues.GetValue(1, 2).ToString();
            if (myValues.GetValue(1, 3) != null)
                validateContracorData.kod_pocztowy = myValues.GetValue(1, 3).ToString();
            if (myValues.GetValue(1, 4) != null)
                validateContracorData.ulica = myValues.GetValue(1, 4).ToString();
            if (myValues.GetValue(1, 5) != null)
                validateContracorData.wojewodztwo = myValues.GetValue(1, 5).ToString();
            if (myValues.GetValue(1, 6) != null)
                validateContracorData.telefon = myValues.GetValue(1, 6).ToString();
            if (myValues.GetValue(1, 7) != null)
                validateContracorData.fax = myValues.GetValue(1, 7).ToString();
            if (myValues.GetValue(1, 8) != null)
                validateContracorData.www = myValues.GetValue(1, 8).ToString();
            if (myValues.GetValue(1, 9) != null)
                validateContracorData.e_mail = myValues.GetValue(1, 9).ToString();
            if (myValues.GetValue(1, 10) != null)
                validateContracorData.prezes = myValues.GetValue(1, 10).ToString();
            if (myValues.GetValue(1, 11) != null)
                validateContracorData.zasoby = myValues.GetValue(1, 11).ToString();
            //validateContracorData.typ_firmy = "Materiały Ogniotrwałe";
            return validateContracorData;
        }


    }
}