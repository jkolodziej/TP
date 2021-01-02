using System.Collections.Generic;
using System.Linq;

namespace Zadanie3
{
    public static class ExtensionMethods
    {

        public static List<Product> GetProductsWithoutCategory(this List<Product> products)
        {
            return products
                .Where(p => p.ProductSubcategoryID.Equals(null)).ToList();
        }

        public static List<Product> GetProductsPage(this List<Product> products, int pageSize, int numberOfPage)
        {
            return products.Skip(pageSize * (numberOfPage - 1)).Take(pageSize).ToList();
        }

        public static string getProductNamesWithVendors(this List<Product> products)
        {        
            return "";
        }

    }
}
