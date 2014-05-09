using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CastKnowledgeWebApp.Models
{
    public class PagingInfo
    {
        public int totalItems { get; set; }
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }

        public int TotalPages
        {
            get 
            { 
                return (int)Math.Ceiling((decimal)totalItems / itemsPerPage); 
            }
        }
    }
}