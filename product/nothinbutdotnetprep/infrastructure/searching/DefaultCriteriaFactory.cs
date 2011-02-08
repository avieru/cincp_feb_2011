using System;

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
            return create_using(new IsEqualToAny<PropertyType>(possible_values_to_equal));
        }


        public Criteria<ItemToFilter> create_using(Criteria<PropertyType> raw_criteria)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(property_accessor, raw_criteria);
        }

        public NegatingCriteriaFactory<ItemToFilter, PropertyType> not
        {
            get { return new NegatingCriteriaFactory<ItemToFilter, PropertyType>(this); }
        }
    }
}