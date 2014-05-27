using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastKnowledgeWebApp.Domain.MultiTableDependency
{
    public class PairDataTemplate<T1,T2>
    {
        public T1 t1 { get; set; }
        public T2 t2 { get; set; }

        public PairDataTemplate(T1 a, T2 b)
        {
            t1 = a;
            t2 = b;
        }


    }
}
