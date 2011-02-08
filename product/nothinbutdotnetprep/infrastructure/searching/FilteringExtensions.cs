using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,PropertyType value_to_equal)
        {
            return equal_to_any(extension_point,value_to_equal);
        }

        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,params PropertyType[] possible_values_to_equal)
        {
            return create_using<ItemToFilter,PropertyType>(extension_point,new IsEqualToAny<PropertyType>(possible_values_to_equal));
        }

        public static Criteria<ItemToFilter> greater_than<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return create_using(extension_point, new FallsInRange<PropertyType>(
                new ExclusiveRangeWithNoUpperbound<PropertyType>(value)));
        }

        public static Criteria<ItemToFilter> between<ItemToFilter,PropertyType>(this FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return
                create_using(extension_point, new FallsInRange<PropertyType>(
                    new InclusiveRange<PropertyType>(start, end)));
        }

        static Criteria<ItemToFilter> create_using<ItemToFilter,PropertyType>(FilteringExtensionPoint<ItemToFilter,PropertyType> extension_point,Criteria<PropertyType> raw_criteria)
        {
            return extension_point.create_criteria_from(raw_criteria);
        }
    }
}