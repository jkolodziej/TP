using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class DatabaseQueries
    {
        private static DataContext db { get; set; }

        public DatabaseQueries()
        {

        }

        public static List<Product> GetProductsByName(string name)
        {
            ProductDataContext db = new ProductDataContext();

            return (from product in db.GetTable<Product>()
                    where product.Name == name
                    select product).ToList();
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            VendorDataContext db = new VendorDataContext();

            int id = (from vendor in db.GetTable<Vendor>()
                      where vendor.Name == vendorName
                      select vendor.BusinessEntityID).First();

            return (from p in db.GetTable<Product>()
                    join pv in db.GetTable<ProductVendor>() on p.ProductID equals pv.ProductID
                    where pv.BusinessEntityID == id
                    select p).ToList();
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            VendorDataContext db = new VendorDataContext();

            int id = (from vendor in db.GetTable<Vendor>()
                      where vendor.Name == vendorName
                      select vendor.BusinessEntityID).First();

            return (from p in db.GetTable<Product>()
                    join pv in db.GetTable<ProductVendor>() on p.ProductID equals pv.ProductID
                    where pv.BusinessEntityID == id
                    select p.Name).ToList();
        }

        // string or List<string> ? multiple vendors
        public static string GetProductVendorByProductName(string productName)
        {
            ProductDataContext db = new ProductDataContext();

            int id = (from product in db.GetTable<Product>()
                      where product.Name == productName
                      select product.ProductID).First();

            var name = (from v in db.GetTable<Vendor>()
                        join pv in db.GetTable<ProductVendor>() on v.BusinessEntityID equals pv.BusinessEntityID
                        where pv.ProductID == id
                        select v.Name).FirstOrDefault();

            return name;
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            ProductReviewDataContext db = new ProductReviewDataContext();

            var ordered = (from pr in db.GetTable<ProductReview>()
                           orderby pr.ReviewDate descending
                           select pr);

            return (from pr in ordered
                    from p in db.GetTable<Product>()
                    where pr.ProductID == p.ProductID
                    select p).Take(howManyReviews).ToList();
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            ProductReviewDataContext db = new ProductReviewDataContext();

            var ordered = (from p in db.GetTable<ProductReview>()
                           orderby p.ReviewDate descending
                           select p);

            return (from pr in ordered
                    from p in db.GetTable<Product>()
                    where pr.ProductID == p.ProductID
                    select p).Distinct().Take(howManyProducts).ToList();
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            ProductCategoryDataContext db = new ProductCategoryDataContext();

            int id = (from category in db.GetTable<ProductCategory>()
                      where category.Name == categoryName
                      select category.ProductCategoryID).First();

            return (from p in db.GetTable<Product>()
                    join ps in db.GetTable<ProductSubcategory>() on p.ProductSubcategoryID equals ps.ProductSubcategoryID
                    where ps.ProductCategoryID == id
                    orderby p.Name ascending
                    select p).Take(n).ToList();
        }

        public static int GetTotalStandardCostByCategory(ProductCategory productCategory)
        {
            ProductCategoryDataContext db = new ProductCategoryDataContext();

            int id = (from category in db.GetTable<ProductCategory>()
                      where category == productCategory
                      select category.ProductCategoryID).First();

            var subcategories = (from subcategory in db.GetTable<ProductSubcategory>()
                                 where subcategory.ProductCategoryID == id
                                 select subcategory.ProductSubcategoryID).ToList();

            int cost = 0;
            var products = (from product in db.GetTable<Product>()
                            where subcategories.Contains((int)product.ProductSubcategoryID)
                            select product);
            foreach (var product in products)
            {
                cost += (int)product.StandardCost;
            }
            return cost;
        }
    }
}
