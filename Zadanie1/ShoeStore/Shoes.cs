using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ShoeStore
{
    class Shoes
    {
        private Guid id { get; set; }
        private string shoesType { get; set; }
        private int size { get; set; }
        private string brand { get; set; }
        private Color color { get; set; }
        private Sex sex { get; set; }

        public Shoes(Guid id, string shoesType, int size, string brand, Color color, Sex sex)
        {
            this.id = id;
            this.shoesType = shoesType;
            this.size = size;
            this.brand = brand;
            this.color = color;
            this.sex = sex;
        }

        public enum Sex
        {
            Male,
            Female,
            Unisex
        }
    }
}
