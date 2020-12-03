using System;


namespace ShoeStore.Data
{
    public class Shoes
    {
        public string ShoesModel { get; set; }
        public int Size { get; set; }
        public string Brand { get; set; }
        public SexEnum Sex { get; set; }

        public Shoes(string shoesModel, int size, string brand, SexEnum sex)
        {
            ShoesModel = shoesModel;
            Size = size;
            Brand = brand;
            Sex = sex;
        }

        public enum SexEnum
        {
            Male,
            Female,
            Unisex
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Shoes i = (Shoes)obj;
                return this.ShoesModel.Equals(i.ShoesModel) &&
                       this.Size.Equals(i.Size) && this.Brand.Equals(i.Brand) &&
                       this.Sex.Equals(i.Sex);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Shoes model: " + ShoesModel + "\nSize: " + Size + "\nBrand: " + Brand +
                   "\nSex: " + Sex;
        }
    }
}
