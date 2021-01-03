using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie3.Tests
{
    [TestClass()]
    public class ExtensionMethodsTests
    {
        [TestMethod()]
        public void GetProductsWithoutCategoryMethodTest()
        {
            ProductionDataContext db = new ProductionDataContext();
            List<Product> productsWithoutCategory = db.Products.ToList().GetProductsWithoutCategoryMethod();           
            Assert.AreEqual(209, productsWithoutCategory.Count);
            Assert.AreEqual("Adjustable Race", productsWithoutCategory[0].Name);
            Assert.IsNull(productsWithoutCategory[0].ProductSubcategoryID);
        }

        [TestMethod()]
        public void GetProductsWithoutCategoryQueryTest()
        {
            ProductionDataContext db = new ProductionDataContext();
            List<Product> productsWithoutCategory = db.Products.ToList().GetProductsWithoutCategoryQuery();
            Assert.AreEqual(209, productsWithoutCategory.Count);
            Assert.AreEqual("Adjustable Race", productsWithoutCategory[0].Name);
            Assert.IsNull(productsWithoutCategory[0].ProductSubcategoryID);
        }

        [TestMethod()]
        public void GetProductsPageMethodTest()
        {
            ProductionDataContext db = new ProductionDataContext();
            List<Product> productPage1 = db.Products.ToList().GetProductsPageMethod(200, 1);
            List<Product> productPage2 = db.Products.ToList().GetProductsPageMethod(200, 2);
            List<Product> productPage3 = db.Products.ToList().GetProductsPageMethod(200, 3);
            Assert.AreEqual(200, productPage1.Count);
            Assert.AreEqual(200, productPage2.Count);
            Assert.AreEqual(104, productPage3.Count);
        }

        [TestMethod()]
        public void GetProductsPageQueryTest()
        {
            ProductionDataContext db = new ProductionDataContext();
            List<Product> productPage1 = db.Products.ToList().GetProductsPageQuery(200, 1);
            List<Product> productPage2 = db.Products.ToList().GetProductsPageQuery(200, 2);
            List<Product> productPage3 = db.Products.ToList().GetProductsPageQuery(200, 3);
            Assert.AreEqual(200, productPage1.Count);
            Assert.AreEqual(200, productPage2.Count);
            Assert.AreEqual(104, productPage3.Count);
        }

        [TestMethod()]
        public void getProductNamesWithVendorsMethodTest()
        {
            ProductionDataContext db = new ProductionDataContext();
            string productsAndVendors = db.Products.ToList().getProductNamesWithVendorsMethod();
            Assert.IsNotNull(productsAndVendors);
            Assert.IsTrue(productsAndVendors.Length > 1000);
            Assert.IsTrue(productsAndVendors.Contains("Adjustable Race"));
        }

        [TestMethod()]
        public void getProductNamesWithVendorsQueryTest()
        {
            ProductionDataContext db = new ProductionDataContext();
            string productsAndVendors = db.Products.ToList().getProductNamesWithVendorsQuery();
            Assert.IsNotNull(productsAndVendors);
            Assert.IsTrue(productsAndVendors.Length > 1000);
            Assert.IsTrue(productsAndVendors.Contains("Adjustable Race"));
        }
    }
}