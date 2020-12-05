using System;
using System.Runtime.Serialization;

namespace ConsoleSerializer.Data
{
    [Serializable]
    public class Shoes : ISerializable
    {
        public string ShoesModel { get; set; }
        public int Size { get; set; }
        public string Brand { get; set; }
        public string Sex { get; set; }

        public Shoes(string shoesModel, int size, string brand, string sex)
        {
            ShoesModel = shoesModel;
            Size = size;
            Brand = brand;
            Sex = sex;
        }

        protected Shoes(SerializationInfo info, StreamingContext context)
        {
            ShoesModel = info.GetString("ShoesModel");
            Size = info.GetInt32("Size");
            Brand = info.GetString("Brand");
            Sex = info.GetString("Sex");
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ShoesModel", ShoesModel);
            info.AddValue("Size", Size);
            info.AddValue("Brand", Brand);
            info.AddValue("Sex", Sex);
        }
    }
}
