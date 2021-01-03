using System.Collections.Generic;


namespace Zadanie3
{
    public class MyContext
    {
        public List<MyProduct> MyProducts { get; set; }
        public List<MyCategory> MyCategories { get; set; }
        public List<MyVendor> MyVendors { get; set; }

        public MyContext()
        {
            MyProducts = new List<MyProduct>();
            MyCategories = new List<MyCategory>();
            MyVendors = new List<MyVendor>();
            GenerateData();
        }

        public void GenerateData()
        {
            MyCategory c1 = new MyCategory(1, "Shoes");
            MyCategory c2 = new MyCategory(2, "Coats");
            MyCategory c3 = new MyCategory(3, "Dresses");
            MyCategories.Add(c1);
            MyCategories.Add(c2);
            MyCategories.Add(c3);

            MyVendor v1 = new MyVendor(1, "Clothing Company", "Los Angeles");
            MyVendor v2 = new MyVendor(2, "Shoes Factory", "Warsaw");
            MyVendor v3 = new MyVendor(3, "Great Shoes Inc.", "Pabianice");
            MyVendor v4 = new MyVendor(4, "Bridal Dresses", "New York");
            MyVendors.Add(v1);
            MyVendors.Add(v2);
            MyVendors.Add(v3);
            MyVendors.Add(v4);

            MyProduct p1 = new MyProduct(1, "Pretty Coat", "Brown", new decimal(199.99), c2, v1);
            MyProduct p2 = new MyProduct(2, "Coat", "Black", new decimal(199.99), c2, v1);
            MyProduct p3 = new MyProduct(3, "High Heels", "Brown", new decimal(259.99), c1, v2);
            MyProduct p4 = new MyProduct(4, "Sneakers", "White", new decimal(99.90), c1, v3);
            MyProduct p5 = new MyProduct(5, "High Boots", "Beige", new decimal(179.99), c1, v2);
            MyProduct p6 = new MyProduct(6, "Pretty White Dress", "White", new decimal(1999.99), c3, v4);
            MyProduct p7 = new MyProduct(7, "Bridal Dress", "White", new decimal(2500), c3, v4);
            MyProduct p8 = new MyProduct(8, "Pretty Dress", "Pink", new decimal(219.99), c3, v1);
            MyProducts.Add(p1);
            MyProducts.Add(p2);
            MyProducts.Add(p3);
            MyProducts.Add(p4);
            MyProducts.Add(p5);
            MyProducts.Add(p6);
            MyProducts.Add(p7);
            MyProducts.Add(p8);
        }
    }
}
