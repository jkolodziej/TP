

namespace Zadanie3
{
    public class MyVendor
    {
        public int BusinessEntityID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public MyVendor(int businessEntityID, string name, string city)
        {
            BusinessEntityID = businessEntityID;
            Name = name;
            City = city;
        }

        public override bool Equals(object obj)
        {
            return obj is MyVendor vendor &&
                   BusinessEntityID == vendor.BusinessEntityID &&
                   Name == vendor.Name &&
                   City == vendor.City;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
