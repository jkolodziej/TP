using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ShoeStore
{
    class Shoes
    {
        public Guid Id { get; set; }
        public string ShoesType { get; set; }
        public int Size { get; set; }
        public string Brand { get; set; }
        public Color Color { get; set; }
        public SexEnum Sex { get; set; }

        public Shoes(Guid id, string shoesType, int size, string brand, Color color, SexEnum sex)
        {
            Id = id;
            ShoesType = shoesType;
            Size = size;
            Brand = brand;
            Color = color;
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
                return this.Id.Equals(i.Id) && this.ShoesType.Equals(i.ShoesType) &&
                       this.Size.Equals(i.Size) && this.Brand.Equals(i.Brand) &&
                       this.Color.Equals(i.Color) && this.Sex.Equals(i.Sex);
            }
        }
    }
}
