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
            using(DatabaseQueries dq = new DatabaseQueries())
            {
                List<Product> productsByName = dq.GetProductsByName("Blade");
                Assert.AreEqual(1, productsByName.Count);
                Assert.AreEqual("Blade", productsByName[0].Name);
            }          
        }

        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
            using (DatabaseQueries dq = new DatabaseQueries())
            {
                List<Product> productsByVendorName = dq.GetProductsByVendorName("Training Systems");
                Assert.AreEqual(3, productsByVendorName.Count);
                Assert.AreEqual(320, productsByVendorName[0].ProductID);
                Assert.AreEqual(321, productsByVendorName[1].ProductID);
                Assert.AreEqual(322, productsByVendorName[2].ProductID);
            }            
        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {
            using (DatabaseQueries dq = new DatabaseQueries())
            {
                 List<string> productNamesByVendorName = dq.GetProductNamesByVendorName("Training Systems");
                Assert.AreEqual(3, productNamesByVendorName.Count);
                Assert.AreEqual("Chainring Bolts", productNamesByVendorName[0]);
                Assert.AreEqual("Chainring Nut", productNamesByVendorName[1]);
                Assert.AreEqual("Chainring", productNamesByVendorName[2]);
            }           
        }

        [TestMethod()]
        public void GetProductVendorByProductNameTest()
        {
            using (DatabaseQueries dq = new DatabaseQueries())
            {
                string productVendorByProductName = dq.GetProductVendorByProductName("Chainring");
                Assert.AreEqual("Training Systems", productVendorByProductName);
            }               
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
            using (DatabaseQueries dq = new DatabaseQueries())
            {
                List<Product> productsWithRecentReviews = dq.GetProductsWithNRecentReviews(3);
                Assert.AreEqual(2, productsWithRecentReviews.Count);
                Assert.AreEqual(709, productsWithRecentReviews[0].ProductID);
                Assert.AreEqual(937, productsWithRecentReviews[1].ProductID);
            }               
        }

        [TestMethod()]
        public void GetNRecentlyReviewedProductsTest()
        {
            using (DatabaseQueries dq = new DatabaseQueries())
            {
                List<Product> recentlyReviewedProducts = dq.GetNRecentlyReviewedProducts(3);
                Assert.AreEqual(3, recentlyReviewedProducts.Count);
                Assert.AreEqual(709, recentlyReviewedProducts[0].ProductID);
                Assert.AreEqual(937, recentlyReviewedProducts[1].ProductID);
                Assert.AreEqual(937, recentlyReviewedProducts[2].ProductID);
            }
        }

        [TestMethod()]
        public void GetNProductsFromCategoryTest()
        {
            using (DatabaseQueries dq = new DatabaseQueries())
            {
                List<Product> productsFromCategory = dq.GetNProductsFromCategory("Bikes", 4);
                Assert.AreEqual(4, productsFromCategory.Count);
                Assert.AreEqual(771, productsFromCategory[0].ProductID);
                Assert.AreEqual(772, productsFromCategory[1].ProductID);
                Assert.AreEqual(773, productsFromCategory[2].ProductID);
            }             
        }

        [TestMethod()]
        public void GetTotalStandardCostByCategoryTest()
        {
            using (DatabaseQueries dq = new DatabaseQueries())
            {
                ProductionDataContext db = new ProductionDataContext();
                ProductCategory productCategory = db.ProductCategories.ToList().First();
                int totalCost = dq.GetTotalStandardCostByCategory(productCategory);
                Assert.AreEqual(92092, totalCost);
            }              
        }
    }
}