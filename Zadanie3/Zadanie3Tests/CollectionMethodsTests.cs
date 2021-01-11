using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie3.Tests
{
    [TestClass()]
    public class CollectionMethodsTests
    {
        [TestMethod()]
        public void GetProductsByNameTest()
        {
            using(CollectionMethods cm = new CollectionMethods())
            {
                List<Product> productsByName = cm.GetProductsByName("Blade");
                Assert.AreEqual(1, productsByName.Count);
                Assert.AreEqual("Blade", productsByName[0].Name);
            }
        }

        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
            using(CollectionMethods cm = new CollectionMethods())
            {
                List<Product> productsByVendorName = cm.GetProductsByVendorName("Training Systems");
                Assert.AreEqual(3, productsByVendorName.Count);
                Assert.AreEqual(320, productsByVendorName[0].ProductID);
                Assert.AreEqual(321, productsByVendorName[1].ProductID);
                Assert.AreEqual(322, productsByVendorName[2].ProductID);
            }
        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {
            using(CollectionMethods cm = new CollectionMethods())
            {
                List<string> productNamesByVendorName = cm.GetProductNamesByVendorName("Training Systems");
                Assert.AreEqual(3, productNamesByVendorName.Count);
                Assert.AreEqual("Chainring Bolts", productNamesByVendorName[0]);
                Assert.AreEqual("Chainring Nut", productNamesByVendorName[1]);
                Assert.AreEqual("Chainring", productNamesByVendorName[2]);
            }
        }

        [TestMethod()]
        public void GetProductVendorByProductNameTest()
        {
            using(CollectionMethods cm = new CollectionMethods())
            {
                string productVendorByProductName = cm.GetProductVendorByProductName("Chainring");
                Assert.AreEqual("Training Systems", productVendorByProductName);
            } 
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
            using(CollectionMethods cm = new CollectionMethods())
            {
                List<Product> productsWithRecentReviews = cm.GetProductsWithNRecentReviews(3);
                Assert.AreEqual(2, productsWithRecentReviews.Count);
                Assert.AreEqual(709, productsWithRecentReviews[0].ProductID);
                Assert.AreEqual(937, productsWithRecentReviews[1].ProductID);
            }
        }

        [TestMethod()]
        public void GetNRecentlyReviewedProductsTest()
        {
            using(CollectionMethods cm = new CollectionMethods())
            {
                List<Product> recentlyReviewedProducts = cm.GetNRecentlyReviewedProducts(3);
                Assert.AreEqual(3, recentlyReviewedProducts.Count);
                Assert.AreEqual(709, recentlyReviewedProducts[0].ProductID);
                Assert.AreEqual(937, recentlyReviewedProducts[1].ProductID);
                Assert.AreEqual(937, recentlyReviewedProducts[2].ProductID);
            }

        }

        [TestMethod()]
        public void GetNProductsFromCategoryTest()
        {
            using(CollectionMethods cm = new CollectionMethods())
            {
                List<Product> productsFromCategory = cm.GetNProductsFromCategory("Bikes", 4);
                Assert.AreEqual(4, productsFromCategory.Count);
                Assert.AreEqual(771, productsFromCategory[0].ProductID);
                Assert.AreEqual(772, productsFromCategory[1].ProductID);
                Assert.AreEqual(773, productsFromCategory[2].ProductID);
            }
        }

        [TestMethod()]
        public void GetTotalStandardCostByCategoryTest()
        {
            using(CollectionMethods cm = new CollectionMethods())
            {
                ProductionDataContext db = new ProductionDataContext();
                ProductCategory productCategory = db.ProductCategories.ToList().First();
                int totalCost = cm.GetTotalStandardCostByCategory(productCategory);
                Assert.AreEqual(92092, totalCost);
            }

        }
    }
}