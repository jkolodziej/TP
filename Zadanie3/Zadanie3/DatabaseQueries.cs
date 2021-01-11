using System.Collections.Generic;
using System;
using System.Linq;

namespace Zadanie3
{
    public class DatabaseQueries : IDisposable
    {
        private ProductionDataContext db = new ProductionDataContext();

        public List<Product> GetProductsByName(string namePart)
        {
            return (from p in db.Products
                    where p.Name.Contains(namePart)
                    select p).ToList();
        }

        public List<Product> GetProductsByVendorName(string vendorName)
        {
            return (from pv in db.ProductVendors
                    where pv.Vendor.Name.Equals(vendorName)
                    select pv.Product).ToList();
        }

        public List<string> GetProductNamesByVendorName(string vendorName)
        {
            return (from pv in db.ProductVendors
                    where pv.Vendor.Name.Equals(vendorName)
                    select pv.Product.Name).ToList();
        }

        public string GetProductVendorByProductName(string productName)
        {
            return (from pv in db.ProductVendors
                        where pv.Product.Name.Equals(productName)
                        select pv.Vendor.Name).FirstOrDefault();
        }

        public List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            return (from pr in db.ProductReviews
                    orderby pr.ReviewDate
                    select pr.Product).Take(howManyReviews).Distinct().ToList();
        }

        public List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            return (from pr in db.ProductReviews
                    orderby pr.ReviewDate
                    select pr.Product).Take(howManyProducts).ToList();
        }

        public List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            return (from p in db.Products
                    where p.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                    select p).Take(n).ToList();
        }

        public int GetTotalStandardCostByCategory(ProductCategory productCategory)
        {
            return (int)(from p in db.Products
                    where p.ProductSubcategory.ProductCategory.Equals(productCategory)
                    select p.StandardCost).ToList().Sum();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
