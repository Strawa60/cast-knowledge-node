using System;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;
using CastKnowledge.Domain.Entities;
using CastKnowledge.Domain.Entities.ContractorModel;
using CastKnowledge.Domain.Abstract;
using CastKnowledge.Domain.Entities.Components;
using System.Collections.Generic;
using Moq;
using System.Linq;


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

            List<Resource> companyResources = new List<Resource>
            { 
                new Resource { resourceName="betony"},
                new Resource { resourceName="betony zaprawy"},
            };

            List<Resource> companyResources2 = new List<Resource>
            { 
                new Resource { resourceName="asdasdd"},
                new Resource { resourceName="asdsad"},
            };

            Mock<IDatabaseQueryResult> mock = new Mock<IDatabaseQueryResult>();
            mock.Setup(m => m.DatabaseQueryResults).Returns(new List<DatabaseQueryResult> 
            {
                new DatabaseQueryResult { QueryResult_Contractor = new Contractor("Manthis","Ostrowiec","27-400","Rosochy","Swietokrzyskie","123312323","3343244","www.ww.pl","sda@as.pl","Strawczynski","dostawca",companyResources)},
                new DatabaseQueryResult { QueryResult_Contractor = new Contractor("Manthis","Ostrowiec","27-400","Rosochy","Swietokrzyskie","123312323","3343244","www.ww.pl","sda@as.pl","Strawczynski","dostawca",companyResources2)}
            }.AsQueryable());

            ninjectKernel.Bind<IDatabaseQueryResult>().ToConstant(mock.Object);

            
        }

    }
}