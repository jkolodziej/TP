using System.Collections.Generic;
using System.Linq;

namespace Zadanie3.MyProduction
{
    public class MyQueries
    {
        private static MyContext context = new MyContext();

        public static List<MyProduct> GetNMyProductsFromMyCategory(string categoryName, int n)
        {
            return (from p in context.MyProducts
                    where p.Category.Name.Equals(categoryName)
                    select p).Take(n).ToList();
        }

        public static List<MyProduct> GetMyProductsByMyVendorName(string vendorName)
        {
            return (from p in context.MyProducts
                    where p.Vendor.Name.Equals(vendorName)
                    select p).ToList();
        }

        public static List<MyProduct> GetMyProductsByName(string namePart)
        {
            return (from p in context.MyProducts
                    where p.Name.Contains(namePart)
                    select p).ToList();
        }
    }
}
