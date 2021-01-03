using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Zadanie3.MyProduction.Tests
{
    [TestClass()]
    public class MyMethodsTests
    {
        [TestMethod()]
        public void GetNMyProductsFromMyCategoryTest()
        {
            List<MyProduct> productsFromCategory = MyMethods.GetNMyProductsFromMyCategory("Dresses", 2);
            Assert.AreEqual(2, productsFromCategory.Count);
            Assert.AreEqual("Dresses", productsFromCategory[0].Category.Name);
            Assert.AreEqual("Dresses", productsFromCategory[1].Category.Name);

        }

        [TestMethod()]
        public void GetMyProductsByMyVendorNameTest()
        {
            List<MyProduct> productsByVendorName = MyMethods.GetMyProductsByMyVendorName("Shoes Factory");
            Assert.AreEqual(2, productsByVendorName.Count);
            Assert.AreEqual("Shoes Factory", productsByVendorName[0].Vendor.Name);
            Assert.AreEqual("Shoes Factory", productsByVendorName[1].Vendor.Name);
        }

        [TestMethod()]
        public void GetMyProductsByNameTest()
        {
            List<MyProduct> productsByName = MyMethods.GetMyProductsByName("Dress");
            Assert.AreEqual(3, productsByName.Count);
            Assert.IsTrue(productsByName[0].Name.Contains("Dress"));
            Assert.IsTrue(productsByName[1].Name.Contains("Dress"));
            Assert.IsTrue(productsByName[2].Name.Contains("Dress"));
        }
    }
}