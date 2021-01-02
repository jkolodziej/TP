using System.Collections.Generic;
using System.Linq;

namespace Zadanie3
{
    public class CollectionMethods
    {
        private static ProductionDataContext db = new ProductionDataContext();

        public static List<Product> GetProductsByName(string namePart)
        {
            return db.Products
                .Where(p => p.Name.Contains(namePart)).ToList();
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            return db.ProductVendors
                .Where(pv => pv.Vendor.Name.Equals(vendorName))
                .Select(pv => pv.Product).ToList();
            
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            return db.ProductVendors
                .Where(pv => pv.Vendor.Name.Equals(vendorName))
                .Select(pv => pv.Product.Name).ToList();
        }

        public static string GetProductVendorByProductName(string productName)
        {
            return db.ProductVendors
                .Where(pv => pv.Product.Name.Equals(productName))
                .Select(pv => pv.Vendor.Name).FirstOrDefault();

        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            return db.ProductReviews
                .OrderBy(pr => pr.ReviewDate)
                .Select(pr => pr.Product).Take(howManyReviews).Distinct().ToList();

        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            return db.ProductReviews
                .OrderBy(pr => pr.ReviewDate)
                .Select(pr => pr.Product).Take(howManyProducts).ToList();
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            return db.Products
               .Where(p => p.ProductSubcategory.ProductCategory.Name.Equals(categoryName))
               .Take(n).ToList();
        }

        public static int GetTotalStandardCostByCategory(ProductCategory productCategory)
        {
            return (int)db.Products
                .Where(p => p.ProductSubcategory.ProductCategory.ProductCategoryID == productCategory.ProductCategoryID)
                .Select(p => p.StandardCost).Sum();

        }
    }

}
