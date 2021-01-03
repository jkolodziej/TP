using System.Collections.Generic;


namespace Zadanie3
{
    public class MyProduct
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public MyCategory Category { get; set; }
        public MyVendor Vendor { get; set; }

        public MyProduct(int productID, string name, string color, decimal standardCost, MyCategory category, MyVendor vendor)
        {
            ProductID = productID;
            Name = name;
            Color = color;
            StandardCost = standardCost;
            Category = category;
            Vendor = vendor;
        }

        public override bool Equals(object obj)
        {
            return obj is MyProduct product &&
                   ProductID == product.ProductID &&
                   Name == product.Name &&
                   Color == product.Color &&
                   StandardCost == product.StandardCost &&
                   EqualityComparer<MyCategory>.Default.Equals(Category, product.Category) &&
                   EqualityComparer<MyVendor>.Default.Equals(Vendor, product.Vendor);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
