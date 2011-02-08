using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(x => accessor(x).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> between(PropertyType firstValue, PropertyType secondValue)
        {

            return
                new AnonymousCriteria<ItemToFilter>(
                    x => accessor(x).CompareTo(firstValue) >= 0 && accessor(x).CompareTo(secondValue) <= 0);
        }

        public Criteria<ItemToFilter> equal_to(PropertyType item)
        {
            return between(item, item);
        }
    }
}