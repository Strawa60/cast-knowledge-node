using System;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;
using CastKnowledge.Domain.Entities;
using CastKnowledge.Domain.Entities.ContractorModel;
using CastKnowledge.Domain.Abstract;
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
            //dodatkowe powiązania
            /*
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> 
            {
                new Product { Name = "Piłka nożna", Price = 25},
                new Product { Name = "Deska Surfingowa", Price = 179},
                new Product { Name = "buty do biegania", Price= 95}
            }.AsQueryable());

            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
            */

            //ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
            List<Resource> companyResources = new List<Resource>
            { 
                new Resource { resourceName="betony"},
                new Resource { resourceName="betony zaprawy"},
            };
            List<Material> companyMaterials = new List<Material>
                {
                    new Material { materialName="stal", materialSymbol="Fe"}
                };
                

            Mock<IDatabaseQueryResult> mock = new Mock<IDatabaseQueryResult>();
            mock.Setup(m => m.DatabaseQueryResults).Returns(new List<DatabaseQueryResult> 
            {
                new DatabaseQueryResult { QueryResult = new Contractor("Manthis","Strawolsky","betony","dostawca","27-400","Ostrowiec","Rosochy",null,null,"swietokrzyskie",null,null,companyResources,companyMaterials) },
                new DatabaseQueryResult { QueryResult = new Contractor("Manthis","Strawolsky","betony","dostawca","27-400","Ostrowiec","Rosochy",null,null,"swietokrzyskie",null,null,companyResources,companyMaterials) },
                new DatabaseQueryResult { QueryResult = new Contractor("Manthis","Strawolsky","betony","dostawca","27-400","Ostrowiec","Rosochy",null,null,"swietokrzyskie",null,null,companyResources,companyMaterials) }

            }.AsQueryable());

            ninjectKernel.Bind<IDatabaseQueryResult>().ToConstant(mock.Object);

        }

    }
}