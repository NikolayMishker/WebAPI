using System;
using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersFroCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersFroCountSpecification(ProductSpecParams productParams) 
        : base(x =>
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {

        }
    }
}
