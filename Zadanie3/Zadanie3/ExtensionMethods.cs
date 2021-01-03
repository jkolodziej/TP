using System.Collections.Generic;
using System.Linq;

namespace Zadanie3
{
    public static class ExtensionMethods
    {

        public static List<Product> GetProductsWithoutCategoryMethod(this List<Product> products)
        {
            return products
                .Where(p => p.ProductSubcategoryID.Equals(null)).ToList();
        }

        public static List<Product> GetProductsWithoutCategoryQuery(this List<Product> products)
        {
            return (from p in products
                   where p.ProductSubcategoryID.Equals(null)
                   select p).ToList();
        }

        public static List<Product> GetProductsPageMethod(this List<Product> products, int pageSize, int numberOfPage)
        {
            return products.Skip(pageSize * (numberOfPage - 1)).Take(pageSize).ToList();
        }

        public static List<Product> GetProductsPageQuery(this List<Product> products, int pageSize, int numberOfPage)
        {
            return (from p in products
                    select p).Skip(pageSize * (numberOfPage - 1)).Take(pageSize).ToList(); 
        }

        public static string getProductNamesWithVendorsQuery(this List<Product> products)
        {
            ProductionDataContext db = new ProductionDataContext();

            var productAndVendor = from p in products
                                   from pv in db.ProductVendors
                                   where pv.ProductID == p.ProductID
                                   select new { productName = pv.Product.Name, vendorName = pv.Vendor.Name };
            string[] rows= productAndVendor.Select(l => l.productName + " - " + l.vendorName).ToArray();

            return string.Join("\n", rows);
        }

        public static string getProductNamesWithVendorsMethod(this List<Product> products)
        {
            ProductionDataContext db = new ProductionDataContext();

            var productAndVendor = products.Join(
                            db.ProductVendors,
                            p => p.ProductID, pv => pv.ProductID,
                            (p, pv) => new { productName = p.Name, vendorName = pv.Vendor.Name });

            string[] rows = productAndVendor.Select(l => l.productName + " - " + l.vendorName).ToArray();

            return string.Join("\n", rows);
        }

    }
}
