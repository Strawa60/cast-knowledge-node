using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Domain.MultiTableDependency;

namespace SyrinxMvc.DbSaveData
{
    public static class ExcelParser
    {
        //private static string excel_PATH = @"D:/Dostawcy materiały ogniotrwałe"; // tempolary excel readpath

        private static Excel.Application myApp = null;
        private static Excel.Workbook myBook = null;
        private static Excel.Worksheet mySheet = null;
        private static int lastRow = 0;

        private static void InitializeExcel(string file)
        {
            try
            {
                myApp = new Excel.Application();
                myApp.Visible = false;
                myBook = myApp.Workbooks.Open(file);
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

        public static List<PairDataTemplate<Dostawca, List<string>>> ParseContractorData(string file)
        {
            List<PairDataTemplate<Dostawca, List<string>>> contractorList = new List<PairDataTemplate<Dostawca, List<string>>>();
            try
            {
                InitializeExcel(file);
                contractorList.Clear();
                contractorList = ReadContractorData();

            }
            finally
            {

                CloseExcel();
            }
            return contractorList;

        }

        public static List<PairDataTemplate<Odlewnia, List<string>>> ParseFoundryData(string file)
        {
            List<PairDataTemplate<Odlewnia, List<string>>> foundryList = new List<PairDataTemplate<Odlewnia, List<string>>>();
            try
            {
                InitializeExcel(file);
                foundryList.Clear();
                foundryList = ReadFoundryData();

            }
            finally
            {

                CloseExcel();
            }
            return foundryList;


        }

        public static List<PairDataTemplate<Publikacje, List<string>>> ParsePublicationData(string file)
        {
            List<PairDataTemplate<Publikacje, List<string>>> publicationList = new List<PairDataTemplate<Publikacje, List<string>>>();
            try
            {
                InitializeExcel(file);
                publicationList.Clear();
                publicationList = ReadPublicationData();

            }
            finally
            {

                CloseExcel();
            }
            return publicationList;


        }

        public static List<PairDataTemplate<Patenty, List<string>>> ParsePatentData(string file)
        {
            List<PairDataTemplate<Patenty, List<string>>> patentsList = new List<PairDataTemplate<Patenty, List<string>>>();
            try
            {
                InitializeExcel(file);
                patentsList.Clear();
                patentsList = ReadPatentData();

            }
            finally
            {

                CloseExcel();
            }
            return patentsList;


        }

        private static List<PairDataTemplate<Patenty, List<string>>> ReadPatentData()
        {
            //posiada patenty i liste slow kluczowych
            List<PairDataTemplate<Patenty, List<string>>> patentList = new List<PairDataTemplate<Patenty, List<string>>>();


            for (int index = 2; index <= lastRow; index++)
            {
                try
                {
                    Patenty patentData = new Patenty();
                    List<string> patentKeyWords = new List<string>();

                    System.Array myValues = (System.Array)mySheet.get_Range("A" + index.ToString(), "L" + index.ToString()).Cells.Value;
                    if (myValues.GetValue(1, 12) != null)
                    {
                        patentKeyWords = Helpers.Contener.SeparateKeyWords(myValues.GetValue(1, 12).ToString());
                    }

                    patentList.Add(new PairDataTemplate<Patenty, List<string>>(ValidatePatentData(myValues, patentData), patentKeyWords));
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    index.ToString();
                }
            }
            return patentList;

        }

        private static List<PairDataTemplate<Publikacje, List<string>>> ReadPublicationData()
        {
            //posiada publikacje i liste slow kluczowych
            List<PairDataTemplate<Publikacje, List<string>>> publicationList = new List<PairDataTemplate<Publikacje, List<string>>>();


            for (int index = 2; index <= lastRow; index++)
            {
                try
                {
                    Publikacje publicationData = new Publikacje();
                    List<string> publicationKeyWords = new List<string>();

                    System.Array myValues = (System.Array)mySheet.get_Range("A" + index.ToString(), "H" + index.ToString()).Cells.Value;
                    if (myValues.GetValue(1, 8) != null)
                    {
                        publicationKeyWords = Helpers.Contener.SeparateKeyWords(myValues.GetValue(1, 8).ToString());
                    }

                    publicationList.Add(new PairDataTemplate<Publikacje, List<string>>(ValidatePublicationData(myValues, publicationData), publicationKeyWords));
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    index.ToString();
                }
            }
            return publicationList;

        }

        private static List<PairDataTemplate<Odlewnia, List<string>>> ReadFoundryData()
        {
            //posiada dostawce i liste slow kluczowych
            List<PairDataTemplate<Odlewnia, List<string>>> foundryList = new List<PairDataTemplate<Odlewnia, List<string>>>();


            for (int index = 2; index <= lastRow; index++)
            {
                try
                {
                    Odlewnia foundryData = new Odlewnia();
                    List<string> foundryKeyWords = new List<string>();

                    System.Array myValues = (System.Array)mySheet.get_Range("A" + index.ToString(), "K" + index.ToString()).Cells.Value;
                    if (myValues.GetValue(1, 11) != null)
                    {
                        foundryKeyWords = Helpers.Contener.SeparateKeyWords(myValues.GetValue(1, 11).ToString());
                    }

                    foundryList.Add(new PairDataTemplate<Odlewnia, List<string>>(ValidateFoundryData(myValues, foundryData), foundryKeyWords));
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    index.ToString();
                }
            }
            return foundryList;

        }

        private static List<PairDataTemplate<Dostawca, List<string>>> ReadContractorData()
        {
            //posiada dostawce i liste slow kluczowych
            List<PairDataTemplate<Dostawca, List<string>>> moContractorList = new List<PairDataTemplate<Dostawca, List<string>>>();

            for (int index = 2; index <= lastRow; index++)
            {
                try
                {
                    Dostawca ContracorData = new Dostawca();

                    System.Array myValues = (System.Array)mySheet.get_Range("A" + index.ToString(), "M" + index.ToString()).Cells.Value;
                    List<string> moKeyWords = Helpers.Contener.SeparateKeyWords(myValues.GetValue(1, 13).ToString());



                    moContractorList.Add(new PairDataTemplate<Dostawca, List<string>>(ValidateContractorData(myValues, ContracorData), moKeyWords));
                }
                catch(Exception e)
                {
                    e.Message.ToString();
                    index.ToString();
                }

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
            if (myValues.GetValue(1, 12) != null)
                validateContracorData.typ_firmy = myValues.GetValue(1, 12).ToString();
            return validateContracorData;
        }

        private static Odlewnia ValidateFoundryData(System.Array myValues, Odlewnia validateFoundryData)
        {
            if (myValues.GetValue(1, 1) != null)
                validateFoundryData.nazwa = myValues.GetValue(1, 1).ToString();
            if (myValues.GetValue(1, 2) != null)
                validateFoundryData.miejscowosc = myValues.GetValue(1, 2).ToString();
            if (myValues.GetValue(1, 3) != null)
                validateFoundryData.kod_pocztowy = myValues.GetValue(1, 3).ToString();
            if (myValues.GetValue(1, 4) != null)
                validateFoundryData.ulica = myValues.GetValue(1, 4).ToString();
            if (myValues.GetValue(1, 5) != null)
                validateFoundryData.telefon = myValues.GetValue(1, 5).ToString();
            if (myValues.GetValue(1, 6) != null)
                validateFoundryData.fax = myValues.GetValue(1, 6).ToString();
            if (myValues.GetValue(1, 7) != null)
                validateFoundryData.www = myValues.GetValue(1, 7).ToString();
            if (myValues.GetValue(1, 8) != null)
                validateFoundryData.e_mail = myValues.GetValue(1, 8).ToString();
            if (myValues.GetValue(1, 9) != null)
                validateFoundryData.nazwa_technologii = myValues.GetValue(1, 9).ToString();
            if (myValues.GetValue(1, 10) != null)
                validateFoundryData.nazwa_tworzywa = myValues.GetValue(1, 10).ToString();


            return validateFoundryData;
        }

        private static Publikacje ValidatePublicationData(System.Array myValues, Publikacje validatePublicationData)
        {

            if (myValues.GetValue(1, 1) != null)
                validatePublicationData.nr_publikacji = myValues.GetValue(1, 1).ToString();
            if (myValues.GetValue(1, 2) != null)
                validatePublicationData.rok_publikacji = myValues.GetValue(1, 2).ToString();
            if (myValues.GetValue(1, 3) != null)
                validatePublicationData.tytul_polski = myValues.GetValue(1, 3).ToString();
            if (myValues.GetValue(1, 4) != null)
                validatePublicationData.tytul_zagraniczny = myValues.GetValue(1, 4).ToString();
            if (myValues.GetValue(1, 5) != null)
                validatePublicationData.streszczenie_pol = myValues.GetValue(1, 5).ToString();
            if (myValues.GetValue(1, 6) != null)
                validatePublicationData.streszczenie_ang = myValues.GetValue(1, 6).ToString();
            if (myValues.GetValue(1, 7) != null)
                validatePublicationData.zrodlo_publikacji = myValues.GetValue(1, 7).ToString();

            return validatePublicationData;
        }

        private static Patenty ValidatePatentData(System.Array myValues, Patenty validatePatentData)
        {

            if (myValues.GetValue(1, 1) != null)
                validatePatentData.numer_wynalazku = myValues.GetValue(1, 1).ToString();
            if (myValues.GetValue(1, 2) != null)
                validatePatentData.data_rozpoczecia = myValues.GetValue(1, 2).ToString();
            if (myValues.GetValue(1, 3) != null)
                validatePatentData.data_zakonczenia = myValues.GetValue(1, 3).ToString();
            if (myValues.GetValue(1, 4) != null)
                validatePatentData.data_zgloszenia = myValues.GetValue(1, 4).ToString();
            if (myValues.GetValue(1, 5) != null)
                validatePatentData.symbol_patentowy = myValues.GetValue(1, 5).ToString();
            if (myValues.GetValue(1, 6) != null)
                validatePatentData.tytul_polski = myValues.GetValue(1, 6).ToString();
            if (myValues.GetValue(1, 7) != null)
                validatePatentData.tytul_angielski = myValues.GetValue(1, 7).ToString();
            if (myValues.GetValue(1, 8) != null)
                validatePatentData.opis_polski= myValues.GetValue(1, 8).ToString();
            if (myValues.GetValue(1, 9) != null)
                validatePatentData.opis_angielski = myValues.GetValue(1, 9).ToString();
            if (myValues.GetValue(1, 10) != null)
                validatePatentData.osrodek_opracowujacy = myValues.GetValue(1, 10).ToString();
            if (myValues.GetValue(1, 11) != null)
                validatePatentData.url = myValues.GetValue(1, 11).ToString();

            return validatePatentData;
        }

    }
}