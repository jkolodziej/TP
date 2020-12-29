using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie3.Tests
{
    [TestClass()]
    public class DatabaseQueriesTests
    {

        [TestMethod()]
        public void GetProductsByNameTest()
        {
            List<Product> productsByName = DatabaseQueries.GetProductsByName("Blade");
            Assert.AreEqual(1, productsByName.Count);
            Assert.AreEqual("Blade", productsByName[0].Name);
        }

        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
            List<Product> productsByVendorName = DatabaseQueries.GetProductsByVendorName("Training Systems");
            Assert.AreEqual(3, productsByVendorName.Count);
            Assert.AreEqual(320, productsByVendorName[0].ProductID);
            Assert.AreEqual(321, productsByVendorName[1].ProductID);
            Assert.AreEqual(322, productsByVendorName[2].ProductID);
        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> productNamesByVendorName = DatabaseQueries.GetProductNamesByVendorName("Training Systems");
            Assert.AreEqual(3, productNamesByVendorName.Count);
            Assert.AreEqual("Chainring Bolts", productNamesByVendorName[0]);
            Assert.AreEqual("Chainring Nut", productNamesByVendorName[1]);
            Assert.AreEqual("Chainring", productNamesByVendorName[2]);
        }

        [TestMethod()]
        public void GetProductVendorByProductNameTest()
        {
            string productVendorByProductName = DatabaseQueries.GetProductVendorByProductName("Chainring");
            Assert.AreEqual("Training Systems", productVendorByProductName);
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> productsWithRecentReviews = DatabaseQueries.GetProductsWithNRecentReviews(3);
            Assert.AreEqual(3, productsWithRecentReviews.Count);
            Assert.AreEqual(937, productsWithRecentReviews[0].ProductID);
            Assert.AreEqual(798, productsWithRecentReviews[1].ProductID);
            Assert.AreEqual(937, productsWithRecentReviews[2].ProductID);
        }

        [TestMethod()]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> recentlyReviewedProducts = DatabaseQueries.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(3, recentlyReviewedProducts.Count);
            Assert.AreEqual(709, recentlyReviewedProducts[0].ProductID);
            Assert.AreEqual(798, recentlyReviewedProducts[1].ProductID);
            Assert.AreEqual(937, recentlyReviewedProducts[2].ProductID);

        }

        [TestMethod()]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> productsFromCategory = DatabaseQueries.GetNProductsFromCategory("Bikes", 4);
            Assert.AreEqual(4, productsFromCategory.Count);
            Assert.AreEqual(775, productsFromCategory[0].ProductID);
            Assert.AreEqual(776, productsFromCategory[1].ProductID);
            Assert.AreEqual(777, productsFromCategory[2].ProductID);
        }

        [TestMethod()]
        public void GetTotalStandardCostByCategoryTest()
        {
            ProductCategoryDataContext db = new ProductCategoryDataContext();
            ProductCategory productCategory = (from category in db.GetTable<ProductCategory>()
                                               where category.ProductCategoryID == 1
                                               select category).ToList().First();
            int totalCost = DatabaseQueries.GetTotalStandardCostByCategory(productCategory);
            Assert.AreEqual(92040, totalCost);

        }
    }
}