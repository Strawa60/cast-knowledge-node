using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;
using Moq;
using CastKnowledge.Domain.Entities;
using CastKnowledge.Domain.Entities.ContractorModel;
using CastKnowledge.Domain.Entities.FoundryModel;
using CastKnowledge.Domain.Entities.PatetnsModel;
using CastKnowledge.Domain.Entities.PublicationModel;
using CastKnowledge.Domain.Entities.AuthorModel;
using CastKnowledge.Domain.Abstract;
using CastKnowledge.Domain.Entities.Components;


namespace CastKnowledge.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ///////abstract


            ///////////

            Mock<IDatabaseQueryResult> mock = new Mock<IDatabaseQueryResult>();
            mock.Setup(m => m.DatabaseQueryResults).Returns(new List<DatabaseQueryResult> 
            {

                new DatabaseQueryResult { QueryResult_Contractor = new Contractor("Manthis","Ostrowiec","27-400","Rosochy","Swietokrzyskie","123312323","3343244","www.ww.pl","sda@as.pl","Strawczynski","dostawca",
                    new List<Resource>
                    { 
                        new Resource { resourceName="betony"},
                        new Resource { resourceName="betony zaprawy"},
                    })
                },

                new DatabaseQueryResult { QueryResult_Foundy = new Foundry("Odlewnia Ostrowiec","","","","","","","http://www.andoria-mot.com.pl/","sdasd@sda.pl","","",
                    new List<Material>
                    { 
                        new Material { materialName= "stop aluminium", materialSymbol= "Al"},
                        new Material { materialName= "stop cynku", materialSymbol= "Zn"}
                    },
                    
                    new List<CastTechnology>
                    {
                        new CastTechnology { technologyName= "die"}
                    })
                 },
                
                new DatabaseQueryResult { QueryResult_Patent = new Patent(9384724, null,null,Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    "C02F 1/44 (2006.01) C22B 60/02 (2006.01) B01D 61/02 (2006.01) G21F 9/06 (2006.01)",
                    "Sposób pozyskiwania i separacji cennych pierwiastków metali, zwłaszcza z ubogich rud uranowych oraz ścieków radioaktywnych","","","","","www.asdasd.pl",
                    new List<Author>
                    {
                        new Author("John", "Newman", "AGH", "dr")
                    })
                },
            
                new DatabaseQueryResult { QueryResult_Publication = new Publication(DateTime.Now.Date,"asdsads","asdasd","dasdasdassadssa asdasd asdasd","","czasopismo",
                    new List<Author>
                    {
                        new Author("John", "Newman", "AGH", "dr")
                    })
                }
            
            }.AsQueryable());

            ninjectKernel.Bind<IDatabaseQueryResult>().ToConstant(mock.Object);

            
        }

    }
}