using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using CastKnowledge.Domain.Entities.ContractorModel;
using CastKnowledge.Domain.Entities.Shared;

namespace CastKnowledge.WebUI.Infrastructure.ExcelEngine
{
    public class ExcelParserEngine
    {
        private static string Excel_PATH = @"D:/Dostawcy materiały ogniotrwałe"; // tempolary excel readpath
        
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;
        private static int lastRow = 0;

        private static List<Contractor> contractorList = new List<Contractor>();

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

        public static List<Contractor> ParseContractorData()
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

        private static List<Contractor> ReadContractorData_MaterialyOgniotrwale()
        {
            List<Contractor> MO_ContractorList = new List<Contractor>();
            for (int index = 2; index <= lastRow; index++)
            {
                System.Array MyValues = (System.Array)MySheet.get_Range("A" + index.ToString(), "L" + index.ToString()).Cells.Value;

                List<KeyWords> MO_KeyWords = SeparateKeyWords(MyValues.GetValue(1, 12).ToString());
                Contractor ContracorData = new Contractor();
                ContracorData.companyType = "Materiały Ogniotrwałe";

                MO_ContractorList.Add(ValidateData(MyValues,ContracorData));
            }

            MyApp.Quit();
            return MO_ContractorList;
        }

        private static Contractor ValidateData(System.Array MyValues, Contractor ValidateContracorData)
        {
            if (MyValues.GetValue(1, 1) != null)
                ValidateContracorData.name = MyValues.GetValue(1, 1).ToString();
            if (MyValues.GetValue(1, 2) != null)
                ValidateContracorData.city = MyValues.GetValue(1, 2).ToString();
            if (MyValues.GetValue(1, 3) != null)
                ValidateContracorData.postcode = MyValues.GetValue(1, 3).ToString();
            if (MyValues.GetValue(1, 4) != null)
                ValidateContracorData.street = MyValues.GetValue(1, 4).ToString();
            if (MyValues.GetValue(1, 5) != null)
                ValidateContracorData.province = MyValues.GetValue(1, 5).ToString();
            if (MyValues.GetValue(1, 6) != null)
                ValidateContracorData.telephone = MyValues.GetValue(1, 6).ToString();
            if (MyValues.GetValue(1, 7) != null)
                ValidateContracorData.fax = MyValues.GetValue(1, 7).ToString();
            if (MyValues.GetValue(1, 8) != null)
                ValidateContracorData.webAddress = MyValues.GetValue(1, 8).ToString();
            if (MyValues.GetValue(1, 9) != null)
                ValidateContracorData.email = MyValues.GetValue(1, 9).ToString();
            if (MyValues.GetValue(1, 10) != null)
                ValidateContracorData.ceo = MyValues.GetValue(1, 10).ToString();
            if (MyValues.GetValue(1, 11) != null)
                ValidateContracorData.resources = MyValues.GetValue(1, 11).ToString();

            return ValidateContracorData;
        }

        private static List<KeyWords> SeparateKeyWords(string KeyWordsLine)
        {
            List<KeyWords> tempolaryList = new List<KeyWords>();

            string[] temp = KeyWordsLine.Split(';');

            for (int i = 0; i < temp.Length-1; i++)
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
                    tempolaryList.Add(new KeyWords
                    {
                        deskryptor = q
                    });
                }
            }

            return tempolaryList;
        }
    }
}