using CastKnowledge.Domain.Abstract;
using CastKnowledge.Domain.Entities.ContractorModel;
using CastKnowledge.Domain.Entities.PublicationModel;
using CastKnowledge.Domain.Entities.FoundryModel;
using CastKnowledge.Domain.Entities.PatetnsModel;
using CastKnowledge.Domain.Entities.AuthorModel;
using CastKnowledge.Domain.Entities.Components;

namespace CastKnowledge.Domain.Entities
{
    public class DatabaseQueryResult
    {
        public Contractor QueryResult_Contractor;
        public Foundry QueryResult_Foundy;
        public Publication QueryResult_Publication;
        public Patent QueryResult_Patent;
        public Author QueryResult_Author;
    }
}
