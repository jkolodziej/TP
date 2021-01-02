using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3.Tests
{
    [TestClass()]
    public class CollectionMethodsTests
    {
        [TestMethod()]
        public void GetProductsByNameTest()
        {
            List<Product> productsByName = CollectionMethods.GetProductsByName("Blade");
            Assert.AreEqual(1, productsByName.Count);
            Assert.AreEqual("Blade", productsByName[0].Name);
        }

        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
            List<Product> productsByVendorName = CollectionMethods.GetProductsByVendorName("Training Systems");
            Assert.AreEqual(3, productsByVendorName.Count);
            Assert.AreEqual(320, productsByVendorName[0].ProductID);
            Assert.AreEqual(321, productsByVendorName[1].ProductID);
            Assert.AreEqual(322, productsByVendorName[2].ProductID);
        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> productNamesByVendorName = CollectionMethods.GetProductNamesByVendorName("Training Systems");
            Assert.AreEqual(3, productNamesByVendorName.Count);
            Assert.AreEqual("Chainring Bolts", productNamesByVendorName[0]);
            Assert.AreEqual("Chainring Nut", productNamesByVendorName[1]);
            Assert.AreEqual("Chainring", productNamesByVendorName[2]);
        }

        [TestMethod()]
        public void GetProductVendorByProductNameTest()
        {
            string productVendorByProductName = CollectionMethods.GetProductVendorByProductName("Chainring");
            Assert.AreEqual("Training Systems", productVendorByProductName);
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> productsWithRecentReviews = CollectionMethods.GetProductsWithNRecentReviews(3);
            Assert.AreEqual(2, productsWithRecentReviews.Count);
            Assert.AreEqual(709, productsWithRecentReviews[0].ProductID);
            Assert.AreEqual(937, productsWithRecentReviews[1].ProductID);
        }

        [TestMethod()]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> recentlyReviewedProducts = CollectionMethods.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(3, recentlyReviewedProducts.Count);
            Assert.AreEqual(709, recentlyReviewedProducts[0].ProductID);
            Assert.AreEqual(937, recentlyReviewedProducts[1].ProductID);
            Assert.AreEqual(937, recentlyReviewedProducts[2].ProductID);

        }

        [TestMethod()]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> productsFromCategory = CollectionMethods.GetNProductsFromCategory("Bikes", 4);
            Assert.AreEqual(4, productsFromCategory.Count);
            Assert.AreEqual(771, productsFromCategory[0].ProductID);
            Assert.AreEqual(772, productsFromCategory[1].ProductID);
            Assert.AreEqual(773, productsFromCategory[2].ProductID);
        }

        [TestMethod()]
        public void GetTotalStandardCostByCategoryTest()
        {
            ProductionDataContext db = new ProductionDataContext();
            ProductCategory productCategory = db.ProductCategories.ToList().First();
            int totalCost = CollectionMethods.GetTotalStandardCostByCategory(productCategory);
            Assert.AreEqual(92092, totalCost);

        }
    }
}