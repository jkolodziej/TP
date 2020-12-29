using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> newList = DatabaseQueries.GetProductsByName("Blade");
            List<Product> newList2 = DatabaseQueries.GetProductsByVendorName("Training Systems");
            Console.WriteLine(newList.Count());
            Console.WriteLine(newList2.Count());
            List<string> newList3 = DatabaseQueries.GetProductNamesByVendorName("Training Systems");
            Console.WriteLine(newList3[0]);
            Console.WriteLine(newList3[1]);
            Console.WriteLine(newList3[2]);
            string test = DatabaseQueries.GetProductVendorByProductName("Chainring");
            Console.WriteLine(test);
            List<Product> newList4 = DatabaseQueries.GetProductsWithNRecentReviews(6);
            Console.WriteLine(newList4[0]);
            Console.WriteLine(newList4.Count());
            List<Product> recentlyReviewedProducts = DatabaseQueries.GetNRecentlyReviewedProducts(3);
            Console.WriteLine(recentlyReviewedProducts.Count);
            Console.WriteLine(recentlyReviewedProducts[0].ProductID);
            Console.WriteLine(recentlyReviewedProducts[1].ProductID);
            Console.WriteLine(recentlyReviewedProducts[2].ProductID);
            List<Product> newList5 = DatabaseQueries.GetNProductsFromCategory("Bikes", 20);
            Console.WriteLine(newList5[0].ProductID);
            Console.WriteLine(newList5[1].ProductID);
            Console.WriteLine(newList5[2].ProductID);
            Console.WriteLine(newList5[3].Name);
            Console.WriteLine(newList5[15].Name);
            Console.WriteLine(newList5[16].Name);
            Console.WriteLine(newList5.Count());

            ProductCategoryDataContext db = new ProductCategoryDataContext();
            ProductCategory productCategory = (from category in db.GetTable<ProductCategory>()
                                              where category.ProductCategoryID == 1
                                              select category).ToList().First();
            Console.WriteLine(productCategory);
            int totalCost = DatabaseQueries.GetTotalStandardCostByCategory(productCategory);
            Console.WriteLine(totalCost);
            Console.ReadLine();
        }
    }
}
