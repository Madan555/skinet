using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithBrandAndTypeSpec : BaseSpecification<Product>
    {
        public ProductsWithBrandAndTypeSpec()
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
        public ProductsWithBrandAndTypeSpec(int id):base(x=> x.Id == id){
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}