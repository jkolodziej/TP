

namespace Zadanie3
{
    public class MyCategory
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public MyCategory(int categoryID, string name)
        {
            CategoryID = categoryID;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is MyCategory category &&
                   CategoryID == category.CategoryID &&
                   Name == category.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
