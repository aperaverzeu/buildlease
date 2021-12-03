using Contracts.DTOs;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Services.Extension.Mapping
{
    public static class CategoryMappingExtension
    {
        public static CategoryInfo MapToCategoryInfo(this Category obj, IEnumerable<Attribute> attributes)
            => new()
            {
                Id = obj.Id,
                Name = obj.Name,
                ImageLink = obj.DefaultImagePath,
                Attributes = obj.Attributes.MapToAttributeInfo().ToArray(),
            };

        public static CategoryInfo MapToCategoryInfo(this Category obj)
            => obj
                .MapToCategoryInfo(obj.Attributes);

        public static Category MapToCategory(this CategoryInfo info)
            => new()
            {
                Id = info.Id,
                Name = info.Name,
                DefaultImagePath = info.ImageLink,

                ParentId = -1,
            };


        public static AttributeInfo MapToAttributeInfo(this Attribute obj)
            => new()
            {
                Id = obj.Id,
                Name = obj.Name,
                ValueType = obj.ValueType,
                UnitName = obj.UnitName,
            };

        public static IEnumerable<AttributeInfo> MapToAttributeInfo(this IEnumerable<Attribute> objs)
            => objs
                .Select(e => e.MapToAttributeInfo());

        public static Attribute MapToAttribute(this AttributeInfo info)
            => new()
            {
                Id = info.Id,
                Name = info.Name,
                ValueType = info.ValueType,
                UnitName = info.UnitName,

                CategoryId = -1,
            };

        public static IEnumerable<Attribute> MapToAttribute(this IEnumerable<AttributeInfo> infos)
            => infos
                .Select(e => e.MapToAttribute());
    }
}
