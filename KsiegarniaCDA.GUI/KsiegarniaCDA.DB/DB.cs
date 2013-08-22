using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KsiegarniaCDA.DTO;

namespace KsiegarniaCDA.DB
{
    class DB
    {
        #region Properties

        public static List<Ksiazka> Ksiazki { get; set; }
        public static List<Autor> Autorzy { get; set; }
        public static List<Gatunek> Gatunki { get; set; }

        #endregion



        #region Construktors

        static DB()
        {
            InitializeDB();
        }

        #endregion



        #region Private methods

        private static void InitializeDB()
        {
            Ksiazki = new List<Ksiazka>()
            {
                //kilka ksiazek
            };

            Autorzy = new List<Autor>()
            {
                //kilku autorow
            };

            Gatunki = new List<Gatunek>()
            {
                //kilka gatonkow
            };

        }

        #endregion



    }
}
