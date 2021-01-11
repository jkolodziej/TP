using System.Collections.Generic;
using System.Linq;
using System;

namespace Zadanie3
{
    public class CollectionMethods : IDisposable
    {
        private ProductionDataContext db = new ProductionDataContext();

        public List<Product> GetProductsByName(string namePart)
        {
            return db.Products
                .Where(p => p.Name.Contains(namePart)).ToList();
        }

        public List<Product> GetProductsByVendorName(string vendorName)
        {
            return db.ProductVendors
                .Where(pv => pv.Vendor.Name.Equals(vendorName))
                .Select(pv => pv.Product).ToList();
            
        }

        public List<string> GetProductNamesByVendorName(string vendorName)
        {
            return db.ProductVendors
                .Where(pv => pv.Vendor.Name.Equals(vendorName))
                .Select(pv => pv.Product.Name).ToList();
        }

        public string GetProductVendorByProductName(string productName)
        {
            return db.ProductVendors
                .Where(pv => pv.Product.Name.Equals(productName))
                .Select(pv => pv.Vendor.Name).FirstOrDefault();

        }

        public List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            return db.ProductReviews
                .OrderBy(pr => pr.ReviewDate)
                .Select(pr => pr.Product).Take(howManyReviews).Distinct().ToList();

        }

        public List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            return db.ProductReviews
                .OrderBy(pr => pr.ReviewDate)
                .Select(pr => pr.Product).Take(howManyProducts).ToList();
        }

        public List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            return db.Products
               .Where(p => p.ProductSubcategory.ProductCategory.Name.Equals(categoryName))
               .Take(n).ToList();
        }

        public int GetTotalStandardCostByCategory(ProductCategory productCategory)
        {
            return (int)db.Products
                .Where(p => p.ProductSubcategory.ProductCategory.ProductCategoryID == productCategory.ProductCategoryID)
                .Select(p => p.StandardCost).Sum();

        }

        public void Dispose(){
            db.Dispose();
        }
    }

}
