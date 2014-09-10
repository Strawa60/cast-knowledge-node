using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Libraries.MultiTableDependency;
using System.Collections;

namespace SyrinxMvc.DbSaveData
{
    public class InsertDataToDB
    {
        private static CastKnowledgeEntities db = new CastKnowledgeEntities();

        public static string InsertPatentsDataFromExcel(string file)
        {
            List<PairDataTemplate<Patenty, List<string>>> dataFromExcel = new List<PairDataTemplate<Patenty, List<string>>>();
            dataFromExcel = SyrinxMvc.DbSaveData.ExcelParser.ParsePatentData(file);

            List<PairDataTemplate<int, int>> patentKeyWordDependency = new List<PairDataTemplate<int, int>>();

            Slowa_kluczowe keyWord = new Slowa_kluczowe();
            int one = 0, two = 0;

            for (int i = 0; i < dataFromExcel.Count; i++)
            {
                try
                {
                    db.patenty.Add(dataFromExcel[i].t1);
                    db.SaveChanges();
                    one = dataFromExcel[i].t1.id_patentu;
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    return dataFromExcel[i].t1.tytul_polski.ToString();
                }

                if (dataFromExcel[i].t2.Count > 0)
                {
                    for (int j = 0; j < dataFromExcel[i].t2.Count; j++)
                    {
                        try
                        {
                            keyWord.nazwa = dataFromExcel[i].t2[j];

                            db.slowa_kluczowe.Add(keyWord);
                            db.SaveChanges();
                            two = keyWord.id_deskryptora;

                            patentKeyWordDependency.Add(new PairDataTemplate<int, int>(one, two));
                        }
                        catch (Exception e)
                        {
                            e.Message.ToString();
                            return dataFromExcel[i].t1.tytul_polski.ToString();
                        }

                    }
                }
            }

            Patenty_tagi tags = new Patenty_tagi();

            foreach (var q in patentKeyWordDependency)
            {

                tags.id_patentu = q.t1;
                tags.id_deskryptora = q.t2;

                try
                {
                    db.patenty_tagi.Add(tags);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }

            return null;
        }

        public static string InsertPublicationDataFromExcel(string file)
        {
            List<PairDataTemplate<Publikacje, List<string>>> dataFromExcel = new List<PairDataTemplate<Publikacje, List<string>>>();
            dataFromExcel = SyrinxMvc.DbSaveData.ExcelParser.ParsePublicationData(file);

            List<PairDataTemplate<int, int>> publicationKeyWordDependency = new List<PairDataTemplate<int, int>>();

            Slowa_kluczowe keyWord = new Slowa_kluczowe();
            int one = 0, two = 0;

            for (int i = 0; i < dataFromExcel.Count; i++)
            {
                try
                {
                    db.publikacje.Add(dataFromExcel[i].t1);
                    db.SaveChanges();
                    one = dataFromExcel[i].t1.id_publikacji;
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    return dataFromExcel[i].t1.tytul_polski.ToString();
                }

                if (dataFromExcel[i].t2.Count > 0)
                {
                    for (int j = 0; j < dataFromExcel[i].t2.Count; j++)
                    {
                        try
                        {
                            keyWord.nazwa = dataFromExcel[i].t2[j];

                            db.slowa_kluczowe.Add(keyWord);
                            db.SaveChanges();
                            two = keyWord.id_deskryptora;

                            publicationKeyWordDependency.Add(new PairDataTemplate<int, int>(one, two));
                        }
                        catch (Exception e)
                        {
                            e.Message.ToString();
                            return dataFromExcel[i].t1.tytul_polski.ToString();
                        }

                    }
                }
            }

            Publikacje_tagi tags = new Publikacje_tagi();

            foreach (var q in publicationKeyWordDependency)
            {

                tags.id_publikacji = q.t1;
                tags.id_deskryptora = q.t2;

                try
                {
                    db.publikacje_tagi.Add(tags);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }

            return null;
        }

        public static string InsertContractorDataFromExcel(string file)
        {
            
            List<PairDataTemplate<Dostawca, List<string>>> dataFromExcel = new List<PairDataTemplate<Dostawca, List<string>>>();
            dataFromExcel.Clear();
            dataFromExcel = SyrinxMvc.DbSaveData.ExcelParser.ParseContractorData(file);
            List<PairDataTemplate<int, int>> contractorKeyWordDependency = new List<PairDataTemplate<int, int>>();

            Slowa_kluczowe keyWord = new Slowa_kluczowe();
            int one=0, two=0;

            for (int i = 0; i < dataFromExcel.Count; i++)
            {
                try
                {
                    db.dostawca.Add(dataFromExcel[i].t1);
                    db.SaveChanges();
                    one = dataFromExcel[i].t1.id_firmy;
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    return dataFromExcel[i].t1.nazwa.ToString();      
                }

                if (dataFromExcel[i].t2.Count > 0)
                {
                    for (int j = 0; j < dataFromExcel[i].t2.Count; j++)
                    {
                        try
                        {
                            keyWord.nazwa = dataFromExcel[i].t2[j];

                            db.slowa_kluczowe.Add(keyWord);
                            db.SaveChanges();
                            two = keyWord.id_deskryptora;

                            contractorKeyWordDependency.Add(new PairDataTemplate<int, int>(one, two));
                        }
                        catch (Exception e)
                        {
                            e.Message.ToString();
                            return dataFromExcel[i].t1.nazwa.ToString();
                        }

                    }
                }
            }

            Dostawca_tagi tags = new Dostawca_tagi();

            foreach (var q in contractorKeyWordDependency)
            {

                tags.id_firmy = q.t1;
                tags.id_deskryptora = q.t2;

                try
                {
                    db.dostawca_tagi.Add(tags);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }

            return null;
        }

        public static string InsertFoundryDataFromExcel(string file)
        {
            List<PairDataTemplate<Odlewnia, List<string>>> dataFromExcel = new List<PairDataTemplate<Odlewnia, List<string>>>();
            dataFromExcel = SyrinxMvc.DbSaveData.ExcelParser.ParseFoundryData(file);


            List<PairDataTemplate<int, int>> foundryKeyWordDependency = new List<PairDataTemplate<int, int>>();

            Slowa_kluczowe keyWord = new Slowa_kluczowe();
            int one = 0, two = 0;

            for (int i = 0; i < dataFromExcel.Count; i++)
            {
                try
                {
                    db.odlewnia.Add(dataFromExcel[i].t1);
                    db.SaveChanges();
                    one = dataFromExcel[i].t1.id_odlewni;
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    return dataFromExcel[i].t1.nazwa.ToString();
                }

                if (dataFromExcel[i].t2.Count > 0)
                {
                    for (int j = 0; j < dataFromExcel[i].t2.Count; j++)
                    {
                        try
                        {
                            keyWord.nazwa = dataFromExcel[i].t2[j];

                            db.slowa_kluczowe.Add(keyWord);
                            db.SaveChanges();
                            two = keyWord.id_deskryptora;

                            foundryKeyWordDependency.Add(new PairDataTemplate<int, int>(one, two));
                        }
                        catch (Exception e)
                        {
                            e.Message.ToString();
                            return dataFromExcel[i].t1.nazwa.ToString();
                        }

                    }
                }
            }

            Odlewnia_tagi tags = new Odlewnia_tagi();

            foreach (var q in foundryKeyWordDependency)
            {

                tags.id_odlewni = q.t1;
                tags.id_deskryptora = q.t2;

                try
                {
                    db.odlewnia_tagi.Add(tags);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }

            return null;

        }

        public static void InsertContractorDataFromForm(SyrinxMvc.Models.DostawcaWrapper contractorDataFromForm)
        {

            List<PairDataTemplate<int, int>> contractorKeyWordDependency = new List<PairDataTemplate<int, int>>();
            List<string> keyWords = new List<string>();
            Slowa_kluczowe keyWord = new Slowa_kluczowe();
            int one = 0, two = 0;

            try
            {
                db.dostawca.Add(contractorDataFromForm.contractors);
                db.SaveChanges();
                one = contractorDataFromForm.contractors.id_firmy;
                
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            keyWords = Helpers.Contener.SeparateKeyWords(contractorDataFromForm.keyWords);

            for (int j = 0; j < keyWords.Count; j++)
            {
                try
                {
                    keyWord.nazwa = keyWords[j];

                    db.slowa_kluczowe.Add(keyWord);
                    db.SaveChanges();
                    two = keyWord.id_deskryptora;

                    contractorKeyWordDependency.Add(new PairDataTemplate<int, int>(one, two));
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }

            }

            Dostawca_tagi tags = new Dostawca_tagi();

            foreach (var q in contractorKeyWordDependency)
            {

                tags.id_firmy = q.t1;
                tags.id_deskryptora = q.t2;

                try
                {
                    db.dostawca_tagi.Add(tags);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }


        }

        public static void InsertFoundryDataFromForm(SyrinxMvc.Models.OdlewniaWrapper foundryDataFromForm)
        {

            List<PairDataTemplate<int, int>> foundryKeyWordDependency = new List<PairDataTemplate<int, int>>();
            List<string> keyWords = new List<string>();
            Slowa_kluczowe keyWord = new Slowa_kluczowe();
            int one = 0, two = 0;

            try
            {
                db.odlewnia.Add(foundryDataFromForm.foundries);
                db.SaveChanges();
                one = foundryDataFromForm.foundries.id_odlewni;

            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            keyWords = Helpers.Contener.SeparateKeyWords(foundryDataFromForm.keyWords);

            for (int j = 0; j < keyWords.Count; j++)
            {
                try
                {
                    keyWord.nazwa = keyWords[j];

                    db.slowa_kluczowe.Add(keyWord);
                    db.SaveChanges();
                    two = keyWord.id_deskryptora;

                    foundryKeyWordDependency.Add(new PairDataTemplate<int, int>(one, two));
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }

            }

            Odlewnia_tagi tags = new Odlewnia_tagi();

            foreach (var q in foundryKeyWordDependency)
            {

                tags.id_odlewni = q.t1;
                tags.id_deskryptora = q.t2;

                try
                {
                    db.odlewnia_tagi.Add(tags);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }


        }

        public static void InsertPublicationDataFromForm(SyrinxMvc.Models.PublikacjeWrapper publicationDataFromForm)
        {

            List<PairDataTemplate<int, int>> publicationKeyWordDependency = new List<PairDataTemplate<int, int>>();
            List<string> keyWords = new List<string>();
            Slowa_kluczowe keyWord = new Slowa_kluczowe();
            int one = 0, two = 0;

            try
            {
                db.publikacje.Add(publicationDataFromForm.publications);
                db.SaveChanges();
                one = publicationDataFromForm.publications.id_publikacji;

            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            keyWords = Helpers.Contener.SeparateKeyWords(publicationDataFromForm.keyWords);

            for (int j = 0; j < keyWords.Count; j++)
            {
                try
                {
                    keyWord.nazwa = keyWords[j];

                    db.slowa_kluczowe.Add(keyWord);
                    db.SaveChanges();
                    two = keyWord.id_deskryptora;

                    publicationKeyWordDependency.Add(new PairDataTemplate<int, int>(one, two));
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }

            }

            Publikacje_tagi tags = new Publikacje_tagi();

            foreach (var q in publicationKeyWordDependency)
            {

                tags.id_publikacji = q.t1;
                tags.id_deskryptora = q.t2;

                try
                {
                    db.publikacje_tagi.Add(tags);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }


        }

        public static void InsertPatentDataFromForm(SyrinxMvc.Models.PatentyWrapper patentDataFromForm)
        {
            List<PairDataTemplate<int, int>> patentKeyWordDependency = new List<PairDataTemplate<int, int>>();
            List<string> keyWords = new List<string>();
            Slowa_kluczowe keyWord = new Slowa_kluczowe();
            int one = 0, two = 0;

            try
            {
                db.patenty.Add(patentDataFromForm.patents);
                db.SaveChanges();
                one = patentDataFromForm.patents.id_patentu;

            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            keyWords = Helpers.Contener.SeparateKeyWords(patentDataFromForm.keyWords);

            for (int j = 0; j < keyWords.Count; j++)
            {
                try
                {
                    keyWord.nazwa = keyWords[j];

                    db.slowa_kluczowe.Add(keyWord);
                    db.SaveChanges();
                    two = keyWord.id_deskryptora;

                    patentKeyWordDependency.Add(new PairDataTemplate<int, int>(one, two));
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }

            }

            Patenty_tagi tags = new Patenty_tagi();

            foreach (var q in patentKeyWordDependency)
            {

                tags.id_patentu = q.t1;
                tags.id_deskryptora = q.t2;

                try
                {
                    db.patenty_tagi.Add(tags);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
            }

        }

    }
}