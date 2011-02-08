using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static ComparableCriteriaFactory<ItemToFilter, PropertyType> has_an<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToFilter, PropertyType>(has_a(accessor));
        }

        public static DefaultCriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            return new DefaultCriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }
    }
}