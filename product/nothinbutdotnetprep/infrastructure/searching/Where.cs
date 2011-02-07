using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public delegate PropertyType PropertyAccessor<ItemToFilter, PropertyType>(ItemToFilter item);

    public class Where<ItemToFilter>
    {
        public static ComparableCriteriaFactory<ItemToFilter, PropertyType> has_an<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }

        public static CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }
    }
}