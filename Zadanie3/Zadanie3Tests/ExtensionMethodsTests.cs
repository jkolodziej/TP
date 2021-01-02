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
    public class ExtensionMethodsTests
    {
        [TestMethod()]
        public void GetProductsWithoutCategoryTest()
        {
            ProductionDataContext db = new ProductionDataContext();
            List<Product> productsWithoutCategory = db.Products.ToList().GetProductsWithoutCategory();           
            Assert.AreEqual(209, productsWithoutCategory.Count);
            Assert.AreEqual("Adjustable Race", productsWithoutCategory[0].Name);
            Assert.IsNull(productsWithoutCategory[0].ProductSubcategoryID);
        }

        [TestMethod()]
        public void GetProductsPageTest()
        {
            ProductionDataContext db = new ProductionDataContext();
            List<Product> productPage1 = db.Products.ToList().GetProductsPage(200, 1);
            List<Product> productPage2 = db.Products.ToList().GetProductsPage(200, 2);
            List<Product> productPage3 = db.Products.ToList().GetProductsPage(200, 3);
            Assert.AreEqual(200, productPage1.Count);
            Assert.AreEqual(200, productPage2.Count);
            Assert.AreEqual(104, productPage3.Count);
        }

        [TestMethod()]
        public void getProductNamesWithVendorsTest()
        {
            Assert.Fail();
        }
    }
}