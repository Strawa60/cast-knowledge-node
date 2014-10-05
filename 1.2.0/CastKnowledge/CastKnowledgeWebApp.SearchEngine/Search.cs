using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CastKnowledgeWebApp.Domain;
using CastKnowledgeWebApp.Tools;

namespace CastKnowledgeWebApp.SearchEngine
{
    public class Search
    {
        private CastKnowledgeEntities db = new CastKnowledgeEntities();

        public List<Dostawca> dostawcaResults { get; set; }
        public List<Publikacje> publikacjaResults { get; set; }
        public List<Patenty> patentResults { get; set; }
        public List<Odlewnia> odlewniaResults { get; set; }

        public Search(string searchCondition)
        {
            dostawcaResults = FindDostawca(searchCondition).ToList();
            publikacjaResults = FindPublikacja(searchCondition).ToList();
            patentResults = FindPatent(searchCondition).ToList();
            odlewniaResults = FindOdlewnia(searchCondition).ToList();

        }

        public HashSet<Dostawca> FindDostawca(string _searchCondition)
        {
            var result = new HashSet<Dostawca>();
            result = db.dostawca.Where(q => q.nazwa.Contains(_searchCondition)).ToHashSet();

            var temp = db.dostawca_tagi.Where(q => q.Slowa_kluczowe.nazwa.Contains(_searchCondition)).ToList();

            foreach (var p in temp)
            {
                result.Add(p.Dostawca);
            }

            return result;
        }

        private HashSet<Publikacje> FindPublikacja(string _searchCondition)
        {
            var result = new HashSet<Publikacje>();
            result = db.publikacje.Where(q => q.tytul_polski.Contains(_searchCondition) || q.tytul_zagraniczny.Contains(_searchCondition)).ToHashSet();

            var temp = db.publikacje_tagi.Where(q => q.Slowa_kluczowe.nazwa.Contains(_searchCondition)).ToList();

            foreach (var p in temp)
            {
                result.Add(p.Publikacje);
            }

            return result;

        }
        private HashSet<Patenty> FindPatent(string _searchCondition)
        {
            var result = new HashSet<Patenty>();
            result = db.patenty.Where(q => q.tytul_polski.Contains(_searchCondition) || q.tytul_angielski.Contains(_searchCondition)).ToHashSet();

            var temp = db.patenty_tagi.Where(q => q.Slowa_kluczowe.nazwa.Contains(_searchCondition)).ToList();

            foreach (var p in temp)
            {
                result.Add(p.Patenty);
            }

            return result;

        }
        private HashSet<Odlewnia> FindOdlewnia(string _searchCondition)
        {
            var result = new HashSet<Odlewnia>();
            result = db.odlewnia.Where(q => q.nazwa.Contains(_searchCondition)).ToHashSet();

            var temp = db.odlewnia_tagi.Where(q => q.Slowa_kluczowe.nazwa.Contains(_searchCondition)).ToList();

            foreach (var p in temp)
            {
                result.Add(p.Odlewnia);
            }

            return result;

        }

    }
}
