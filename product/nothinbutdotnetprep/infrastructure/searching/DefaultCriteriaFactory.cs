using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> property_accessor;

        public DefaultCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values_to_equal)
        {
            return create_using(x =>
                                                           new List<PropertyType>(possible_values_to_equal).Contains(
                                                               property_accessor(x)));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }

        public Criteria<ItemToFilter> create_using(Condition<ItemToFilter> condition)
        {
            return new AnonymousCriteria<ItemToFilter>(condition);
        }
    }
}