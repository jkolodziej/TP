using System.Collections.Generic;
using System.Linq;


namespace Zadanie3
{
    public class DatabaseQueries
    {
        private static ProductionDataContext db = new ProductionDataContext();

        public static List<Product> GetProductsByName(string namePart)
        {
            return (from p in db.Products
                    where p.Name.Contains(namePart)
                    select p).ToList();
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            return (from pv in db.ProductVendors
                    where pv.Vendor.Name.Equals(vendorName)
                    select pv.Product).ToList();
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            return (from pv in db.ProductVendors
                    where pv.Vendor.Name.Equals(vendorName)
                    select pv.Product.Name).ToList();
        }

        public static string GetProductVendorByProductName(string productName)
        {
            return (from pv in db.ProductVendors
                        where pv.Product.Name.Equals(productName)
                        select pv.Vendor.Name).FirstOrDefault();
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            return (from pr in db.ProductReviews
                    orderby pr.ReviewDate
                    select pr.Product).Take(howManyReviews).Distinct().ToList();
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            return (from pr in db.ProductReviews
                    orderby pr.ReviewDate
                    select pr.Product).Take(howManyProducts).ToList();
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            return (from p in db.Products
                    where p.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                    select p).Take(n).ToList();
        }

        public static int GetTotalStandardCostByCategory(ProductCategory productCategory)
        {
            return (int)(from p in db.Products
                    where p.ProductSubcategory.ProductCategory.Equals(productCategory)
                    select p.StandardCost).ToList().Sum();
        }
    }
}
