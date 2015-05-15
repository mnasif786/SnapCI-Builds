using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Nancy;
using Nancy.ModelBinding;

namespace NancyApplication
{
    public class ProductsModule : NancyModule 
    {
        public ProductsModule()
        {
            var productRepo =  new ProdcutRepository();

            Get["/product"] = parameters => productRepo.GetAll();

            Get["/product/{id}"] = parameters => productRepo.Get(parameters.Id);

            Post["/product"] = parameters =>
            {
                var product = this.Bind<Product>();
                
                productRepo.Save(product);
                return HttpStatusCode.OK;
            };
        }
    }
}