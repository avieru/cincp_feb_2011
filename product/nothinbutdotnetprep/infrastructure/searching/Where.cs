using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public delegate PropertyType PropertyAccessor<ItemToFilter, PropertyType>(ItemToFilter item);

    public class Where<ItemToFilter>
    {
        public static CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }
    }

    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> property_accessor;

        public CriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToFilter>(item =>
                                                           property_accessor(item).Equals(value_to_equal)
                );
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values_to_equal)
        {
            throw new NotImplementedException();
        }
    }
}