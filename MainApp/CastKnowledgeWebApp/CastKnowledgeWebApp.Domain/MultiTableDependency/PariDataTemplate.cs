using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastKnowledgeWebApp.Domain.MultiTableDependency
{
    public class PariDataTemplate<T1,T2>
    {
        public T1 typeOne { get; set; }
        public T2 typeTwo { get; set; }

        public PariDataTemplate(T1 a, T2 b)
        {
            typeOne = a;
            typeTwo = b;
        }


    }
}
