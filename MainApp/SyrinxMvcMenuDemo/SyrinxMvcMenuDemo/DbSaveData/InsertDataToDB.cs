using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Domain.MultiTableDependency;
using System.Collections;

namespace SyrinxMvc.DbSaveData
{
    public class InsertDataToDB
    {
        private static CastKnowledgeEntities db = new CastKnowledgeEntities();

        public static string InsertContractorDataFromExcel(string file)
        {
            List<PairDataTemplate<Dostawca, List<string>>> dataFromExcel = new List<PairDataTemplate<Dostawca, List<string>>>();
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



    }
}