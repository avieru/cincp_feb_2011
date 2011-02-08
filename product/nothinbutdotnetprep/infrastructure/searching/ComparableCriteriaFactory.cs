using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor;

        CriteriaFactory<ItemToFilter, PropertyType> basic;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor, CriteriaFactory<ItemToFilter, PropertyType> basic)
        {
            this.accessor = accessor;
            this.basic = basic;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return create_using(x => accessor(x).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> between(PropertyType firstValue, PropertyType secondValue)
        {
            return
                create_using(
                    x => accessor(x).CompareTo(firstValue) >= 0 && accessor(x).CompareTo(secondValue) <= 0);
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return basic.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] possible_values_to_equal)
        {
            return basic.equal_to_any(possible_values_to_equal);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return basic.not_equal_to(value);
        }

        public Criteria<ItemToFilter> create_using(Condition<ItemToFilter> condition)
        {
            return basic.create_using(condition);
        }
    }
}