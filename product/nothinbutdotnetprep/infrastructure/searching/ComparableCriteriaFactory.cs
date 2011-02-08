using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> basic;

        public ComparableCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> basic)
        {
            this.basic = basic;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return create_using(new FallsInRange<PropertyType>(
                new ExclusiveRangeWithNoUpperbound<PropertyType>(value)));
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return
                create_using(new FallsInRange<PropertyType>(
                    new InclusiveRange<PropertyType>(start, end)));
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return basic.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values_to_equal)
        {
            return basic.equal_to_any(possible_values_to_equal);
        }

        public Criteria<ItemToFilter> create_using(Criteria<PropertyType> criteria)
        {
            return basic.create_using(criteria);
        }

    }
}