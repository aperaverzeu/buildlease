using Domain.Models;
using System.Collections.Generic;

namespace Domain.EntitiesExample
{
    public static class AttributeEntities
    {
        public static List<Attribute> Get()
        {
            return new List<Attribute>()
            {
                new Attribute()
                {
                    Id = -1,
                    CategoryId = 10,
                    Name = "Material",
                    ValueType = AttributeType.String,
                },
                new Attribute()
                {
                    Id = -2,
                    CategoryId = 11,
                    Name = "Metal",
                    ValueType = AttributeType.String,
                },
                new Attribute()
                {
                    Id = -3,
                    CategoryId = 12,
                    Name = "Tree",
                    ValueType = AttributeType.String,
                },
                new Attribute()
                {
                    Id = -4,
                    CategoryId = 15,
                    Name = "Lenght",
                    ValueType = AttributeType.Number,
                    UnitName = "metres"
                },
                new Attribute()
                {
                    Id = -5,
                    CategoryId = 13,
                    Name = "Lenght",
                    ValueType = AttributeType.Number,
                    UnitName = "metres"
                },
                new Attribute()
                {
                    Id = -6,
                    CategoryId = 14,
                    Name = "Thickness",
                    ValueType = AttributeType.Number,
                    UnitName = "millimetres"
                },
                new Attribute()
                {
                    Id = -7,
                    CategoryId = 17,
                    Name = "Lenght",
                    ValueType = AttributeType.Number,
                    UnitName = "metres"
                },
                new Attribute()
                {
                    Id = -8,
                    CategoryId = 17,
                    Name = "Thickness",
                    ValueType = AttributeType.Number,
                    UnitName = "centimeter"
                },
                new Attribute()
                {
                    Id = -9,
                    CategoryId = 2,
                    Name = "Material",
                    ValueType = AttributeType.String
                },
                new Attribute()
                {
                    Id = -10,
                    CategoryId = 3,
                    Name = "Power",
                    ValueType = AttributeType.Number,
                    UnitName = "watt"
                },
                new Attribute()
                {
                    Id = -11,
                    CategoryId = 3,
                    Name = "Rotational speed",
                    ValueType = AttributeType.Number,
                    UnitName = "rps"
                },
                new Attribute()
                {
                    Id = -12,
                    CategoryId = 7,
                    Name = "Lenght",
                    ValueType = AttributeType.Number,
                    UnitName = "metres"
                },
                new Attribute()
                {
                    Id = -13,
                    CategoryId = 8,
                    Name = "Width",
                    ValueType = AttributeType.Number,
                    UnitName = "centimetres"
                },
                new Attribute()
                {
                    Id = -14,
                    CategoryId = 2,
                    Name = "Length",
                    ValueType = AttributeType.Number,
                    UnitName = "cm"
                },
                new Attribute()
                {
                    Id = -15,
                    CategoryId = 6,
                    Name = "Material",
                    ValueType = AttributeType.String,
                },
            };
        }
    }
}