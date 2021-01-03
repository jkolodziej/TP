using System.Collections.Generic;
using System.Linq;


namespace Zadanie3.MyProduction
{
    public class MyMethods
    {
        private static MyContext context = new MyContext();

        public static List<MyProduct> GetNMyProductsFromMyCategory(string categoryName, int n)
        {
            return context.MyProducts
                .Where(p => p.Category.Name.Equals(categoryName)).Take(n).ToList();
        }

        public static List<MyProduct> GetMyProductsByMyVendorName(string vendorName)
        {
            return context.MyProducts
                .Where(p => p.Vendor.Name.Equals(vendorName)).ToList();
        }

        public static List<MyProduct> GetMyProductsByName(string namePart)
        {
            return context.MyProducts
                .Where(p => p.Name.Contains(namePart)).ToList();
        }
    }
}
