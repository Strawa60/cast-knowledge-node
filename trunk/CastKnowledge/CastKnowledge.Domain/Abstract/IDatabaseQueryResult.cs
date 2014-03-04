using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastKnowledge.Domain.Entities;

namespace CastKnowledge.Domain.Abstract
{
    public interface IDatabaseQueryResult
    {
        IQueryable<DatabaseQueryResult> DatabaseQueryResults { get; }
    }
}
